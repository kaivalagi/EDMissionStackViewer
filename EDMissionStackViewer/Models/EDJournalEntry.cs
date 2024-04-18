using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace EDMissionStackViewer.Models
{
    public enum EDJournalEventType
    {
        Unknown = 0,
        Massacre = 1,
        Mining = 2,
        Collect = 3,
        Courier = 4,
        CargoDepot = 5,
        Bounty = 6
    }

    
    public class EDJournalEventBase
    {
        public JToken JToken { get; set; }
        public DateTime Timestamp { get; set; }
        public string Event { get; set; }
        public EDJournalEventType Type { get; set; }

        public EDJournalEventBase(JToken entry)
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

    public class EDJournalMissionBase : EDJournalEventBase
    {
        public long MissionId { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }


        public EDJournalMissionBase(JToken entry)  : base(entry) {
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

    public class EDJournalMissionMassacre : EDJournalMissionBase
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

        public EDJournalMissionMassacre(JToken entry) : base(entry)
        {
            Type = EDJournalEventType.Massacre;
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

    public class EDJournalMissionMining : EDJournalMissionBase
    {
        public string DestinationSystem { get; set; }
        public string DestinationStation { get; set; }
        public string Faction { get; set; }
        public int Reward { get; set; }
        public bool Wing { get; set; } = false;
        public DateTime Expiry { get; set; }
        public string Commodity { get; set; }
        public int Count { get; set; }
        public int DeliveredCount { get; set; } = 0;

        public EDJournalMissionMining(JToken entry) : base(entry)
        {
            DestinationSystem = (string)entry["DestinationSystem"];
            DestinationStation = (string)entry["DestinationStation"];
            Faction = (string)entry["Faction"];
            Reward = (int)entry["Reward"];

            if (entry["Wing"] != null)
            {
                Wing = true;
            }
            Expiry = (DateTime)entry["Expiry"];
            Type = EDJournalEventType.Mining;
            Commodity = (string)entry["Commodity_Localised"];
            Count = (int)entry["Count"];
        }
    }

    public class EDJournalMissionCollect: EDJournalMissionBase
    {
        public string DestinationSystem { get; set; }
        public string DestinationStation { get; set; }
        public string Faction { get; set; }
        public int Reward { get; set; }
        public bool Wing { get; set; } = false;
        public DateTime Expiry { get; set; }
        public string Commodity { get; set; }
        public int Count { get; set; }
        public int DeliveredCount { get; set; } = 0;

        public EDJournalMissionCollect(JToken entry) : base(entry)
        {
            Type = EDJournalEventType.Collect;
            DestinationSystem = (string)entry["DestinationSystem"];
            DestinationStation = (string)entry["DestinationStation"];
            Faction = (string)entry["Faction"];
            Reward = (int)entry["Reward"];

            if (entry["Wing"] != null)
            {
                Wing = true;
            }
            Expiry = (DateTime)entry["Expiry"];
            Commodity = (string)entry["Commodity_Localised"];
            Count = (int)entry["Count"];
        }
    }

    public class EDJournalMissionCourier: EDJournalMissionBase
    {
        public string DestinationSystem { get; set; }
        public string DestinationStation { get; set; }
        public string Faction { get; set; }
        public int Reward { get; set; }
        public bool Wing { get; set; } = false;
        public DateTime Expiry { get; set; }
        public string TargetFaction { get; set; }

        public EDJournalMissionCourier(JToken entry) : base(entry)
        {
            Type = EDJournalEventType.Courier;
            DestinationSystem = (string)entry["DestinationSystem"];
            DestinationStation = (string)entry["DestinationStation"];
            Faction = (string)entry["Faction"];
            Reward = (int)entry["Reward"];

            if (entry["Wing"] != null)
            {
                Wing = true;
            }
            Expiry = (DateTime)entry["Expiry"];
            TargetFaction = (string)entry["TargetFaction"];
        }
    }

    public class EDJournalCargoDepot : EDJournalEventBase
    {
        public long MissionId { get; set; }
        public string UpdateType { get; set; }
        public string CargoType { get; set; }
        public int Count { get; set; }


        public EDJournalCargoDepot(JToken entry) : base(entry)
        {
            Type = EDJournalEventType.CargoDepot;
            MissionId = (long)entry["MissionID"];
            UpdateType = (string)entry["UpdateType"];
            CargoType = (string)entry["CargoType_Localised"];
            Count = (int)entry["Count"];
        }
    }

    public class EDJournalBounty : EDJournalEventBase
    {
        public string VictimFaction { get; set; }
        public int TotalReward { get; set; }
        public string PilotName { get; set; }


        public EDJournalBounty(JToken entry) : base(entry)
        {
            Type = EDJournalEventType.Bounty;
            VictimFaction = (string)entry["VictimFaction"];
            TotalReward = (int)entry["TotalReward"];
            PilotName = (string)entry["PilotName_Localised"];
        }
    }


}
