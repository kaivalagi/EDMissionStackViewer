using EDJournalQueue.Models;

namespace EDMissionStackViewer.Models
{
    public class MissionMassacre
    {

        #region Properties

        public string Location { get; set; }
        public string Faction { get; set; }
        public int Required { get; set; }
        public int Killed { get; set; }
        public int Remaining => Required - Killed;
        public int Reward { get; set; }
        public bool Shared { get; set; }
        public DateTime Expiry { get; set; }

        #endregion

        #region Constructor

        public MissionMassacre(JournalEntryMissionMassacre mission) {
            this.Location = $"{mission.DestinationSystem}\\{mission.DestinationStation}";
            this.Faction = mission.Faction;
            this.Required = mission.KillCount;
            this.Killed = mission.VictimCount;
            this.Reward = mission.Reward;
            this.Shared = mission.Wing;
            this.Expiry = mission.Expiry;
        }

        #endregion

    }
}
