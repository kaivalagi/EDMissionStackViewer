using Newtonsoft.Json.Linq;

namespace EDJournalQueue.Models
{

    public class JournalEntryMissionCourier : JournalEntryMissionBase
    {

        #region Properties

        public string DestinationSystem { get; set; }
        public string DestinationStation { get; set; }
        public string Faction { get; set; }
        public int Required { get; set; }
        public int Delivered { get; set; }
        public int Remaining => Required - Delivered;
        public decimal Reward { get; set; }
        public bool Wing { get; set; } = false;
        public DateTime Expiry { get; set; }
        public string TargetFaction { get; set; }
        public string Influence { get; set; }
        public string Reputation { get; set; }

        #endregion

        #region Constructor

        public JournalEntryMissionCourier(JToken entry) : base(entry)
        {
            Type = JournalEntryType.Courier;
            DestinationSystem = (string)entry["DestinationSystem"];
            DestinationStation = (string)entry["DestinationStation"];
            Faction = (string)entry["Faction"];
            Required = 1;
            Delivered = 0;
            Reward = (int)entry["Reward"];

            if (entry["Wing"] != null)
            {
                Wing = true;
            }
            Expiry = (DateTime)entry["Expiry"];
            TargetFaction = (string)entry["TargetFaction"];
            Influence = (string)entry["Influence"];
            Reputation = (string)entry["Reputation"];
        }

        #endregion

    }

}
