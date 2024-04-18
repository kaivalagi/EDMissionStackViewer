using EDMissionStackViewer.Models;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace EDMissionStackViewer.Extensions
{
    public static class EDJournalExtensions
    {
        public static object Populate(this JObject journalEntry)
        {
            object entry = null;            

            switch (journalEntry["event"].ToString())
            {
                case "MissionAccepted":

                    var name = (string)journalEntry["Name"];
                    var onFoot = journalEntry.ContainsKey("OnFoot");
                    var targetType = journalEntry.ContainsKey("TargetType");

                    if (name.StartsWith("Mission_Massacre") && !onFoot && targetType)
                    {
                        entry = new EDJournalMissionMassacre(journalEntry);
                    }
                    else if (name.StartsWith("Mission_Mining") && !onFoot)
                    {
                        entry = new EDJournalMissionMining(journalEntry);
                    }
                    else if (name.StartsWith("Mission_Collect") && !onFoot)
                    {
                        entry = new EDJournalMissionCollect(journalEntry);
                    }
                    else if (name.StartsWith("Mission_Courier") && !onFoot)
                    {
                        entry = new EDJournalMissionCourier(journalEntry);
                    }
                    break;
                case "CargoDepot":
                    entry = new EDJournalCargoDepot(journalEntry);
                    break;
                case "Bounty":
                    break;
                    entry = new EDJournalBounty(journalEntry);
                default:
                    entry = new EDJournalEventBase(journalEntry);
                    break;
            }

            return entry;
        }



        //        def populate_missions_bounty(bounty: dict, missions: dict[int, dict]):
        //    changed = False
        //    associated_missions = [mission for mission in missions.values() if (mission["Name"].startswith("Mission_Massacre") and mission["TargetFaction"] == bounty["VictimFaction"])]
        //    if associated_missions:
        //        factions = []  
        //        for mission in associated_missions:
        //            if mission["Faction"] not in factions:

        //                if "VictimCount" not in mission or mission["VictimCount"] < mission["KillCount"]:
        //                    if "VictimCount" not in mission:
        //                        mission["VictimCount"] = 0
        //                    mission["VictimCount"] += 1
        //                    logger.info(f"Mission {mission['MissionID']} kill count increased")
        //                    factions.append(mission["Faction"])
        //                    changed = True
        //                else:
        //                    next

        //    return changed

        public static void PopulateMissionsBounty(this List<object> journalEvents, EDJournalBounty bounty)
        {
            var associatedMissions = journalEvents.OfType<EDJournalMissionMassacre>().Where(j => j.TargetFaction == bounty.VictimFaction).ToList();
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

        //def populate_missions_cargodepot(cargodepot: dict, missions: dict[int, dict]) :
        //    changed = False
        //    if cargodepot["MissionID"] in missions.keys():
        //        logger.info(f"Mission {cargodepot['MissionID']} cargo delivered")
        //        mission = missions[cargodepot["MissionID"]]
        //        if "DeliveredCount" not in mission:
        //            mission["DeliveredCount"] = 0
        //        mission["DeliveredCount"] += cargodepot["Count"]
        //        changes = True

        //    return changed

        public static void PopulateMissionsCargoDepot(this List<object> journalEvents, EDJournalCargoDepot cargoDepot)
        {
            var mission = journalEvents.OfType<EDJournalMissionBase>().Where(j => j.MissionId == cargoDepot.MissionId).FirstOrDefault();
            if (mission != null)
            {
                var missionType = mission.GetType().Name;
                switch (missionType)
                {
                    case "EDJournalMissionMining":
                        ((EDJournalMissionMining)mission).DeliveredCount += cargoDepot.Count;
                        break;

                    case "EDJournalMissionCollect":
                        ((EDJournalMissionCollect)mission).DeliveredCount += cargoDepot.Count;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException($"Unsupported mission type of '{missionType}'");
                }
            }
        }
    }
}
