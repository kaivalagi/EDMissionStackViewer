namespace EDMissionStackViewer.Controls
{
    partial class UIMissionMining
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
            dgMissionMining = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgMissionMining).BeginInit();
            SuspendLayout();
            // 
            // dgMissionMining
            // 
            dgMissionMining.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgMissionMining.Dock = DockStyle.Fill;
            dgMissionMining.Location = new Point(0, 0);
            dgMissionMining.Name = "dgMissionMining";
            dgMissionMining.RowHeadersWidth = 62;
            dgMissionMining.Size = new Size(916, 583);
            dgMissionMining.TabIndex = 0;
            // 
            // EDMissionMiningUI
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgMissionMining);
            Name = "EDMissionMiningUI";
            Size = new Size(916, 583);
            ((System.ComponentModel.ISupportInitialize)dgMissionMining).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgMissionMining;
    }
}
