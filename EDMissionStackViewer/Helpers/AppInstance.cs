namespace EDMissionStackViewer.Helpers
{
    public static class AppInstance
    {

        private static Semaphore _semaphore;
        public static string Identifier { get; private set; } = "5FCF5D4A-D401-4706-96B8-DCCDB95E5975";

        public static bool IsRunning()
        {
            try
            {
                _semaphore = Semaphore.OpenExisting($"Global\\{Identifier}");
                
                Close();
                return true;
            }
            catch (Exception ex)
            {
                _semaphore = new Semaphore(0, 1, $"Global\\{Identifier}");
                return false;
            }
        }


        public static void Close()
        {
            if (_semaphore != null)
            {
                _semaphore.Close();
                _semaphore = null;
            }
        }
    }
}
