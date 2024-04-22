using Newtonsoft.Json.Linq;

namespace EDJournalQueue.Models
{

    public class JournalEntryMissionMining : JournalEntryMissionBase
    {

        #region Properties

        public string DestinationSystem { get; set; }
        public string DestinationStation { get; set; }
        public string Faction { get; set; }
        public decimal Reward { get; set; }
        public bool Wing { get; set; } = false;
        public DateTime Expiry { get; set; }
        public string Commodity { get; set; }
        public int Count { get; set; }
        public int DeliveredCount { get; set; } = 0;
        public string Influence { get; set; }
        public string Reputation { get; set; }

        #endregion

        #region Constructor

        public JournalEntryMissionMining(JToken entry) : base(entry)
        {
            DestinationSystem = (string)entry["DestinationSystem"];
            DestinationStation = (string)entry["DestinationStation"];
            Faction = (string)entry["Faction"];
            Reward = (int)entry["Reward"];

            if (entry["Wing"] != null)
            {
                Wing = true;
            }
            Expiry = (DateTime)entry["Expiry"];
            Type = JournalEntryType.Mining;
            Commodity = (string)entry["Commodity_Localised"];
            Count = (int)entry["Count"];
            Influence = (string)entry["Influence"];
            Reputation  = (string)entry["Reputation"];
        }

        #endregion

    }

}
