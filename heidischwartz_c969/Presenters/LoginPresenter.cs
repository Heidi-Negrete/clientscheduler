using heidischwartz_c969.Views;
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
        public LoginPresenter(ILoginView view)
        {
            View = view;
            View.LoginAttempted += View_LoginAttempted;
            Scheduler = View.Scheduler;
        }

        private void View_LoginAttempted(object sender, EventArgs e)
        {
            // to do implement login logic
            //UserContext.name = View.Username;
            if (Scheduler.Login(View.Username, View.Password))
            {
                UserContext.name = View.Username;
                View.LoginAttempted -= View_LoginAttempted;
                View.LaunchDashboard();
                return;
                // unsubscribe from events and switch to the Dashboard
            }
            View.FailLogin();
        }
    }
}
