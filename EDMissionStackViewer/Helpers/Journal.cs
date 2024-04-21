using Microsoft.Win32;
using System.Runtime.CompilerServices;

namespace EDMissionStackViewer.Helpers
{
    public static class Journal
    {

        public static DirectoryInfo GetDefaultJournalFolder()
        {
            var defaultPath = Path.Combine(Environment.GetEnvironmentVariable("USERPROFILE"), "Saved Games");
            var regKey = @"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders";
            var regKeyValue = "{4C5C32FF-BB9D-43b0-B5B4-2D72E54EAAA4}";
            var savedGamesFolder = (string)Registry.GetValue(regKey, regKeyValue, defaultPath);

            var journalFolder = Path.Combine(savedGamesFolder, @"Frontier Developments\Elite Dangerous");
            return new DirectoryInfo(journalFolder);
        }

        public static string ToDaysHoursMins(this TimeSpan timeSpan) {
            return string.Format("{0:%d} days, {0:%h} hrs, {0:%m} mins", timeSpan);
        }
    }
}
