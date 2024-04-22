using EDMissionStackViewer.Helpers;
using Microsoft.Extensions.DependencyInjection;
using System.ServiceProcess;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Hosting;
using Serilog;
using EDJournalQueue;

namespace EDMissionStackViewer
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            if (AppInstance.IsRunning())
            {
                MessageBox.Show($"{Application.ProductName} is already running", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ApplicationConfiguration.Initialize();

            var builder = new HostBuilder()
              .ConfigureServices((hostContext, services) =>
              {
                  services.AddSingleton<MissionStackViewer>();
                  services.AddSingleton<Watcher>();

                  var serilogLogger = new LoggerConfiguration()
                  .WriteTo.File("EDMissionStackViewer.log", rollingInterval: RollingInterval.Day, retainedFileCountLimit: 7)
                  .CreateLogger();
                  services.AddLogging(x =>
                  {
                      x.SetMinimumLevel(LogLevel.Information);
                      x.AddSerilog(logger: serilogLogger, dispose: true);
                  });
              });

            var host = builder.Build();

            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                var missionStackViewer = services.GetRequiredService<MissionStackViewer>();
                Application.Run(missionStackViewer);
            }

            AppInstance.Close();
        }


    }
}