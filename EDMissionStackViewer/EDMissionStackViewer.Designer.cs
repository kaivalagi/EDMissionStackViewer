namespace EDMissionStackViewer
{
    partial class EDMissionStackViewer
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
            commanderTabs = new TabControl();
            refreshTimer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // commanderTabs
            // 
            commanderTabs.Dock = DockStyle.Fill;
            commanderTabs.Location = new Point(0, 0);
            commanderTabs.Name = "commanderTabs";
            commanderTabs.SelectedIndex = 0;
            commanderTabs.Size = new Size(800, 450);
            commanderTabs.TabIndex = 3;
            // 
            // refreshTimer
            // 
            refreshTimer.Enabled = true;
            refreshTimer.Interval = 1000;
            refreshTimer.Tick += refreshTimer_Tick;
            // 
            // EDMissionStackViewer
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(commanderTabs);
            Name = "EDMissionStackViewer";
            Text = "ED Mission Stack Viewer";
            Load += MissionStackViewer_Load;
            ResumeLayout(false);
        }

        #endregion

        private TabControl commanderTabs;
        private System.Windows.Forms.Timer refreshTimer;
    }
}
