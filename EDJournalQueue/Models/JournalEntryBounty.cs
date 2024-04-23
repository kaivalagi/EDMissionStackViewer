using EDJournalQueue.Extensions;
using Newtonsoft.Json.Linq;

namespace EDJournalQueue.Models
{
    public class JournalEntryBounty : JournalEntryBase
    {

        #region Properties

        public string VictimFaction { get; set; }
        public decimal TotalReward { get; set; }
        public string PilotName { get; set; }

        #endregion

        #region Constructor

        public JournalEntryBounty(JToken entry) : base(entry)
        {
            Type = JournalEntryType.Bounty;
            VictimFaction = entry.GetValue<string>("VictimFaction");
            TotalReward = entry.GetValue<int>("TotalReward");
            PilotName = entry.GetValue<string>("PilotName_Localised");
        }

        #endregion

    }
}
