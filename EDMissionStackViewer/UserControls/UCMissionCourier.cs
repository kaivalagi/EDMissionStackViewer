using EDJournalQueue.Models;
using EDMissionStackViewer.Helpers;
using EDMissionStackViewer.Models;
using System.ComponentModel;

namespace EDMissionStackViewer.UserControls
{
    public partial class UCMissionCourier : UserControl
    {

        #region Class Data

        private List<MissionCourier> _missionData = null;
        private List<MissionCourierByLocation> _summaryData = null;
        private MissionCourierByLocation _summaryDataTotal = null;

        #endregion

        #region Constructor

        public UCMissionCourier()
        {
            InitializeComponent();

            dgMissions.EnableHeadersVisualStyles = false;
            dgMissions.ColumnHeadersDefaultCellStyle.SelectionBackColor = dgMissions.ColumnHeadersDefaultCellStyle.BackColor;

            dgSummary.EnableHeadersVisualStyles = false;
            dgSummary.ColumnHeadersDefaultCellStyle.SelectionBackColor = dgMissions.ColumnHeadersDefaultCellStyle.BackColor;

        }

        #endregion

        #region Events

        private void dgMissions_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && dgMissions.Columns[e.ColumnIndex].DataPropertyName.EndsWith("Expiry"))
                e.Value = ((TimeSpan)e.Value).ToDaysHoursMins();
        }

        private void dgSummary_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && dgSummary.Columns[e.ColumnIndex].DataPropertyName.EndsWith("Expiry"))
                e.Value = ((TimeSpan)e.Value).ToDaysHoursMins();
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
Location: {_missionData[0].Location}
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

        public void LoadData(List<JournalEntryMissionCourier> missions)
        {
            dgMissions.SuspendLayout();
            dgSummary.SuspendLayout();

            var missionsBindingList = new SortableBindingList<MissionCourier>(GetMissionsData(missions));
            dgMissions.DataSource = new BindingSource(missionsBindingList, null);

            var summaryBindingList = new BindingList<MissionCourierByLocation>(GetSummaryData(missions));
            dgSummary.DataSource = new BindingSource(summaryBindingList, null);

            dgMissions.ResumeLayout(false);
            dgSummary.ResumeLayout(false);
        }

        private List<MissionCourier> GetMissionsData(List<JournalEntryMissionCourier> missions)
        {
            _missionData = new List<MissionCourier>();

            foreach (var mission in missions)
            {
                _missionData.Add(new MissionCourier(mission));
            }

            return _missionData;
        }

        private List<MissionCourierByLocation> GetSummaryData(List<JournalEntryMissionCourier> missions)
        {
            _summaryData = new List<MissionCourierByLocation>();

            var locationMissionsGroups = missions.GroupBy(m => $"{m.DestinationSystem}\\{m.DestinationStation}").OrderBy(m => m.Key);

            foreach (var locationMissions in locationMissionsGroups)
            {
                _summaryData.Add(new MissionCourierByLocation(locationMissions));
            }

            _summaryDataTotal = new MissionCourierByLocation(_summaryData);
            _summaryData.Add(_summaryDataTotal);

            return _summaryData;
        }

        #endregion

    }
}
