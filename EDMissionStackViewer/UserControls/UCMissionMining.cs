using EDJournalQueue.Models;
using EDMissionStackViewer.Helpers;
using EDMissionStackViewer.Models;
using System.ComponentModel;
using System.Windows.Forms;

namespace EDMissionStackViewer.UserControls
{
    public partial class UCMissionMining : UserControl
    {

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

        #endregion

        #region Methods

        public void LoadData(List<JournalEntryMissionMining> missions)
        {
            this.SuspendLayout();
            splitContainer.SuspendLayout();
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
            splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
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

            foreach (var commodityMissions in missions.GroupBy(m => m.Commodity).OrderBy(m => m.Key))
            {
                summaryDataSource.Add(new MissionMiningByCommodity(commodityMissions));
            }

            summaryDataSource.Add(new MissionMiningByCommodity(summaryDataSource));

            return summaryDataSource;
        }

        #endregion

    }
}
