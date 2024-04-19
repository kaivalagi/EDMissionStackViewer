using Newtonsoft.Json.Linq;

namespace EDJournalQueue.Events
{
    public class MissionsChangedEventArgs : EventArgs
    {
        public string CommanderName { get; set; }
        public long MissionId { get; set; }
        public JToken JToken { get; set; }
    }
}
