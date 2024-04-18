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
            tabPagekaivalagi = new TabPage();
            splitContainerkaivalagi = new SplitContainer();
            listBoxMissionskaivalagi = new ListBox();
            listViewkaivalagi = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            refreshTimer = new System.Windows.Forms.Timer(components);
            commanderTabs.SuspendLayout();
            tabPagekaivalagi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerkaivalagi).BeginInit();
            splitContainerkaivalagi.Panel1.SuspendLayout();
            splitContainerkaivalagi.Panel2.SuspendLayout();
            splitContainerkaivalagi.SuspendLayout();
            SuspendLayout();
            // 
            // commanderTabs
            // 
            commanderTabs.Controls.Add(tabPagekaivalagi);
            commanderTabs.Dock = DockStyle.Fill;
            commanderTabs.Location = new Point(0, 0);
            commanderTabs.Name = "commanderTabs";
            commanderTabs.SelectedIndex = 0;
            commanderTabs.Size = new Size(2580, 909);
            commanderTabs.TabIndex = 3;
            // 
            // tabPagekaivalagi
            // 
            tabPagekaivalagi.Controls.Add(splitContainerkaivalagi);
            tabPagekaivalagi.Location = new Point(4, 34);
            tabPagekaivalagi.Name = "tabPagekaivalagi";
            tabPagekaivalagi.Size = new Size(2572, 871);
            tabPagekaivalagi.TabIndex = 0;
            tabPagekaivalagi.Text = "tabPagekaivalagi";
            tabPagekaivalagi.UseVisualStyleBackColor = true;
            // 
            // splitContainerkaivalagi
            // 
            splitContainerkaivalagi.Dock = DockStyle.Fill;
            splitContainerkaivalagi.Location = new Point(0, 0);
            splitContainerkaivalagi.Name = "splitContainerkaivalagi";
            // 
            // splitContainerkaivalagi.Panel1
            // 
            splitContainerkaivalagi.Panel1.Controls.Add(listBoxMissionskaivalagi);
            // 
            // splitContainerkaivalagi.Panel2
            // 
            splitContainerkaivalagi.Panel2.Controls.Add(listViewkaivalagi);
            splitContainerkaivalagi.Size = new Size(2572, 871);
            splitContainerkaivalagi.SplitterDistance = 390;
            splitContainerkaivalagi.TabIndex = 0;
            // 
            // listBoxMissionskaivalagi
            // 
            listBoxMissionskaivalagi.Dock = DockStyle.Fill;
            listBoxMissionskaivalagi.FormattingEnabled = true;
            listBoxMissionskaivalagi.HorizontalScrollbar = true;
            listBoxMissionskaivalagi.ItemHeight = 25;
            listBoxMissionskaivalagi.Location = new Point(0, 0);
            listBoxMissionskaivalagi.Name = "listBoxMissionskaivalagi";
            listBoxMissionskaivalagi.Size = new Size(390, 871);
            listBoxMissionskaivalagi.TabIndex = 0;
            // 
            // listViewkaivalagi
            // 
            listViewkaivalagi.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
            listViewkaivalagi.Dock = DockStyle.Fill;
            listViewkaivalagi.Location = new Point(0, 0);
            listViewkaivalagi.Name = "listViewkaivalagi";
            listViewkaivalagi.Size = new Size(2178, 871);
            listViewkaivalagi.TabIndex = 1;
            listViewkaivalagi.UseCompatibleStateImageBehavior = false;
            listViewkaivalagi.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "MissionId";
            columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Event";
            columnHeader2.Width = 1000;
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
            ClientSize = new Size(2580, 909);
            Controls.Add(commanderTabs);
            Name = "EDMissionStackViewer";
            Text = "ED Mission Stack Viewer";
            Load += MissionStackViewer_Load;
            commanderTabs.ResumeLayout(false);
            tabPagekaivalagi.ResumeLayout(false);
            splitContainerkaivalagi.Panel1.ResumeLayout(false);
            splitContainerkaivalagi.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerkaivalagi).EndInit();
            splitContainerkaivalagi.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl commanderTabs;
        private System.Windows.Forms.Timer refreshTimer;
        private TabPage tabPagekaivalagi;
        private SplitContainer splitContainerkaivalagi;
        private ListBox listBoxMissionskaivalagi;
        private ListView listViewkaivalagi;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
    }
}
