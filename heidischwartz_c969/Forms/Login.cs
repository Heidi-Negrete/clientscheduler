using Serilog;
using System.Globalization;

namespace heidischwartz_c969.Forms
{
    public partial class Login : Form
    {
        private ILogger _logger;
        private readonly IClientSchedulerRepository _repository;
        private string location { get => this.lblLocation.Text; set => lblLocation.Text = value; }
        private string Username { get => this.tbUsername.Text; set => tbUsername.Text = value; }
        private string Password { get => this.tbPassword.Text; set => tbPassword.Text = value; }

        public Login(IClientSchedulerRepository repository, ILogger logger)
        {
            InitializeComponent();
            if (repository == null) throw new ArgumentNullException("Database Repository");
            _repository = repository;
            _logger = logger;
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

            AttemptLogin();
        }

        private void AttemptLogin()
        {
            if (_repository.Login(Username, Password))
            {
                _logger.Information("User {User} logged in", UserContext.Name);
                LaunchDashboard();
                return;
            }
            FailLogin();
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
            var dashboard = new MainDashboard(_repository, _logger);
            dashboard.FormClosed += (s, args) => this.Close();
            dashboard.Show();
        }
    }
}