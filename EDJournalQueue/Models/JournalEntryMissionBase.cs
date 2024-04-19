using Newtonsoft.Json.Linq;

namespace EDJournalQueue.Models
{
    public class JournalEntryMissionBase : JournalEntryBase
    {
        public long MissionId { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }


        public JournalEntryMissionBase(JToken entry) : base(entry)
        {
            MissionId = (long)entry["MissionID"];
            Name = (string)entry["Name"];

            Status = this switch
            {
                { Event: "MissionAccepted" } => "Active",
                { Event: "MissionCompleted" } => "Completed",
                { Event: "MissionAbandoned" } => "Abandoned",
                { Event: "MissionRedirected" } => "Redirected"
            };
        }
    }

}
