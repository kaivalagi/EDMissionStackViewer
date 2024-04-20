using EDJournalQueue.Models;
using EDMissionStackViewer.Models;
using System.ComponentModel;

namespace EDMissionStackViewer.UserControls
{
    public partial class UCMissionMassacre : UserControl
    {

        #region Constructor

        public UCMissionMassacre()
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

        public void LoadData(List<JournalEntryMissionMassacre> missions)
        {
            var missionsBindingList = new BindingList<MissionMassacre>(GetMissionsData(missions));
            dgMissions.DataSource = new BindingSource(missionsBindingList, null);

            var summaryBindingList = new BindingList<MissionMassacreByFaction>(GetSummaryData(missions));
            dgSummary.DataSource = new BindingSource(summaryBindingList, null);
        }

        private List<MissionMassacre> GetMissionsData(List<JournalEntryMissionMassacre> missions)
        {
            var missionsDataSource = new List<MissionMassacre>();

            foreach (var mission in missions)
            {
                missionsDataSource.Add(new MissionMassacre(mission));
            }

            return missionsDataSource;
        }

        private List<MissionMassacreByFaction> GetSummaryData(List<JournalEntryMissionMassacre> missions)
        {
            var summaryDataSource = new List<MissionMassacreByFaction>();

            foreach (var factionMissions in missions.GroupBy(m => m.Faction))
            {
                summaryDataSource.Add(new MissionMassacreByFaction(factionMissions));
            }

            return summaryDataSource;
        }

        #endregion

    }
}
