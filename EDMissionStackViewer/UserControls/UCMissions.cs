using EDJournalQueue.Models;
using EDMissionStackViewer.Models;
using System.Windows.Forms;

namespace EDMissionStackViewer.UserControls
{
    public partial class UCMissions : UserControl
    {
        public List<string> ActiveMissions { get; set; }
        public bool ShowEmptyTabs = true;

        public UCMissions()
        {
            InitializeComponent();
            ActiveMissions = new List<string>();
        }

        public void ShowMissionCollect(List<JournalEntryMissionCollect> missions)
        {
            uiMissionCollect.LoadData(missions);
            tabPageMissionCollect.Text = $"Collect [{missions.Count}]";
            tabPageMissionCollect.Parent = tabControlMissions;
            tabControlMissions.SelectTab(tabPageMissionCollect);
            ActiveMissions.Add(tabPageMissionCollect.Tag.ToString());
        }
        public void ShowMissionCourier(List<JournalEntryMissionCourier> missions)
        {
            uiMissionCourier.LoadData(missions);
            tabPageMissionCourier.Text = $"Courier [{missions.Count}]";
            tabPageMissionCourier.Parent = tabControlMissions;
            tabControlMissions.SelectTab(tabPageMissionCourier);
            ActiveMissions.Add(tabPageMissionCourier.Tag.ToString());
        }
        public void ShowMissionMassacre(List<JournalEntryMissionMassacre> missions)
        {
            uiMissionMassacre.LoadData(missions);
            tabPageMissionMassacre.Text = $"Massacre [{missions.Count}]";
            tabPageMissionMassacre.Parent = tabControlMissions;
            tabControlMissions.SelectTab(tabPageMissionMassacre);
            ActiveMissions.Add(tabPageMissionMassacre.Tag.ToString());
        }

        public void ShowMissionMining(List<JournalEntryMissionMining> missions)
        {
            uiMissionMining.LoadData(missions);
            tabPageMissionMining.Text = $"Mining [{missions.Count}]";
            tabPageMissionMining.Parent = tabControlMissions;
            tabControlMissions.SelectTab(tabPageMissionMining);
            ActiveMissions.Add(tabPageMissionMining.Tag.ToString());
        }

        public void HideAllMissions()
        {
            foreach (TabPage tabPage in tabControlMissions.TabPages)
            {
                tabPage.Parent = null;
                ActiveMissions.Remove(tabPage.Tag.ToString());
            }
        }

        public void HideMissionCollect()
        {
            tabPageMissionCollect.Parent = null;
            ActiveMissions.Remove(tabPageMissionMassacre.Tag.ToString());
        }

        public void HideMissionCourier()
        {
            tabPageMissionCourier.Parent = null;
            ActiveMissions.Remove(tabPageMissionMassacre.Tag.ToString());
        }

        public void HideMissionMassacre()
        {
            tabPageMissionMassacre.Parent = null;
            ActiveMissions.Remove(tabPageMissionMassacre.Tag.ToString());
        }

        public void HideMissionMining()
        {
            tabPageMissionMining.Parent = null;
            ActiveMissions.Remove(tabPageMissionMassacre.Tag.ToString());
        }
    }
}
