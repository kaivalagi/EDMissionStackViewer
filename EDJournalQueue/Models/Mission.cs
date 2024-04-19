﻿using Newtonsoft.Json.Linq;

namespace EDJournalQueue.Models
{
    public class Mission
    {
        public JToken JToken { get; set; }
        public long MissionId { get; set; }
        public string Name { get; set; }
        public bool PassengerMission { get; set; }
        public long Expires { get; set; } = 0;

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

        public string ToString()
        {
            return JToken?.ToString();
        }
    }
}
