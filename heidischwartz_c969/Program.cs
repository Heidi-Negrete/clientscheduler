using heidischwartz_c969.Forms;
using heidischwartz_c969.Models;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace heidischwartz_c969
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            var services = new ServiceCollection();
            services.AddLogging(builder => builder.AddSerilog(dispose: true));

            ApplicationConfiguration.Initialize();

            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Login_History.txt");

                Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File(path)
                .CreateLogger();

                var repository = new MySqlClientSchedulerRepository(new ClientSchedulerContext());
                var schedulerService = new SchedulerService(repository);
                Application.Run(new Login(schedulerService, Log.Logger));
                //Application.Run(new AddAppointment(schedulerService));
            }

        }
    }
}