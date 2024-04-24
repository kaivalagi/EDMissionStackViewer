using EDJournalQueue.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EDJournalQueue.Extensions
{
    public static class JournalExtensions
    {

        #region Methods

        public static T GetValue<T>(this JToken jToken, string key, T defaultValue = default(T))
        {
            dynamic ret = jToken[key];
            if (ret == null) return defaultValue;
            if (ret is JObject) return JsonConvert.DeserializeObject<T>(ret.ToString());
            return (T)ret;
        }

        public static object Populate(this JObject journalEntry)
        {
            object entry = null;

            switch (journalEntry["event"].ToString())
            {
                case "MissionAccepted":

                    var acceptedName = (string)journalEntry["Name"];
                    var onFoot = journalEntry.ContainsKey("OnFoot");
                    var targetType = journalEntry.ContainsKey("TargetType");

                    if (acceptedName.StartsWith("Mission_Massacre") && !onFoot && targetType)
                    {
                        entry = new JournalEntryMissionMassacre(journalEntry);
                    }
                    else if (acceptedName.StartsWith("Mission_Mining") && !onFoot)
                    {
                        entry = new JournalEntryMissionMining(journalEntry);
                    }
                    else if (acceptedName.StartsWith("Mission_Collect") && !onFoot)
                    {
                        entry = new JournalEntryMissionCollect(journalEntry);
                    }
                    else if (acceptedName.StartsWith("Mission_Courier") && !onFoot)
                    {
                        entry = new JournalEntryMissionCourier(journalEntry);
                    }
                    break;
                case "MissionCompleted":
                case "MissionAbandoned":
                case "MissionRedirected":
                    entry = new JournalEntryMissionRemoved(journalEntry);
                    break;
                case "CargoDepot":
                    entry = new JournalEntryCargoDepot(journalEntry);
                    break;
                case "Bounty":
                    entry = new JournalEntryBounty(journalEntry);
                    break;
                default:
                    entry = new JournalEntryBase(journalEntry);
                    break;
            }

            return entry;
        }

        //Original
        //public static void PopulateMissionFromBounty(this List<object> journalEvents, JournalEntryBounty bounty)
        //{
        //    var associatedMissions = journalEvents.OfType<JournalEntryMissionMassacre>().Where(j => j.TargetFaction == bounty.VictimFaction).ToList();
        //    var factions = new List<string>();

        //    foreach (var mission in associatedMissions)
        //    {
        //        if (!factions.Contains(mission.Faction))
        //        {
        //            if (mission.VictimCount < mission.KillCount)
        //            {
        //                mission.VictimCount++;
        //                factions.Add(mission.Faction);
        //            }
        //            else
        //            {
        //                continue;
        //            }
        //        }
        //    }
        //}

        public static void PopulateMissionFromBounty(this List<object> journalEvents, JournalEntryBounty bounty)
        {
            var associatedMissions = journalEvents.OfType<JournalEntryMissionMassacre>().Where(j => j.TargetFaction == bounty.VictimFaction && j.VictimCount < j.KillCount).ToList().DistinctBy(j => j.Faction);

            foreach (var mission in associatedMissions)
            {
                mission.VictimCount++;
            }
        }

        public static void PopulateMissionFromBounty(this List<JournalEntryMissionMassacre> journalEvents, JournalEntryBounty bounty)
        {
            var associatedMissions = journalEvents.Where(j => j.TargetFaction == bounty.VictimFaction).ToList();
            var factions = new List<string>();

            foreach (var mission in associatedMissions)
            {
                if (!factions.Contains(mission.Faction))
                {
                    if (mission.VictimCount == 0 || mission.VictimCount < mission.KillCount)
                    {
                        mission.VictimCount++;
                        factions.Add(mission.Faction);
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }

        public static void PopulateMissionFromCargoDepot(this List<object> journalEvents, JournalEntryCargoDepot cargoDepot)
        {
            var mission = journalEvents.OfType<JournalEntryMissionBase>().Where(j => j.MissionId == cargoDepot.MissionId).FirstOrDefault();
            if (mission != null)
            {
                var missionType = mission.GetType().Name;
                switch (missionType)
                {
                    case "JournalEntryMissionMining":
                        ((JournalEntryMissionMining)mission).DeliveredCount += cargoDepot.Count;
                        break;

                    case "JournalEntryMissionCollect":
                        ((JournalEntryMissionCollect)mission).DeliveredCount += cargoDepot.Count;
                        break;
                    //default:
                    //    throw new ArgumentOutOfRangeException($"Unsupported mission type of '{missionType}'");
                }
            }
        }

        public static void PopulateMissionFromCargoDepot(this List<JournalEntryMissionMining> journalEvents, JournalEntryCargoDepot cargoDepot)
        {
            var mission = journalEvents.Where(j => j.MissionId == cargoDepot.MissionId).FirstOrDefault();
            if (mission != null)
            {
                mission.DeliveredCount += cargoDepot.Count;
            }
        }

        public static void PopulateMissionFromCargoDepot(this List<JournalEntryMissionCollect> journalEvents, JournalEntryCargoDepot cargoDepot)
        {
            var mission = journalEvents.Where(j => j.MissionId == cargoDepot.MissionId).FirstOrDefault();
            if (mission != null)
            {
                mission.DeliveredCount += cargoDepot.Count;
            }
        }

        #endregion

    }
}
