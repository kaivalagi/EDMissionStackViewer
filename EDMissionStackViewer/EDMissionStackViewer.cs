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

        private async Task ProcessQueue(string commander)
        {
            while (_watcher.CmdrJournalEventQueue[commander].Count > 0)
            {

                _watcher.CmdrJournalEventQueue[commander].TryDequeue(out var journalEntry);
                if (journalEntry != null)
                {
                    await AddJournalEntry(commander, journalEntry, true);
                    Application.DoEvents();
                }

                Application.DoEvents();
            }
        }

        private async void MissionStackViewer_Load(object sender, EventArgs e)
        {
            _watcher = new EDJournalWatcher(new List<string> { "E:\\Users\\Mark\\Saved Games\\Frontier Developments\\Elite Dangerous" });
            await _watcher.InitializeAsync();
        }

        private async Task AddJournalEntry(string commander, dynamic journalEntry, bool focus = false)
        {

            ListBox listBox = null;

            if (!commanderTabs.TabPages.ContainsKey($"tabPage{commander}"))
            {

                // 
                // listBox1
                // 
                listBox = new ListBox();
                listBox.Dock = DockStyle.Fill;
                listBox.FormattingEnabled = true;
                listBox.ItemHeight = 25;
                listBox.Location = new Point(0, 0);
                listBox.Name = $"listBox{commander}";
                listBox.Size = new Size(792, 412);
                listBox.TabIndex = 0;

                // 
                // tabPage1
                // 
                var tabPage = new TabPage();
                tabPage.Controls.Add(listBox);
                tabPage.Location = new Point(4, 34);
                tabPage.Name = $"tabPage{commander}";
                tabPage.Size = new Size(792, 412);
                tabPage.TabIndex = 0;
                tabPage.Text = commander;
                tabPage.UseVisualStyleBackColor = true;

                commanderTabs.TabPages.Add(tabPage);
            }

            var commanderTab = commanderTabs.TabPages[$"tabPage{commander}"];

            listBox = (ListBox)commanderTab.Controls[0];
            listBox.Items.Add(journalEntry.ToString());

            if (focus)
            {
                commanderTab.Focus();
            }
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            foreach (var commander in _watcher.CmdrJournalEventQueue.Keys)
            {
                if (_watcher.CmdrJournalEventQueue[commander].Count > 0)
                {
                    refreshTimer.Enabled = false;
                    ProcessQueue(commander);
                    refreshTimer.Enabled = true;
                }
            }
        }
    }
}
