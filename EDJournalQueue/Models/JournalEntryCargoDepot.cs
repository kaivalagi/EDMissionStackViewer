using EDJournalQueue.Extensions;
using Newtonsoft.Json.Linq;

namespace EDJournalQueue.Models
{

    public class JournalEntryCargoDepot : JournalEntryBase
    {

        #region Properties

        public long MissionId { get; set; }
        public string UpdateType { get; set; }
        public string CargoType { get; set; }
        public int Count { get; set; }

        #endregion

        #region Constructor

        public JournalEntryCargoDepot(JToken entry) : base(entry)
        {
            Type = JournalEntryType.CargoDepot;
            MissionId = entry.GetValue<long>("MissionID");
            UpdateType = entry.GetValue<string>("UpdateType");
            CargoType = entry.GetValue<string>("CargoType_Localised");
            Count = entry.GetValue<int>("Count");
        }

        #endregion

    }
}
