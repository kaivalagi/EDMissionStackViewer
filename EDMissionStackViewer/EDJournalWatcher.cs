using EDMissionStackViewer.Extensions;
using EDMissionStackViewer.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Concurrent;
using System.Dynamic;
using System.Security.Policy;
using System.Text;

namespace EDMissionStackViewer
{
    public class EDJournalWatcher
    {

        #region Class Data

        public Dictionary<string, ConcurrentQueue<object>> CmdrJournalEventQueue = new Dictionary<string, ConcurrentQueue<object>>();
        public Dictionary<string, List<object>> CmdrJournalEventPreload = new Dictionary<string, List<object>>();
        public Dictionary<string, List<long>> CmdrMissionIds = new Dictionary<string, List<long>>();

        private List<DirectoryInfo> _journalFolders = new List<DirectoryInfo>();
        private List<FileSystemWatcher> _watchers = new List<FileSystemWatcher>();
        private Dictionary<string, EDJournalFileInfo> _journalFileInfo = new Dictionary<string, EDJournalFileInfo>();

        #endregion region

        #region Constructor

        public EDJournalWatcher(List<string> journalFolders)
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
            if (loadExistingJournalFiles) { 
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
            foreach (var commanderName in CmdrMissionIds.Keys)
            {
                var activeMissions = CmdrJournalEventPreload[commanderName].OfType<EDJournalMissionBase>().Where(j => CmdrMissionIds[commanderName].Contains(j.MissionId));

                foreach (var activeMission in activeMissions)
                {
                    if (!CmdrJournalEventQueue.ContainsKey(commanderName))
                    {
                        CmdrJournalEventQueue[commanderName] = new ConcurrentQueue<object>();
                    }
                    CmdrJournalEventQueue[commanderName].Enqueue(activeMission);
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
                                    _journalFileInfo[journalFilePath] = new EDJournalFileInfo(journalFilePath, commanderName);
                                    break;

                                case "Missions":
                                    // { "timestamp":"2024-02-27T17:05:30Z", "event":"Missions", "Active":[ { "MissionID":955337826, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":262323 }, { "MissionID":955419328, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":320172 }, { "MissionID":955449221, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":337814 }, { "MissionID":955459858, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":343286 }, { "MissionID":955461285, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":344759 }, { "MissionID":955463846, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":346046 }, { "MissionID":955478187, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":351933 }, { "MissionID":955483642, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":355237 }, { "MissionID":955566389, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":409926 }, { "MissionID":955570187, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":413081 }, { "MissionID":955581955, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":418324 }, { "MissionID":955583725, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":419640 }, { "MissionID":955583823, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":420502 }, { "MissionID":955588994, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":422996 }, { "MissionID":955611100, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":431214 }, { "MissionID":955645131, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":446121 }, { "MissionID":955720771, "Name":"Mission_Mining_name", "PassengerMission":false, "Expires":533166 } ], "Failed":[  ], "Complete":[  ] }
                                    var activeMissions = journalEntry["Active"];

                                    CmdrMissionIds[commanderName] = new List<long>();

                                    if (preload)
                                    {                                        
                                        if (!CmdrJournalEventPreload.ContainsKey(commanderName))
                                        {
                                            CmdrJournalEventPreload[commanderName] = new List<object>();
                                        }
                                    } 
                                    else
                                    {
                                        if (!CmdrJournalEventQueue.ContainsKey(commanderName))
                                        {
                                            CmdrJournalEventQueue[commanderName] = new ConcurrentQueue<object>();
                                        }
                                    }
                                    
                                    if (activeMissions.Count() > 0)
                                    {
                                        foreach (var activeMission in activeMissions)
                                        {
                                            CmdrMissionIds[commanderName].Add((long)activeMission["MissionID"]);
                                        }
                                    }

                                    break;

                                case "MissionAccepted":
                                    // { "timestamp":"2024-04-17T21:18:41Z", "event":"MissionAccepted", "Faction":"Partnership of Zemez", "Name":"Mission_Mining", "LocalisedName":"Mine 372 Units of Silver", "Commodity":"$Silver_Name;", "Commodity_Localised":"Silver", "Count":372, "DestinationSystem":"Wally Bei", "DestinationStation":"Malerba Orbital", "Expiry":"2024-04-24T20:52:35Z", "Wing":true, "Influence":"++", "Reputation":"++", "Reward":50000000, "MissionID":961673229 }
                                    var mission = journalEntry.Populate();

                                    if (preload)
                                    {
                                        CmdrJournalEventPreload[commanderName].Add(mission);
                                    } 
                                    else
                                    {
                                        CmdrJournalEventQueue[commanderName].Enqueue(mission);
                                    }
                                    
                                    break;

                                case "MissionAbandoned":
                                case "MissionCompleted":
                                case "MissionRedirected":
                                    // { "timestamp":"2024-02-27T16:47:41Z", "event":"MissionCompleted", "Faction":"Traditional Wally Bei Constitution Party", "Name":"Mission_AltruismCredits_CivilUnrest_name", "LocalisedName":"Provide 1,000,000 Cr to Tackle Civil Unrest", "MissionID":955797651, "Donation":"1000000", "Donated":1000000, "FactionEffects":[ { "Faction":"Traditional Wally Bei Constitution Party", "Effects":[ { "Effect":"$MISSIONUTIL_Interaction_Summary_EP_up;", "Effect_Localised":"The economic status of $#MinorFaction; has improved in the $#System; system.", "Trend":"UpGood" } ], "Influence":[ { "SystemAddress":5031654855394, "Trend":"UpGood", "Influence":"++" } ], "ReputationTrend":"UpGood", "Reputation":"++" } ] }
                                    // { "timestamp":"2024-02-04T13:24:55Z", "event":"MissionRedirected", "MissionID":953030920, "Name":"Mission_Massacre", "LocalisedName":"Kill LP 932-12 Society faction Pirates", "NewDestinationStation":"Braun Station", "NewDestinationSystem":"Gliese 868", "OldDestinationStation":"", "OldDestinationSystem":"LP 932-12" }
                                    var missionOther = journalEntry.Populate();

                                    if (preload)
                                    {
                                        CmdrJournalEventPreload[commanderName].Add(missionOther);
                                    }
                                    else
                                    {
                                        CmdrJournalEventQueue[commanderName].Enqueue(missionOther);
                                    }
                                    break;

                                case "CargoDepot":
                                    // { "timestamp":"2024-02-05T11:47:22Z", "event":"CargoDepot", "MissionID":953167866, "UpdateType":"Deliver", "CargoType":"DomesticAppliances", "CargoType_Localised":"Domestic Appliances", "Count":643, "StartMarketID":0, "EndMarketID":3230588160, "ItemsCollected":0, "ItemsDelivered":643, "TotalItemsToDeliver":1090, "Progress":0.000000 }
                                    var cargoDepot = (EDJournalCargoDepot)journalEntry.Populate();
                                    if (cargoDepot.UpdateType == "Deliver")
                                    {
                                        if (preload)
                                        {
                                            //CmdrJournalEventPreload[commanderName].Add(cargoDepot); //populate existing mission with this
                                            CmdrJournalEventPreload[commanderName].PopulateMissionsCargoDepot(cargoDepot);
                                        }
                                        else
                                        {
                                            CmdrJournalEventQueue[commanderName].Enqueue(cargoDepot);
                                        }
                                    }
                                    break;

                                case "Bounty":
                                    // { "timestamp":"2023-08-26T10:04:19Z", "event":"Bounty", "Rewards":[ { "Faction":"Arbor Caelum Internal Defense", "Reward":527187 } ], "Target":"python", "TotalReward":527187, "VictimFaction":"Zeta Trianguli Australis Corporation" }                                    
                                    var bounty = (EDJournalBounty)journalEntry.Populate();
                                    if (preload)
                                    {
                                        //CmdrJournalEventPreload[commanderName].Add(Guid.NewGuid(), bounty); //populate existing mission with this
                                        CmdrJournalEventPreload[commanderName].PopulateMissionsBounty(bounty);
                                    }
                                    else
                                    {
                                        CmdrJournalEventQueue[commanderName].Enqueue(bounty);
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
