using Newtonsoft.Json.Linq;

namespace EDJournalQueue.Models
{

    public class JournalEntryBounty : JournalEntryBase
    {
        public string VictimFaction { get; set; }
        public int TotalReward { get; set; }
        public string PilotName { get; set; }


        public JournalEntryBounty(JToken entry) : base(entry)
        {
            Type = JournalEntryType.Bounty;
            VictimFaction = (string)entry["VictimFaction"];
            TotalReward = (int)entry["TotalReward"];
            PilotName = (string)entry["PilotName_Localised"];
        }
    }


}
