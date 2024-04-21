namespace EDMissionStackViewer.UserControls
{
    partial class UCMissionMassacre
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            layoutPanel = new TableLayoutPanel();
            dgSummary = new DataGridView();
            colSummaryFaction = new DataGridViewTextBoxColumn();
            colSummaryTotalMissions = new DataGridViewTextBoxColumn();
            colSummaryRequired = new DataGridViewTextBoxColumn();
            colSummaryKilled = new DataGridViewTextBoxColumn();
            colSummaryRemaining = new DataGridViewTextBoxColumn();
            colSummaryTotalReward = new DataGridViewTextBoxColumn();
            colSummarySharedReward = new DataGridViewTextBoxColumn();
            colSummaryRewardPerTon = new DataGridViewTextBoxColumn();
            colSummaryMinExpiry = new DataGridViewTextBoxColumn();
            colSummaryMaxExpiry = new DataGridViewTextBoxColumn();
            dgMissions = new DataGridView();
            colMissionsLocation = new DataGridViewTextBoxColumn();
            colMissionsFaction = new DataGridViewTextBoxColumn();
            colMissionsRequired = new DataGridViewTextBoxColumn();
            colMissionsKilled = new DataGridViewTextBoxColumn();
            colMissionsRemaining = new DataGridViewTextBoxColumn();
            colMissionsReward = new DataGridViewTextBoxColumn();
            colMissionsShared = new DataGridViewCheckBoxColumn();
            colMissionsExpiry = new DataGridViewTextBoxColumn();
            layoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgSummary).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgMissions).BeginInit();
            SuspendLayout();
            // 
            // layoutPanel
            // 
            layoutPanel.ColumnCount = 1;
            layoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutPanel.Controls.Add(dgSummary, 0, 1);
            layoutPanel.Controls.Add(dgMissions, 0, 0);
            layoutPanel.Dock = DockStyle.Fill;
            layoutPanel.Location = new Point(0, 0);
            layoutPanel.Name = "layoutPanel";
            layoutPanel.RowCount = 2;
            layoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            layoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            layoutPanel.Size = new Size(1369, 633);
            layoutPanel.TabIndex = 5;
            // 
            // dgSummary
            // 
            dgSummary.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgSummary.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgSummary.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgSummary.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgSummary.Columns.AddRange(new DataGridViewColumn[] { colSummaryFaction, colSummaryTotalMissions, colSummaryRequired, colSummaryKilled, colSummaryRemaining, colSummaryTotalReward, colSummarySharedReward, colSummaryRewardPerTon, colSummaryMinExpiry, colSummaryMaxExpiry });
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Window;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dgSummary.DefaultCellStyle = dataGridViewCellStyle5;
            dgSummary.Dock = DockStyle.Fill;
            dgSummary.Location = new Point(3, 446);
            dgSummary.Name = "dgSummary";
            dgSummary.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Control;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dgSummary.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dgSummary.RowHeadersVisible = false;
            dgSummary.RowHeadersWidth = 62;
            dgSummary.Size = new Size(1363, 184);
            dgSummary.TabIndex = 5;
            // 
            // colSummaryFaction
            // 
            colSummaryFaction.DataPropertyName = "Faction";
            colSummaryFaction.HeaderText = "Faction";
            colSummaryFaction.MinimumWidth = 8;
            colSummaryFaction.Name = "colSummaryFaction";
            colSummaryFaction.ReadOnly = true;
            colSummaryFaction.Width = 102;
            // 
            // colSummaryTotalMissions
            // 
            colSummaryTotalMissions.DataPropertyName = "TotalMissions";
            colSummaryTotalMissions.HeaderText = "Total Missions";
            colSummaryTotalMissions.MinimumWidth = 8;
            colSummaryTotalMissions.Name = "colSummaryTotalMissions";
            colSummaryTotalMissions.ReadOnly = true;
            colSummaryTotalMissions.Width = 154;
            // 
            // colSummaryRequired
            // 
            colSummaryRequired.DataPropertyName = "Required";
            colSummaryRequired.HeaderText = "Required";
            colSummaryRequired.MinimumWidth = 8;
            colSummaryRequired.Name = "colSummaryRequired";
            colSummaryRequired.ReadOnly = true;
            colSummaryRequired.Width = 115;
            // 
            // colSummaryKilled
            // 
            colSummaryKilled.DataPropertyName = "Killed";
            colSummaryKilled.HeaderText = "Killed";
            colSummaryKilled.MinimumWidth = 8;
            colSummaryKilled.Name = "colSummaryKilled";
            colSummaryKilled.ReadOnly = true;
            colSummaryKilled.Width = 90;
            // 
            // colSummaryRemaining
            // 
            colSummaryRemaining.DataPropertyName = "Remaining";
            colSummaryRemaining.HeaderText = "Remaining";
            colSummaryRemaining.MinimumWidth = 8;
            colSummaryRemaining.Name = "colSummaryRemaining";
            colSummaryRemaining.ReadOnly = true;
            colSummaryRemaining.Width = 129;
            // 
            // colSummaryTotalReward
            // 
            colSummaryTotalReward.DataPropertyName = "TotalReward";
            dataGridViewCellStyle2.Format = "C0";
            dataGridViewCellStyle2.NullValue = null;
            colSummaryTotalReward.DefaultCellStyle = dataGridViewCellStyle2;
            colSummaryTotalReward.HeaderText = "Total Reward";
            colSummaryTotalReward.MinimumWidth = 8;
            colSummaryTotalReward.Name = "colSummaryTotalReward";
            colSummaryTotalReward.ReadOnly = true;
            colSummaryTotalReward.Width = 145;
            // 
            // colSummarySharedReward
            // 
            colSummarySharedReward.DataPropertyName = "SharedReward";
            dataGridViewCellStyle3.Format = "C0";
            dataGridViewCellStyle3.NullValue = null;
            colSummarySharedReward.DefaultCellStyle = dataGridViewCellStyle3;
            colSummarySharedReward.HeaderText = "Shared Reward";
            colSummarySharedReward.MinimumWidth = 8;
            colSummarySharedReward.Name = "colSummarySharedReward";
            colSummarySharedReward.ReadOnly = true;
            colSummarySharedReward.Width = 160;
            // 
            // colSummaryRewardPerTon
            // 
            colSummaryRewardPerTon.DataPropertyName = "RewardPerTon";
            dataGridViewCellStyle4.Format = "C0";
            dataGridViewCellStyle4.NullValue = null;
            colSummaryRewardPerTon.DefaultCellStyle = dataGridViewCellStyle4;
            colSummaryRewardPerTon.HeaderText = "Reward/Ton";
            colSummaryRewardPerTon.MinimumWidth = 8;
            colSummaryRewardPerTon.Name = "colSummaryRewardPerTon";
            colSummaryRewardPerTon.ReadOnly = true;
            colSummaryRewardPerTon.Width = 138;
            // 
            // colSummaryMinExpiry
            // 
            colSummaryMinExpiry.DataPropertyName = "MinExpiry";
            colSummaryMinExpiry.HeaderText = "Min Expiry";
            colSummaryMinExpiry.MinimumWidth = 8;
            colSummaryMinExpiry.Name = "colSummaryMinExpiry";
            colSummaryMinExpiry.ReadOnly = true;
            colSummaryMinExpiry.Width = 129;
            // 
            // colSummaryMaxExpiry
            // 
            colSummaryMaxExpiry.DataPropertyName = "MaxExpiry";
            colSummaryMaxExpiry.HeaderText = "Max Expiry";
            colSummaryMaxExpiry.MinimumWidth = 8;
            colSummaryMaxExpiry.Name = "colSummaryMaxExpiry";
            colSummaryMaxExpiry.ReadOnly = true;
            colSummaryMaxExpiry.Width = 132;
            // 
            // dgMissions
            // 
            dgMissions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgMissions.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = SystemColors.Control;
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle7.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dgMissions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dgMissions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgMissions.Columns.AddRange(new DataGridViewColumn[] { colMissionsLocation, colMissionsFaction, colMissionsRequired, colMissionsKilled, colMissionsRemaining, colMissionsReward, colMissionsShared, colMissionsExpiry });
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = SystemColors.Window;
            dataGridViewCellStyle9.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle9.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.False;
            dgMissions.DefaultCellStyle = dataGridViewCellStyle9;
            dgMissions.Dock = DockStyle.Fill;
            dgMissions.Location = new Point(3, 3);
            dgMissions.Name = "dgMissions";
            dgMissions.ReadOnly = true;
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = SystemColors.Control;
            dataGridViewCellStyle10.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle10.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.True;
            dgMissions.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            dgMissions.RowHeadersVisible = false;
            dgMissions.RowHeadersWidth = 62;
            dgMissions.Size = new Size(1363, 437);
            dgMissions.TabIndex = 4;
            // 
            // colMissionsLocation
            // 
            colMissionsLocation.DataPropertyName = "Location";
            colMissionsLocation.HeaderText = "Location";
            colMissionsLocation.MinimumWidth = 8;
            colMissionsLocation.Name = "colMissionsLocation";
            colMissionsLocation.ReadOnly = true;
            colMissionsLocation.Width = 112;
            // 
            // colMissionsFaction
            // 
            colMissionsFaction.DataPropertyName = "Faction";
            colMissionsFaction.HeaderText = "Faction";
            colMissionsFaction.MinimumWidth = 8;
            colMissionsFaction.Name = "colMissionsFaction";
            colMissionsFaction.ReadOnly = true;
            colMissionsFaction.Width = 102;
            // 
            // colMissionsRequired
            // 
            colMissionsRequired.DataPropertyName = "Required";
            colMissionsRequired.HeaderText = "Required";
            colMissionsRequired.MinimumWidth = 8;
            colMissionsRequired.Name = "colMissionsRequired";
            colMissionsRequired.ReadOnly = true;
            colMissionsRequired.Width = 115;
            // 
            // colMissionsKilled
            // 
            colMissionsKilled.DataPropertyName = "Killed";
            colMissionsKilled.HeaderText = "Killed";
            colMissionsKilled.MinimumWidth = 8;
            colMissionsKilled.Name = "colMissionsKilled";
            colMissionsKilled.ReadOnly = true;
            colMissionsKilled.Width = 90;
            // 
            // colMissionsRemaining
            // 
            colMissionsRemaining.DataPropertyName = "Remaining";
            colMissionsRemaining.HeaderText = "Remaining";
            colMissionsRemaining.MinimumWidth = 8;
            colMissionsRemaining.Name = "colMissionsRemaining";
            colMissionsRemaining.ReadOnly = true;
            colMissionsRemaining.Width = 129;
            // 
            // colMissionsReward
            // 
            colMissionsReward.DataPropertyName = "Reward";
            dataGridViewCellStyle8.Format = "C0";
            dataGridViewCellStyle8.NullValue = null;
            colMissionsReward.DefaultCellStyle = dataGridViewCellStyle8;
            colMissionsReward.HeaderText = "Reward";
            colMissionsReward.MinimumWidth = 8;
            colMissionsReward.Name = "colMissionsReward";
            colMissionsReward.ReadOnly = true;
            colMissionsReward.Width = 103;
            // 
            // colMissionsShared
            // 
            colMissionsShared.DataPropertyName = "Shared";
            colMissionsShared.HeaderText = "Shared";
            colMissionsShared.MinimumWidth = 8;
            colMissionsShared.Name = "colMissionsShared";
            colMissionsShared.ReadOnly = true;
            colMissionsShared.Resizable = DataGridViewTriState.True;
            colMissionsShared.SortMode = DataGridViewColumnSortMode.Automatic;
            colMissionsShared.Width = 99;
            // 
            // colMissionsExpiry
            // 
            colMissionsExpiry.DataPropertyName = "Expiry";
            colMissionsExpiry.HeaderText = "Expiry";
            colMissionsExpiry.MinimumWidth = 8;
            colMissionsExpiry.Name = "colMissionsExpiry";
            colMissionsExpiry.ReadOnly = true;
            colMissionsExpiry.Width = 95;
            // 
            // UCMissionMassacre
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(layoutPanel);
            Name = "UCMissionMassacre";
            Size = new Size(1369, 633);
            layoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgSummary).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgMissions).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlcPanel;
        private DataGridView dgSummary;
        private DataGridView dgMissions;
        private DataGridViewTextBoxColumn colSummaryFaction;
        private DataGridViewTextBoxColumn colSummaryTotalMissions;
        private DataGridViewTextBoxColumn colSummaryRequired;
        private DataGridViewTextBoxColumn colSummaryKilled;
        private DataGridViewTextBoxColumn colSummaryRemaining;
        private DataGridViewTextBoxColumn colSummaryTotalReward;
        private DataGridViewTextBoxColumn colSummarySharedReward;
        private DataGridViewTextBoxColumn colSummaryRewardPerTon;
        private DataGridViewTextBoxColumn colSummaryMinExpiry;
        private DataGridViewTextBoxColumn colSummaryMaxExpiry;
        private DataGridViewTextBoxColumn colMissionsLocation;
        private DataGridViewTextBoxColumn colMissionsFaction;
        private DataGridViewTextBoxColumn colMissionsRequired;
        private DataGridViewTextBoxColumn colMissionsKilled;
        private DataGridViewTextBoxColumn colMissionsRemaining;
        private DataGridViewTextBoxColumn colMissionsReward;
        private DataGridViewCheckBoxColumn colMissionsShared;
        private DataGridViewTextBoxColumn colMissionsExpiry;
        private TableLayoutPanel layoutPanel;
    }
}
