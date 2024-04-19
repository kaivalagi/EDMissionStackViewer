using EDJournalQueue.Models;
using EDMissionStackViewer.Models;
using System.ComponentModel;

namespace EDMissionStackViewer.Controls
{
    public partial class UIMissionMining : UserControl
    {

        public UIMissionMining()
        {
            InitializeComponent();
        }

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

            return summaryDataSource;
        }
    }
}
