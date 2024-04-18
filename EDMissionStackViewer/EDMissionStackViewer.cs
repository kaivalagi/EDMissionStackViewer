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

        public Dictionary<string, List<object>> CmdrJournalEvents = new Dictionary<string, List<object>>();
        public Dictionary<string, Dictionary<long,EDJournalMission>> CmdrMissions = new Dictionary<string, Dictionary<long, EDJournalMission>>();

        public EDMissionStackViewer()
        {
            InitializeComponent();
        }

        private async Task ProcessQueues(string commander)
        {
            while (_watcher.CmdrJournalEventQueue[commander].Count > 0)
            {
                _watcher.CmdrJournalEventQueue[commander].TryDequeue(out var journalEntry);
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
                case "EDJournalCargoDepot":
                    CmdrJournalEvents[commander].PopulateMissionsCargoDepot((EDJournalCargoDepot)journalEntry);
                    break;
                case "EDJournalBounty":
                    CmdrJournalEvents[commander].PopulateMissionsBounty((EDJournalBounty)journalEntry);
                    break;
                case "EDJournalMissionMassacre":
                case "EDJournalMissionMining":
                case "EDJournalMissionCollect":
                case "EDJournalMissionCourier":
                case "EDJournalMissionBase":
                    visible = true;
                    CmdrJournalEvents[commander].Add(journalEntry);
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

                var listViewEvents = (ListView)commanderTab.Controls[0].Controls[1].Controls[0];

                var mission = (EDJournalMissionBase)journalEntry;
                var listViewItem = new ListViewItem(mission.MissionId.ToString());
                listViewItem.SubItems.Add(mission.ToString());
                listViewEvents.Items.Add(listViewItem);

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
                
                var listViewEvents = new ListView();
                listViewEvents.Columns.AddRange(new ColumnHeader[] { new ColumnHeader() { Text = "MissionId", Width = 100 }, new ColumnHeader() { Text = "Event", Width = 1000 } });
                listViewEvents.Dock = DockStyle.Fill;
                listViewEvents.Location = new Point(0, 0);
                listViewEvents.Name = $"listViewEvents{commander}";
                listViewEvents.Size = new Size(2178, 871);
                listViewEvents.TabIndex = 1;
                listViewEvents.UseCompatibleStateImageBehavior = false;
                listViewEvents.View = View.Details;

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
                splitContainer.Panel2.Controls.Add(listViewEvents);
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
            foreach (var commander in _watcher.CmdrJournalEventQueue.Keys)
            {
                if (!CmdrJournalEvents.ContainsKey(commander))
                {
                    CmdrJournalEvents[commander] = new List<object>();
                }

                if (_watcher.CmdrJournalEventQueue[commander].Count > 0)
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
