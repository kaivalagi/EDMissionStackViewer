using EDJournalQueue.Models;
using EDMissionStackViewer.Models;
using System.ComponentModel;

namespace EDMissionStackViewer.UserControls
{
    public partial class UCMissionMining : UserControl
    {

        #region Constructor
        public UCMissionMining()
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

        public void LoadData(List<JournalEntryMissionMining> missions)
        {
            var missionsBindingList = new BindingList<MissionMining>(GetMissionsData(missions));
            dgMissions.DataSource = new BindingSource(missionsBindingList, null);

            var summaryBindingList = new BindingList<MissionMiningByCommodity>(GetSummaryData(missions));
            dgSummary.DataSource = new BindingSource(summaryBindingList, null);
        }

        private List<MissionMining> GetMissionsData(List<JournalEntryMissionMining> missions)
        {
            var missionsDataSource = new List<MissionMining>();

            foreach (var mission in missions)
            {
                missionsDataSource.Add(new MissionMining(mission));
            }

            return missionsDataSource;
        }

        private List<MissionMiningByCommodity> GetSummaryData(List<JournalEntryMissionMining> missions)
        {
            var summaryDataSource = new List<MissionMiningByCommodity>();

            foreach (var commodityMissions in missions.GroupBy(m => m.Commodity))
            {
                summaryDataSource.Add(new MissionMiningByCommodity(commodityMissions));
            }

            summaryDataSource.Add(new MissionMiningByCommodity(summaryDataSource));

            return summaryDataSource;
        }

        #endregion

    }
}
