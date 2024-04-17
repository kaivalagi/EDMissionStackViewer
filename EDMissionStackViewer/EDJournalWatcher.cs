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

        public Dictionary<string, ConcurrentQueue<dynamic>> CmdrJournalEventQueue = new Dictionary<string, ConcurrentQueue<dynamic>>();
        public Dictionary<string, List<EDJournalMission>> CmdrMissions = new Dictionary<string, List<EDJournalMission>>();

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
                await LoadExistingFilesAsync();
            }
            await WatchFilesAsync();
        }

        private async Task LoadExistingFilesAsync(int maxAgeDays = 28)
        {
            foreach (var journalFolder in _journalFolders)
            {
                var journalFileInfos = journalFolder.GetFiles("*.log").ToList().Where(f => (DateTime.UtcNow - f.LastWriteTimeUtc).TotalDays < maxAgeDays).OrderBy(f => f.LastWriteTimeUtc);

                foreach (var journalFileInfo in journalFileInfos)
                {
                    await ReadJournal(journalFileInfo.FullName);
                }
            }
        }

        private async Task WatchFilesAsync()
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

        private async Task ReadJournal(string journalFilePath)
        {

            string commanderName = string.Empty;

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
                        var journalEntry = JsonConvert.DeserializeObject<JObject>(line);                        

                        if (journalEntry != null)
                        {

                            string journalEntryEvent = (string)journalEntry["event"];

                            switch (journalEntryEvent)
                            {
                                case "Commander":
                                    commanderName = (string)journalEntry["Name"];
                                    _journalFileInfo[journalFilePath] = new EDJournalFileInfo(journalFilePath, commanderName);
                                    break;

                                case "Missions":
                                    var activeMissions = journalEntry["Active"];

                                    CmdrMissions[commanderName] = new List<EDJournalMission>();
                                    CmdrJournalEventQueue[commanderName] = new ConcurrentQueue<dynamic>(); // new mission list found, only interested in newer entries

                                    if (activeMissions.Count() > 0)
                                    {
                                        foreach (var activeMission in activeMissions)
                                        {
                                            var edJournalMission = new EDJournalMission(activeMission);
                                            CmdrMissions[commanderName].Add(edJournalMission);
                                        }
                                    }

                                    break;

                                case "MissionAccepted":
                                case "MissionAbandoned":
                                case "MissionCompleted":
                                case "MissionRedirected":
                                case "CargoDepot":
                                case "Bounty":
                                    // { "timestamp":"2024-04-17T21:18:41Z", "event":"MissionAccepted", "Faction":"Partnership of Zemez", "Name":"Mission_Mining", "LocalisedName":"Mine 372 Units of Silver", "Commodity":"$Silver_Name;", "Commodity_Localised":"Silver", "Count":372, "DestinationSystem":"Wally Bei", "DestinationStation":"Malerba Orbital", "Expiry":"2024-04-24T20:52:35Z", "Wing":true, "Influence":"++", "Reputation":"++", "Reward":50000000, "MissionID":961673229 }
                                    CmdrJournalEventQueue[commanderName].Enqueue(journalEntry);
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
