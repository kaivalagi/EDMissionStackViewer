using EDJournalQueue.Models;

namespace EDMissionStackViewer.Models
{
    public class MissionMassacre
    {

        #region Properties

        public string Location { get; set; }
        public string Faction { get; set; }
        public string TargetFaction { get; set; }
        public int Required { get; set; }
        public int Killed { get; set; }
        public int Remaining => Required - Killed;
        public decimal Reward { get; set; }
        public bool Shared { get; set; }
        public string Influence { get; set; }
        public string Reputation { get; set; }
        public DateTime Expiry { get; set; }

        #endregion

        #region Constructor

        public MissionMassacre(JournalEntryMissionMassacre mission)
        {
            this.Location = $"{mission.DestinationSystem}\\{mission.DestinationStation}";
            this.Faction = mission.Faction;
            this.TargetFaction = mission.TargetFaction;
            this.Required = mission.KillCount;
            this.Killed = mission.VictimCount;
            this.Reward = mission.Reward;
            this.Shared = mission.Wing;
            this.Influence = mission.Influence;
            this.Reputation = mission.Reputation;
            this.Expiry = mission.Expiry;
        }

        #endregion

    }
}
