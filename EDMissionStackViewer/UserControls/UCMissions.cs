using EDJournalQueue.Models;
using EDMissionStackViewer.Models;

namespace EDMissionStackViewer.UserControls
{
    public partial class UCMissions : UserControl
    {
        public bool ActiveMissions => (tabPageMissionCollect.Parent != null || tabPageMissionCourier.Parent != null || tabPageMissionMassacre.Parent != null || tabPageMissionMining.Parent != null);
        public bool ShowEmptyTabs = true;

        public UCMissions()
        {
            InitializeComponent();
        }

        public void ShowMissionCollect(List<JournalEntryMissionCollect> missions)
        {
            this.SuspendLayout();
            uiMissionCollect.SuspendLayout();
            uiMissionCollect.LoadData(missions);
            tabPageMissionCollect.Text = $"Collect [{missions.Count}]";
            tabPageMissionCollect.Parent = tabControlMissions;
            tabControlMissions.SelectTab(tabPageMissionCollect);
            uiMissionCollect.ResumeLayout();
            this.ResumeLayout();
        }
        public void ShowMissionCourier(List<JournalEntryMissionCourier> missions)
        {
            this.SuspendLayout();
            uiMissionCourier.SuspendLayout();
            uiMissionCourier.LoadData(missions);
            tabPageMissionCourier.Text = $"Courier [{missions.Count}]";
            tabPageMissionCourier.Parent = tabControlMissions;
            tabControlMissions.SelectTab(tabPageMissionCourier);
            uiMissionCourier.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        public void ShowMissionMassacre(List<JournalEntryMissionMassacre> missions)
        {
            this.SuspendLayout();
            uiMissionMassacre.SuspendLayout();
            uiMissionMassacre.LoadData(missions);
            tabPageMissionMassacre.Text = $"Massacre [{missions.Count}]";
            tabPageMissionMassacre.Parent = tabControlMissions;
            tabControlMissions.SelectTab(tabPageMissionMassacre);
            uiMissionMassacre.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        public void ShowMissionMining(List<JournalEntryMissionMining> missions)
        {
            this.SuspendLayout();
            uiMissionMining.SuspendLayout();
            uiMissionMining.LoadData(missions);
            tabPageMissionMining.Text = $"Mining [{missions.Count}]";
            tabPageMissionMining.Parent = tabControlMissions;
            tabControlMissions.SelectTab(tabPageMissionMining);
            uiMissionMining.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        public void HideAllMissions()
        {
            foreach (TabPage tabPage in tabControlMissions.TabPages)
            {
                tabPage.Parent = null;
            }
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
