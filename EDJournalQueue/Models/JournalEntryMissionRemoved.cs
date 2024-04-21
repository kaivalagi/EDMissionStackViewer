using Newtonsoft.Json.Linq;

namespace EDJournalQueue.Models
{
    public class JournalEntryMissionRemoved : JournalEntryMissionBase
    {

        #region Constructor

        public JournalEntryMissionRemoved(JToken entry) : base(entry)
        {

        }

        #endregion

    }
}
