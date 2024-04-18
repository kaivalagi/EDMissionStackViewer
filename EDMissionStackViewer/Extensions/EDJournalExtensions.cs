using EDMissionStackViewer.Models;
using Newtonsoft.Json.Linq;

namespace EDMissionStackViewer.Extensions
{
    public static class EDJournalExtensions
    {
        public static dynamic Populate(this JObject journalEntry)
        {
            dynamic entry = null;            

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

    }
}
