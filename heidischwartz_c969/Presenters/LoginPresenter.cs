using heidischwartz_c969.Views;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace heidischwartz_c969.Presenters
{
    internal class LoginPresenter : Presenter
    {
        ILoginView View { get; set; }
        SchedulerService  Scheduler { get; set; }

        private readonly ILogger _logger;
        public LoginPresenter(ILoginView view, ILogger logger)
        {
            View = view;
            _logger = logger;
            View.LoginAttempted += View_LoginAttempted;
            Scheduler = View.Scheduler;
        }

        private void View_LoginAttempted(object sender, EventArgs e)
        {
            if (Scheduler.Login(View.Username, View.Password))
            {
                UserContext.Name = View.Username;
                _logger.Information("User {User} logged in", UserContext.Name);
                View.LoginAttempted -= View_LoginAttempted;
                View.LaunchDashboard();
                return;
            }
            View.FailLogin();
        }
    }
}
