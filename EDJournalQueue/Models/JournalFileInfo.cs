namespace EDJournalQueue.Models
{
    public class JournalFileInfo
    {
        public string FilePath { get; set; }
        public string CmdrName { get; set; }
        public long FilePosition { get; set; }
        public JournalFileInfo(string filePath, string cmdrName)
        {
            FilePath = filePath;
            CmdrName = cmdrName;
            FilePosition = 0;
        }
    }
}
