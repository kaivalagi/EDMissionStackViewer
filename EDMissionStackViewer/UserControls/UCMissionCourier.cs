using EDJournalQueue.Models;
using EDMissionStackViewer.Helpers;
using EDMissionStackViewer.Models;
using System.ComponentModel;

namespace EDMissionStackViewer.UserControls
{
    public partial class UCMissionCourier : UserControl
    {

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

        #endregion

        #region Methods

        public void LoadData(List<JournalEntryMissionCourier> missions)
        {
            var missionsBindingList = new SortableBindingList<MissionCourier>(GetMissionsData(missions));
            dgMissions.DataSource = new BindingSource(missionsBindingList, null);

            var summaryBindingList = new BindingList<MissionCourierByLocation>(GetSummaryData(missions));
            dgSummary.DataSource = new BindingSource(summaryBindingList, null);
        }

        private List<MissionCourier> GetMissionsData(List<JournalEntryMissionCourier> missions)
        {
            var missionsDataSource = new List<MissionCourier>();

            foreach (var mission in missions)
            {
                missionsDataSource.Add(new MissionCourier(mission));
            }

            return missionsDataSource;
        }

        private List<MissionCourierByLocation> GetSummaryData(List<JournalEntryMissionCourier> missions)
        {
            var summaryDataSource = new List<MissionCourierByLocation>();

            var locationMissionsGroups = missions.GroupBy(m => $"{m.DestinationSystem}\\{m.DestinationStation}").OrderBy(m => m.Key);

            foreach (var locationMissions in locationMissionsGroups)
            {
                summaryDataSource.Add(new MissionCourierByLocation(locationMissions));
            }

            return summaryDataSource;
        }

        #endregion

    }
}
