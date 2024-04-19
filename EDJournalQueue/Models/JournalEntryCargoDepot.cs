using Newtonsoft.Json.Linq;

namespace EDJournalQueue.Models
{

    public class JournalEntryCargoDepot : JournalEntryBase
    {
        public long MissionId { get; set; }
        public string UpdateType { get; set; }
        public string CargoType { get; set; }
        public int Count { get; set; }


        public JournalEntryCargoDepot(JToken entry) : base(entry)
        {
            Type = JournalEntryType.CargoDepot;
            MissionId = (long)entry["MissionID"];
            UpdateType = (string)entry["UpdateType"];
            CargoType = (string)entry["CargoType_Localised"];
            Count = (int)entry["Count"];
        }
    }

}
