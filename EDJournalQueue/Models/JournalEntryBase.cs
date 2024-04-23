using EDJournalQueue.Extensions;
using Newtonsoft.Json.Linq;

namespace EDJournalQueue.Models
{
    public enum JournalEntryType
    {
        Unknown = 0,
        Massacre = 1,
        Mining = 2,
        Collect = 3,
        Courier = 4,
        CargoDepot = 5,
        Bounty = 6,
    }


    public class JournalEntryBase
    {

        #region Properties

        public JToken JToken { get; set; }
        public DateTime Timestamp { get; set; }
        public string Event { get; set; }
        public JournalEntryType Type { get; set; }

        #endregion

        #region Constructor

        public JournalEntryBase(JToken entry)
        {
            JToken = entry;
            Timestamp = entry.GetValue<DateTime>("timestamp");
            Event = entry.GetValue<string>("event");
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return JToken?.ToString();
        }

        #endregion
    }
}
