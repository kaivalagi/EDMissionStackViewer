using EDJournalQueue.Extensions;
using EDJournalQueue.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System.Collections.Concurrent;
using System.ComponentModel.Design.Serialization;
using System.Text;

namespace EDJournalQueue
{
    public class Watcher
    {
        #region Class Data

        private readonly ILogger _logger;

        public Dictionary<string, JournalFileInfo> JournalFileInfoList;
        public Dictionary<string, ConcurrentQueue<object>> JournalEntryQueue;
        public Dictionary<string, List<object>> JournalEntryPreload;
        public Dictionary<string, Dictionary<long, Mission>> ActiveMissions;

        private List<string> _journalFolderPaths;
        private int _ageLimitDays = 28;
        private bool _archiveInactiveJournals = false;

        private List<string> _activeJournalFilePaths;
        private List<FileSystemWatcher> _watchers;


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
            await ReadJournal(e.FullPath);
        }

        private async void OnCreated(object sender, FileSystemEventArgs e)
        {
            await ReadJournal(e.FullPath);
        }

        #endregion

        #region Methods

        public async Task InitializeAsync(List<string> journalFolderPaths, int ageLimitDays = 28, bool archiveInactiveJournals = false)
        {
            using (_logger.BeginScope("Initialising Watcher"))
            {
                _logger.LogInformation($"Initialising watcher [age limit {ageLimitDays} days and archiving {(archiveInactiveJournals ? "on" : "off")}]");

                _journalFolderPaths = new List<string>();
                _ageLimitDays = ageLimitDays;
                _archiveInactiveJournals = archiveInactiveJournals;

                JournalFileInfoList = new Dictionary<string, JournalFileInfo>();
                JournalEntryQueue = new Dictionary<string, ConcurrentQueue<object>>();
                JournalEntryPreload = new Dictionary<string, List<object>>();
                ActiveMissions = new Dictionary<string, Dictionary<long, Mission>>();

                foreach (var journalFolderPath in journalFolderPaths)
                {
                    if (Path.Exists(journalFolderPath))
                    {
                        _journalFolderPaths.Add(journalFolderPath);
                    }
                    else
                    {
                        _logger.LogWarning($"Journal folder '{journalFolderPath}' doesn't exist!");
                    }
                }

                if (_journalFolderPaths.Count > 0)
                {
                    await PreloadJournalFilesAsync();
                    await WatchJournalFilesAsync();
                }
                else
                {
                    _logger.LogWarning("No valid journal folders to process");
                }
            }
        }

        private async Task PreloadJournalFilesAsync()
        {
            var journalFileInfos = new List<FileInfo>();

            try
            {
                using (_logger.BeginScope("Preloading Journal Files"))
                {                    
                    foreach (var journalFolder in _journalFolderPaths)
                    {
                        journalFileInfos.AddRange(new DirectoryInfo(journalFolder).GetFiles("*.log").ToList());
                    }

                    var journalFilePathsFiltered = journalFileInfos.Where(f => (DateTime.UtcNow - f.LastWriteTimeUtc).TotalDays < _ageLimitDays).OrderBy(f => f.LastWriteTimeUtc).Select(f => f.FullName);

                    _logger.LogInformation($"Preloading {journalFilePathsFiltered.Count()} journal files");

                    foreach (var journalFilePath in journalFilePathsFiltered)
                    {
                        await ReadJournal(journalFilePath, true);
                    }
                }

                // Now we establish what is active for queueing and file retention
                using (_logger.BeginScope("Queuing Preloaded Events"))
                {
                    _activeJournalFilePaths = new List<string>();

                    foreach (var commanderName in ActiveMissions.Keys)
                    {
                        if (JournalEntryPreload.ContainsKey(commanderName))
                        {
                            var activeMissions = JournalEntryPreload[commanderName].OfType<JournalEntryMissionBase>().Where(j => ActiveMissions[commanderName].ContainsKey(j.MissionId));

                            _logger.LogInformation($"Queueing {activeMissions.Count()} preloaded missions for cmdr {commanderName}");

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
                    }
                }

                // figure out what journals do not contain active missions and move then into the "JournalArchive" subfolder
                using (_logger.BeginScope("Archiving Inactive Journal Files"))
                {
                    var inactiveJournalFiles = journalFileInfos.Select(j => j.FullName).Except(_activeJournalFilePaths).ToList();

                    if (_archiveInactiveJournals)
                    {
                        _logger.LogInformation($"Archiving inactive journal files - {inactiveJournalFiles.Count}/{JournalFileInfoList.Values.Count} [{(((decimal)inactiveJournalFiles.Count / JournalFileInfoList.Values.Count) * 100).ToString("00")}%]");

                        foreach (var journalFilePath in inactiveJournalFiles)
                        {
                            var journalFileInfo = new FileInfo(journalFilePath);

                            var archiveFolder = new DirectoryInfo(Path.Combine(journalFileInfo.DirectoryName, "JournalArchive"));
                            if (!archiveFolder.Exists)
                            {
                                archiveFolder.Create();
                            }

                            journalFileInfo.MoveTo(Path.Combine(archiveFolder.FullName, journalFileInfo.Name));
                        }
                    }
                    else
                    {
                        _logger.LogDebug($"Consider archiving inactive journal files - {inactiveJournalFiles.Count}/{JournalFileInfoList.Values.Count} [{(((decimal)inactiveJournalFiles.Count / JournalFileInfoList.Values.Count) * 100).ToString("00")}%]");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        private async Task WatchJournalFilesAsync()
        {
            try
            {
                _logger.LogInformation($"Setting up watchers for {_journalFolderPaths.Count} journal folder(s)");

                _watchers = new List<FileSystemWatcher>();

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
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
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

        private async Task PreloadJournalEntryFromBounty(string commanderName, JournalEntryBounty bounty)
        {
            if (JournalEntryPreload.ContainsKey(commanderName))
            {
                JournalEntryPreload[commanderName].PopulateMissionFromBounty(bounty);
            }
        }

        private async Task PreloadJournalEntryFromCargoDepot(string commanderName, JournalEntryCargoDepot cargoDepot)
        {
            if (JournalEntryPreload.ContainsKey(commanderName))
            {
                JournalEntryPreload[commanderName].PopulateMissionFromCargoDepot(cargoDepot);
            }
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
            try
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

                        var line = string.Empty;

                        try
                        {
                            line = sr.ReadLine();

                            if (!string.IsNullOrEmpty(line))
                            {
                                var journalEntry = JObject.Parse(line);

                                if (journalEntry != null)
                                {

                                    string journalEntryEvent = journalEntry.GetValue<string>("event");

                                    switch (journalEntryEvent)
                                    {
                                        case "Commander":
                                            // { "timestamp":"2024-02-27T17:07:05Z", "event":"Commander", "FID":"F184262", "Name":"Kaivalagi" }
                                            _logger.LogDebug($"Processing '{journalFilePath}', Line #:{fs.Position}, Event:'{journalEntryEvent}'");
                                            commanderName = journalEntry.GetValue<string>("Name");
                                            if (!JournalFileInfoList.ContainsKey(journalFilePath)) {
                                                JournalFileInfoList[journalFilePath] = new JournalFileInfo(journalFilePath, commanderName);
                                            }                                            
                                            break;

                                        case "Missions":
                                            // { "timestamp":"2024-02-27T17:05:30Z", "event":"Missions", "Active":[ { "MissionID":955337826, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":262323 }, { "MissionID":955419328, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":320172 }, { "MissionID":955449221, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":337814 }, { "MissionID":955459858, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":343286 }, { "MissionID":955461285, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":344759 }, { "MissionID":955463846, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":346046 }, { "MissionID":955478187, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":351933 }, { "MissionID":955483642, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":355237 }, { "MissionID":955566389, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":409926 }, { "MissionID":955570187, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":413081 }, { "MissionID":955581955, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":418324 }, { "MissionID":955583725, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":419640 }, { "MissionID":955583823, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":420502 }, { "MissionID":955588994, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":422996 }, { "MissionID":955611100, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":431214 }, { "MissionID":955645131, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":446121 }, { "MissionID":955720771, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":533166 } ], "Failed":[  ], "Complete":[  ] }
                                            _logger.LogDebug($"Processing '{journalFilePath}', Line #:{fs.Position}, Event:'{journalEntryEvent}'");
                                            var activeMissions = journalEntry["Active"];
                                            ActiveMissions[commanderName] = new Dictionary<long, Mission>();
                                            if (activeMissions.Count() > 0)
                                            {
                                                _logger.LogInformation($"{activeMissions.Count()} active missions found for {commanderName}");
                                                foreach (var activeMission in activeMissions)
                                                {
                                                    ActiveMissions[commanderName].Add(activeMission.GetValue<long>("MissionID"), new Mission(activeMission));
                                                }
                                            }
                                            break;

                                        case "MissionAccepted":
                                            // { "timestamp":"2024-04-17T21:18:41Z", "event":"MissionAccepted", "Faction":"Partnership of Zemez", "Name":"Mission_Mining", "LocalisedName":"Mine 372 Units of Silver", "Commodity":"$Silver_Name;", "Commodity_Localised":"Silver", "Count":372, "DestinationSystem":"Wally Bei", "DestinationStation":"Malerba Orbital", "Expiry":"2024-04-24T20:52:35Z", "Wing":true, "Influence":"++", "Reputation":"++", "Reward":50000000, "MissionID":961673229 }
                                            _logger.LogDebug($"Processing '{journalFilePath}', Line #:{fs.Position}, Event:'{journalEntryEvent}'");
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

                                                var missionAcceptedBase = (JournalEntryMissionBase)missionAccepted;
                                                ActiveMissions[commanderName].Add(missionAcceptedBase.MissionId, new Mission(journalEntry));
                                                JournalFileInfoList[journalFilePath].MissionIds.Add(missionAcceptedBase.MissionId);
                                            }

                                            break;

                                        case "MissionAbandoned":
                                        case "MissionCompleted":
                                            // { "timestamp":"2024-02-27T16:47:41Z", "event":"MissionCompleted", "Faction":"Traditional Wally Bei Constitution Party", "Name":"Mission_AltruismCredits_CivilUnrest_name", "LocalisedName":"Provide 1,000,000 Cr to Tackle Civil Unrest", "MissionID":955797651, "Donation":"1000000", "Donated":1000000, "FactionEffects":[ { "Faction":"Traditional Wally Bei Constitution Party", "Effects":[ { "Effect":"$MISSIONUTIL_Interaction_Summary_EP_up;", "Effect_Localised":"The economic status of $#MinorFaction; has improved in the $#System; system.", "Trend":"UpGood" } ], "Influence":[ { "SystemAddress":5031654855394, "Trend":"UpGood", "Influence":"++" } ], "ReputationTrend":"UpGood", "Reputation":"++" } ] }
                                            _logger.LogDebug($"Processing '{journalFilePath}', Line #:{fs.Position}, Event:'{journalEntryEvent}'");
                                            var missionRemoved = journalEntry.Populate();

                                            if (preload)
                                            {
                                                //await PreloadJournalEntry(commanderName, missionRemoved);

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

                                        case "MissionRedirected":
                                            // { "timestamp":"2024-02-04T13:24:55Z", "event":"MissionRedirected", "MissionID":953030920, "Name":"Mission_Massacre", "LocalisedName":"Kill LP 932-12 Society faction Pirates", "NewDestinationStation":"Braun Station", "NewDestinationSystem":"Gliese 868", "OldDestinationStation":"", "OldDestinationSystem":"LP 932-12" }
                                            _logger.LogDebug($"Processing '{journalFilePath}', Line #:{fs.Position}, Event:'{journalEntryEvent}'");
                                            var missionRedirected = journalEntry.Populate();

                                            if (preload)
                                            {
                                                //await PreloadJournalEntry(commanderName, missionRemoved);

                                                //var missionRedirectedId = ((JournalEntryMissionRemoved)missionRedirected).MissionId;
                                                //if (ActiveMissions[commanderName].ContainsKey(missionRedirectedId))
                                                //{
                                                //    ActiveMissions[commanderName].Remove(missionRedirectedId);
                                                //}

                                            }
                                            else
                                            {
                                                await EnqueueJournalEntry(commanderName, missionRedirected);
                                            }
                                            break;


                                        case "CargoDepot":
                                            // { "timestamp":"2024-02-05T11:47:22Z", "event":"CargoDepot", "MissionID":953167866, "UpdateType":"Deliver", "CargoType":"DomesticAppliances", "CargoType_Localised":"Domestic Appliances", "Count":643, "StartMarketID":0, "EndMarketID":3230588160, "ItemsCollected":0, "ItemsDelivered":643, "TotalItemsToDeliver":1090, "Progress":0.000000 }
                                            _logger.LogDebug($"Processing '{journalFilePath}', Line #:{fs.Position}, Event:'{journalEntryEvent}'");
                                            var cargoDepot = (JournalEntryCargoDepot)journalEntry.Populate();
                                            if (cargoDepot.UpdateType == "Deliver")
                                            {
                                                if (preload)
                                                {
                                                    await PreloadJournalEntryFromCargoDepot(commanderName, cargoDepot);
                                                }
                                                else
                                                {
                                                    await EnqueueJournalEntry(commanderName, cargoDepot);
                                                }
                                            }
                                            break;

                                        case "Bounty":
                                            // { "timestamp":"2023-08-26T10:04:19Z", "event":"Bounty", "Rewards":[ { "Faction":"Arbor Caelum Internal Defense", "Reward":527187 } ], "Target":"python", "TotalReward":527187, "VictimFaction":"Zeta Trianguli Australis Corporation" }                                    
                                            _logger.LogDebug($"Processing '{journalFilePath}', Line #:{fs.Position}, Event:'{journalEntryEvent}'");
                                            var bounty = (JournalEntryBounty)journalEntry.Populate();
                                            if (preload)
                                            {
                                                await PreloadJournalEntryFromBounty(commanderName, bounty);
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
                        catch (Exception ex)
                        {
                            _logger.LogError(ex, $"Failed to process '{journalFilePath}', Line#:{fs.Position}\nContent:{line}");
                        }
                    }

                    if (JournalFileInfoList.ContainsKey(journalFilePath))
                    {
                        JournalFileInfoList[journalFilePath].FilePosition = fs.Position;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        #endregion

    }
}
