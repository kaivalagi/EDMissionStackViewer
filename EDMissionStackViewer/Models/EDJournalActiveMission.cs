using Newtonsoft.Json.Linq;

namespace EDMissionStackViewer.Models
{
    public class EDJournalActiveMission
    {
        public JToken JToken { get; set; }
        public long MissionId { get; set; }
        public string Name { get; set; }
        public bool PassengerMission { get; set; }
        public long Expires { get; set; }

        public EDJournalActiveMission(JToken activeMission) { 
            JToken = activeMission;
            MissionId = (long)activeMission["MissionID"];
            Name = (string)activeMission["Name"];
            Expires = (long)activeMission["Expires"];
        }   

        public string ToString()
        {
            return JToken.ToString();
        }
    }
}
