﻿using EDJournalQueue.Models;
using Newtonsoft.Json.Linq;

namespace EDJournalQueue.Extensions
{
    public static class JournalExtensions
    {

        #region Methods

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
                    break;
                    entry = new JournalEntryBounty(journalEntry);
                default:
                    entry = new JournalEntryBase(journalEntry);
                    break;
            }

            return entry;
        }

        public static void PopulateMissionsBounty(this List<JournalEntryMissionMassacre> journalEvents, JournalEntryBounty bounty)
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

        public static void PopulateMissionsCargoDepot(this List<object> journalEvents, JournalEntryCargoDepot cargoDepot)
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
                    default:
                        throw new ArgumentOutOfRangeException($"Unsupported mission type of '{missionType}'");
                }
            }
        }

        public static void PopulateMissionsCargoDepot(this List<JournalEntryMissionMining> journalEvents, JournalEntryCargoDepot cargoDepot)
        {
            var mission = journalEvents.Where(j => j.MissionId == cargoDepot.MissionId).FirstOrDefault();
            if (mission != null)
            {
                mission.DeliveredCount += cargoDepot.Count;
            }
        }

        public static void PopulateMissionsCargoDepot(this List<JournalEntryMissionCollect> journalEvents, JournalEntryCargoDepot cargoDepot)
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