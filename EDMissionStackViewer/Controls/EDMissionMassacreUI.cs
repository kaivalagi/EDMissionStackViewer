using EDMissionStackViewer.Models;
using System.ComponentModel;

namespace EDMissionStackViewer.Controls
{
    public partial class EDMissionMassacreUI : UserControl
    {
        public EDMissionMassacreUI()
        {
            InitializeComponent();
        }

        public void LoadData(List<EDJournalEntryMissionMassacre> missions)
        {
            var bindingList = new BindingList<EDJournalEntryMissionMassacre>(missions);
            var source = new BindingSource(bindingList, null);
            dgMissionMassacre.DataSource = source;

        }
    }
}
