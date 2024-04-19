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
        Bounty = 6
    }


    public class JournalEntryBase
    {
        public JToken JToken { get; set; }
        public DateTime Timestamp { get; set; }
        public string Event { get; set; }
        public JournalEntryType Type { get; set; }

        public JournalEntryBase(JToken entry)
        {
            JToken = entry;
            Timestamp = (DateTime)entry["timestamp"];
            Event = (string)entry["event"];
        }

        public string ToString()
        {
            return JToken.ToString();
        }
    }
}
