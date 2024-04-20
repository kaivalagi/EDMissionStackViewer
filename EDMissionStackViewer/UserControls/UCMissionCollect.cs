using EDJournalQueue.Models;
using EDMissionStackViewer.Models;
using System.ComponentModel;

namespace EDMissionStackViewer.UserControls
{
    public partial class UCMissionCollect : UserControl
    {

        #region Constructor

        public UCMissionCollect()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        private void dgSummary_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            foreach (DataGridViewCell cell in dgSummary.Rows[dgSummary.Rows.Count - 1].Cells)
            {
                cell.Style.Font = new Font(cell.InheritedStyle.Font, FontStyle.Bold);
            }
        }

        #endregion

        #region Methods

        public void LoadData(List<JournalEntryMissionCollect> missions)
        {
            var missionsBindingList = new BindingList<Models.MissionCollect>(GetMissionsData(missions));
            dgMissions.DataSource = new BindingSource(missionsBindingList, null);

            var summaryBindingList = new BindingList<MissionCollectByCommodity>(GetSummaryData(missions));
            dgSummary.DataSource = new BindingSource(summaryBindingList, null);
        }

        private List<Models.MissionCollect> GetMissionsData(List<JournalEntryMissionCollect> missions)
        {
            var missionsDataSource = new List<Models.MissionCollect>();

            foreach (var mission in missions)
            {
                missionsDataSource.Add(new Models.MissionCollect(mission));
            }

            return missionsDataSource;
        }

        private List<MissionCollectByCommodity> GetSummaryData(List<JournalEntryMissionCollect> missions)
        {
            var summaryDataSource = new List<MissionCollectByCommodity>();

            foreach (var commodityMissions in missions.GroupBy(m => m.Commodity))
            {
                summaryDataSource.Add(new MissionCollectByCommodity(commodityMissions));
            }

            return summaryDataSource;
        }

        #endregion

    }
}
