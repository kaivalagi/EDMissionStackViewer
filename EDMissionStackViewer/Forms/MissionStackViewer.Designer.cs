using EDMissionStackViewer.UserControls;

namespace EDMissionStackViewer
{
    partial class MissionStackViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MissionStackViewer));
            tabControlCommanders = new TabControl();
            tabPageCommander = new TabPage();
            ucMissionsCommander = new UCMissions();
            refreshTimer = new System.Windows.Forms.Timer(components);
            lblNoCommander = new Label();
            menuStrip = new MenuStrip();
            menuSettings = new ToolStripMenuItem();
            menuSettingsJournalFolder = new ToolStripMenuItem();
            dlgJournalFolder = new FolderBrowserDialog();
            tabControlCommanders.SuspendLayout();
            tabPageCommander.SuspendLayout();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // tabControlCommanders
            // 
            tabControlCommanders.Controls.Add(tabPageCommander);
            tabControlCommanders.Dock = DockStyle.Fill;
            tabControlCommanders.Location = new Point(0, 30);
            tabControlCommanders.Margin = new Padding(2);
            tabControlCommanders.Name = "tabControlCommanders";
            tabControlCommanders.SelectedIndex = 0;
            tabControlCommanders.Size = new Size(1023, 313);
            tabControlCommanders.TabIndex = 3;
            tabControlCommanders.Visible = false;
            // 
            // tabPageCommander
            // 
            tabPageCommander.Controls.Add(ucMissionsCommander);
            tabPageCommander.Location = new Point(4, 24);
            tabPageCommander.Margin = new Padding(2);
            tabPageCommander.Name = "tabPageCommander";
            tabPageCommander.Padding = new Padding(2);
            tabPageCommander.Size = new Size(1015, 285);
            tabPageCommander.TabIndex = 0;
            tabPageCommander.Text = "Commander";
            tabPageCommander.UseVisualStyleBackColor = true;
            // 
            // ucMissionsCommander
            // 
            ucMissionsCommander.Dock = DockStyle.Fill;
            ucMissionsCommander.Location = new Point(2, 2);
            ucMissionsCommander.Margin = new Padding(1);
            ucMissionsCommander.Name = "ucMissionsCommander";
            ucMissionsCommander.Size = new Size(1011, 281);
            ucMissionsCommander.TabIndex = 0;
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
            lblNoCommander.Location = new Point(22, 29);
            lblNoCommander.Margin = new Padding(2, 0, 2, 0);
            lblNoCommander.Name = "lblNoCommander";
            lblNoCommander.Size = new Size(390, 25);
            lblNoCommander.TabIndex = 4;
            lblNoCommander.Text = "No commander(s) with active missions found";
            lblNoCommander.Visible = false;
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(24, 24);
            menuStrip.Items.AddRange(new ToolStripItem[] { menuSettings });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(4, 1, 0, 1);
            menuStrip.RightToLeft = RightToLeft.Yes;
            menuStrip.Size = new Size(1023, 30);
            menuStrip.TabIndex = 5;
            menuStrip.Text = "menuStrip";
            // 
            // menuSettings
            // 
            menuSettings.DropDownItems.AddRange(new ToolStripItem[] { menuSettingsJournalFolder });
            menuSettings.Image = Properties.Resources.settings;
            menuSettings.Name = "menuSettings";
            menuSettings.Size = new Size(36, 28);
            menuSettings.Click += menuSettings_Click;
            // 
            // menuSettingsJournalFolder
            // 
            menuSettingsJournalFolder.Name = "menuSettingsJournalFolder";
            menuSettingsJournalFolder.Size = new Size(67, 22);
            // 
            // dlgJournalFolder
            // 
            dlgJournalFolder.RootFolder = Environment.SpecialFolder.UserProfile;
            // 
            // MissionStackViewer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1023, 343);
            Controls.Add(tabControlCommanders);
            Controls.Add(lblNoCommander);
            Controls.Add(menuStrip);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            Name = "MissionStackViewer";
            Text = "ED Mission Stack Viewer";
            Load += MissionStackViewer_Load;
            tabControlCommanders.ResumeLayout(false);
            tabPageCommander.ResumeLayout(false);
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabControlCommanders;
        private System.Windows.Forms.Timer refreshTimer;
        private Label lblNoCommander;
        private TabPage tabPageCommander;
        private MenuStrip menuStrip;
        private ToolStripMenuItem menuSettings;
        private ToolStripMenuItem menuSettingsJournalFolder;
        private FolderBrowserDialog dlgJournalFolder;
        private UCMissions ucMissionsCommander;
    }
}
