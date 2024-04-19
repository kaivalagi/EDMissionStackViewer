using Newtonsoft.Json.Linq;

namespace EDJournalQueue.Events
{
    public class JournalEntryQueueChangedEventArgs : EventArgs
    {
        public string CommanderName { get; set; }
        public JToken JToken { get; set; }
    }
}
