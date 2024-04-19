using EDJournalQueue.Models;
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
            var bindingList = new BindingList<JournalEntryMissionCollect>(missions);
            var source = new BindingSource(bindingList, null);
            dgMissionCollect.DataSource = source;

        }
    }
}
