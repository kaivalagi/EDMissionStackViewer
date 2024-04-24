using EDJournalQueue.Models;

namespace EDMissionStackViewer.Models
{
    public class MissionMassacreByTargetFaction
    {

        #region Properties

        public string TargetFaction { get; set; }
        public int TotalMissions { get; set; }
        public int Required { get; set; }
        public int Killed { get; set; }
        public int Remaining => Required - Killed;
        public decimal TotalReward { get; set; }
        public decimal SharedReward { get; set; }
        public decimal RewardPerTon => TotalReward / Required;
        public TimeSpan MinExpiry { get; set; }
        public TimeSpan MaxExpiry { get; set; }

        #endregion

        #region Constructor

        public MissionMassacreByTargetFaction(List<MissionMassacreByTargetFaction> summaryData)
        {
            this.TargetFaction = "Total";
            this.Required = summaryData.Sum(m => m.Required);
            this.Killed = summaryData.Sum(m => m.Killed);
            this.TotalMissions = summaryData.Sum(m => m.TotalMissions);
            this.TotalReward = summaryData.Sum(m => m.TotalReward);
            this.SharedReward = summaryData.Sum(m => m.SharedReward);
            this.MinExpiry = summaryData.Min(m => m.MinExpiry);
            this.MaxExpiry = summaryData.Max(m => m.MaxExpiry);
        }

        public MissionMassacreByTargetFaction(IGrouping<string, JournalEntryMissionMassacre> missionData)
        {
            this.TargetFaction = missionData.Key;
            this.TotalMissions = missionData.Count();
            this.Required = missionData.Sum(m => m.KillCount);
            this.Killed = missionData.Sum(m => m.VictimCount);
            this.TotalReward = missionData.Sum(m => m.Reward);
            this.SharedReward = missionData.Where(m => m.Wing).Sum(m => m.Reward);
            this.MinExpiry = missionData.Min(m => m.Expiry) - DateTime.UtcNow;
            this.MaxExpiry = missionData.Max(m => m.Expiry) - DateTime.UtcNow;

        }

        #endregion

    }
}
