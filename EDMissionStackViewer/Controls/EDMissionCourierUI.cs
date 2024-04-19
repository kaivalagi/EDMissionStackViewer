using EDMissionStackViewer.Models;
using System.ComponentModel;

namespace EDMissionStackViewer.Controls
{
    public partial class EDMissionCourierUI : UserControl
    {
        public EDMissionCourierUI()
        {
            InitializeComponent();
        }

        public void LoadData(List<EDJournalEntryMissionCourier> missions)
        {
            var bindingList = new BindingList<EDJournalEntryMissionCourier>(missions);
            var source = new BindingSource(bindingList, null);
            dgMissionCourier.DataSource = source;

        }
    }
}
