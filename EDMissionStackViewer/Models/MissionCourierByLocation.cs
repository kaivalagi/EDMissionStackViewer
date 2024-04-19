using EDJournalQueue.Models;

namespace EDMissionStackViewer.Models
{
    public class MissionCourierByLocation
    {

        public string Location { get; set; }
        public int TotalMissions { get; set; }
        public int Required { get; set; }
        public int Delivered { get; set; }
        public int Remaining => Required - Delivered;
        public int TotalReward { get; set; }
        public int SharedReward { get; set; }
        public int RewardPerTon => TotalReward / Required;
        public DateTime MinExpiry { get; set; }
        public DateTime MaxExpiry { get; set; }

        public MissionCourierByLocation(IGrouping<string,JournalEntryMissionCourier> missions) {            
            this.Location = missions.Key;
            this.TotalMissions = missions.Count();
            this.Required = missions.Sum(m=>m.Reward);
            this.Delivered = missions.Sum(m => m.Reward);
            this.TotalReward = missions.Sum(m => m.Reward);
            this.SharedReward = missions.Where(m => m.Wing).Sum(m => m.Reward);
            this.MinExpiry = missions.Min(m => m.Expiry);
            this.MaxExpiry = missions.Max(m => m.Expiry);

        }
    }
}
