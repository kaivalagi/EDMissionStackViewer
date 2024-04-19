using EDJournalQueue.Models;
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
            var bindingList = new BindingList<JournalEntryMissionMining>(missions);
            var source = new BindingSource(bindingList, null);
            dgMissionMining.DataSource = source;

        }
    }
}
