namespace EDMissionStackViewer.Models
{
    public class EDJournalFileInfo
    {
        public string FilePath { get; set; }
        public string CmdrName { get; set; }
        public long FilePosition { get; set; }
        public EDJournalFileInfo(string filePath, string cmdrName)
        {
            FilePath = filePath;
            CmdrName = cmdrName;
            FilePosition = 0;
        }
    }
}
