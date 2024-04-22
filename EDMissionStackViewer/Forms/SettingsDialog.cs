namespace EDMissionStackViewer.Forms
{
    public partial class SettingsDialog : Form
    {

        #region Class Data

        public List<string> JournalFolders { get; set; }
        public int JournalMaxAgeDays { get; set; }
        public bool ArchiveInactiveJournals { get; set; }

        #endregion

        #region Constructor

        public SettingsDialog()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        private void FormJournalFolders_Load(object sender, EventArgs e)
        {
            JournalFolders = Properties.Settings.Default.JournalFolders.Split(",").ToList();
            JournalMaxAgeDays = Properties.Settings.Default.JournalMaxAgeDays;
            ArchiveInactiveJournals = Properties.Settings.Default.ArchiveInactiveJournals;
            LoadView();
        }
        private void numericUpDownMaxAgeDays_ValueChanged(object sender, EventArgs e)
        {
            JournalMaxAgeDays = (int)numericUpDownMaxAgeDays.Value;
        }

        private void checkBoxArchiveInactiveJournals_CheckedChanged(object sender, EventArgs e)
        {
            ArchiveInactiveJournals = checkBoxArchiveInactiveJournals.Checked;
        }

        private void listViewJournalFolders_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewJournalFolders.SelectedItems.Count > 0)
            {
                buttonRemove.Enabled = true;
            }
            else
            {
                buttonRemove.Enabled = false;
            }
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var result = dialogFolder.ShowDialog();
            if (result == DialogResult.OK)
            {
                JournalFolders.Add(dialogFolder.SelectedPath);
            }
            LoadView();

        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewJournalFolders.SelectedItems)
            {
                JournalFolders.Remove(item.Text);
            }
            LoadView();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.JournalFolders = string.Join(",", JournalFolders);
            Properties.Settings.Default.JournalMaxAgeDays = JournalMaxAgeDays;
            Properties.Settings.Default.ArchiveInactiveJournals = ArchiveInactiveJournals;
            Properties.Settings.Default.Save();
            this.Close();
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Methods

        private async Task LoadView()
        {
            listViewJournalFolders.Clear();
            foreach (string folder in JournalFolders)
            {
                listViewJournalFolders.Items.Add(folder);
            }
            numericUpDownMaxAgeDays.Value = JournalMaxAgeDays;
            checkBoxArchiveInactiveJournals.Checked = ArchiveInactiveJournals;
        }

        #endregion

    }
}
