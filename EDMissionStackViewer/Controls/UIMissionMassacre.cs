using EDJournalQueue.Models;
using System.ComponentModel;

namespace EDMissionStackViewer.Controls
{
    public partial class UIMissionMassacre : UserControl
    {
        public UIMissionMassacre()
        {
            InitializeComponent();
        }

        public void LoadData(List<JournalEntryMissionMassacre> missions)
        {
            var bindingList = new BindingList<JournalEntryMissionMassacre>(missions);
            var source = new BindingSource(bindingList, null);
            dgMissionMassacre.DataSource = source;

        }
    }
}
