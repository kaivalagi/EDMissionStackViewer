using EDJournalQueue.Extensions;
using EDJournalQueue.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System.Collections.Concurrent;
using System.Linq;
using System.Runtime.Intrinsics;
using System.Text;

namespace EDJournalQueue
{
    public class Watcher
    {
        #region Class Data

        private readonly ILogger _logger;

        public Dictionary<string, JournalFileInfo> JournalFileInfoList = new Dictionary<string, JournalFileInfo>();
        public Dictionary<string, ConcurrentQueue<object>> JournalEntryQueue = new Dictionary<string, ConcurrentQueue<object>>();
        public Dictionary<string, List<object>> JournalEntryPreload = new Dictionary<string, List<object>>();
        public Dictionary<string, Dictionary<long, Mission>> ActiveMissions = new Dictionary<string, Dictionary<long, Mission>>();
       
        private List<string> _journalFolderPaths = new List<string>();
        private int _journalMaxAgeDays = 28;
        private bool _archiveInactiveJournals = false;

        private List<string> _activeJournalFilePaths = new List<string>();
        private List<FileSystemWatcher> _watchers = new List<FileSystemWatcher>();


        #endregion

        #region Constructor

        public Watcher(ILogger<Watcher> logger)
        {
            _logger = logger;
        }

        #endregion

        #region Events

        private async void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType != WatcherChangeTypes.Changed)
            {
                return;
            }

            Console.WriteLine($"Processing change to '{e.FullPath}'");

            await ReadJournal(e.FullPath);

        }

        private async void OnCreated(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"Processing '{e.FullPath}' creation");

            await ReadJournal(e.FullPath);
        }

        #endregion

        #region Methods

        public async Task InitializeAsync(List<string> journalFolderPaths, int journalMaxAgeDays = 28, bool archiveInactiveJournals = false)
        {
            _logger.LogInformation("Initialising Watcher");

            _journalMaxAgeDays = journalMaxAgeDays;
            _archiveInactiveJournals = archiveInactiveJournals;

            foreach (var journalFolderPath in journalFolderPaths)
            {
                if (Path.Exists(journalFolderPath))
                {
                    _journalFolderPaths.Add(journalFolderPath);
                }
                else
                {
                    throw new IndexOutOfRangeException($"Journal folder '{journalFolderPath}' doesn't exist!");
                }
            }

            if (_journalFolderPaths.Count > 0)
            {
                await PreloadJournalFilesAsync();
                await WatchJournalFilesAsync();
            }
        }

        private async Task PreloadJournalFilesAsync()
        {

            _logger.LogInformation("Preloading Journal Files");

            var journalFileInfos = new List<FileInfo>();
            foreach (var journalFolder in _journalFolderPaths)
            {
                journalFileInfos.AddRange(new DirectoryInfo(journalFolder).GetFiles("*.log").ToList());
            }

            var journalFilePathsFiltered = journalFileInfos.Where(f => (DateTime.UtcNow - f.LastWriteTimeUtc).TotalDays < _journalMaxAgeDays).OrderBy(f => f.LastWriteTimeUtc).Select(f => f.FullName);

            foreach (var journalFilePath in journalFilePathsFiltered)
            {
                await ReadJournal(journalFilePath, true);
            }

            // Now we establish what is active for queueing and file retention

            _logger.LogInformation("Queuing Preloaded Events");

            _activeJournalFilePaths = new List<string>();
            foreach (var commanderName in ActiveMissions.Keys)
            {
                var activeMissions = JournalEntryPreload[commanderName].OfType<JournalEntryMissionBase>().Where(j => ActiveMissions[commanderName].ContainsKey(j.MissionId));

                foreach (var activeMission in activeMissions)
                {
                    await EnqueueJournalEntry(commanderName, activeMission);
                }
                
                foreach (var journalFileInfo in JournalFileInfoList.Values)
                {
                    if (journalFileInfo.MissionIds.Any(ActiveMissions[commanderName].Keys.Contains))
                    {
                        _activeJournalFilePaths.Add(journalFileInfo.FilePath);
                    }
                }
            }

            if (_archiveInactiveJournals)
            {
                _logger.LogInformation("Archiving Inactive Journal Files");

                var inactiveJournalFiles = journalFileInfos.Select(j => j.FullName).Except(_activeJournalFilePaths).ToList();

                foreach (var journalFilePath in inactiveJournalFiles)
                {
                    var journalFileInfo = new FileInfo(journalFilePath);

                    var archiveFolder = new DirectoryInfo(Path.Combine(journalFileInfo.DirectoryName, "JournalArchive"));
                    if (!archiveFolder.Exists) {
                        archiveFolder.Create();
                    }

                    journalFileInfo.MoveTo(Path.Combine(archiveFolder.FullName, journalFileInfo.Name));                    
                }
            }
        }

        private async Task WatchJournalFilesAsync()
        {

            _logger.LogInformation("Setting Up Watchers For Journal Files");

            foreach (var journalFolder in _journalFolderPaths)
            {
                var watcher = new FileSystemWatcher(journalFolder, "*.log");
                watcher.NotifyFilter = NotifyFilters.CreationTime | NotifyFilters.LastWrite;
                watcher.Created += OnCreated;
                watcher.Changed += OnChanged;
                watcher.IncludeSubdirectories = false;
                watcher.EnableRaisingEvents = true;
                _watchers.Add(watcher);
            }
        }

        private async Task PreloadJournalEntry(string commanderName, object journalEntry)
        {
            if (!JournalEntryPreload.ContainsKey(commanderName))
            {
                JournalEntryPreload[commanderName] = new List<object>();
            }
            JournalEntryPreload[commanderName].Add(journalEntry);
        }

        private async Task EnqueueJournalEntry(string commanderName, object journalEntry)
        {
            if (!JournalEntryQueue.ContainsKey(commanderName))
            {
                JournalEntryQueue[commanderName] = new ConcurrentQueue<object>();
            }
            JournalEntryQueue[commanderName].Enqueue(journalEntry);
        }

        private async Task ReadJournal(string journalFilePath, bool preload = false)
        {
            string commanderName = string.Empty;
            if (JournalFileInfoList.ContainsKey(journalFilePath))
            {
                commanderName = JournalFileInfoList[journalFilePath].CmdrName;
            }

            using (var fs = new FileStream(journalFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var sr = new StreamReader(fs, Encoding.Default))
            {
                if (JournalFileInfoList.ContainsKey(journalFilePath))
                {
                    fs.Position = JournalFileInfoList[journalFilePath].FilePosition;
                }
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();

                    if (!string.IsNullOrEmpty(line))
                    {
                        var journalEntry = JObject.Parse(line);

                        if (journalEntry != null)
                        {

                            string journalEntryEvent = (string)journalEntry["event"];

                            switch (journalEntryEvent)
                            {
                                case "Commander":
                                    // { "timestamp":"2024-02-27T17:07:05Z", "event":"Commander", "FID":"F184262", "Name":"Kaivalagi" }
                                    commanderName = (string)journalEntry["Name"];
                                    JournalFileInfoList[journalFilePath] = new JournalFileInfo(journalFilePath, commanderName);
                                    break;

                                case "Missions":
                                    // { "timestamp":"2024-02-27T17:05:30Z", "event":"Missions", "Active":[ { "MissionID":955337826, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":262323 }, { "MissionID":955419328, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":320172 }, { "MissionID":955449221, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":337814 }, { "MissionID":955459858, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":343286 }, { "MissionID":955461285, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":344759 }, { "MissionID":955463846, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":346046 }, { "MissionID":955478187, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":351933 }, { "MissionID":955483642, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":355237 }, { "MissionID":955566389, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":409926 }, { "MissionID":955570187, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":413081 }, { "MissionID":955581955, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":418324 }, { "MissionID":955583725, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":419640 }, { "MissionID":955583823, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":420502 }, { "MissionID":955588994, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":422996 }, { "MissionID":955611100, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":431214 }, { "MissionID":955645131, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":446121 }, { "MissionID":955720771, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":533166 } ], "Failed":[  ], "Complete":[  ] }
                                    var activeMissions = journalEntry["Active"];

                                    ActiveMissions[commanderName] = new Dictionary<long, Mission>();

                                    if (activeMissions.Count() > 0)
                                    {
                                        foreach (var activeMission in activeMissions)
                                        {
                                            ActiveMissions[commanderName].Add((long)activeMission["MissionID"], new Mission(activeMission));
                                        }
                                    }

                                    break;

                                case "MissionAccepted":
                                    // { "timestamp":"2024-04-17T21:18:41Z", "event":"MissionAccepted", "Faction":"Partnership of Zemez", "Name":"Mission_Mining", "LocalisedName":"Mine 372 Units of Silver", "Commodity":"$Silver_Name;", "Commodity_Localised":"Silver", "Count":372, "DestinationSystem":"Wally Bei", "DestinationStation":"Malerba Orbital", "Expiry":"2024-04-24T20:52:35Z", "Wing":true, "Influence":"++", "Reputation":"++", "Reward":50000000, "MissionID":961673229 }
                                    var missionAccepted = journalEntry.Populate();

                                    if (missionAccepted != null)
                                    {
                                        if (preload)
                                        {
                                            await PreloadJournalEntry(commanderName, missionAccepted);
                                        }
                                        else
                                        {
                                            await EnqueueJournalEntry(commanderName, missionAccepted);
                                        }

                                        ActiveMissions[commanderName].Add(((JournalEntryMissionBase)missionAccepted).MissionId, new Mission((JournalEntryMissionBase)missionAccepted));

                                        JournalFileInfoList[journalFilePath].MissionIds.Add(((JournalEntryMissionBase)missionAccepted).MissionId);
                                    }

                                    break;

                                case "MissionAbandoned":
                                case "MissionCompleted":
                                case "MissionRedirected":
                                    // { "timestamp":"2024-02-27T16:47:41Z", "event":"MissionCompleted", "Faction":"Traditional Wally Bei Constitution Party", "Name":"Mission_AltruismCredits_CivilUnrest_name", "LocalisedName":"Provide 1,000,000 Cr to Tackle Civil Unrest", "MissionID":955797651, "Donation":"1000000", "Donated":1000000, "FactionEffects":[ { "Faction":"Traditional Wally Bei Constitution Party", "Effects":[ { "Effect":"$MISSIONUTIL_Interaction_Summary_EP_up;", "Effect_Localised":"The economic status of $#MinorFaction; has improved in the $#System; system.", "Trend":"UpGood" } ], "Influence":[ { "SystemAddress":5031654855394, "Trend":"UpGood", "Influence":"++" } ], "ReputationTrend":"UpGood", "Reputation":"++" } ] }
                                    // { "timestamp":"2024-02-04T13:24:55Z", "event":"MissionRedirected", "MissionID":953030920, "Name":"Mission_Massacre", "LocalisedName":"Kill LP 932-12 Society faction Pirates", "NewDestinationStation":"Braun Station", "NewDestinationSystem":"Gliese 868", "OldDestinationStation":"", "OldDestinationSystem":"LP 932-12" }
                                    var missionRemoved = journalEntry.Populate();

                                    if (preload)
                                    {
                                        await PreloadJournalEntry(commanderName, missionRemoved);

                                        var missionRemovedId = ((JournalEntryMissionRemoved)missionRemoved).MissionId;
                                        if (ActiveMissions[commanderName].ContainsKey(missionRemovedId))
                                        {
                                            ActiveMissions[commanderName].Remove(missionRemovedId);
                                        }

                                    }
                                    else
                                    {
                                        await EnqueueJournalEntry(commanderName, missionRemoved);
                                    }
                                    break;

                                case "CargoDepot":
                                    // { "timestamp":"2024-02-05T11:47:22Z", "event":"CargoDepot", "MissionID":953167866, "UpdateType":"Deliver", "CargoType":"DomesticAppliances", "CargoType_Localised":"Domestic Appliances", "Count":643, "StartMarketID":0, "EndMarketID":3230588160, "ItemsCollected":0, "ItemsDelivered":643, "TotalItemsToDeliver":1090, "Progress":0.000000 }
                                    var cargoDepot = (JournalEntryCargoDepot)journalEntry.Populate();
                                    //962031653
                                    if (cargoDepot.UpdateType == "Deliver")
                                    {
                                        if (preload)
                                        {
                                            JournalEntryPreload[commanderName].PopulateMissionsCargoDepot(cargoDepot);
                                        }
                                        else
                                        {
                                            await EnqueueJournalEntry(commanderName, cargoDepot);
                                        }
                                    }
                                    break;

                                case "Bounty":
                                    // { "timestamp":"2023-08-26T10:04:19Z", "event":"Bounty", "Rewards":[ { "Faction":"Arbor Caelum Internal Defense", "Reward":527187 } ], "Target":"python", "TotalReward":527187, "VictimFaction":"Zeta Trianguli Australis Corporation" }                                    
                                    var bounty = (JournalEntryBounty)journalEntry.Populate();
                                    if (preload)
                                    {
                                        JournalEntryPreload[commanderName].PopulateMissionsBounty(bounty);
                                    }
                                    else
                                    {
                                        await EnqueueJournalEntry(commanderName, bounty);
                                    }

                                    break;
                            }
                        }
                    }
                }

                if (JournalFileInfoList.ContainsKey(journalFilePath))
                {
                    JournalFileInfoList[journalFilePath].FilePosition = fs.Position;
                }
            }
        }

        #endregion

    }
}
