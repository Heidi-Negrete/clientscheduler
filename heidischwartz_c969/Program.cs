using heidischwartz_c969.Forms;
using heidischwartz_c969.Models;

namespace heidischwartz_c969
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            
            var repository = new MySqlClientSchedulerRepository(new ClientSchedulerContext());
            var schedulerService = new SchedulerService(repository);
            Application.Run(new Login(schedulerService));
        }
    }
}