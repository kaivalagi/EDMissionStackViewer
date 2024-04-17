using Newtonsoft.Json.Linq;

namespace EDMissionStackViewer.Models
{
    public class EDJournalMission
    {
        public string MissionId { get; set; }
        public string Name { get; set; }
        public bool PassengerMission { get; set; }
        public long Expires { get; set; }

        public EDJournalMission(JToken activeMission) { 
            MissionId = (string)activeMission["MissionID"];
            Name = (string)activeMission["Name"];
            Expires = (long)activeMission["Expires"];
        }   
    }
}
