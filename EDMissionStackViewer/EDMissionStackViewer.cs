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

        public Dictionary<string, List<object>> CmdrJournalEntryList = new Dictionary<string, List<object>>();
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
            while (_watcher.CmdrJournalEntryQueue[commander].Count > 0)
            {
                _watcher.CmdrJournalEntryQueue[commander].TryDequeue(out var journalEntry);
                if (journalEntry != null)
                {
                    await AddJournalEntry(commander, journalEntry, true);
                }

                Application.DoEvents();
            }

            if (!CmdrMissions.ContainsKey(commander) || CmdrMissions[commander] != _watcher.CmdrMissions[commander])
            {
                CmdrMissions[commander] = _watcher.CmdrMissions[commander];
                await LoadActiveMissions(commander, true);
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

            if (visible)
            {
                if (!commanderTabs.TabPages.ContainsKey($"tabPage{commander}"))
                {
                    CreateUI(commander);
                }

                var commanderTab = commanderTabs.TabPages[$"tabPage{commander}"];

                var edMissionMiningUI = (EDMissionMiningUI)commanderTab.Controls[0].Controls[1].Controls[0];
                edMissionMiningUI.LoadData(CmdrJournalEntryMissionMiningList[commander]);

                if (focus)
                {
                    commanderTab.Focus();
                }
            }
        }

        private async Task LoadActiveMissions(string commander, bool focus = false)
        {

            if (!commanderTabs.TabPages.ContainsKey($"tabPage{commander}"))
            {
                CreateUI(commander);
            }

            var commanderTab = commanderTabs.TabPages[$"tabPage{commander}"];

            var listBoxMissions = (ListBox)commanderTab.Controls[0].Controls[0].Controls[0];
            foreach (var mission in CmdrMissions[commander].Values)
            {
                listBoxMissions.Items.Add(mission.ToString());
            }
            
            if (focus)
            {
                commanderTab.Focus();
            }
        }

        private void CreateUI(string commander)
        {

            if (!commanderTabs.TabPages.ContainsKey($"tabPage{commander}"))
            {
                var listBoxMissions = new ListBox();
                listBoxMissions.Dock = DockStyle.Fill;
                listBoxMissions.FormattingEnabled = true;
                listBoxMissions.ItemHeight = 25;
                listBoxMissions.Location = new Point(0, 0);
                listBoxMissions.Name = $"listBoxMissions{commander}";
                listBoxMissions.Size = new Size(390, 871);
                listBoxMissions.TabIndex = 0;
                listBoxMissions.HorizontalScrollbar = true;
                listBoxMissions.ScrollAlwaysVisible = true;
                
                //var listViewEvents = new ListView();
                //listViewEvents.Columns.AddRange(new ColumnHeader[] { new ColumnHeader() { Text = "MissionId", Width = 100 }, new ColumnHeader() { Text = "Event", Width = 1000 } });
                //listViewEvents.Dock = DockStyle.Fill;
                //listViewEvents.Location = new Point(0, 0);
                //listViewEvents.Name = $"listViewEvents{commander}";
                //listViewEvents.Size = new Size(2178, 871);
                //listViewEvents.TabIndex = 1;
                //listViewEvents.UseCompatibleStateImageBehavior = false;
                //listViewEvents.View = View.Details;

                var edMissionMiningUI = new EDMissionMiningUI();
                edMissionMiningUI.Dock = DockStyle.Fill;
                edMissionMiningUI.Location = new Point(0, 0);
                edMissionMiningUI.Name = $"edMissionMiningUI{commander}";
                edMissionMiningUI.Size = new Size(2178, 871);
                edMissionMiningUI.TabIndex = 1;                

                var listBoxEvents = new ListBox();
                listBoxEvents.Dock = DockStyle.Fill;
                listBoxEvents.FormattingEnabled = true;
                listBoxEvents.ItemHeight = 25;
                listBoxEvents.Location = new Point(0, 0);
                listBoxEvents.Name = $"listBoxEvents{commander}";
                listBoxEvents.Size = new Size(2178, 871);
                listBoxEvents.TabIndex = 0;
                listBoxEvents.HorizontalScrollbar = true;   
                listBoxEvents.ScrollAlwaysVisible = true;


                var splitContainer = new SplitContainer();
                splitContainer.Dock = DockStyle.Fill;
                splitContainer.Location = new Point(0, 0);
                splitContainer.Name = $"splitContainer{commander}";
                splitContainer.Panel1.Controls.Add(listBoxMissions);
                //splitContainer.Panel2.Controls.Add(listViewEvents);
                splitContainer.Panel2.Controls.Add(edMissionMiningUI);
                splitContainer.Size = new Size(2572, 871);
                splitContainer.SplitterDistance = 390;
                splitContainer.TabIndex = 0;

                var tabPage = new TabPage();
                tabPage.Controls.Add(splitContainer);
                tabPage.Location = new Point(4, 34);
                tabPage.Name = $"tabPage{commander}";
                tabPage.Size = new Size(2572, 871);
                tabPage.TabIndex = 0;
                tabPage.Text = commander;
                tabPage.UseVisualStyleBackColor = true;

                commanderTabs.TabPages.Add(tabPage);
            }
        }
        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            foreach (var commander in _watcher.CmdrJournalEntryQueue.Keys)
            {
                if (!CmdrJournalEntryList.ContainsKey(commander))
                {
                    CmdrJournalEntryList[commander] = new List<object>();
                    CmdrJournalEntryMissionMassacreList[commander] = new List<EDJournalEntryMissionMassacre>();
                    CmdrJournalEntryMissionMiningList[commander] = new List<EDJournalEntryMissionMining>();
                    CmdrJournalEntryMissionCollectList[commander] = new List<EDJournalEntryMissionCollect>();
                    CmdrJournalEntryMissionCourierList[commander] = new List<EDJournalEntryMissionCourier>();
                }

                if (_watcher.CmdrJournalEntryQueue[commander].Count > 0)
                {
                    refreshTimer.Enabled = false;
                    ProcessQueues(commander);
                    refreshTimer.Enabled = true;
                }
            }
        }



//        def populate_missions_bounty(bounty: dict, missions: dict[int, dict]):
//    changed = False
//    associated_missions = [mission for mission in missions.values() if (mission["Name"].startswith("Mission_Massacre") and mission["TargetFaction"] == bounty["VictimFaction"])]
//    if associated_missions:
//        factions = []  
//        for mission in associated_missions:
//            if mission["Faction"] not in factions:
                    
//                if "VictimCount" not in mission or mission["VictimCount"] < mission["KillCount"]:
//                    if "VictimCount" not in mission:
//                        mission["VictimCount"] = 0
//                    mission["VictimCount"] += 1
//                    logger.info(f"Mission {mission['MissionID']} kill count increased")
//                    factions.append(mission["Faction"])
//                    changed = True
//                else:
//                    next

//    return changed

//def populate_missions_cargodepot(cargodepot: dict, missions: dict[int, dict]) :
//    changed = False
//    if cargodepot["MissionID"] in missions.keys():
//        logger.info(f"Mission {cargodepot['MissionID']} cargo delivered")
//        mission = missions[cargodepot["MissionID"]]
//        if "DeliveredCount" not in mission:
//            mission["DeliveredCount"] = 0
//        mission["DeliveredCount"] += cargodepot["Count"]
//        changes = True
        
//    return changed

    }
}
