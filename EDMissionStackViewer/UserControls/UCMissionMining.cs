using EDJournalQueue.Models;
using EDMissionStackViewer.Forms;
using EDMissionStackViewer.Helpers;
using EDMissionStackViewer.Models;
using System.ComponentModel;

namespace EDMissionStackViewer.UserControls
{
    public partial class UCMissionMining : UserControl
    {
        #region Class Data

        private List<MissionMining> _missionData = null;
        private List<MissionMiningByCommodity> _summaryData = null;
        private MissionMiningByCommodity _summaryDataTotal = null;

        #endregion

        #region Constructor
        public UCMissionMining()
        {
            InitializeComponent();

            //dgMissions.ColumnHeadersDefaultCellStyle.SelectionBackColor = dgMissions.ColumnHeadersDefaultCellStyle.BackColor;
            //dgMissions.ColumnHeadersDefaultCellStyle.SelectionForeColor = dgMissions.ColumnHeadersDefaultCellStyle.ForeColor;

            //dgSummary.ColumnHeadersDefaultCellStyle.SelectionBackColor = dgMissions.ColumnHeadersDefaultCellStyle.BackColor;
            //dgSummary.ColumnHeadersDefaultCellStyle.SelectionForeColor = dgMissions.ColumnHeadersDefaultCellStyle.ForeColor;

            //dgMissions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            //dgSummary.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        }

        #endregion

        #region Events

        private void dgMissions_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.Value is TimeSpan)
            {
                e.Value = ((TimeSpan)e.Value).ToDaysHoursMins();
            }
        }

        private void dgSummary_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.Value is TimeSpan)
            {
                e.Value = ((TimeSpan)e.Value).ToDaysHoursMins();
            }
        }

        private void dgSummary_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            foreach (DataGridViewCell cell in dgSummary.Rows[dgSummary.Rows.Count - 1].Cells)
            {
                cell.Style.Font = new Font(cell.InheritedStyle.Font, FontStyle.Bold);
            }
        }

        private void dgSummary_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                if (_summaryDataTotal != null)
                {
                    var info = $@"
Locations: {string.Join(",", _missionData.DistinctBy(m => m.Location).Select(m => m.Location).ToList())}
Mission Count: {_summaryDataTotal.TotalMissions}
Current Value: {_summaryDataTotal.TotalReward.ToString("N0")} Cr
Expiry: {_summaryDataTotal.MinExpiry.ToDaysHoursMins()}";
                    Clipboard.SetText(info);
                }
            }
        }

        private void dgSummary_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.Control)
            {
                e.IsInputKey = true;
            }
        }

        #endregion

        #region Methods

        public void LoadData(List<JournalEntryMissionMining> missions)
        {
            dgMissions.SuspendLayout();
            dgSummary.SuspendLayout();

            var missionsBindingList = new SortableBindingList<MissionMining>(GetMissionsData(missions));
            dgMissions.DataSource = new BindingSource(missionsBindingList, null);
            dgMissions.Refresh();

            var summaryBindingList = new BindingList<MissionMiningByCommodity>(GetSummaryData(missions));
            dgSummary.DataSource = new BindingSource(summaryBindingList, null);
            dgSummary.Refresh();

            dgMissions.ResumeLayout(false);
            dgSummary.ResumeLayout(false);
        }

        private List<MissionMining> GetMissionsData(List<JournalEntryMissionMining> missions)
        {
            _missionData = new List<MissionMining>();

            foreach (var mission in missions)
            {
                _missionData.Add(new MissionMining(mission));
            }

            return _missionData;
        }

        private List<MissionMiningByCommodity> GetSummaryData(List<JournalEntryMissionMining> missions)
        {
            _summaryData = new List<MissionMiningByCommodity>();

            foreach (var commodityMissions in missions.GroupBy(m => m.Commodity).OrderBy(m => m.Key))
            {
                _summaryData.Add(new MissionMiningByCommodity(commodityMissions));
            }

            _summaryDataTotal = new MissionMiningByCommodity(_summaryData);
            _summaryData.Add(_summaryDataTotal);

            return _summaryData;
        }

        #endregion

    }
}
