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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            tlcPanel = new TableLayoutPanel();
            dgSummary = new DataGridView();
            dgMissions = new DataGridView();
            colSummaryCommodity = new DataGridViewTextBoxColumn();
            colSummaryTotalMissions = new DataGridViewTextBoxColumn();
            colSummaryRequired = new DataGridViewTextBoxColumn();
            colSummaryDelivered = new DataGridViewTextBoxColumn();
            colSummaryRemaining = new DataGridViewTextBoxColumn();
            colSummaryTotalReward = new DataGridViewTextBoxColumn();
            colSummarySharedReward = new DataGridViewTextBoxColumn();
            colSummaryRewardPerTon = new DataGridViewTextBoxColumn();
            colSummaryMinExpiry = new DataGridViewTextBoxColumn();
            colSummaryMaxExpiry = new DataGridViewTextBoxColumn();
            colMissionsLocation = new DataGridViewTextBoxColumn();
            colMissionsCommodity = new DataGridViewTextBoxColumn();
            colMissionsRequired = new DataGridViewTextBoxColumn();
            colMissionsDelivered = new DataGridViewTextBoxColumn();
            colMissionsRemaining = new DataGridViewTextBoxColumn();
            colMissionsReward = new DataGridViewTextBoxColumn();
            colMissionsShared = new DataGridViewCheckBoxColumn();
            Expiry = new DataGridViewTextBoxColumn();
            tlcPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgSummary).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgMissions).BeginInit();
            SuspendLayout();
            // 
            // tlcPanel
            // 
            tlcPanel.ColumnCount = 1;
            tlcPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlcPanel.Controls.Add(dgSummary, 0, 1);
            tlcPanel.Controls.Add(dgMissions, 0, 0);
            tlcPanel.Dock = DockStyle.Fill;
            tlcPanel.Location = new Point(0, 0);
            tlcPanel.Name = "tlcPanel";
            tlcPanel.RowCount = 3;
            tlcPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 62.5F));
            tlcPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 37.5F));
            tlcPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 200F));
            tlcPanel.Size = new Size(1570, 838);
            tlcPanel.TabIndex = 4;
            // 
            // dgSummary
            // 
            dgSummary.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgSummary.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgSummary.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgSummary.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgSummary.Columns.AddRange(new DataGridViewColumn[] { colSummaryCommodity, colSummaryTotalMissions, colSummaryRequired, colSummaryDelivered, colSummaryRemaining, colSummaryTotalReward, colSummarySharedReward, colSummaryRewardPerTon, colSummaryMinExpiry, colSummaryMaxExpiry });
            dgSummary.Dock = DockStyle.Fill;
            dgSummary.Location = new Point(3, 401);
            dgSummary.Name = "dgSummary";
            dgSummary.ReadOnly = true;
            dgSummary.RowHeadersVisible = false;
            dgSummary.RowHeadersWidth = 62;
            dgSummary.Size = new Size(1564, 233);
            dgSummary.TabIndex = 5;
            dgSummary.RowPrePaint += dgSummary_RowPrePaint;
            // 
            // dgMissions
            // 
            dgMissions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgMissions.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Control;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgMissions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgMissions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgMissions.Columns.AddRange(new DataGridViewColumn[] { colMissionsLocation, colMissionsCommodity, colMissionsRequired, colMissionsDelivered, colMissionsRemaining, colMissionsReward, colMissionsShared, Expiry });
            dgMissions.Dock = DockStyle.Fill;
            dgMissions.Location = new Point(3, 3);
            dgMissions.Name = "dgMissions";
            dgMissions.ReadOnly = true;
            dgMissions.RowHeadersVisible = false;
            dgMissions.RowHeadersWidth = 62;
            dgMissions.Size = new Size(1564, 392);
            dgMissions.TabIndex = 4;
            // 
            // colSummaryCommodity
            // 
            colSummaryCommodity.DataPropertyName = "Commodity";
            colSummaryCommodity.HeaderText = "Commodity";
            colSummaryCommodity.MinimumWidth = 8;
            colSummaryCommodity.Name = "colSummaryCommodity";
            colSummaryCommodity.ReadOnly = true;
            colSummaryCommodity.Width = 146;
            // 
            // colSummaryTotalMissions
            // 
            colSummaryTotalMissions.DataPropertyName = "TotalMissions";
            colSummaryTotalMissions.HeaderText = "Total Missions";
            colSummaryTotalMissions.MinimumWidth = 8;
            colSummaryTotalMissions.Name = "colSummaryTotalMissions";
            colSummaryTotalMissions.ReadOnly = true;
            colSummaryTotalMissions.Width = 168;
            // 
            // colSummaryRequired
            // 
            colSummaryRequired.DataPropertyName = "Required";
            colSummaryRequired.HeaderText = "Required";
            colSummaryRequired.MinimumWidth = 8;
            colSummaryRequired.Name = "colSummaryRequired";
            colSummaryRequired.ReadOnly = true;
            colSummaryRequired.Width = 125;
            // 
            // colSummaryDelivered
            // 
            colSummaryDelivered.DataPropertyName = "Delivered";
            colSummaryDelivered.HeaderText = "Delivered";
            colSummaryDelivered.MinimumWidth = 8;
            colSummaryDelivered.Name = "colSummaryDelivered";
            colSummaryDelivered.ReadOnly = true;
            colSummaryDelivered.Width = 129;
            // 
            // colSummaryRemaining
            // 
            colSummaryRemaining.DataPropertyName = "Remaining";
            colSummaryRemaining.HeaderText = "Remaining";
            colSummaryRemaining.MinimumWidth = 8;
            colSummaryRemaining.Name = "colSummaryRemaining";
            colSummaryRemaining.ReadOnly = true;
            colSummaryRemaining.Width = 139;
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
            colSummaryTotalReward.Width = 159;
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
            colSummarySharedReward.Width = 176;
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
            colSummaryRewardPerTon.Width = 151;
            // 
            // colSummaryMinExpiry
            // 
            colSummaryMinExpiry.DataPropertyName = "MinExpiry";
            colSummaryMinExpiry.HeaderText = "Min Expiry";
            colSummaryMinExpiry.MinimumWidth = 8;
            colSummaryMinExpiry.Name = "colSummaryMinExpiry";
            colSummaryMinExpiry.ReadOnly = true;
            colSummaryMinExpiry.Width = 140;
            // 
            // colSummaryMaxExpiry
            // 
            colSummaryMaxExpiry.DataPropertyName = "MaxExpiry";
            colSummaryMaxExpiry.HeaderText = "Max Expiry";
            colSummaryMaxExpiry.MinimumWidth = 8;
            colSummaryMaxExpiry.Name = "colSummaryMaxExpiry";
            colSummaryMaxExpiry.ReadOnly = true;
            colSummaryMaxExpiry.Width = 144;
            // 
            // colMissionsLocation
            // 
            colMissionsLocation.DataPropertyName = "Location";
            colMissionsLocation.HeaderText = "Location";
            colMissionsLocation.MinimumWidth = 8;
            colMissionsLocation.Name = "colMissionsLocation";
            colMissionsLocation.ReadOnly = true;
            colMissionsLocation.Width = 121;
            // 
            // colMissionsCommodity
            // 
            colMissionsCommodity.DataPropertyName = "Commodity";
            colMissionsCommodity.HeaderText = "Commodity";
            colMissionsCommodity.MinimumWidth = 8;
            colMissionsCommodity.Name = "colMissionsCommodity";
            colMissionsCommodity.ReadOnly = true;
            colMissionsCommodity.Width = 146;
            // 
            // colMissionsRequired
            // 
            colMissionsRequired.DataPropertyName = "Required";
            colMissionsRequired.HeaderText = "Required";
            colMissionsRequired.MinimumWidth = 8;
            colMissionsRequired.Name = "colMissionsRequired";
            colMissionsRequired.ReadOnly = true;
            colMissionsRequired.Width = 125;
            // 
            // colMissionsDelivered
            // 
            colMissionsDelivered.DataPropertyName = "Delivered";
            colMissionsDelivered.HeaderText = "Delivered";
            colMissionsDelivered.MinimumWidth = 8;
            colMissionsDelivered.Name = "colMissionsDelivered";
            colMissionsDelivered.ReadOnly = true;
            colMissionsDelivered.Width = 129;
            // 
            // colMissionsRemaining
            // 
            colMissionsRemaining.DataPropertyName = "Remaining";
            colMissionsRemaining.HeaderText = "Remaining";
            colMissionsRemaining.MinimumWidth = 8;
            colMissionsRemaining.Name = "colMissionsRemaining";
            colMissionsRemaining.ReadOnly = true;
            colMissionsRemaining.Width = 139;
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
            colMissionsReward.Width = 112;
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
            colMissionsShared.Width = 107;
            // 
            // Expiry
            // 
            Expiry.DataPropertyName = "Expiry";
            Expiry.HeaderText = "Expiry";
            Expiry.MinimumWidth = 8;
            Expiry.Name = "Expiry";
            Expiry.ReadOnly = true;
            Expiry.Width = 102;
            // 
            // UIMissionMining
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tlcPanel);
            Name = "UIMissionMining";
            Size = new Size(1570, 838);
            tlcPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgSummary).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgMissions).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlcPanel;
        private DataGridView dgSummary;
        private DataGridView dgMissions;
        private DataGridViewTextBoxColumn colSummaryCommodity;
        private DataGridViewTextBoxColumn colSummaryTotalMissions;
        private DataGridViewTextBoxColumn colSummaryRequired;
        private DataGridViewTextBoxColumn colSummaryDelivered;
        private DataGridViewTextBoxColumn colSummaryRemaining;
        private DataGridViewTextBoxColumn colSummaryTotalReward;
        private DataGridViewTextBoxColumn colSummarySharedReward;
        private DataGridViewTextBoxColumn colSummaryRewardPerTon;
        private DataGridViewTextBoxColumn colSummaryMinExpiry;
        private DataGridViewTextBoxColumn colSummaryMaxExpiry;
        private DataGridViewTextBoxColumn colMissionsLocation;
        private DataGridViewTextBoxColumn colMissionsCommodity;
        private DataGridViewTextBoxColumn colMissionsRequired;
        private DataGridViewTextBoxColumn colMissionsDelivered;
        private DataGridViewTextBoxColumn colMissionsRemaining;
        private DataGridViewTextBoxColumn colMissionsReward;
        private DataGridViewCheckBoxColumn colMissionsShared;
        private DataGridViewTextBoxColumn Expiry;
    }
}
