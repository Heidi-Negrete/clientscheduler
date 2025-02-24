using heidischwartz_c969.Presenters;
using heidischwartz_c969.Views;
using Serilog;
using System.Globalization;

namespace heidischwartz_c969.Forms
{
    public partial class Login : Form, ILoginView
    {
        private LoginPresenter _loginPresenter;
        private ErrorProvider _errorProvider;
        private ILogger _logger;
        public SchedulerService Scheduler { get; set; }
        public event EventHandler<EventArgs> LoginAttempted;
        private string location 
        { 
            get => this.lblLocation.Text;
            set => lblLocation.Text = value;
        }
        string ILoginView.Username { get => this.tbUsername.Text; set => tbUsername.Text = value; }
        string ILoginView.Password { get => this.tbPassword.Text; set => tbPassword.Text = value; }

        public Login(SchedulerService schedulerService, ILogger logger)
        {
            InitializeComponent();
            if (schedulerService == null) throw new ArgumentNullException("Scheduler Service");
            Scheduler = schedulerService;
            _logger = logger;
            _loginPresenter = new LoginPresenter(this, _logger);
            _errorProvider = new ErrorProvider();
            location = setUpLocalization();
        }

        private string setUpLocalization()
        {
            string userlocation = CultureInfo.CurrentCulture.Name;
            UserContext.Location = userlocation;
            
            if (userlocation == "de-DE")
            {
                lblLoginTitle.Text = "Einloggen auf Ihr Konto";
                btnLogin.Text = "Anmelden";
                lblWelcome1.Text = "Willkommen beim";
                lblWelcome2.Text = "Client Scheduler";
                btnForgotPassword.Text = "Passwort vergessen?";
                lblBy.Text = "Entwickelt von";
            }
            
            return userlocation;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbUsername.Text) || string.IsNullOrWhiteSpace(tbPassword.Text))
            {
                if (location == "de-DE")
                {
                    MessageBox.Show("Bitte geben Sie Ihren Benutzernamen und Ihr Passwort ein.");
                }
                else
                {
                    MessageBox.Show("Please enter your username and password.");
                }
                return;
            }
            LoginAttempted?.Invoke(this, EventArgs.Empty);
        }

        public void FailLogin()
        {
            if (location == "de-DE")
            {
                MessageBox.Show("Benutzername oder Passwort ungültig.");
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        private void btnForgotPassword_Click(object sender, EventArgs e)
        {
            if (location == "de-DE")
            {
                MessageBox.Show("Benutzername: test\\nPasswort: test");
            }
            else
            {
                MessageBox.Show("Username: test\\nPassword: test");
            }
        }
        public void LaunchDashboard()
        {
            this.Hide();
            var Dashboard = new MainDashboard(Scheduler, _logger);
            Dashboard.FormClosed += (s, args) => this.Close();
            Dashboard.Show();
        }

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