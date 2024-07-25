using heidischwartz_c969.Presenters;
using heidischwartz_c969.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace heidischwartz_c969.Forms
{
    public partial class Login : Form, ILoginView
    {
        private LoginPresenter _loginPresenter;
        private ErrorProvider _errorProvider;
        public SchedulerService Scheduler { get; set; }
        public event EventHandler<EventArgs> LoginAttempted;
        string ILoginView.Username { get => this.tbUsername.Text; set => tbUsername.Text = value; }
        string ILoginView.Password { get => this.tbPassword.Text; set => tbPassword.Text = value; }

        public Login(SchedulerService schedulerService)
        {
            InitializeComponent();
            if (schedulerService == null) throw new ArgumentNullException("Scheduler Service");
            Scheduler = schedulerService;
            _loginPresenter = new LoginPresenter(this);
            _errorProvider = new ErrorProvider();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbUsername.Text) ||
                string.IsNullOrWhiteSpace(tbPassword.Text))
            {
                MessageBox.Show("Please enter a username and password.");
                return;
            }
            LoginAttempted?.Invoke(this, EventArgs.Empty);
        }

        private void btnForgotPassword_Click(object sender, EventArgs e)
        {
            //hardcoded values for evaluation just for fun :)
            MessageBox.Show("Username: test\nPassword: test");
        }

        public void FailLogin()
        {
            MessageBox.Show("Login Failed. Please check your username and password and try again.");
        }

        public void LaunchDashboard()
        {
            this.Hide();
            var Dashboard = new MainDashboard(Scheduler);
            Dashboard.FormClosed += (s, args) => this.Close();
            Dashboard.Show();
        }

        // THIS CURRENTLY DOES NOT WORK.
        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MessageBox.Show("trying");
                btnLogin_Click(sender, e);
            }
        }
    }
}
