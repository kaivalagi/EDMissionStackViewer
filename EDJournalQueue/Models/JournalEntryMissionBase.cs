using EDJournalQueue.Extensions;
using Newtonsoft.Json.Linq;

namespace EDJournalQueue.Models
{

    public class JournalEntryMissionBase : JournalEntryBase
    {

        #region Properties

        public long MissionId { get; set; }
        public string Name { get; set; }

        #endregion

        #region Constructor

        public JournalEntryMissionBase(JToken entry) : base(entry)
        {
            MissionId = entry.GetValue<long>("MissionID");
            Name = entry.GetValue<string>("Name");
        }

        #endregion

    }

}
