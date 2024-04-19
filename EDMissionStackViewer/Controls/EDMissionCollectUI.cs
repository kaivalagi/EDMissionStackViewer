using EDMissionStackViewer.Models;
using System.ComponentModel;

namespace EDMissionStackViewer.Controls
{
    public partial class EDMissionCollectUI : UserControl
    {
        public EDMissionCollectUI()
        {
            InitializeComponent();
        }

        public void LoadData(List<EDJournalEntryMissionCollect> missions)
        {
            var bindingList = new BindingList<EDJournalEntryMissionCollect>(missions);
            var source = new BindingSource(bindingList, null);
            dgMissionCollect.DataSource = source;

        }
    }
}
