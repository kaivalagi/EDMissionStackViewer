using EDJournalQueue;
using EDJournalQueue.Extensions;
using EDJournalQueue.Models;
using EDMissionStackViewer.Forms;
using EDMissionStackViewer.UserControls;
using EDMissionStackViewer;

namespace EDMissionStackViewer
{
    public partial class FormMissionStackViewer : Form
    {

        #region Class Data

        private Watcher _watcher;
        private bool _processQueues = true;

        public Dictionary<string, Dictionary<long, Mission>> Missions = new Dictionary<string, Dictionary<long, Mission>>();
        public Dictionary<string, List<JournalEntryMissionMassacre>> JournalEntryMissionMassacreList = new Dictionary<string, List<JournalEntryMissionMassacre>>();
        public Dictionary<string, List<JournalEntryMissionMining>> JournalEntryMissionMiningList = new Dictionary<string, List<JournalEntryMissionMining>>();
        public Dictionary<string, List<JournalEntryMissionCollect>> JournalEntryMissionCollectList = new Dictionary<string, List<JournalEntryMissionCollect>>();
        public Dictionary<string, List<JournalEntryMissionCourier>> JournalEntryMissionCourierList = new Dictionary<string, List<JournalEntryMissionCourier>>();

        public List<string> _journalFolders;

        #endregion

        #region Constructor

        public FormMissionStackViewer()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        private async void MissionStackViewer_Load(object sender, EventArgs e)
        {
            tabControlCommanders.TabPages.Clear(); // Shouldn't need this but we have dummy controls there for now to help with dev            

            if (Properties.Settings.Default.JournalFolders == "")
            {
                Properties.Settings.Default.JournalFolders = Helper.GetDefaultJournalFolder().FullName;
                Properties.Settings.Default.Save();
            }
            _journalFolders = Properties.Settings.Default.JournalFolders.Split(",").ToList();

            await InitialiseWatcher();
        }

        public async Task InitialiseWatcher()
        {            
            _watcher = new Watcher(_journalFolders);
            await _watcher.InitializeAsync();
        }


        private async void refreshTimer_Tick(object sender, EventArgs e)
        {
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

        private async void menuSettingsJournalFolder_Click(object sender, EventArgs e)
        {
            var formJournalFolders = new FormJournalFolders();
            var result = formJournalFolders.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (formJournalFolders.JournalFolders != _journalFolders)
                {
                    _journalFolders = formJournalFolders.JournalFolders;
                    await InitialiseWatcher();
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
                    await ProcessJournalEntry(commanderName, journalEntry, true);
                }

                Application.DoEvents();
            }
        }        

        private async Task ProcessJournalEntry(string commanderName, object journalEntry, bool focus = false)
        {

            var journalEntryType = journalEntry.GetType().Name;

            switch (journalEntryType)
            {
                case "JournalEntryCargoDepot":
                    JournalEntryMissionMiningList[commanderName].PopulateMissionsCargoDepot((JournalEntryCargoDepot)journalEntry);
                    JournalEntryMissionCollectList[commanderName].PopulateMissionsCargoDepot((JournalEntryCargoDepot)journalEntry);
                    break;
                case "JournalEntryBounty":
                    JournalEntryMissionMassacreList[commanderName].PopulateMissionsBounty((JournalEntryBounty)journalEntry);
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
            }
            else
            {
                uiMissions.HideMissionCollect();
            }

            if (JournalEntryMissionCourierList[commanderName].Count > 0)
            {
                uiMissions.ShowMissionCourier(JournalEntryMissionCourierList[commanderName]);
            }
            else
            {
                uiMissions.HideMissionCourier();
            }

            if (JournalEntryMissionMassacreList[commanderName].Count > 0)
            {
                uiMissions.ShowMissionMassacre(JournalEntryMissionMassacreList[commanderName]);
            }
            else
            {
                uiMissions.HideMissionMassacre();
            }

            if (JournalEntryMissionMiningList[commanderName].Count > 0)
            {
                uiMissions.ShowMissionMining(JournalEntryMissionMiningList[commanderName]);
            }
            else
            {
                uiMissions.HideMissionMining();
            }

            if (uiMissions.ActiveMissions)
            {
                tabPageCommander.Parent = tabControlCommanders;
            }
            else
            {
                tabPageCommander.Parent = null;
            }

        }

        #endregion

    }
}
