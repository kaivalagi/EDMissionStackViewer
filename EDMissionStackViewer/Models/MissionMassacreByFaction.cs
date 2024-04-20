using EDJournalQueue.Models;

namespace EDMissionStackViewer.Models
{
    public class MissionMassacreByFaction
    {

        #region Properties

        public string Faction { get; set; }
        public int TotalMissions { get; set; }
        public int Required { get; set; }
        public int Killed { get; set; }
        public int Remaining => Required - Killed;
        public int TotalReward { get; set; }
        public int SharedReward { get; set; }
        public int RewardPerTon => TotalReward / Required;
        public DateTime MinExpiry { get; set; }
        public DateTime MaxExpiry { get; set; }

        #endregion

        #region Constructor

        public MissionMassacreByFaction(IGrouping<string,JournalEntryMissionMassacre> missions) {            
            this.Faction = missions.Key;
            this.TotalMissions = missions.Count();
            this.Required = missions.Sum(m=>m.KillCount);
            this.Killed = missions.Sum(m => m.VictimCount);
            this.TotalReward = missions.Sum(m => m.Reward);
            this.SharedReward = missions.Where(m => m.Wing).Sum(m => m.Reward);
            this.MinExpiry = missions.Min(m => m.Expiry);
            this.MaxExpiry = missions.Max(m => m.Expiry);

        }

        #endregion

    }
}
