namespace EDMissionStackViewer.UserControls
{
    partial class UCMissionCourier
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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            splitContainer = new SplitContainer();
            dgMissions = new DataGridView();
            colMissionsLocation = new DataGridViewTextBoxColumn();
            colMissionsFaction = new DataGridViewTextBoxColumn();
            colMissionsRequired = new DataGridViewTextBoxColumn();
            colMissionsDelivered = new DataGridViewTextBoxColumn();
            colMissionsRemaining = new DataGridViewTextBoxColumn();
            colMissionsReward = new DataGridViewTextBoxColumn();
            colMissionsShared = new DataGridViewCheckBoxColumn();
            colMissionsExpiry = new DataGridViewTextBoxColumn();
            dgSummary = new DataGridView();
            colSummaryLocation = new DataGridViewTextBoxColumn();
            colSummaryTotalMissions = new DataGridViewTextBoxColumn();
            colSummaryRequired = new DataGridViewTextBoxColumn();
            colSummaryDelivered = new DataGridViewTextBoxColumn();
            colSummaryRemaining = new DataGridViewTextBoxColumn();
            colSummaryTotalReward = new DataGridViewTextBoxColumn();
            colSummarySharedReward = new DataGridViewTextBoxColumn();
            colSummaryRewardPerTon = new DataGridViewTextBoxColumn();
            colSummaryMinExpiry = new DataGridViewTextBoxColumn();
            colSummaryMaxExpiry = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgMissions).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgSummary).BeginInit();
            SuspendLayout();
            // 
            // splitContainer
            // 
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.Location = new Point(0, 0);
            splitContainer.Name = "splitContainer";
            splitContainer.Orientation = Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(dgMissions);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(dgSummary);
            splitContainer.Size = new Size(1369, 633);
            splitContainer.SplitterDistance = 456;
            splitContainer.TabIndex = 0;
            // 
            // dgMissions
            // 
            dgMissions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgMissions.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Control;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgMissions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgMissions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgMissions.Columns.AddRange(new DataGridViewColumn[] { colMissionsLocation, colMissionsFaction, colMissionsRequired, colMissionsDelivered, colMissionsRemaining, colMissionsReward, colMissionsShared, colMissionsExpiry });
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = SystemColors.Window;
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle7.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.False;
            dgMissions.DefaultCellStyle = dataGridViewCellStyle7;
            dgMissions.Dock = DockStyle.Fill;
            dgMissions.Location = new Point(0, 0);
            dgMissions.Name = "dgMissions";
            dgMissions.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = SystemColors.Control;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle8.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
            dgMissions.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            dgMissions.RowHeadersVisible = false;
            dgMissions.RowHeadersWidth = 62;
            dgMissions.Size = new Size(1369, 456);
            dgMissions.TabIndex = 5;
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
            // colMissionsDelivered
            // 
            colMissionsDelivered.DataPropertyName = "Delivered";
            colMissionsDelivered.HeaderText = "Delivered";
            colMissionsDelivered.MinimumWidth = 8;
            colMissionsDelivered.Name = "colMissionsDelivered";
            colMissionsDelivered.ReadOnly = true;
            colMissionsDelivered.Width = 120;
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
            dataGridViewCellStyle6.Format = "C0";
            dataGridViewCellStyle6.NullValue = null;
            colMissionsReward.DefaultCellStyle = dataGridViewCellStyle6;
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
            // dgSummary
            // 
            dgSummary.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgSummary.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = SystemColors.Control;
            dataGridViewCellStyle9.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle9.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
            dgSummary.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dgSummary.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgSummary.Columns.AddRange(new DataGridViewColumn[] { colSummaryLocation, colSummaryTotalMissions, colSummaryRequired, colSummaryDelivered, colSummaryRemaining, colSummaryTotalReward, colSummarySharedReward, colSummaryRewardPerTon, colSummaryMinExpiry, colSummaryMaxExpiry });
            dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = SystemColors.Window;
            dataGridViewCellStyle13.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle13.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle13.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = DataGridViewTriState.False;
            dgSummary.DefaultCellStyle = dataGridViewCellStyle13;
            dgSummary.Dock = DockStyle.Fill;
            dgSummary.Location = new Point(0, 0);
            dgSummary.Name = "dgSummary";
            dgSummary.ReadOnly = true;
            dataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = SystemColors.Control;
            dataGridViewCellStyle14.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle14.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = DataGridViewTriState.True;
            dgSummary.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            dgSummary.RowHeadersVisible = false;
            dgSummary.RowHeadersWidth = 62;
            dgSummary.Size = new Size(1369, 173);
            dgSummary.TabIndex = 6;
            // 
            // colSummaryLocation
            // 
            colSummaryLocation.DataPropertyName = "Location";
            colSummaryLocation.HeaderText = "Location";
            colSummaryLocation.MinimumWidth = 8;
            colSummaryLocation.Name = "colSummaryLocation";
            colSummaryLocation.ReadOnly = true;
            colSummaryLocation.Width = 112;
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
            // colSummaryDelivered
            // 
            colSummaryDelivered.DataPropertyName = "Delivered";
            colSummaryDelivered.HeaderText = "Delivered";
            colSummaryDelivered.MinimumWidth = 8;
            colSummaryDelivered.Name = "colSummaryDelivered";
            colSummaryDelivered.ReadOnly = true;
            colSummaryDelivered.Width = 120;
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
            dataGridViewCellStyle10.Format = "C0";
            dataGridViewCellStyle10.NullValue = null;
            colSummaryTotalReward.DefaultCellStyle = dataGridViewCellStyle10;
            colSummaryTotalReward.HeaderText = "Total Reward";
            colSummaryTotalReward.MinimumWidth = 8;
            colSummaryTotalReward.Name = "colSummaryTotalReward";
            colSummaryTotalReward.ReadOnly = true;
            colSummaryTotalReward.Width = 145;
            // 
            // colSummarySharedReward
            // 
            colSummarySharedReward.DataPropertyName = "SharedReward";
            dataGridViewCellStyle11.Format = "C0";
            dataGridViewCellStyle11.NullValue = null;
            colSummarySharedReward.DefaultCellStyle = dataGridViewCellStyle11;
            colSummarySharedReward.HeaderText = "Shared Reward";
            colSummarySharedReward.MinimumWidth = 8;
            colSummarySharedReward.Name = "colSummarySharedReward";
            colSummarySharedReward.ReadOnly = true;
            colSummarySharedReward.Width = 160;
            // 
            // colSummaryRewardPerTon
            // 
            colSummaryRewardPerTon.DataPropertyName = "RewardPerTon";
            dataGridViewCellStyle12.Format = "C0";
            dataGridViewCellStyle12.NullValue = null;
            colSummaryRewardPerTon.DefaultCellStyle = dataGridViewCellStyle12;
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
            // UCMissionCourier
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer);
            Name = "UCMissionCourier";
            Size = new Size(1369, 633);
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgMissions).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgSummary).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlcPanel;
        private SplitContainer splitContainer;
        private DataGridView dgMissions;
        private DataGridViewTextBoxColumn colMissionsLocation;
        private DataGridViewTextBoxColumn colMissionsFaction;
        private DataGridViewTextBoxColumn colMissionsRequired;
        private DataGridViewTextBoxColumn colMissionsDelivered;
        private DataGridViewTextBoxColumn colMissionsRemaining;
        private DataGridViewTextBoxColumn colMissionsReward;
        private DataGridViewCheckBoxColumn colMissionsShared;
        private DataGridViewTextBoxColumn colMissionsExpiry;
        private DataGridView dgSummary;
        private DataGridViewTextBoxColumn colSummaryLocation;
        private DataGridViewTextBoxColumn colSummaryTotalMissions;
        private DataGridViewTextBoxColumn colSummaryRequired;
        private DataGridViewTextBoxColumn colSummaryDelivered;
        private DataGridViewTextBoxColumn colSummaryRemaining;
        private DataGridViewTextBoxColumn colSummaryTotalReward;
        private DataGridViewTextBoxColumn colSummarySharedReward;
        private DataGridViewTextBoxColumn colSummaryRewardPerTon;
        private DataGridViewTextBoxColumn colSummaryMinExpiry;
        private DataGridViewTextBoxColumn colSummaryMaxExpiry;
    }
}
