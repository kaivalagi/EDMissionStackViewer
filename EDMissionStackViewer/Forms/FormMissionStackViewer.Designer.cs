using EDMissionStackViewer.UserControls;

namespace EDMissionStackViewer
{
    partial class FormMissionStackViewer
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMissionStackViewer));
            tabControlCommanders = new TabControl();
            tabPageCommander = new TabPage();
            refreshTimer = new System.Windows.Forms.Timer(components);
            lblNoCommander = new Label();
            menuStrip1 = new MenuStrip();
            menuSettings = new ToolStripMenuItem();
            menuSettingsJournalFolder = new ToolStripMenuItem();
            dlgJournalFolder = new FolderBrowserDialog();
            ucMissionsCommander = new UCMissions();
            tabControlCommanders.SuspendLayout();
            tabPageCommander.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControlCommanders
            // 
            tabControlCommanders.Appearance = TabAppearance.FlatButtons;
            tabControlCommanders.Controls.Add(tabPageCommander);
            tabControlCommanders.Dock = DockStyle.Fill;
            tabControlCommanders.Location = new Point(0, 33);
            tabControlCommanders.Name = "tabControlCommanders";
            tabControlCommanders.SelectedIndex = 0;
            tabControlCommanders.Size = new Size(1453, 726);
            tabControlCommanders.TabIndex = 3;
            tabControlCommanders.Visible = false;
            // 
            // tabPageCommander
            // 
            tabPageCommander.Controls.Add(ucMissionsCommander);
            tabPageCommander.Location = new Point(4, 37);
            tabPageCommander.Name = "tabPageCommander";
            tabPageCommander.Padding = new Padding(3);
            tabPageCommander.Size = new Size(1445, 685);
            tabPageCommander.TabIndex = 0;
            tabPageCommander.Text = "Commander";
            tabPageCommander.UseVisualStyleBackColor = true;
            // 
            // refreshTimer
            // 
            refreshTimer.Enabled = true;
            refreshTimer.Interval = 1000;
            refreshTimer.Tick += refreshTimer_Tick;
            // 
            // lblNoCommander
            // 
            lblNoCommander.AutoSize = true;
            lblNoCommander.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNoCommander.Location = new Point(31, 48);
            lblNoCommander.Name = "lblNoCommander";
            lblNoCommander.Size = new Size(572, 38);
            lblNoCommander.TabIndex = 4;
            lblNoCommander.Text = "No commander(s) with active missions found";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuSettings });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1453, 33);
            menuStrip1.TabIndex = 5;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuSettings
            // 
            menuSettings.DropDownItems.AddRange(new ToolStripItem[] { menuSettingsJournalFolder });
            menuSettings.Name = "menuSettings";
            menuSettings.Size = new Size(92, 29);
            menuSettings.Text = "Settings";
            // 
            // menuSettingsJournalFolder
            // 
            menuSettingsJournalFolder.Name = "menuSettingsJournalFolder";
            menuSettingsJournalFolder.Size = new Size(233, 34);
            menuSettingsJournalFolder.Text = "Journal Folders";
            menuSettingsJournalFolder.Click += menuSettingsJournalFolder_Click;
            // 
            // dlgJournalFolder
            // 
            dlgJournalFolder.RootFolder = Environment.SpecialFolder.UserProfile;
            // 
            // ucMissionsCommander
            // 
            ucMissionsCommander.Dock = DockStyle.Fill;
            ucMissionsCommander.Location = new Point(3, 3);
            ucMissionsCommander.Name = "ucMissionsCommander";
            ucMissionsCommander.Size = new Size(1439, 679);
            ucMissionsCommander.TabIndex = 0;
            // 
            // FormMissionStackViewer
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1453, 759);
            Controls.Add(tabControlCommanders);
            Controls.Add(lblNoCommander);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormMissionStackViewer";
            Text = "ED Mission Stack Viewer";
            Load += MissionStackViewer_Load;
            tabControlCommanders.ResumeLayout(false);
            tabPageCommander.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabControlCommanders;
        private System.Windows.Forms.Timer refreshTimer;
        private Label lblNoCommander;
        private TabPage tabPageCommander;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuSettings;
        private ToolStripMenuItem menuSettingsJournalFolder;
        private FolderBrowserDialog dlgJournalFolder;
        private UCMissions ucMissionsCommander;
    }
}
