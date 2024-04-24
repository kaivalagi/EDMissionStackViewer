using EDJournalQueue.Models;
using EDMissionStackViewer.Helpers;
using EDMissionStackViewer.Models;
using System.ComponentModel;

namespace EDMissionStackViewer.UserControls
{
    public partial class UCMissionMassacre : UserControl
    {

        #region Class Data

        private List<MissionMassacre> _missionData = null;
        private List<MissionMassacreByTargetFaction> _summaryData = null;
        private MissionMassacreByTargetFaction _summaryDataTotal = null;

        #endregion

        #region Constructor

        public UCMissionMassacre()
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

        public void LoadData(List<JournalEntryMissionMassacre> missions)
        {
            dgMissions.SuspendLayout();
            dgSummary.SuspendLayout();

            var missionsBindingList = new SortableBindingList<MissionMassacre>(GetMissionsData(missions));
            dgMissions.DataSource = new BindingSource(missionsBindingList, null);

            var summaryBindingList = new BindingList<MissionMassacreByTargetFaction>(GetSummaryData(missions));
            dgSummary.DataSource = new BindingSource(summaryBindingList, null);

            dgMissions.ResumeLayout(false);
            dgSummary.ResumeLayout(false);
        }

        private List<MissionMassacre> GetMissionsData(List<JournalEntryMissionMassacre> missions)
        {
            _missionData = new List<MissionMassacre>();

            foreach (var mission in missions)
            {
                _missionData.Add(new MissionMassacre(mission));
            }

            return _missionData;
        }

        private List<MissionMassacreByTargetFaction> GetSummaryData(List<JournalEntryMissionMassacre> missions)
        {
            _summaryData = new List<MissionMassacreByTargetFaction>();

            foreach (var targetFactionMissions in missions.GroupBy(m => m.TargetFaction).OrderBy(m => m.Key))
            {
                _summaryData.Add(new MissionMassacreByTargetFaction(targetFactionMissions));
            }

            _summaryDataTotal = new MissionMassacreByTargetFaction(_summaryData);
            _summaryData.Add(_summaryDataTotal);

            return _summaryData;
        }

        #endregion

    }
}
