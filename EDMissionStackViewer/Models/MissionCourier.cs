using EDJournalQueue.Models;

namespace EDMissionStackViewer.Models
{
    public class MissionCourier
    {

        #region Properties

        public string Location { get; set; }
        public string Faction { get; set; }
        public int Required { get; set; }
        public int Delivered { get; set; }
        public int Remaining => Required - Delivered;
        public int Reward { get; set; }
        public bool Shared { get; set; }
        public DateTime Expiry { get; set; }

        #endregion

        #region Constructor

        public MissionCourier(JournalEntryMissionCourier mission)
        {
            this.Location = $"{mission.DestinationSystem}\\{mission.DestinationStation}";
            this.Faction = mission.Faction;
            this.Required = mission.Required;
            this.Delivered = mission.Delivered;
            this.Reward = mission.Reward;
            this.Shared = mission.Wing;
            this.Expiry = mission.Expiry;
        }

        #endregion

    }
}
