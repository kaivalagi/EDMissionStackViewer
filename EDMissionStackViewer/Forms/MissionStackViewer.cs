using EDJournalQueue;
using EDJournalQueue.Extensions;
using EDJournalQueue.Models;
using EDMissionStackViewer.Forms;
using EDMissionStackViewer.UserControls;
using Microsoft.Extensions.Logging;

namespace EDMissionStackViewer
{
    public partial class MissionStackViewer : Form
    {

        #region Class Data

        private readonly ILogger _logger;

        private Watcher _watcher;

        public Dictionary<string, Dictionary<long, Mission>> Missions;
        public Dictionary<string, List<JournalEntryMissionMassacre>> JournalEntryMissionMassacreList;
        public Dictionary<string, List<JournalEntryMissionMining>> JournalEntryMissionMiningList;
        public Dictionary<string, List<JournalEntryMissionCollect>> JournalEntryMissionCollectList;
        public Dictionary<string, List<JournalEntryMissionCourier>> JournalEntryMissionCourierList;

        public List<string> _journalFolderPaths;
        private int _journalMaxAgeDays = 28;
        private bool _archiveInactiveJournals = false;

        #endregion

        #region Constructor

        public MissionStackViewer(ILogger<MissionStackViewer> logger, Watcher watcher)
        {
            _logger = logger;
            _watcher = watcher;
            InitializeComponent();
        }

        #endregion

        #region Events

        private async void MissionStackViewer_Load(object sender, EventArgs e)
        {

            try
            {
                _logger.LogInformation("Loading mission stack viewer");

                tabControlCommanders.TabPages.Clear(); // Shouldn't need this but we have dummy controls there for now to help with dev            

                if (Properties.Settings.Default.JournalFolders == string.Empty)
                {
                    Properties.Settings.Default.JournalFolders = Helpers.Journal.GetDefaultJournalFolder().FullName;
                    Properties.Settings.Default.Save();
                }
                _journalFolderPaths = Properties.Settings.Default.JournalFolders.Split(",").ToList();
                _journalMaxAgeDays = Properties.Settings.Default.JournalMaxAgeDays;
                _archiveInactiveJournals = Properties.Settings.Default.ArchiveInactiveJournals;

                Missions = new Dictionary<string, Dictionary<long, Mission>>();
                JournalEntryMissionMassacreList = new Dictionary<string, List<JournalEntryMissionMassacre>>();
                JournalEntryMissionMiningList = new Dictionary<string, List<JournalEntryMissionMining>>();
                JournalEntryMissionCollectList = new Dictionary<string, List<JournalEntryMissionCollect>>();
                JournalEntryMissionCourierList = new Dictionary<string, List<JournalEntryMissionCourier>>();
                await _watcher.InitializeAsync(_journalFolderPaths, _journalMaxAgeDays, _archiveInactiveJournals);
            } 
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading mission stack viewer");
            }
        }

        private async void refreshTimer_Tick(object sender, EventArgs e)
        {
            try {
                refreshTimer.Enabled = false;
                foreach (var commanderName in _watcher.JournalEntryQueue.Keys)
                {
                    await CreateControls(commanderName);
                    await ProcessMissions(commanderName);

                    if (_watcher.JournalEntryQueue[commanderName].Count > 0)
                    {
                        await ProcessJournalEntryQueue(commanderName);
                        await RefreshMissions(commanderName);
                    }
                }
                refreshTimer.Enabled = true;
            } 
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error refreshing mission stack viewer");
            }
            finally
            {
                refreshTimer.Enabled = true;
            }
        }

        private async void menuSettings_Click(object sender, EventArgs e)
        {
            var settingsDialog = new SettingsDialog();
            var result = settingsDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (settingsDialog.JournalFolders != _journalFolderPaths)
                {
                    try {
                        _journalFolderPaths = settingsDialog.JournalFolders;
                        Missions = new Dictionary<string, Dictionary<long, Mission>>();
                        JournalEntryMissionMassacreList = new Dictionary<string, List<JournalEntryMissionMassacre>>();
                        JournalEntryMissionMiningList = new Dictionary<string, List<JournalEntryMissionMining>>();
                        JournalEntryMissionCollectList = new Dictionary<string, List<JournalEntryMissionCollect>>();
                        JournalEntryMissionCourierList = new Dictionary<string, List<JournalEntryMissionCourier>>();
                        tabControlCommanders.Controls.Clear();
                        await _watcher.InitializeAsync(_journalFolderPaths, _journalMaxAgeDays, _archiveInactiveJournals);
                    } 
                    catch (Exception ex)
                    {
                            _logger.LogError(ex, "Error reloading mission stack viewer after settings update");
                    }
                }
            }
        }

        #endregion

        #region Methods

        private async Task ProcessMissions(string commanderName)
        {
            if (!Missions.ContainsKey(commanderName) || Missions[commanderName] != _watcher.ActiveMissions[commanderName])
            {
                Missions[commanderName] = _watcher.ActiveMissions[commanderName];
                Application.DoEvents();
            }
        }

        private async Task ProcessJournalEntryQueue(string commanderName)
        {
            while (_watcher.JournalEntryQueue[commanderName].Count > 0)
            {
                _watcher.JournalEntryQueue[commanderName].TryDequeue(out var journalEntry);
                if (journalEntry != null)
                {
                    await ProcessJournalEntry(commanderName, journalEntry);
                }

                Application.DoEvents();
            }
        }

        private async Task ProcessJournalEntry(string commanderName, object journalEntry)
        {

            var journalEntryType = journalEntry.GetType().Name;

            switch (journalEntryType)
            {
                case "JournalEntryCargoDepot":
                    JournalEntryMissionMiningList[commanderName].PopulateMissionFromCargoDepot((JournalEntryCargoDepot)journalEntry);
                    JournalEntryMissionCollectList[commanderName].PopulateMissionFromCargoDepot((JournalEntryCargoDepot)journalEntry);
                    break;
                case "JournalEntryBounty":
                    JournalEntryMissionMassacreList[commanderName].PopulateMissionFromBounty((JournalEntryBounty)journalEntry);
                    break;
                case "JournalEntryMissionMassacre":
                    JournalEntryMissionMassacreList[commanderName].Add((JournalEntryMissionMassacre)journalEntry);
                    break;
                case "JournalEntryMissionMining":
                    JournalEntryMissionMiningList[commanderName].Add((JournalEntryMissionMining)journalEntry);
                    break;
                case "JournalEntryMissionCollect":
                    JournalEntryMissionCollectList[commanderName].Add((JournalEntryMissionCollect)journalEntry);
                    break;
                case "JournalEntryMissionCourier":
                    JournalEntryMissionCourierList[commanderName].Add((JournalEntryMissionCourier)journalEntry);
                    break;
                case "JournalEntryMissionRemoved":
                    await RemoveJournalEntry(commanderName, (JournalEntryMissionRemoved)journalEntry);
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"Unsupported journal type of '{journalEntryType}'\n{journalEntry.ToString()}");
            }

        }

        private async Task RemoveJournalEntry(string commanderName, JournalEntryMissionRemoved missionRemoved)
        {
            if (missionRemoved.Name.StartsWith("Mission_Collect"))
            {
                var collectMission = JournalEntryMissionCollectList[commanderName].Where(m => m.MissionId == missionRemoved.MissionId).FirstOrDefault();
                if (collectMission != null)
                {
                    JournalEntryMissionCollectList[commanderName].Remove(collectMission);
                }
            }
            else if (missionRemoved.Name.StartsWith("Mission_Courier"))
            {
                var courierMission = JournalEntryMissionCourierList[commanderName].Where(m => m.MissionId == missionRemoved.MissionId).FirstOrDefault();
                if (courierMission != null)
                {
                    JournalEntryMissionCourierList[commanderName].Remove(courierMission);
                }
            }
            else if (missionRemoved.Name.StartsWith("Mission_Massacre"))
            {
                var massacreMission = JournalEntryMissionMassacreList[commanderName].Where(m => m.MissionId == missionRemoved.MissionId).FirstOrDefault();
                if (massacreMission != null)
                {
                    JournalEntryMissionMassacreList[commanderName].Remove(massacreMission);
                }
            }
            else if (missionRemoved.Name.StartsWith("Mission_Mining"))
            {
                var miningMission = JournalEntryMissionMiningList[commanderName].Where(m => m.MissionId == missionRemoved.MissionId).FirstOrDefault();
                if (miningMission != null)
                {
                    JournalEntryMissionMiningList[commanderName].Remove(miningMission);
                }
            }
        }

        private async Task CreateControls(string commanderName)
        {
            if (!JournalEntryMissionMassacreList.ContainsKey(commanderName))
            {
                JournalEntryMissionMassacreList[commanderName] = new List<JournalEntryMissionMassacre>();
            }

            if (!JournalEntryMissionMiningList.ContainsKey(commanderName))
            {
                JournalEntryMissionMiningList[commanderName] = new List<JournalEntryMissionMining>();
            }

            if (!JournalEntryMissionCollectList.ContainsKey(commanderName))
            {

                JournalEntryMissionCollectList[commanderName] = new List<JournalEntryMissionCollect>();
            }

            if (!JournalEntryMissionCourierList.ContainsKey(commanderName))
            {
                JournalEntryMissionCourierList[commanderName] = new List<JournalEntryMissionCourier>();
            }

            tabControlCommanders.Visible = true;

            if (!tabControlCommanders.TabPages.ContainsKey($"tabPageCommander{commanderName}"))
            {
                var tabPageCommander = new TabPage();
                tabPageCommander.Location = new Point(4, 34);
                tabPageCommander.Name = $"tabPageCommander{commanderName}";
                tabPageCommander.Size = new Size(2572, 871);
                tabPageCommander.TabIndex = 0;
                tabPageCommander.Text = commanderName;
                tabPageCommander.UseVisualStyleBackColor = true;
                tabControlCommanders.TabPages.Add(tabPageCommander);

                var uiMissions = new UCMissions();
                uiMissions.Dock = DockStyle.Fill;
                uiMissions.Location = new Point(3, 3);
                uiMissions.Name = $"uiMissions{commanderName}";
                uiMissions.Size = new Size(1439, 715);
                uiMissions.TabIndex = 0;
                uiMissions.HideAllMissions();
                tabPageCommander.Controls.Add(uiMissions);
            }
        }
        private async Task RefreshMissions(string commanderName)
        {
            var tabPageCommander = tabControlCommanders.TabPages[$"tabPageCommander{commanderName}"];
            var uiMissions = (UCMissions)(tabPageCommander.Controls[0]);

            if (JournalEntryMissionCollectList[commanderName].Count > 0)
            {
                uiMissions.ShowMissionCollect(JournalEntryMissionCollectList[commanderName]);
                tabControlCommanders.SelectTab(tabPageCommander);
            }
            else
            {
                uiMissions.HideMissionCollect();
            }

            if (JournalEntryMissionCourierList[commanderName].Count > 0)
            {
                uiMissions.ShowMissionCourier(JournalEntryMissionCourierList[commanderName]);
                tabControlCommanders.SelectTab(tabPageCommander);
            }
            else
            {
                uiMissions.HideMissionCourier();
            }

            if (JournalEntryMissionMassacreList[commanderName].Count > 0)
            {
                uiMissions.ShowMissionMassacre(JournalEntryMissionMassacreList[commanderName]);
                tabControlCommanders.SelectTab(tabPageCommander);
            }
            else
            {
                uiMissions.HideMissionMassacre();
            }

            if (JournalEntryMissionMiningList[commanderName].Count > 0)
            {
                uiMissions.ShowMissionMining(JournalEntryMissionMiningList[commanderName]);
                tabControlCommanders.SelectTab(tabPageCommander);
            }
            else
            {
                uiMissions.HideMissionMining();
            }

            if (uiMissions.ActiveMissions)
            {
                lblNoCommander.Visible = false;
                tabPageCommander.Parent = tabControlCommanders;
            }
            else
            {
                lblNoCommander.Visible = true;
                tabPageCommander.Parent = null;
            }
        }

        #endregion


    }
}
