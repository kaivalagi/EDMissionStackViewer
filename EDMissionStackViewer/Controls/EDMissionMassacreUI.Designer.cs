namespace EDMissionStackViewer.Controls
{
    partial class EDMissionMassacreUI
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
            dgMissionMassacre = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgMissionMassacre).BeginInit();
            SuspendLayout();
            // 
            // dgMissionMining
            // 
            dgMissionMassacre.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgMissionMassacre.Dock = DockStyle.Fill;
            dgMissionMassacre.Location = new Point(0, 0);
            dgMissionMassacre.Name = "dgMissionMassacre";
            dgMissionMassacre.RowHeadersWidth = 62;
            dgMissionMassacre.Size = new Size(916, 583);
            dgMissionMassacre.TabIndex = 0;
            // 
            // EDMissionMiningUI
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgMissionMassacre);
            Name = "EDMissionMiningUI";
            Size = new Size(916, 583);
            ((System.ComponentModel.ISupportInitialize)dgMissionMassacre).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgMissionMassacre;
    }
}
