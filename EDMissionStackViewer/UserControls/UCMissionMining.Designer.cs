namespace EDMissionStackViewer.UserControls
{
    partial class UCMissionMining
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            splitContainer = new SplitContainer();
            dgMissions = new DataGridView();
            colMissionsLocation = new DataGridViewTextBoxColumn();
            colMissionsCommodity = new DataGridViewTextBoxColumn();
            colMissionsRequired = new DataGridViewTextBoxColumn();
            colMissionsDelivered = new DataGridViewTextBoxColumn();
            colMissionsRemaining = new DataGridViewTextBoxColumn();
            colMissionsReward = new DataGridViewTextBoxColumn();
            colMissionsShared = new DataGridViewCheckBoxColumn();
            colMissionsExpiry = new DataGridViewTextBoxColumn();
            dgSummary = new DataGridView();
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
            splitContainer.Panel1MinSize = 125;
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(dgSummary);
            splitContainer.Panel2MinSize = 125;
            splitContainer.Size = new Size(1369, 633);
            splitContainer.SplitterDistance = 418;
            splitContainer.TabIndex = 0;
            // 
            // dgMissions
            // 
            dataGridViewCellStyle1.BackColor = Color.Gainsboro;
            dgMissions.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgMissions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgMissions.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgMissions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgMissions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgMissions.Columns.AddRange(new DataGridViewColumn[] { colMissionsLocation, colMissionsCommodity, colMissionsRequired, colMissionsDelivered, colMissionsRemaining, colMissionsReward, colMissionsShared, colMissionsExpiry });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgMissions.DefaultCellStyle = dataGridViewCellStyle4;
            dgMissions.Dock = DockStyle.Fill;
            dgMissions.Location = new Point(0, 0);
            dgMissions.Name = "dgMissions";
            dgMissions.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Control;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgMissions.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgMissions.RowHeadersVisible = false;
            dgMissions.RowHeadersWidth = 62;
            dgMissions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgMissions.Size = new Size(1369, 418);
            dgMissions.TabIndex = 5;
            dgMissions.CellFormatting += dgMissions_CellFormatting;
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
            // colMissionsCommodity
            // 
            colMissionsCommodity.DataPropertyName = "Commodity";
            colMissionsCommodity.HeaderText = "Commodity";
            colMissionsCommodity.MinimumWidth = 8;
            colMissionsCommodity.Name = "colMissionsCommodity";
            colMissionsCommodity.ReadOnly = true;
            colMissionsCommodity.Width = 136;
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
            dataGridViewCellStyle3.Format = "C0";
            dataGridViewCellStyle3.NullValue = null;
            colMissionsReward.DefaultCellStyle = dataGridViewCellStyle3;
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
            dataGridViewCellStyle6.BackColor = Color.Gainsboro;
            dgSummary.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            dgSummary.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgSummary.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = SystemColors.Control;
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle7.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dgSummary.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dgSummary.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgSummary.Columns.AddRange(new DataGridViewColumn[] { colSummaryCommodity, colSummaryTotalMissions, colSummaryRequired, colSummaryDelivered, colSummaryRemaining, colSummaryTotalReward, colSummarySharedReward, colSummaryRewardPerTon, colSummaryMinExpiry, colSummaryMaxExpiry });
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = SystemColors.Window;
            dataGridViewCellStyle11.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle11.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = DataGridViewTriState.False;
            dgSummary.DefaultCellStyle = dataGridViewCellStyle11;
            dgSummary.Dock = DockStyle.Fill;
            dgSummary.Location = new Point(0, 0);
            dgSummary.Name = "dgSummary";
            dgSummary.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = SystemColors.Control;
            dataGridViewCellStyle12.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle12.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = DataGridViewTriState.True;
            dgSummary.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            dgSummary.RowHeadersVisible = false;
            dgSummary.RowHeadersWidth = 62;
            dgSummary.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgSummary.Size = new Size(1369, 211);
            dgSummary.TabIndex = 7;
            dgSummary.CellFormatting += dgSummary_CellFormatting;
            dgSummary.RowPrePaint += dgSummary_RowPrePaint;
            // 
            // colSummaryCommodity
            // 
            colSummaryCommodity.DataPropertyName = "Commodity";
            colSummaryCommodity.HeaderText = "Commodity";
            colSummaryCommodity.MinimumWidth = 8;
            colSummaryCommodity.Name = "colSummaryCommodity";
            colSummaryCommodity.ReadOnly = true;
            colSummaryCommodity.Width = 136;
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
            dataGridViewCellStyle8.Format = "C0";
            dataGridViewCellStyle8.NullValue = null;
            colSummaryTotalReward.DefaultCellStyle = dataGridViewCellStyle8;
            colSummaryTotalReward.HeaderText = "Total Reward";
            colSummaryTotalReward.MinimumWidth = 8;
            colSummaryTotalReward.Name = "colSummaryTotalReward";
            colSummaryTotalReward.ReadOnly = true;
            colSummaryTotalReward.Width = 145;
            // 
            // colSummarySharedReward
            // 
            colSummarySharedReward.DataPropertyName = "SharedReward";
            dataGridViewCellStyle9.Format = "C0";
            dataGridViewCellStyle9.NullValue = null;
            colSummarySharedReward.DefaultCellStyle = dataGridViewCellStyle9;
            colSummarySharedReward.HeaderText = "Shared Reward";
            colSummarySharedReward.MinimumWidth = 8;
            colSummarySharedReward.Name = "colSummarySharedReward";
            colSummarySharedReward.ReadOnly = true;
            colSummarySharedReward.Width = 160;
            // 
            // colSummaryRewardPerTon
            // 
            colSummaryRewardPerTon.DataPropertyName = "RewardPerTon";
            dataGridViewCellStyle10.Format = "C0";
            dataGridViewCellStyle10.NullValue = null;
            colSummaryRewardPerTon.DefaultCellStyle = dataGridViewCellStyle10;
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
            // UCMissionMining
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer);
            Name = "UCMissionMining";
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
        private DataGridView dgSummary;
        private DataGridViewTextBoxColumn colMissionsLocation;
        private DataGridViewTextBoxColumn colMissionsCommodity;
        private DataGridViewTextBoxColumn colMissionsRequired;
        private DataGridViewTextBoxColumn colMissionsDelivered;
        private DataGridViewTextBoxColumn colMissionsRemaining;
        private DataGridViewTextBoxColumn colMissionsReward;
        private DataGridViewCheckBoxColumn colMissionsShared;
        private DataGridViewTextBoxColumn colMissionsExpiry;
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
    }
}
