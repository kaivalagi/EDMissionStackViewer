namespace EDMissionStackViewer.Forms
{
    public partial class EditJournalFolders : Form
    {

        #region Class Data

        public List<string> JournalFolders { get; set; }

        #endregion

        #region Constructor

        public EditJournalFolders()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FormJournalFolders_Load(object sender, EventArgs e)
        {
            JournalFolders = Properties.Settings.Default.JournalFolders.Split(",").ToList();
            LoadView();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.JournalFolders = string.Join(",", JournalFolders);
            Properties.Settings.Default.Save();
            this.DialogResult = DialogResult.OK;
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

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewJournalFolders.SelectedItems)
            {
                JournalFolders.Remove(item.Text);
            }
            LoadView();
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
        }

        #endregion

    }
}
