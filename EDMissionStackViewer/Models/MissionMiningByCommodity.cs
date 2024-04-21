using EDJournalQueue.Models;

namespace EDMissionStackViewer.Models
{
    public class MissionMiningByCommodity
    {

        #region Properties

        public string Commodity { get; set; }
        public int TotalMissions { get; set; }
        public int Required { get; set; }
        public int Delivered { get; set; }
        public int Remaining => Required - Delivered;
        public int TotalReward { get; set; }
        public int SharedReward { get; set; }
        public int RewardPerTon => TotalReward / Required;
        public TimeSpan MinExpiry { get; set; }
        public TimeSpan MaxExpiry { get; set; }

        #endregion

        #region Constructor

        public MissionMiningByCommodity(List<MissionMiningByCommodity> summaryDataSource)
        {
            this.Commodity = "Total";
            this.Required = summaryDataSource.Sum(m => m.Required);
            this.Delivered = summaryDataSource.Sum(m => m.Delivered);
            this.TotalMissions = summaryDataSource.Sum(m => m.TotalMissions);
            this.TotalReward = summaryDataSource.Sum(m => m.TotalReward);
            this.SharedReward = summaryDataSource.Sum(m => m.SharedReward);
            this.MinExpiry = summaryDataSource.Min(m => m.MinExpiry);
            this.MaxExpiry = summaryDataSource.Max(m => m.MaxExpiry);
        }
        public MissionMiningByCommodity(IGrouping<string, JournalEntryMissionMining> missions)
        {
            this.Commodity = missions.Key;
            this.TotalMissions = missions.Count();
            this.Required = missions.Sum(m => m.Count);
            this.Delivered = missions.Sum(m => m.DeliveredCount);
            this.TotalReward = missions.Sum(m => m.Reward);
            this.SharedReward = missions.Where(m => m.Wing).Sum(m => m.Reward);
            this.MinExpiry = missions.Min(m => m.Expiry) - DateTime.UtcNow;
            this.MaxExpiry = missions.Max(m => m.Expiry) - DateTime.UtcNow;
        }

        #endregion

    }
}
