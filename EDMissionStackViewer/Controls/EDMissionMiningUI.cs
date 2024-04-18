using EDMissionStackViewer.Models;
using System.ComponentModel;

namespace EDMissionStackViewer.Controls
{
    public partial class EDMissionMiningUI : UserControl
    {
        public EDMissionMiningUI()
        {
            InitializeComponent();
        }

        public void LoadData(List<EDJournalEntryMissionMining> missions)
        {
            var bindingList = new BindingList<EDJournalEntryMissionMining>(missions);
            var source = new BindingSource(bindingList, null);
            dgMissionMining.DataSource = source;

        }
    }
}
