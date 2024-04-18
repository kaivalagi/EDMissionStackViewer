using EDMissionStackViewer.Models;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;

namespace EDMissionStackViewer
{
    public partial class EDMissionStackViewer : Form
    {

        private EDJournalWatcher _watcher;
        private bool _processQueues = true;

        public EDMissionStackViewer()
        {
            InitializeComponent();
        }

        private async Task ProcessQueues(string commander)
        {
            while (_watcher.CmdrJournalEventQueue[commander].Count > 0)
            {

                // _watcher.CmdrJournalEventQueue[commander].TryDequeue(out var journalEntry);
                var journalEntry = _watcher.CmdrJournalEventQueue[commander].First();                
                if (journalEntry.Value != null)
                {
                    await AddJournalEntry(commander, journalEntry.Value, true);
                }
                _watcher.CmdrJournalEventQueue[commander].Remove(journalEntry.Key);

                Application.DoEvents();
            }

            while (_watcher.CmdrMissions[commander].Count > 0)
            {

                var activeMission = _watcher.CmdrMissions[commander].First();
                if (activeMission != null)
                {
                    await AddActiveMission(commander, activeMission, true);
                }
                _watcher.CmdrMissions[commander].Remove(activeMission);

                Application.DoEvents();
            }

        }

        private async void MissionStackViewer_Load(object sender, EventArgs e)
        {
            commanderTabs.TabPages.Clear();
            _watcher = new EDJournalWatcher(new List<string> { "E:\\Users\\Mark\\Saved Games\\Frontier Developments\\Elite Dangerous" });
            await _watcher.InitializeAsync();
        }

        private async Task AddJournalEntry(string commander, dynamic journalEntry, bool focus = false)
        {

            if (!commanderTabs.TabPages.ContainsKey($"tabPage{commander}"))
            {
                CreateUI(commander);
            }

            var commanderTab = commanderTabs.TabPages[$"tabPage{commander}"];

            var listViewEvents = (ListView)commanderTab.Controls[0].Controls[1].Controls[0];
            ListViewItem listViewItem = null;

            if (journalEntry.GetType().BaseType.Name == "EDJournalMissionBase")
            {
                listViewItem = new ListViewItem(journalEntry.MissionId.ToString());
            } else
            {
                listViewItem = new ListViewItem("");
            }
            
            listViewItem.SubItems.Add(journalEntry.ToString());
            listViewEvents.Items.Add(listViewItem);

            if (focus)
            {
                commanderTab.Focus();
            }
        }

        private async Task AddActiveMission(string commander, dynamic activeMission, bool focus = false)
        {

            if (!commanderTabs.TabPages.ContainsKey($"tabPage{commander}"))
            {
                CreateUI(commander);
            }

            var commanderTab = commanderTabs.TabPages[$"tabPage{commander}"];

            var listBoxMissions = (ListBox)commanderTab.Controls[0].Controls[0].Controls[0];
            listBoxMissions.Items.Add(activeMission.ToString());

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
                if (_watcher.CmdrJournalEventQueue[commander].Count > 0)
                {
                    refreshTimer.Enabled = false;
                    ProcessQueues(commander);
                    refreshTimer.Enabled = true;
                }
            }
        }
    }
}
