using heidischwartz_c969.Forms;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heidischwartz_c969.Views
{
    internal interface ILoginView
    {
        public SchedulerService Scheduler { get; set; }
        public event EventHandler<EventArgs> LoginAttempted;
        public string Username { get; set; }
        public string Password { get; set; }
        public void FailLogin();
        public void LaunchDashboard();
    }
}
