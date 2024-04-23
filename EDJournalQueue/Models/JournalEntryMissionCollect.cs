using EDJournalQueue.Extensions;
using Newtonsoft.Json.Linq;

namespace EDJournalQueue.Models
{

    public class JournalEntryMissionCollect : JournalEntryMissionBase
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

        public JournalEntryMissionCollect(JToken entry) : base(entry)
        {
            Type = JournalEntryType.Collect;
            DestinationSystem = entry.GetValue<string>("DestinationSystem");
            DestinationStation = entry.GetValue<string>("DestinationStation");
            Faction = entry.GetValue<string>("Faction");
            Reward = entry.GetValue<int>("Reward");
            if (entry["Wing"] != null) Wing = true;
            Expiry = entry.GetValue<DateTime>("Expiry");
            Commodity = entry.GetValue<string>("Commodity_Localised");
            Count = entry.GetValue<int>("Count");
            Influence = entry.GetValue<string>("Influence");
            Reputation = entry.GetValue<string>("Reputation");
        }

        #endregion

    }

}
