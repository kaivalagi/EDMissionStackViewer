namespace EDMissionStackViewer.Controls
{
    partial class EDMissionCollectUI
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
            dgMissionCollect = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgMissionCollect).BeginInit();
            SuspendLayout();
            // 
            // dgMissionMining
            // 
            dgMissionCollect.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgMissionCollect.Dock = DockStyle.Fill;
            dgMissionCollect.Location = new Point(0, 0);
            dgMissionCollect.Name = "dgMissionMassacre";
            dgMissionCollect.RowHeadersWidth = 62;
            dgMissionCollect.Size = new Size(916, 583);
            dgMissionCollect.TabIndex = 0;
            // 
            // EDMissionMiningUI
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgMissionCollect);
            Name = "EDMissionMiningUI";
            Size = new Size(916, 583);
            ((System.ComponentModel.ISupportInitialize)dgMissionCollect).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgMissionCollect;
    }
}
