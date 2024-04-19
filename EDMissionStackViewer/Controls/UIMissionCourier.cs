using EDJournalQueue.Models;
using EDMissionStackViewer.Models;
using System.ComponentModel;

namespace EDMissionStackViewer.Controls
{
    public partial class UIMissionCourier : UserControl
    {
        public UIMissionCourier()
        {
            InitializeComponent();
        }

        public void LoadData(List<JournalEntryMissionCourier> missions)
        {
            var missionsBindingList = new BindingList<MissionCourier>(GetMissionsData(missions));
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

            var locationMissionsGroups = missions.GroupBy(m => $"{m.DestinationSystem}\\{m.DestinationStation}");

            foreach (var locationMissions in locationMissionsGroups)
            {
                summaryDataSource.Add(new MissionCourierByLocation(locationMissions));
            }

            return summaryDataSource;
        }
    }
}
