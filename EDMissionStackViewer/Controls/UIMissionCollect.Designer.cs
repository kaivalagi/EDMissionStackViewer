namespace EDMissionStackViewer.Controls
{
    partial class UIMissionCollect
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgMissions = new DataGridView();
            dgSummary = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgMissions).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgSummary).BeginInit();
            SuspendLayout();
            // 
            // dgMissions
            // 
            dgMissions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgMissions.Dock = DockStyle.Top;
            dgMissions.Location = new Point(0, 0);
            dgMissions.Name = "dgMissions";
            dgMissions.RowHeadersWidth = 62;
            dgMissions.Size = new Size(916, 307);
            dgMissions.TabIndex = 0;
            // 
            // dgSummary
            // 
            dgSummary.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgSummary.Dock = DockStyle.Bottom;
            dgSummary.Location = new Point(0, 313);
            dgSummary.Name = "dgSummary";
            dgSummary.RowHeadersWidth = 62;
            dgSummary.Size = new Size(916, 270);
            dgSummary.TabIndex = 1;
            // 
            // UIMissionCollect
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgSummary);
            Controls.Add(dgMissions);
            Name = "UIMissionCollect";
            Size = new Size(916, 583);
            ((System.ComponentModel.ISupportInitialize)dgMissions).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgSummary).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgMissions;
        private DataGridView dgSummary;
    }
}
