using EDMissionStackViewer.Helpers;

namespace EDMissionStackViewer
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            if (AppInstance.IsRunning())
            {
                MessageBox.Show($"{Application.ProductName} is already running",Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new FormMissionStackViewer());

            AppInstance.Close();
        }
    }
}