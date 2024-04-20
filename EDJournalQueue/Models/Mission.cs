using Newtonsoft.Json.Linq;

namespace EDJournalQueue.Models
{
    public class Mission
    {

        #region Properties

        public JToken JToken { get; set; }
        public long MissionId { get; set; }
        public string Name { get; set; }
        public bool PassengerMission { get; set; }
        public long Expires { get; set; } = 0;

        #endregion

        #region Constructor

        public Mission(JToken activeMission)
        {
            JToken = activeMission;
            MissionId = (long)activeMission["MissionID"];
            Name = (string)activeMission["Name"];
            Expires = (long)activeMission["Expires"];
        }

        public Mission(JournalEntryMissionBase acceptedMission)
        {
            JToken = acceptedMission.JToken;
            MissionId = acceptedMission.MissionId;
            Name = acceptedMission.Name;
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
