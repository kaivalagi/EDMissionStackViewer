namespace EDJournalQueue.Models
{
    public class JournalFileInfo
    {

        #region Properties

        public string FilePath { get; set; }
        public string CmdrName { get; set; }
        public long FilePosition { get; set; }
        public List<long> MissionIds { get; set; } = new List<long>();

        #endregion

        #region Constructor

        public JournalFileInfo(string filePath, string cmdrName)
        {
            FilePath = filePath;
            CmdrName = cmdrName;
            FilePosition = 0;
        }

        #endregion

    }
}
