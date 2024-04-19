using EDJournalQueue.Models;
using EDMissionStackViewer.Models;
using System.ComponentModel;

namespace EDMissionStackViewer.Controls
{
    public partial class UIMissionCollect : UserControl
    {
        public UIMissionCollect()
        {
            InitializeComponent();
        }

        public void LoadData(List<JournalEntryMissionCollect> missions)
        {
            var missionsBindingList = new BindingList<MissionCollect>(GetMissionsData(missions));
            dgMissions.DataSource = new BindingSource(missionsBindingList, null);

            var summaryBindingList = new BindingList<MissionCollectByCommodity>(GetSummaryData(missions));
            dgSummary.DataSource = new BindingSource(summaryBindingList, null);
        }

        private List<MissionCollect> GetMissionsData(List<JournalEntryMissionCollect> missions)
        {
            var missionsDataSource = new List<MissionCollect>();

            foreach (var mission in missions)
            {
                missionsDataSource.Add(new MissionCollect(mission));
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
    }
}
