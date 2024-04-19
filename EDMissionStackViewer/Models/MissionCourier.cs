using EDJournalQueue.Models;

namespace EDMissionStackViewer.Models
{
    public class MissionCourier
    {
        public string Location { get; set; }
        public string Faction { get; set; }
        public int Reward { get; set; }
        public bool Shared { get; set; }
        public DateTime Expiry { get; set; }

        public MissionCourier(JournalEntryMissionCourier mission) {
            this.Location = $"{mission.DestinationSystem}\\{mission.DestinationStation}";
            this.Faction = mission.Faction;
            this.Reward = mission.Reward;
            this.Shared = mission.Wing;
            this.Expiry = mission.Expiry;
        }
    }
}
