namespace EDMissionStackViewer.Controls
{
    partial class EDMissionCourierUI
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
            dgMissionCourier = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgMissionCourier).BeginInit();
            SuspendLayout();
            // 
            // dgMissionMining
            // 
            dgMissionCourier.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgMissionCourier.Dock = DockStyle.Fill;
            dgMissionCourier.Location = new Point(0, 0);
            dgMissionCourier.Name = "dgMissionMassacre";
            dgMissionCourier.RowHeadersWidth = 62;
            dgMissionCourier.Size = new Size(916, 583);
            dgMissionCourier.TabIndex = 0;
            // 
            // EDMissionMiningUI
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgMissionCourier);
            Name = "EDMissionMiningUI";
            Size = new Size(916, 583);
            ((System.ComponentModel.ISupportInitialize)dgMissionCourier).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgMissionCourier;
    }
}
