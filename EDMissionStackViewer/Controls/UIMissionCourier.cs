using EDJournalQueue.Models;
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
            var bindingList = new BindingList<JournalEntryMissionCourier>(missions);
            var source = new BindingSource(bindingList, null);
            dgMissionCourier.DataSource = source;

        }
    }
}
