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
            tabControlMissions.Margin = new Padding(2, 2, 2, 2);
            tabControlMissions.Name = "tabControlMissions";
            tabControlMissions.SelectedIndex = 0;
            tabControlMissions.Size = new Size(962, 402);
            tabControlMissions.TabIndex = 0;
            // 
            // tabPageMissionCollect
            // 
            tabPageMissionCollect.Controls.Add(uiMissionCollect);
            tabPageMissionCollect.Location = new Point(4, 24);
            tabPageMissionCollect.Margin = new Padding(2, 2, 2, 2);
            tabPageMissionCollect.Name = "tabPageMissionCollect";
            tabPageMissionCollect.Padding = new Padding(2, 2, 2, 2);
            tabPageMissionCollect.Size = new Size(954, 374);
            tabPageMissionCollect.TabIndex = 0;
            tabPageMissionCollect.Tag = "Collect";
            tabPageMissionCollect.Text = "Collect";
            tabPageMissionCollect.UseVisualStyleBackColor = true;
            // 
            // uiMissionCollect
            // 
            uiMissionCollect.Dock = DockStyle.Fill;
            uiMissionCollect.Location = new Point(2, 2);
            uiMissionCollect.Margin = new Padding(1, 1, 1, 1);
            uiMissionCollect.Name = "uiMissionCollect";
            uiMissionCollect.Size = new Size(950, 370);
            uiMissionCollect.TabIndex = 0;
            // 
            // tabPageMissionCourier
            // 
            tabPageMissionCourier.Controls.Add(uiMissionCourier);
            tabPageMissionCourier.Location = new Point(4, 24);
            tabPageMissionCourier.Margin = new Padding(2, 2, 2, 2);
            tabPageMissionCourier.Name = "tabPageMissionCourier";
            tabPageMissionCourier.Padding = new Padding(2, 2, 2, 2);
            tabPageMissionCourier.Size = new Size(954, 374);
            tabPageMissionCourier.TabIndex = 1;
            tabPageMissionCourier.Tag = "Courier";
            tabPageMissionCourier.Text = "Courier";
            tabPageMissionCourier.UseVisualStyleBackColor = true;
            // 
            // uiMissionCourier
            // 
            uiMissionCourier.Dock = DockStyle.Fill;
            uiMissionCourier.Location = new Point(2, 2);
            uiMissionCourier.Margin = new Padding(1, 1, 1, 1);
            uiMissionCourier.Name = "uiMissionCourier";
            uiMissionCourier.Size = new Size(950, 370);
            uiMissionCourier.TabIndex = 0;
            // 
            // tabPageMissionMassacre
            // 
            tabPageMissionMassacre.Controls.Add(uiMissionMassacre);
            tabPageMissionMassacre.Location = new Point(4, 24);
            tabPageMissionMassacre.Margin = new Padding(2, 2, 2, 2);
            tabPageMissionMassacre.Name = "tabPageMissionMassacre";
            tabPageMissionMassacre.Size = new Size(954, 374);
            tabPageMissionMassacre.TabIndex = 2;
            tabPageMissionMassacre.Tag = "Massacre";
            tabPageMissionMassacre.Text = "Massacre";
            tabPageMissionMassacre.UseVisualStyleBackColor = true;
            // 
            // uiMissionMassacre
            // 
            uiMissionMassacre.Dock = DockStyle.Fill;
            uiMissionMassacre.Location = new Point(0, 0);
            uiMissionMassacre.Margin = new Padding(1, 1, 1, 1);
            uiMissionMassacre.Name = "uiMissionMassacre";
            uiMissionMassacre.Size = new Size(954, 374);
            uiMissionMassacre.TabIndex = 0;
            // 
            // tabPageMissionMining
            // 
            tabPageMissionMining.Controls.Add(uiMissionMining);
            tabPageMissionMining.Location = new Point(4, 24);
            tabPageMissionMining.Margin = new Padding(2, 2, 2, 2);
            tabPageMissionMining.Name = "tabPageMissionMining";
            tabPageMissionMining.Size = new Size(954, 374);
            tabPageMissionMining.TabIndex = 3;
            tabPageMissionMining.Tag = "Mining";
            tabPageMissionMining.Text = "Mining";
            tabPageMissionMining.UseVisualStyleBackColor = true;
            // 
            // uiMissionMining
            // 
            uiMissionMining.Dock = DockStyle.Fill;
            uiMissionMining.Location = new Point(0, 0);
            uiMissionMining.Margin = new Padding(1, 1, 1, 1);
            uiMissionMining.Name = "uiMissionMining";
            uiMissionMining.Size = new Size(954, 374);
            uiMissionMining.TabIndex = 0;
            // 
            // UCMissions
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabControlMissions);
            Margin = new Padding(2, 2, 2, 2);
            Name = "UCMissions";
            Size = new Size(962, 402);
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
