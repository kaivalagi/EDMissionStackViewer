using EDMissionStackViewer.Models;

namespace EDMissionStackViewer.UserControls
{
    partial class UCMissions
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
            tabControlMissions = new TabControl();
            tabPageMissionCollect = new TabPage();
            uiMissionCollect = new UCMissionCollect();
            tabPageMissionCourier = new TabPage();
            uiMissionCourier = new UCMissionCourier();
            tabPageMissionMassacre = new TabPage();
            uiMissionMassacre = new UCMissionMassacre();
            tabPageMissionMining = new TabPage();
            uiMissionMining = new UCMissionMining();
            tabControlMissions.SuspendLayout();
            tabPageMissionCollect.SuspendLayout();
            tabPageMissionCourier.SuspendLayout();
            tabPageMissionMassacre.SuspendLayout();
            tabPageMissionMining.SuspendLayout();
            SuspendLayout();
            // 
            // tabControlMissions
            // 
            tabControlMissions.Controls.Add(tabPageMissionCollect);
            tabControlMissions.Controls.Add(tabPageMissionCourier);
            tabControlMissions.Controls.Add(tabPageMissionMassacre);
            tabControlMissions.Controls.Add(tabPageMissionMining);
            tabControlMissions.Dock = DockStyle.Fill;
            tabControlMissions.Location = new Point(0, 0);
            tabControlMissions.Name = "tabControlMissions";
            tabControlMissions.SelectedIndex = 0;
            tabControlMissions.Size = new Size(1439, 715);
            tabControlMissions.TabIndex = 0;
            // 
            // tabPageMissionCollect
            // 
            tabPageMissionCollect.Controls.Add(uiMissionCollect);
            tabPageMissionCollect.Location = new Point(4, 34);
            tabPageMissionCollect.Name = "tabPageMissionCollect";
            tabPageMissionCollect.Padding = new Padding(3);
            tabPageMissionCollect.Size = new Size(1431, 677);
            tabPageMissionCollect.TabIndex = 0;
            tabPageMissionCollect.Text = "Collect";
            tabPageMissionCollect.UseVisualStyleBackColor = true;
            // 
            // uiMissionCollect
            // 
            uiMissionCollect.Dock = DockStyle.Fill;
            uiMissionCollect.Location = new Point(0, 0);
            uiMissionCollect.Name = "uiMissionCollect";
            uiMissionCollect.Size = new Size(1431, 677);
            uiMissionCollect.TabIndex = 0;
            // 
            // tabPageMissionCourier
            // 
            tabPageMissionCourier.Controls.Add(uiMissionCourier);
            tabPageMissionCourier.Location = new Point(4, 34);
            tabPageMissionCourier.Name = "tabPageMissionCourier";
            tabPageMissionCourier.Padding = new Padding(3);
            tabPageMissionCourier.Size = new Size(1431, 677);
            tabPageMissionCourier.TabIndex = 1;
            tabPageMissionCourier.Text = "Courier";
            tabPageMissionCourier.UseVisualStyleBackColor = true;
            // 
            // uiMissionCourier
            // 
            uiMissionCourier.Dock = DockStyle.Fill;
            uiMissionCourier.Location = new Point(0, 0);
            uiMissionCourier.Name = "uiMissionCourier";
            uiMissionCourier.Size = new Size(1431, 677);
            uiMissionCourier.TabIndex = 0;
            // 
            // tabPageMissionMassacre
            // 
            tabPageMissionMassacre.Controls.Add(uiMissionMassacre);
            tabPageMissionMassacre.Location = new Point(4, 34);
            tabPageMissionMassacre.Name = "tabPageMissionMassacre";
            tabPageMissionMassacre.Size = new Size(1431, 677);
            tabPageMissionMassacre.TabIndex = 2;
            tabPageMissionMassacre.Text = "Massacre";
            tabPageMissionMassacre.UseVisualStyleBackColor = true;
            // 
            // uiMissionMassacre
            // 
            uiMissionMassacre.Dock = DockStyle.Fill;
            uiMissionMassacre.Location = new Point(0, 0);
            uiMissionMassacre.Name = "uiMissionMassacre";
            uiMissionMassacre.Size = new Size(1431, 677);
            uiMissionMassacre.TabIndex = 0;
            // 
            // tabPageMissionMining
            // 
            tabPageMissionMining.Controls.Add(uiMissionMining);
            tabPageMissionMining.Location = new Point(4, 34);
            tabPageMissionMining.Name = "tabPageMissionMining";
            tabPageMissionMining.Size = new Size(1431, 677);
            tabPageMissionMining.TabIndex = 3;
            tabPageMissionMining.Text = "Mining";
            tabPageMissionMining.UseVisualStyleBackColor = true;
            // 
            // uiMissionMining
            // 
            uiMissionMining.Dock = DockStyle.Fill;
            uiMissionMining.Location = new Point(0, 0);
            uiMissionMining.Name = "uiMissionMining";
            uiMissionMining.Size = new Size(1431, 677);
            uiMissionMining.TabIndex = 0;
            // 
            // UIMissions
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabControlMissions);
            Name = "UIMissions";
            Size = new Size(1439, 715);
            tabControlMissions.ResumeLayout(false);
            tabPageMissionCollect.ResumeLayout(false);
            tabPageMissionCourier.ResumeLayout(false);
            tabPageMissionMassacre.ResumeLayout(false);
            tabPageMissionMining.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControlMissions;
        private TabPage tabPageMissionCollect;
        private UCMissionCollect uiMissionCollect;
        private TabPage tabPageMissionCourier;
        private UCMissionCourier uiMissionCourier;
        private TabPage tabPageMissionMassacre;
        private UCMissionMassacre uiMissionMassacre;
        private TabPage tabPageMissionMining;
        private UCMissionMining uiMissionMining;
    }
}
