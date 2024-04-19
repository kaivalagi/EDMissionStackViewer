﻿using Newtonsoft.Json.Linq;

namespace EDJournalQueue.Models
{

    public class JournalEntryMissionMassacre : JournalEntryMissionBase
    {
        public string DestinationSystem { get; set; }
        public string DestinationStation { get; set; }
        public string Faction { get; set; }
        public int Reward { get; set; }
        public bool Wing { get; set; } = false;
        public DateTime Expiry { get; set; }
        public string TargetType { get; set; }
        public string TargetFaction { get; set; }
        public int KillCount { get; set; }
        public int VictimCount { get; set; } = 0;

        public JournalEntryMissionMassacre(JToken entry) : base(entry)
        {
            Type = JournalEntryType.Massacre;
            DestinationSystem = (string)entry["DestinationSystem"];
            DestinationStation = (string)entry["DestinationStation"];
            Faction = (string)entry["Faction"];
            Reward = (int)entry["Reward"];

            if (entry["Wing"] != null)
            {
                Wing = true;
            }
            Expiry = (DateTime)entry["Expiry"];
            TargetType = (string)entry["TargetType"];
            TargetFaction = (string)entry["TargetFaction"];
            KillCount = (int)entry["KillCount"];
        }
    }

}
