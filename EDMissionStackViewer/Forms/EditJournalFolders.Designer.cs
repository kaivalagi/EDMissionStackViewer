namespace EDMissionStackViewer.Forms
{
    partial class EditJournalFolders
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditJournalFolders));
            layoutJournalFolders = new TableLayoutPanel();
            listViewJournalFolders = new ListView();
            panelActions = new Panel();
            buttonOK = new Button();
            buttonCancel = new Button();
            buttonRemove = new Button();
            buttonAdd = new Button();
            dialogFolder = new FolderBrowserDialog();
            layoutJournalFolders.SuspendLayout();
            panelActions.SuspendLayout();
            SuspendLayout();
            // 
            // layoutJournalFolders
            // 
            layoutJournalFolders.ColumnCount = 1;
            layoutJournalFolders.ColumnStyles.Add(new ColumnStyle());
            layoutJournalFolders.Controls.Add(listViewJournalFolders, 0, 0);
            layoutJournalFolders.Controls.Add(panelActions, 0, 1);
            layoutJournalFolders.Dock = DockStyle.Fill;
            layoutJournalFolders.Location = new Point(0, 0);
            layoutJournalFolders.Name = "layoutJournalFolders";
            layoutJournalFolders.RowCount = 2;
            layoutJournalFolders.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutJournalFolders.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            layoutJournalFolders.Size = new Size(800, 254);
            layoutJournalFolders.TabIndex = 3;
            // 
            // listViewJournalFolders
            // 
            listViewJournalFolders.Dock = DockStyle.Fill;
            listViewJournalFolders.Location = new Point(3, 3);
            listViewJournalFolders.Name = "listViewJournalFolders";
            listViewJournalFolders.Size = new Size(794, 188);
            listViewJournalFolders.TabIndex = 0;
            listViewJournalFolders.UseCompatibleStateImageBehavior = false;
            listViewJournalFolders.View = View.List;
            listViewJournalFolders.SelectedIndexChanged += listViewJournalFolders_SelectedIndexChanged;
            // 
            // panelActions
            // 
            panelActions.Controls.Add(buttonOK);
            panelActions.Controls.Add(buttonCancel);
            panelActions.Controls.Add(buttonRemove);
            panelActions.Controls.Add(buttonAdd);
            panelActions.Dock = DockStyle.Fill;
            panelActions.Location = new Point(3, 197);
            panelActions.Name = "panelActions";
            panelActions.Size = new Size(794, 54);
            panelActions.TabIndex = 1;
            // 
            // buttonOK
            // 
            buttonOK.Location = new Point(673, 11);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(112, 34);
            buttonOK.TabIndex = 3;
            buttonOK.Text = "&OK";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += buttonOK_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(555, 11);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(112, 34);
            buttonCancel.TabIndex = 2;
            buttonCancel.Text = "&Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonClose_Click;
            // 
            // buttonRemove
            // 
            buttonRemove.Enabled = false;
            buttonRemove.Location = new Point(127, 11);
            buttonRemove.Name = "buttonRemove";
            buttonRemove.Size = new Size(112, 34);
            buttonRemove.TabIndex = 1;
            buttonRemove.Text = "&Remove";
            buttonRemove.UseVisualStyleBackColor = true;
            buttonRemove.Click += buttonRemove_Click;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(9, 11);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(112, 34);
            buttonAdd.TabIndex = 0;
            buttonAdd.Text = "&Add";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // dialogFolder
            // 
            dialogFolder.RootFolder = Environment.SpecialFolder.UserProfile;
            // 
            // EditJournalFolders
            // 
            AcceptButton = buttonOK;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(800, 254);
            ControlBox = false;
            Controls.Add(layoutJournalFolders);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "EditJournalFolders";
            Text = "Journal Folders";
            Load += FormJournalFolders_Load;
            layoutJournalFolders.ResumeLayout(false);
            panelActions.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TableLayoutPanel layoutJournalFolders;
        private ListView listViewJournalFolders;
        private Panel panelActions;
        private Button buttonCancel;
        private Button buttonRemove;
        private Button buttonAdd;
        private Button buttonOK;
        private FolderBrowserDialog dialogFolder;
    }
}