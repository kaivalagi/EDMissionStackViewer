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
            groupBox1 = new GroupBox();
            buttonAdd = new Button();
            buttonRemove = new Button();
            listViewJournalFolders = new ListView();
            groupBox2 = new GroupBox();
            checkBoxArchiveInactiveJournals = new CheckBox();
            numericUpDownMaxAgeDays = new NumericUpDown();
            labelMaxAgeDays = new Label();
            buttonCancel = new Button();
            buttonOK = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMaxAgeDays).BeginInit();
            SuspendLayout();
            // 
            // dialogFolder
            // 
            dialogFolder.RootFolder = Environment.SpecialFolder.UserProfile;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(buttonAdd);
            groupBox1.Controls.Add(buttonRemove);
            groupBox1.Controls.Add(listViewJournalFolders);
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(808, 261);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Journal Folders";
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(676, 215);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(112, 34);
            buttonAdd.TabIndex = 0;
            buttonAdd.Text = "&Add";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonRemove
            // 
            buttonRemove.Enabled = false;
            buttonRemove.Location = new Point(558, 215);
            buttonRemove.Name = "buttonRemove";
            buttonRemove.Size = new Size(112, 34);
            buttonRemove.TabIndex = 1;
            buttonRemove.Text = "&Remove";
            buttonRemove.UseVisualStyleBackColor = true;
            buttonRemove.Click += buttonRemove_Click;
            // 
            // listViewJournalFolders
            // 
            listViewJournalFolders.Location = new Point(25, 30);
            listViewJournalFolders.Name = "listViewJournalFolders";
            listViewJournalFolders.Size = new Size(763, 179);
            listViewJournalFolders.TabIndex = 1;
            listViewJournalFolders.UseCompatibleStateImageBehavior = false;
            listViewJournalFolders.View = View.List;
            listViewJournalFolders.SelectedIndexChanged += listViewJournalFolders_SelectedIndexChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(checkBoxArchiveInactiveJournals);
            groupBox2.Controls.Add(numericUpDownMaxAgeDays);
            groupBox2.Controls.Add(labelMaxAgeDays);
            groupBox2.Location = new Point(3, 270);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(808, 98);
            groupBox2.TabIndex = 10;
            groupBox2.TabStop = false;
            groupBox2.Text = "Journal Files";
            // 
            // checkBoxArchiveInactiveJournals
            // 
            checkBoxArchiveInactiveJournals.AutoSize = true;
            checkBoxArchiveInactiveJournals.Location = new Point(379, 45);
            checkBoxArchiveInactiveJournals.Name = "checkBoxArchiveInactiveJournals";
            checkBoxArchiveInactiveJournals.Size = new Size(230, 29);
            checkBoxArchiveInactiveJournals.TabIndex = 2;
            checkBoxArchiveInactiveJournals.Text = "Archive Inactive Journals";
            checkBoxArchiveInactiveJournals.UseVisualStyleBackColor = true;
            checkBoxArchiveInactiveJournals.CheckedChanged += checkBoxArchiveInactiveJournals_CheckedChanged;
            // 
            // numericUpDownMaxAgeDays
            // 
            numericUpDownMaxAgeDays.Location = new Point(175, 45);
            numericUpDownMaxAgeDays.Name = "numericUpDownMaxAgeDays";
            numericUpDownMaxAgeDays.Size = new Size(180, 31);
            numericUpDownMaxAgeDays.TabIndex = 4;
            numericUpDownMaxAgeDays.ValueChanged += numericUpDownMaxAgeDays_ValueChanged;
            // 
            // labelMaxAgeDays
            // 
            labelMaxAgeDays.AutoSize = true;
            labelMaxAgeDays.Location = new Point(22, 47);
            labelMaxAgeDays.Name = "labelMaxAgeDays";
            labelMaxAgeDays.Size = new Size(136, 25);
            labelMaxAgeDays.TabIndex = 3;
            labelMaxAgeDays.Text = "Max Age (Days)";
            // 
            // buttonCancel
            // 
            buttonCancel.DialogResult = DialogResult.Cancel;
            buttonCancel.Location = new Point(582, 383);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(112, 34);
            buttonCancel.TabIndex = 11;
            buttonCancel.Text = "&Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonOK
            // 
            buttonOK.DialogResult = DialogResult.OK;
            buttonOK.Location = new Point(700, 383);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(112, 34);
            buttonOK.TabIndex = 12;
            buttonOK.Text = "&OK";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += buttonOK_Click;
            // 
            // SettingsDialog
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(826, 427);
            ControlBox = false;
            Controls.Add(buttonCancel);
            Controls.Add(buttonOK);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SettingsDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Settings";
            Load += FormJournalFolders_Load;
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMaxAgeDays).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private FolderBrowserDialog dialogFolder;
        private GroupBox groupBox1;
        private Button buttonAdd;
        private Button buttonRemove;
        private ListView listViewJournalFolders;
        private GroupBox groupBox2;
        private CheckBox checkBoxArchiveInactiveJournals;
        private NumericUpDown numericUpDownMaxAgeDays;
        private Label labelMaxAgeDays;
        private Button buttonCancel;
        private Button buttonOK;
    }
}