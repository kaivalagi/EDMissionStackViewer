using EDJournalQueue;
using EDJournalQueue.Events;
using EDJournalQueue.Extensions;
using EDJournalQueue.Models;
using EDMissionStackViewer.Controls;

namespace EDMissionStackViewer
{
    public partial class MissionStackViewer : Form
    {

        private Watcher _watcher;
        private bool _processQueues = true;

        public Dictionary<string, List<JournalEntryMissionMassacre>> JournalEntryMissionMassacreList = new Dictionary<string, List<JournalEntryMissionMassacre>>();
        public Dictionary<string, List<JournalEntryMissionMining>> JournalEntryMissionMiningList = new Dictionary<string, List<JournalEntryMissionMining>>();
        public Dictionary<string, List<JournalEntryMissionCollect>> JournalEntryMissionCollectList = new Dictionary<string, List<JournalEntryMissionCollect>>();
        public Dictionary<string, List<JournalEntryMissionCourier>> JournalEntryMissionCourierList = new Dictionary<string, List<JournalEntryMissionCourier>>();
        public Dictionary<string, Dictionary<long, Mission>> Missions = new Dictionary<string, Dictionary<long, Mission>>();

        public MissionStackViewer()
        {
            InitializeComponent();
        }

        private async Task ProcessQueues(string commander)
        {
            if (!Missions.ContainsKey(commander) || Missions[commander] != _watcher.ActiveMissions[commander])
            {
                Missions[commander] = _watcher.ActiveMissions[commander];
                Application.DoEvents();
            }

            while (_watcher.JournalEntryQueue[commander].Count > 0)
            {
                _watcher.JournalEntryQueue[commander].TryDequeue(out var journalEntry);
                if (journalEntry != null)
                {
                    await AddJournalEntry(commander, journalEntry, true);
                }

                Application.DoEvents();
            }


        }

        #region Events

        private async void MissionStackViewer_Load(object sender, EventArgs e)
        {
            commanderTabs.TabPages.Clear();
            _watcher = new Watcher(new List<string> { "E:\\Users\\Mark\\Saved Games\\Frontier Developments\\Elite Dangerous" });
            _watcher.JournalEntryQueueChanged += Watcher_JournalEntryQueueChanged;
            _watcher.MissionsChanged += Watcher_MissionsChanged;
            await _watcher.InitializeAsync();
        }

        private void Watcher_MissionsChanged(object? sender, MissionsChangedEventArgs e)
        {
            Console.WriteLine($"MissionsChanged for '{e.CommanderName}': {e.JToken.ToString()}");
        }

        private void Watcher_JournalEntryQueueChanged(object? sender, JournalEntryQueueChangedEventArgs e)
        {
            Console.WriteLine($"JournalEntryQueueChanged for '{e.CommanderName}': {e.JToken.ToString()}");
        }

        #endregion

        private async Task AddJournalEntry(string commander, object journalEntry, bool focus = false)
        {

            var journalEntryType = journalEntry.GetType().Name;

            switch (journalEntryType)
            {
                case "JournalEntryCargoDepot":
                    JournalEntryMissionMiningList[commander].PopulateMissionsCargoDepot((JournalEntryCargoDepot)journalEntry);
                    JournalEntryMissionCollectList[commander].PopulateMissionsCargoDepot((JournalEntryCargoDepot)journalEntry);
                    break;
                case "JournalEntryBounty":
                    JournalEntryMissionMassacreList[commander].PopulateMissionsBounty((JournalEntryBounty)journalEntry);
                    break;
                case "JournalEntryMissionMassacre":
                    JournalEntryMissionMassacreList[commander].Add((JournalEntryMissionMassacre)journalEntry);
                    break;
                case "JournalEntryMissionMining":
                    JournalEntryMissionMiningList[commander].Add((JournalEntryMissionMining)journalEntry);
                    break;
                case "JournalEntryMissionCollect":
                    JournalEntryMissionCollectList[commander].Add((JournalEntryMissionCollect)journalEntry);
                    break;
                case "JournalEntryMissionCourier":
                    JournalEntryMissionCourierList[commander].Add((JournalEntryMissionCourier)journalEntry);
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"Unsupported journal type of '{journalEntryType}'");
            }

        }

        private void CreateUI(string commander)
        {

            if (!JournalEntryMissionMassacreList.ContainsKey(commander))
            {
                JournalEntryMissionMassacreList[commander] = new List<JournalEntryMissionMassacre>();
            }

            if (!JournalEntryMissionMiningList.ContainsKey(commander))
            {
                JournalEntryMissionMiningList[commander] = new List<JournalEntryMissionMining>();
            }

            if (!JournalEntryMissionCollectList.ContainsKey(commander))
            {

                JournalEntryMissionCollectList[commander] = new List<JournalEntryMissionCollect>();
            }

            if (!JournalEntryMissionCourierList.ContainsKey(commander))
            {
                JournalEntryMissionCourierList[commander] = new List<JournalEntryMissionCourier>();
            }

            if (!commanderTabs.TabPages.ContainsKey($"tabPage{commander}"))
            {
                var tabPage = new TabPage();
                tabPage.Location = new Point(4, 34);
                tabPage.Name = $"tabPage{commander}";
                tabPage.Size = new Size(2572, 871);
                tabPage.TabIndex = 0;
                tabPage.Text = commander;
                tabPage.UseVisualStyleBackColor = true;
                commanderTabs.TabPages.Add(tabPage);

                var missionTabs = new TabControl();
                missionTabs.Dock = DockStyle.Fill;
                missionTabs.Location = new Point(0, 0);
                missionTabs.Name = $"missionTabs{commander}";
                missionTabs.SelectedIndex = 0;
                missionTabs.Size = new Size(2580, 909);
                missionTabs.TabIndex = 3;
                tabPage.Controls.Add(missionTabs);

                if (JournalEntryMissionMassacreList[commander] != null)
                {
                    var massacreTab = new TabPage();
                    massacreTab.Location = new Point(4, 34);
                    massacreTab.Name = $"massacreTab{commander}";
                    massacreTab.Size = new Size(2572, 871);
                    massacreTab.TabIndex = 0;
                    massacreTab.Text = "Massacre";
                    massacreTab.UseVisualStyleBackColor = true;
                    missionTabs.Controls.Add(massacreTab);

                    var edMissionMassacreUI = new UIMissionMassacre();
                    edMissionMassacreUI.Dock = DockStyle.Fill;
                    edMissionMassacreUI.Location = new Point(0, 0);
                    edMissionMassacreUI.Name = $"edMissionMassacreUI{commander}";
                    edMissionMassacreUI.Size = new Size(2178, 871);
                    edMissionMassacreUI.TabIndex = 1;
                    massacreTab.Controls.Add(edMissionMassacreUI);
                }

                if (JournalEntryMissionMiningList[commander] != null)
                {
                    var miningTab = new TabPage();
                    miningTab.Location = new Point(4, 34);
                    miningTab.Name = $"miningTab{commander}";
                    miningTab.Size = new Size(2572, 871);
                    miningTab.TabIndex = 0;
                    miningTab.Text = "Mining";
                    miningTab.UseVisualStyleBackColor = true;
                    missionTabs.Controls.Add(miningTab);

                    var edMissionMiningUI = new UIMissionMining();
                    edMissionMiningUI.Dock = DockStyle.Fill;
                    edMissionMiningUI.Location = new Point(0, 0);
                    edMissionMiningUI.Name = $"edMissionMiningUI{commander}";
                    edMissionMiningUI.Size = new Size(2178, 871);
                    edMissionMiningUI.TabIndex = 1;
                    miningTab.Controls.Add(edMissionMiningUI);
                }

                if (JournalEntryMissionCollectList[commander] != null)
                {
                    var collectTab = new TabPage();
                    collectTab.Location = new Point(4, 34);
                    collectTab.Name = $"collectTab{commander}";
                    collectTab.Size = new Size(2572, 871);
                    collectTab.TabIndex = 0;
                    collectTab.Text = "Collect";
                    collectTab.UseVisualStyleBackColor = true;
                    missionTabs.Controls.Add(collectTab);

                    var edMissionCollectUI = new UIMissionCollect();
                    edMissionCollectUI.Dock = DockStyle.Fill;
                    edMissionCollectUI.Location = new Point(0, 0);
                    edMissionCollectUI.Name = $"edMissionCollectUI{commander}";
                    edMissionCollectUI.Size = new Size(2178, 871);
                    edMissionCollectUI.TabIndex = 1;
                    collectTab.Controls.Add(edMissionCollectUI);
                }

                if (JournalEntryMissionCourierList[commander] != null)
                {
                    var courierTab = new TabPage();
                    courierTab.Location = new Point(4, 34);
                    courierTab.Name = $"courierTab{commander}";
                    courierTab.Size = new Size(2572, 871);
                    courierTab.TabIndex = 0;
                    courierTab.Text = "Courier";
                    courierTab.UseVisualStyleBackColor = true;
                    missionTabs.Controls.Add(courierTab);

                    var edMissionCourierUI = new UIMissionCourier();
                    edMissionCourierUI.Dock = DockStyle.Fill;
                    edMissionCourierUI.Location = new Point(0, 0);
                    edMissionCourierUI.Name = $"edMissionCourierUI{commander}";
                    edMissionCourierUI.Size = new Size(2178, 871);
                    edMissionCourierUI.TabIndex = 1;
                    courierTab.Controls.Add(edMissionCourierUI);
                }

            }
        }

        private void LoadData(string commander)
        {
            var commanderTab = commanderTabs.TabPages[$"tabPage{commander}"];
            var missionsTab = (TabControl)(commanderTab.Controls[0]);

            if (JournalEntryMissionMassacreList[commander].Count > 0)
            {
                var massacreTab = (TabPage)(missionsTab.TabPages[$"massacreTab{commander}"]);
                var edMissionMassacreUI = (UIMissionMassacre)(massacreTab.Controls[0]);
                edMissionMassacreUI.LoadData(JournalEntryMissionMassacreList[commander]);
                massacreTab.Focus();
            }

            if (JournalEntryMissionMiningList[commander].Count > 0)
            {
                var miningTab = (TabPage)(missionsTab.TabPages[$"miningTab{commander}"]);
                var edMissionMiningUI = (UIMissionMining)(miningTab.Controls[0]);
                edMissionMiningUI.LoadData(JournalEntryMissionMiningList[commander]);
                miningTab.Focus();
            }

            if (JournalEntryMissionCollectList[commander].Count > 0)
            {
                var collectTab = (TabPage)(missionsTab.TabPages[$"collectTab{commander}"]);
                var edMissionCollectUI = (UIMissionCollect)(collectTab.Controls[0]);
                edMissionCollectUI.LoadData(JournalEntryMissionCollectList[commander]);
                collectTab.Focus();
            }

            if (JournalEntryMissionCourierList[commander].Count > 0)
            {
                var courierTab = (TabPage)(missionsTab.TabPages[$"courierTab{commander}"]);
                var edMissionCourierUI = (UIMissionCourier)(courierTab.Controls[0]);
                edMissionCourierUI.LoadData(JournalEntryMissionCourierList[commander]);
                courierTab.Focus();

            }
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            refreshTimer.Enabled = false;

            foreach (var commander in _watcher.JournalEntryQueue.Keys)
            {
                if (!commanderTabs.TabPages.ContainsKey($"tabPage{commander}"))
                {
                    CreateUI(commander);
                }

                if (_watcher.JournalEntryQueue[commander].Count > 0)
                {
                    ProcessQueues(commander);
                }

                LoadData(commander);
            }

            refreshTimer.Enabled = true;

        }
    }
}
