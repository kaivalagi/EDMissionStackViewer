using EDJournalQueue.Extensions;
using Newtonsoft.Json.Linq;

namespace EDJournalQueue.Models
{
    public class Mission
    {

        #region Properties

        public JToken JToken { get; set; }
        public long MissionId { get; set; }
        public string Name { get; set; }
        public bool PassengerMission { get; set; }
        public long Expires { get; set; }

        #endregion

        #region Constructor

        public Mission(JToken activeMission)
        {
            JToken = activeMission;
            MissionId = activeMission.GetValue<long>("MissionID");
            Name = activeMission.GetValue<string>("Name");
            Expires = activeMission.GetValue<long>("Expires", 0);
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return JToken?.ToString();
        }

        #endregion

    }
}
