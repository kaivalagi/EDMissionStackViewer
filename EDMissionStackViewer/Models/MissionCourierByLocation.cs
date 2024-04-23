using EDJournalQueue.Models;

namespace EDMissionStackViewer.Models
{
    public class MissionCourierByLocation
    {

        #region Properties

        public string Location { get; set; }
        public int TotalMissions { get; set; }
        public int Required { get; set; }
        public int Delivered { get; set; }
        public int Remaining => Required - Delivered;
        public decimal TotalReward { get; set; }
        public decimal SharedReward { get; set; }
        public decimal RewardPerTon => TotalReward / Required;
        public TimeSpan MinExpiry { get; set; }
        public TimeSpan MaxExpiry { get; set; }

        #endregion

        #region Constructor

        public MissionCourierByLocation(List<MissionCourierByLocation> summaryData)
        {
            this.Location = "Total";
            this.Required = summaryData.Sum(m => m.Required);
            this.Delivered = summaryData.Sum(m => m.Delivered);
            this.TotalMissions = summaryData.Sum(m => m.TotalMissions);
            this.TotalReward = summaryData.Sum(m => m.TotalReward);
            this.SharedReward = summaryData.Sum(m => m.SharedReward);
            this.MinExpiry = summaryData.Min(m => m.MinExpiry);
            this.MaxExpiry = summaryData.Max(m => m.MaxExpiry);
        }

        public MissionCourierByLocation(IGrouping<string, JournalEntryMissionCourier> missionData)
        {
            this.Location = missionData.Key;
            this.TotalMissions = missionData.Count();
            this.Required = missionData.Sum(m => m.Required);
            this.Delivered = missionData.Sum(m => m.Delivered);
            this.TotalReward = missionData.Sum(m => m.Reward);
            this.SharedReward = missionData.Where(m => m.Wing).Sum(m => m.Reward);
            this.MinExpiry = missionData.Min(m => m.Expiry) - DateTime.UtcNow;
            this.MaxExpiry = missionData.Max(m => m.Expiry) - DateTime.UtcNow;

        }

        #endregion

    }
}
