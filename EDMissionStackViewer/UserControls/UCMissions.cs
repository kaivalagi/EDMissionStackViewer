using EDJournalQueue.Models;

namespace EDMissionStackViewer.UserControls
{
    public partial class UCMissions : UserControl
    {
        public bool ActiveMissions => (tabPageMissionCollect.Parent != null || tabPageMissionCourier.Parent != null || tabPageMissionMassacre.Parent != null || tabPageMissionMining.Parent != null);

        public UCMissions()
        {
            InitializeComponent();

            // remove parent link to hide until loaded
            foreach (TabPage tabPage in tabControlMissions.TabPages)
            {
                tabPage.Parent = null;
            }
        }

        public void ShowMissionCollect(List<JournalEntryMissionCollect> missions)
        {
            uiMissionCollect.LoadData(missions);
            tabPageMissionCollect.Parent = tabControlMissions;
            tabControlMissions.SelectTab(tabPageMissionCollect);
        }
        public void ShowMissionCourier(List<JournalEntryMissionCourier> missions)
        {
            uiMissionCourier.LoadData(missions);
            tabPageMissionCourier.Parent = tabControlMissions;
            tabControlMissions.SelectTab(tabPageMissionCourier);
        }
        public void ShowMissionMassacre(List<JournalEntryMissionMassacre> missions)
        {
            uiMissionMassacre.LoadData(missions);
            tabPageMissionMassacre.Parent = tabControlMissions;
            tabControlMissions.SelectTab(tabPageMissionMassacre);
        }

        public void ShowMissionMining(List<JournalEntryMissionMining> missions)
        {
            uiMissionMining.LoadData(missions);
            tabPageMissionMining.Parent = tabControlMissions;
            tabControlMissions.SelectTab(tabPageMissionMining);
        }

        public void HideMissionCollect()
        {
            tabPageMissionCollect.Parent = null;
        }

        public void HideMissionCourier()
        {
            tabPageMissionCourier.Parent = null;
        }

        public void HideMissionMassacre()
        {
            tabPageMissionMassacre.Parent = null;
        }

        public void HideMissionMining()
        {
            tabPageMissionMining.Parent = null;
        }
    }
}
