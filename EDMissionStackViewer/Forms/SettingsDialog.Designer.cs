namespace EDMissionStackViewer.Forms
{
    partial class SettingsDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsDialog));
            dialogFolder = new FolderBrowserDialog();
            groupBoxJournalFolders = new GroupBox();
            buttonAdd = new Button();
            buttonRemove = new Button();
            listViewJournalFolders = new ListView();
            groupBoxJournalFiles = new GroupBox();
            checkBoxArchiveInactiveJournals = new CheckBox();
            numericUpDownMaxAgeDays = new NumericUpDown();
            labelMaxAgeDays = new Label();
            buttonCancel = new Button();
            buttonOK = new Button();
            layoutSettings = new TableLayoutPanel();
            panelActions = new Panel();
            groupBoxJournalFolders.SuspendLayout();
            groupBoxJournalFiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMaxAgeDays).BeginInit();
            layoutSettings.SuspendLayout();
            panelActions.SuspendLayout();
            SuspendLayout();
            // 
            // dialogFolder
            // 
            dialogFolder.RootFolder = Environment.SpecialFolder.UserProfile;
            // 
            // groupBoxJournalFolders
            // 
            groupBoxJournalFolders.Controls.Add(buttonAdd);
            groupBoxJournalFolders.Controls.Add(buttonRemove);
            groupBoxJournalFolders.Controls.Add(listViewJournalFolders);
            groupBoxJournalFolders.Location = new Point(3, 3);
            groupBoxJournalFolders.Name = "groupBoxJournalFolders";
            groupBoxJournalFolders.Size = new Size(799, 177);
            groupBoxJournalFolders.TabIndex = 9;
            groupBoxJournalFolders.TabStop = false;
            groupBoxJournalFolders.Text = "Journal Folders";
            // 
            // buttonAdd
            // 
            buttonAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonAdd.Location = new Point(25, 137);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(112, 34);
            buttonAdd.TabIndex = 0;
            buttonAdd.Text = "&Add";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonRemove
            // 
            buttonRemove.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonRemove.Enabled = false;
            buttonRemove.Location = new Point(143, 138);
            buttonRemove.Name = "buttonRemove";
            buttonRemove.Size = new Size(112, 34);
            buttonRemove.TabIndex = 1;
            buttonRemove.Text = "&Remove";
            buttonRemove.UseVisualStyleBackColor = true;
            buttonRemove.Click += buttonRemove_Click;
            // 
            // listViewJournalFolders
            // 
            listViewJournalFolders.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            listViewJournalFolders.Location = new Point(25, 30);
            listViewJournalFolders.Name = "listViewJournalFolders";
            listViewJournalFolders.Size = new Size(763, 102);
            listViewJournalFolders.TabIndex = 1;
            listViewJournalFolders.UseCompatibleStateImageBehavior = false;
            listViewJournalFolders.View = View.List;
            listViewJournalFolders.SelectedIndexChanged += listViewJournalFolders_SelectedIndexChanged;
            // 
            // groupBoxJournalFiles
            // 
            groupBoxJournalFiles.Controls.Add(checkBoxArchiveInactiveJournals);
            groupBoxJournalFiles.Controls.Add(numericUpDownMaxAgeDays);
            groupBoxJournalFiles.Controls.Add(labelMaxAgeDays);
            groupBoxJournalFiles.Location = new Point(3, 187);
            groupBoxJournalFiles.Name = "groupBoxJournalFiles";
            groupBoxJournalFiles.Size = new Size(799, 94);
            groupBoxJournalFiles.TabIndex = 10;
            groupBoxJournalFiles.TabStop = false;
            groupBoxJournalFiles.Text = "Journal Files";
            // 
            // checkBoxArchiveInactiveJournals
            // 
            checkBoxArchiveInactiveJournals.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            checkBoxArchiveInactiveJournals.AutoSize = true;
            checkBoxArchiveInactiveJournals.CheckAlign = ContentAlignment.MiddleRight;
            checkBoxArchiveInactiveJournals.Location = new Point(532, 43);
            checkBoxArchiveInactiveJournals.Name = "checkBoxArchiveInactiveJournals";
            checkBoxArchiveInactiveJournals.Size = new Size(230, 29);
            checkBoxArchiveInactiveJournals.TabIndex = 2;
            checkBoxArchiveInactiveJournals.Text = "Archive Inactive Journals";
            checkBoxArchiveInactiveJournals.UseVisualStyleBackColor = true;
            checkBoxArchiveInactiveJournals.CheckedChanged += checkBoxArchiveInactiveJournals_CheckedChanged;
            // 
            // numericUpDownMaxAgeDays
            // 
            numericUpDownMaxAgeDays.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            numericUpDownMaxAgeDays.Location = new Point(164, 45);
            numericUpDownMaxAgeDays.Name = "numericUpDownMaxAgeDays";
            numericUpDownMaxAgeDays.Size = new Size(180, 31);
            numericUpDownMaxAgeDays.TabIndex = 4;
            numericUpDownMaxAgeDays.ValueChanged += numericUpDownMaxAgeDays_ValueChanged;
            // 
            // labelMaxAgeDays
            // 
            labelMaxAgeDays.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            labelMaxAgeDays.AutoSize = true;
            labelMaxAgeDays.Location = new Point(22, 47);
            labelMaxAgeDays.Name = "labelMaxAgeDays";
            labelMaxAgeDays.Size = new Size(136, 25);
            labelMaxAgeDays.TabIndex = 3;
            labelMaxAgeDays.Text = "Max Age (Days)";
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.DialogResult = DialogResult.Cancel;
            buttonCancel.Location = new Point(561, 7);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(112, 40);
            buttonCancel.TabIndex = 11;
            buttonCancel.Text = "&Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonOK
            // 
            buttonOK.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            buttonOK.DialogResult = DialogResult.OK;
            buttonOK.Location = new Point(679, 7);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(112, 40);
            buttonOK.TabIndex = 12;
            buttonOK.Text = "&OK";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += buttonOK_Click;
            // 
            // layoutSettings
            // 
            layoutSettings.ColumnCount = 1;
            layoutSettings.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutSettings.Controls.Add(panelActions, 0, 2);
            layoutSettings.Controls.Add(groupBoxJournalFolders, 0, 0);
            layoutSettings.Controls.Add(groupBoxJournalFiles, 0, 1);
            layoutSettings.Dock = DockStyle.Fill;
            layoutSettings.Location = new Point(0, 0);
            layoutSettings.Name = "layoutSettings";
            layoutSettings.RowCount = 3;
            layoutSettings.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutSettings.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            layoutSettings.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            layoutSettings.Size = new Size(805, 344);
            layoutSettings.TabIndex = 13;
            // 
            // panelActions
            // 
            panelActions.Controls.Add(buttonOK);
            panelActions.Controls.Add(buttonCancel);
            panelActions.Dock = DockStyle.Fill;
            panelActions.Location = new Point(3, 287);
            panelActions.Name = "panelActions";
            panelActions.Size = new Size(799, 54);
            panelActions.TabIndex = 0;
            // 
            // SettingsDialog
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(805, 344);
            Controls.Add(layoutSettings);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SettingsDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Settings";
            Load += FormJournalFolders_Load;
            groupBoxJournalFolders.ResumeLayout(false);
            groupBoxJournalFiles.ResumeLayout(false);
            groupBoxJournalFiles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMaxAgeDays).EndInit();
            layoutSettings.ResumeLayout(false);
            panelActions.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private FolderBrowserDialog dialogFolder;
        private GroupBox groupBoxJournalFolders;
        private Button buttonAdd;
        private Button buttonRemove;
        private ListView listViewJournalFolders;
        private GroupBox groupBoxJournalFiles;
        private CheckBox checkBoxArchiveInactiveJournals;
        private NumericUpDown numericUpDownMaxAgeDays;
        private Label labelMaxAgeDays;
        private Button buttonCancel;
        private Button buttonOK;
        private TableLayoutPanel layoutSettings;
        private Panel panelActions;
    }
}