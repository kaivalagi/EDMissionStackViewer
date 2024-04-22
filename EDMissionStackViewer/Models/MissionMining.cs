using EDJournalQueue.Models;

namespace EDMissionStackViewer.Models
{
    public class MissionMining
    {

        #region Properties

        public string Location { get; set; }
        public string Commodity { get; set; }
        public int Required { get; set; }
        public int Delivered { get; set; }
        public int Remaining => Required - Delivered;
        public decimal Reward { get; set; }
        public bool Shared { get; set; }
        public string Influence { get; set; }
        public string Reputation { get; set; }
        public TimeSpan Expiry { get; set; }

        #endregion

        #region Constructor

        public MissionMining(JournalEntryMissionMining mission)
        {
            this.Location = $"{mission.DestinationSystem}\\{mission.DestinationStation}";
            this.Commodity = mission.Commodity;
            this.Required = mission.Count;
            this.Delivered = mission.DeliveredCount;
            this.Reward = mission.Reward;
            this.Shared = mission.Wing;
            this.Influence = mission.Influence;
            this.Reputation = mission.Reputation;
            this.Expiry = mission.Expiry - DateTime.UtcNow;
        }

        #endregion

    }
}
