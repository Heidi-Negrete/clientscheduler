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
        public LoginPresenter(ILoginView view)
        {
            View = view;
            View.LoginAttempted += View_LoginAttempted;
        }

        private void View_LoginAttempted(object sender, EventArgs e)
        {
            // to do implement login logic
            View.FailLogin();
        }
    }
}
