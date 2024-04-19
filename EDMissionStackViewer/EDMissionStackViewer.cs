using EDMissionStackViewer.Controls;
using EDMissionStackViewer.Extensions;
using EDMissionStackViewer.Models;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Reflection;
using System.Threading.Channels;
using System.Windows.Forms;

namespace EDMissionStackViewer
{
    public partial class EDMissionStackViewer : Form
    {

        private EDJournalWatcher _watcher;
        private bool _processQueues = true;

        public Dictionary<string, List<EDJournalEntryMissionMassacre>> CmdrJournalEntryMissionMassacreList = new Dictionary<string, List<EDJournalEntryMissionMassacre>>();
        public Dictionary<string, List<EDJournalEntryMissionMining>> CmdrJournalEntryMissionMiningList = new Dictionary<string, List<EDJournalEntryMissionMining>>();
        public Dictionary<string, List<EDJournalEntryMissionCollect>> CmdrJournalEntryMissionCollectList= new Dictionary<string, List<EDJournalEntryMissionCollect>>();
        public Dictionary<string, List<EDJournalEntryMissionCourier>> CmdrJournalEntryMissionCourierList = new Dictionary<string, List<EDJournalEntryMissionCourier>>();
        public Dictionary<string, Dictionary<long,EDJournalMission>> CmdrMissions = new Dictionary<string, Dictionary<long, EDJournalMission>>();

        public EDMissionStackViewer()
        {
            InitializeComponent();
        }

        private async Task ProcessQueues(string commander)
        {
            if (!CmdrMissions.ContainsKey(commander) || CmdrMissions[commander] != _watcher.CmdrMissions[commander])
            {
                CmdrMissions[commander] = _watcher.CmdrMissions[commander];
                Application.DoEvents();
            }
            
            while (_watcher.CmdrJournalEntryQueue[commander].Count > 0)
            {
                _watcher.CmdrJournalEntryQueue[commander].TryDequeue(out var journalEntry);
                if (journalEntry != null)
                {
                    await AddJournalEntry(commander, journalEntry, true);
                }

                Application.DoEvents();
            }


        }

        private async void MissionStackViewer_Load(object sender, EventArgs e)
        {
            commanderTabs.TabPages.Clear();
            _watcher = new EDJournalWatcher(new List<string> { "E:\\Users\\Mark\\Saved Games\\Frontier Developments\\Elite Dangerous" });
            await _watcher.InitializeAsync();
        }

        private async Task AddJournalEntry(string commander, object journalEntry, bool focus = false)
        {

            var journalEntryType = journalEntry.GetType().Name;
            bool visible = false;

            switch (journalEntryType)
            {
                case "EDJournalEntryCargoDepot":
                    CmdrJournalEntryMissionMiningList[commander].PopulateMissionsCargoDepot((EDJournalEntryCargoDepot)journalEntry);
                    CmdrJournalEntryMissionCollectList[commander].PopulateMissionsCargoDepot((EDJournalEntryCargoDepot)journalEntry);
                    break;
                case "EDJournalEntryBounty":
                    CmdrJournalEntryMissionMassacreList[commander].PopulateMissionsBounty((EDJournalEntryBounty)journalEntry);
                    break;
                case "EDJournalEntryMissionMassacre":
                    visible = true;
                    CmdrJournalEntryMissionMassacreList[commander].Add((EDJournalEntryMissionMassacre)journalEntry);
                    break;
                case "EDJournalEntryMissionMining":
                    visible = true;
                    CmdrJournalEntryMissionMiningList[commander].Add((EDJournalEntryMissionMining)journalEntry);
                    break;
                case "EDJournalEntryMissionCollect":
                    visible = true;
                    CmdrJournalEntryMissionCollectList[commander].Add((EDJournalEntryMissionCollect)journalEntry);
                    break;
                case "EDJournalEntryMissionCourier":
                    visible = true;
                    CmdrJournalEntryMissionCourierList[commander].Add((EDJournalEntryMissionCourier)journalEntry);
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"Unsupported journal type of '{journalEntryType}'");
            }

        }

        private void CreateUI(string commander)
        {

            if (!CmdrJournalEntryMissionMassacreList.ContainsKey(commander))
            {
                CmdrJournalEntryMissionMassacreList[commander] = new List<EDJournalEntryMissionMassacre>();
            }

            if (!CmdrJournalEntryMissionMiningList.ContainsKey(commander))
            {
                CmdrJournalEntryMissionMiningList[commander] = new List<EDJournalEntryMissionMining>();
            }

            if (!CmdrJournalEntryMissionCollectList.ContainsKey(commander))
            {

                CmdrJournalEntryMissionCollectList[commander] = new List<EDJournalEntryMissionCollect>();
            }

            if (!CmdrJournalEntryMissionCourierList.ContainsKey(commander))
            {
                CmdrJournalEntryMissionCourierList[commander] = new List<EDJournalEntryMissionCourier>();
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

                if (CmdrJournalEntryMissionMassacreList[commander] != null)
                {
                    var massacreTab = new TabPage();
                    massacreTab.Location = new Point(4, 34);
                    massacreTab.Name = $"massacreTab{commander}";
                    massacreTab.Size = new Size(2572, 871);
                    massacreTab.TabIndex = 0;
                    massacreTab.Text = "Massacre";
                    massacreTab.UseVisualStyleBackColor = true;
                    missionTabs.Controls.Add(massacreTab);

                    var edMissionMassacreUI = new EDMissionMassacreUI();
                    edMissionMassacreUI.Dock = DockStyle.Fill;
                    edMissionMassacreUI.Location = new Point(0, 0);
                    edMissionMassacreUI.Name = $"edMissionMassacreUI{commander}";
                    edMissionMassacreUI.Size = new Size(2178, 871);
                    edMissionMassacreUI.TabIndex = 1;
                    massacreTab.Controls.Add(edMissionMassacreUI);
                }

                if (CmdrJournalEntryMissionMiningList[commander] != null)
                {
                    var miningTab = new TabPage();                    
                    miningTab.Location = new Point(4, 34);
                    miningTab.Name = $"miningTab{commander}";
                    miningTab.Size = new Size(2572, 871);
                    miningTab.TabIndex = 0;
                    miningTab.Text = "Mining";
                    miningTab.UseVisualStyleBackColor = true;
                    missionTabs.Controls.Add(miningTab);
                    
                    var edMissionMiningUI = new EDMissionMiningUI();
                    edMissionMiningUI.Dock = DockStyle.Fill;
                    edMissionMiningUI.Location = new Point(0, 0);
                    edMissionMiningUI.Name = $"edMissionMiningUI{commander}";
                    edMissionMiningUI.Size = new Size(2178, 871);
                    edMissionMiningUI.TabIndex = 1;
                    miningTab.Controls.Add(edMissionMiningUI);
                }

                if (CmdrJournalEntryMissionCollectList[commander] != null)
                {
                    var collectTab = new TabPage();
                    collectTab.Location = new Point(4, 34);
                    collectTab.Name = $"collectTab{commander}";
                    collectTab.Size = new Size(2572, 871);
                    collectTab.TabIndex = 0;
                    collectTab.Text = "Collect";
                    collectTab.UseVisualStyleBackColor = true;
                    missionTabs.Controls.Add(collectTab);

                    var edMissionCollectUI = new EDMissionCollectUI();
                    edMissionCollectUI.Dock = DockStyle.Fill;
                    edMissionCollectUI.Location = new Point(0, 0);
                    edMissionCollectUI.Name = $"edMissionCollectUI{commander}";
                    edMissionCollectUI.Size = new Size(2178, 871);
                    edMissionCollectUI.TabIndex = 1;
                    collectTab.Controls.Add(edMissionCollectUI);
                }

                if (CmdrJournalEntryMissionCourierList[commander] != null)
                {
                    var courierTab = new TabPage();
                    courierTab.Location = new Point(4, 34);
                    courierTab.Name = $"courierTab{commander}";
                    courierTab.Size = new Size(2572, 871);
                    courierTab.TabIndex = 0;
                    courierTab.Text = "Courier";
                    courierTab.UseVisualStyleBackColor = true;
                    missionTabs.Controls.Add(courierTab);

                    var edMissionCourierUI = new EDMissionCourierUI();
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

            if (CmdrJournalEntryMissionMassacreList[commander].Count > 0)
            {
                var massacreTab = (TabPage)(missionsTab.TabPages[$"massacreTab{commander}"]);
                var edMissionMassacreUI = (EDMissionMassacreUI)(massacreTab.Controls[0]);
                edMissionMassacreUI.LoadData(CmdrJournalEntryMissionMassacreList[commander]);
                massacreTab.Focus();
            }

            if (CmdrJournalEntryMissionMiningList[commander].Count > 0)
            {
                var miningTab = (TabPage)(missionsTab.TabPages[$"miningTab{commander}"]);
                var edMissionMiningUI = (EDMissionMiningUI)(miningTab.Controls[0]);
                edMissionMiningUI.LoadData(CmdrJournalEntryMissionMiningList[commander]);
                miningTab.Focus();
            }

            if (CmdrJournalEntryMissionCollectList[commander].Count > 0)
            {
                var collectTab= (TabPage)(missionsTab.TabPages[$"collectTab{commander}"]);
                var edMissionCollectUI = (EDMissionCollectUI)(collectTab.Controls[0]);
                edMissionCollectUI.LoadData(CmdrJournalEntryMissionCollectList[commander]);
                collectTab.Focus();
            }

            if (CmdrJournalEntryMissionCourierList[commander].Count > 0)
            {
                var courierTab = (TabPage)(missionsTab.TabPages[$"courierTab{commander}"]);
                var edMissionCourierUI = (EDMissionCourierUI)(courierTab.Controls[0]);
                edMissionCourierUI.LoadData(CmdrJournalEntryMissionCourierList[commander]);
                courierTab.Focus();

            }
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            refreshTimer.Enabled = false;

            foreach (var commander in _watcher.CmdrJournalEntryQueue.Keys)
            {
                if (!commanderTabs.TabPages.ContainsKey($"tabPage{commander}"))
                {
                    CreateUI(commander);
                }

                if (_watcher.CmdrJournalEntryQueue[commander].Count > 0)
                {                    
                    ProcessQueues(commander);
                }

                LoadData(commander);
            }

            refreshTimer.Enabled = true;

        }
    }
}
