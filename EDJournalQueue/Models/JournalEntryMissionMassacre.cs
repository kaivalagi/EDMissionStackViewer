using EDJournalQueue.Extensions;
using Newtonsoft.Json.Linq;

namespace EDJournalQueue.Models
{

    public class JournalEntryMissionMassacre : JournalEntryMissionBase
    {

        #region Properties

        public string DestinationSystem { get; set; }
        public string DestinationStation { get; set; }
        public string Faction { get; set; }
        public decimal Reward { get; set; }
        public bool Wing { get; set; } = false;
        public DateTime Expiry { get; set; }
        public string TargetType { get; set; }
        public string TargetFaction { get; set; }
        public int KillCount { get; set; }
        public int VictimCount { get; set; } = 0;
        public string Influence { get; set; }
        public string Reputation { get; set; }

        #endregion

        #region Constructor

        public JournalEntryMissionMassacre(JToken entry) : base(entry)
        {
            Type = JournalEntryType.Massacre;
            DestinationSystem = entry.GetValue<string>("DestinationSystem");
            DestinationStation = entry.GetValue<string>("DestinationStation");
            Faction = entry.GetValue<string>("Faction");
            Reward = entry.GetValue<int>("Reward");

            if (entry["Wing"] != null)
            {
                Wing = true;
            }
            Expiry = entry.GetValue<DateTime>("Expiry");
            TargetType = entry.GetValue<string>("TargetType");
            TargetFaction = entry.GetValue<string>("TargetFaction");
            KillCount = entry.GetValue<int>("KillCount");
            Influence = entry.GetValue<string>("Influence");
            Reputation = entry.GetValue<string>("Reputation");
        }

        #endregion

    }
}
