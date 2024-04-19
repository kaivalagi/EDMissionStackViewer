using EDJournalQueue.Events;
using EDJournalQueue.Extensions;
using EDJournalQueue.Models;
using Newtonsoft.Json.Linq;
using System.Collections.Concurrent;
using System.Text;

namespace EDJournalQueue
{
    public class Watcher
    {
        #region Class Data

        public Dictionary<string, ConcurrentQueue<object>> JournalEntryQueue = new Dictionary<string, ConcurrentQueue<object>>();
        public Dictionary<string, List<object>> JournalEntryPreload = new Dictionary<string, List<object>>();
        public Dictionary<string, Dictionary<long, Mission>> ActiveMissions = new Dictionary<string, Dictionary<long, Mission>>();

        private List<DirectoryInfo> _journalFolders = new List<DirectoryInfo>();
        private List<FileSystemWatcher> _watchers = new List<FileSystemWatcher>();
        private Dictionary<string, JournalFileInfo> _journalFileInfo = new Dictionary<string, JournalFileInfo>();

        public event EventHandler<JournalEntryQueueChangedEventArgs> JournalEntryQueueChanged;
        public event EventHandler<MissionsChangedEventArgs> MissionsChanged;

        #endregion region

        #region Constructor

        public Watcher(List<string> journalFolders)
        {
            foreach (var journalFolder in journalFolders)
            {
                var directoryInfo = new DirectoryInfo(journalFolder);

                if (directoryInfo.Exists)
                {
                    _journalFolders.Add(directoryInfo);
                }
                else
                {
                    Console.WriteLine($"Journal folder '{journalFolder}' doesn't exist!");
                }
            }
        }

        #endregion

        #region Events

        protected virtual void OnJournalEntryQueueChanged(JournalEntryQueueChangedEventArgs e)
        {
            EventHandler<JournalEntryQueueChangedEventArgs> handler = JournalEntryQueueChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnMissionsChanged(MissionsChangedEventArgs e)
        {
            EventHandler<MissionsChangedEventArgs> handler = MissionsChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType != WatcherChangeTypes.Changed)
            {
                return;
            }

            Console.WriteLine($"Processing change to '{e.FullPath}'");

            ReadJournal(e.FullPath).Wait();

        }

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"Processing '{e.FullPath}' creation");

            ReadJournal(e.FullPath).Wait();
        }

        #endregion

        #region Methods

        public async Task InitializeAsync(bool loadExistingJournalFiles = true)
        {
            if (loadExistingJournalFiles)
            {
                await PreloadJournalFilesAsync();
            }
            await WatchJournalFilesAsync();
        }

        private async Task PreloadJournalFilesAsync(int maxAgeDays = 28)
        {
            foreach (var journalFolder in _journalFolders)
            {
                var journalFileInfos = journalFolder.GetFiles("*.log").ToList().Where(f => (DateTime.UtcNow - f.LastWriteTimeUtc).TotalDays < maxAgeDays).OrderBy(f => f.LastWriteTimeUtc);

                foreach (var journalFileInfo in journalFileInfos)
                {
                    await ReadJournal(journalFileInfo.FullName, true);
                }
            }

            // now add only active missions to the queue from CmdrJournalEventPreload
            foreach (var commanderName in ActiveMissions.Keys)
            {
                var activeMissions = JournalEntryPreload[commanderName].OfType<JournalEntryMissionBase>().Where(j => ActiveMissions[commanderName].ContainsKey(j.MissionId));

                foreach (var activeMission in activeMissions)
                {
                    if (!JournalEntryQueue.ContainsKey(commanderName))
                    {
                        JournalEntryQueue[commanderName] = new ConcurrentQueue<object>();
                    }
                    JournalEntryQueue[commanderName].Enqueue(activeMission);
                }
            }
        }

        private async Task WatchJournalFilesAsync()
        {
            foreach (var journalFolder in _journalFolders)
            {
                var watcher = new FileSystemWatcher(journalFolder.FullName, "*.log");
                watcher.NotifyFilter = NotifyFilters.CreationTime | NotifyFilters.LastWrite;
                watcher.Created += OnCreated;
                watcher.Changed += OnChanged;
                watcher.IncludeSubdirectories = false;
                watcher.EnableRaisingEvents = true;
                _watchers.Add(watcher);
            }
        }

        private async Task ReadJournal(string journalFilePath, bool preload = false)
        {

            string commanderName = string.Empty;
            if (_journalFileInfo.ContainsKey(journalFilePath))
            {
                commanderName = _journalFileInfo[journalFilePath].CmdrName;
            }

            using (var fs = new FileStream(journalFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var sr = new StreamReader(fs, Encoding.Default))
            {
                if (_journalFileInfo.ContainsKey(journalFilePath))
                {
                    fs.Position = _journalFileInfo[journalFilePath].FilePosition;
                }
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();

                    if (!string.IsNullOrEmpty(line))
                    {
                        //var journalEntry = JsonConvert.DeserializeObject<JObject>(line);
                        var journalEntry = JObject.Parse(line);

                        if (journalEntry != null)
                        {

                            string journalEntryEvent = (string)journalEntry["event"];

                            switch (journalEntryEvent)
                            {
                                case "Commander":
                                    // { "timestamp":"2024-02-27T17:07:05Z", "event":"Commander", "FID":"F184262", "Name":"Kaivalagi" }
                                    commanderName = (string)journalEntry["Name"];
                                    _journalFileInfo[journalFilePath] = new JournalFileInfo(journalFilePath, commanderName);
                                    break;

                                case "Missions":
                                    // { "timestamp":"2024-02-27T17:05:30Z", "event":"Missions", "Active":[ { "MissionID":955337826, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":262323 }, { "MissionID":955419328, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":320172 }, { "MissionID":955449221, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":337814 }, { "MissionID":955459858, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":343286 }, { "MissionID":955461285, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":344759 }, { "MissionID":955463846, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":346046 }, { "MissionID":955478187, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":351933 }, { "MissionID":955483642, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":355237 }, { "MissionID":955566389, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":409926 }, { "MissionID":955570187, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":413081 }, { "MissionID":955581955, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":418324 }, { "MissionID":955583725, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":419640 }, { "MissionID":955583823, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":420502 }, { "MissionID":955588994, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":422996 }, { "MissionID":955611100, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":431214 }, { "MissionID":955645131, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":446121 }, { "MissionID":955720771, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":533166 } ], "Failed":[  ], "Complete":[  ] }
                                    var activeMissions = journalEntry["Active"];

                                    ActiveMissions[commanderName] = new Dictionary<long, Mission>();

                                    if (preload)
                                    {
                                        if (!JournalEntryPreload.ContainsKey(commanderName))
                                        {
                                            JournalEntryPreload[commanderName] = new List<object>();
                                        }
                                    }
                                    else
                                    {
                                        if (!JournalEntryQueue.ContainsKey(commanderName))
                                        {
                                            JournalEntryQueue[commanderName] = new ConcurrentQueue<object>();
                                        }
                                    }

                                    if (activeMissions.Count() > 0)
                                    {
                                        foreach (var activeMission in activeMissions)
                                        {
                                            ActiveMissions[commanderName].Add((long)activeMission["MissionID"], new Mission(activeMission));
                                        }
                                    }

                                    if (!preload) // Only raise events post preload
                                    {
                                        OnMissionsChanged(new MissionsChangedEventArgs() { CommanderName = commanderName, JToken = activeMissions });
                                    }                                    

                                    break;

                                case "MissionAccepted":
                                    // { "timestamp":"2024-04-17T21:18:41Z", "event":"MissionAccepted", "Faction":"Partnership of Zemez", "Name":"Mission_Mining", "LocalisedName":"Mine 372 Units of Silver", "Commodity":"$Silver_Name;", "Commodity_Localised":"Silver", "Count":372, "DestinationSystem":"Wally Bei", "DestinationStation":"Malerba Orbital", "Expiry":"2024-04-24T20:52:35Z", "Wing":true, "Influence":"++", "Reputation":"++", "Reward":50000000, "MissionID":961673229 }
                                    var missionAccepted = journalEntry.Populate();

                                    if (missionAccepted != null)
                                    {
                                        if (preload)
                                        {
                                            JournalEntryPreload[commanderName].Add(missionAccepted);
                                        }
                                        else
                                        {
                                            JournalEntryQueue[commanderName].Enqueue(missionAccepted);
                                            OnJournalEntryQueueChanged(new JournalEntryQueueChangedEventArgs() { CommanderName = commanderName, JToken = journalEntry });
                                        }

                                        ActiveMissions[commanderName].Add(((JournalEntryMissionBase)missionAccepted).MissionId, new Mission((JournalEntryMissionBase)missionAccepted));

                                        if (!preload) // Only raise events post preload
                                        {
                                            OnMissionsChanged(new MissionsChangedEventArgs() { CommanderName = commanderName, JToken = journalEntry });
                                        }
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
                                        JournalEntryPreload[commanderName].Add(missionRemoved);

                                        var missionRemovedId = ((JournalEntryMissionBase)missionRemoved).MissionId;
                                        if (ActiveMissions[commanderName].ContainsKey(missionRemovedId))
                                        {
                                            ActiveMissions[commanderName].Remove(missionRemovedId);
                                        }

                                    }
                                    else
                                    {
                                        JournalEntryQueue[commanderName].Enqueue(missionRemoved);
                                        OnJournalEntryQueueChanged(new JournalEntryQueueChangedEventArgs() { CommanderName = commanderName, JToken = journalEntry });
                                    }
                                    break;

                                case "CargoDepot":
                                    // { "timestamp":"2024-02-05T11:47:22Z", "event":"CargoDepot", "MissionID":953167866, "UpdateType":"Deliver", "CargoType":"DomesticAppliances", "CargoType_Localised":"Domestic Appliances", "Count":643, "StartMarketID":0, "EndMarketID":3230588160, "ItemsCollected":0, "ItemsDelivered":643, "TotalItemsToDeliver":1090, "Progress":0.000000 }
                                    var cargoDepot = (JournalEntryCargoDepot)journalEntry.Populate();
                                    if (cargoDepot.UpdateType == "Deliver")
                                    {
                                        if (preload)
                                        {
                                            JournalEntryPreload[commanderName].PopulateMissionsCargoDepot(cargoDepot);
                                        }
                                        else
                                        {
                                            JournalEntryQueue[commanderName].Enqueue(cargoDepot);
                                            OnJournalEntryQueueChanged(new JournalEntryQueueChangedEventArgs() { CommanderName = commanderName, JToken = journalEntry });
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
                                        JournalEntryQueue[commanderName].Enqueue(bounty);
                                        OnJournalEntryQueueChanged(new JournalEntryQueueChangedEventArgs() { CommanderName = commanderName, JToken = journalEntry });
                                    }

                                    break;

                            }
                        }
                    }
                }
                if (_journalFileInfo.ContainsKey(journalFilePath))
                {
                    _journalFileInfo[journalFilePath].FilePosition = fs.Position;
                }

            }
        }

        #endregion
    }
}
