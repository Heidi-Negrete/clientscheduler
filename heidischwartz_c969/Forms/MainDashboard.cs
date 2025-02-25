using heidischwartz_c969.Presenters;
using heidischwartz_c969.Views;
using heidischwartz_c969.Models;
using Serilog;

namespace heidischwartz_c969.Forms
{
    public partial class MainDashboard : Form, IDashboardView
    {
        public event EventHandler<AppointmentEventArgs> AppointmentAdded;
        public event EventHandler<AppointmentEventArgs> AppointmentChanged;
        public event EventHandler<AppointmentEventArgs> AppointmentDeleted;
        public event EventHandler<DateRangeEventArgs> DateChanged;
        public event EventHandler<WeekDayChangedEventArgs> WeekDayChanged;
        public event EventHandler<EventArgs> LoggedOut;
        public event EventHandler<EventArgs> ReportRequested;
        public event EventHandler<EventArgs> ClientsManaged;
        public SchedulerService Scheduler { get; set; }

        private DashboardPresenter _dashboardPresenter;
        private ErrorProvider _errorProvider;
        public List<string> Reports { get; set; } = new List<string>();

        // Today's Appointments
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();

        private IAddAppointment? AddAppointmentForm = null;

        // This Week's Appointments
        public List<WeekSummaryView> WeekSummary { get; set; } = new List<WeekSummaryView>();

        public List<Customer> Clients { get; set; } = new List<Customer>();
        public DateTime dateTime { get; set; }
        public string Username { get => this.lblUserStamp.Text; set => lblUserStamp.Text = value; }
        public string LoginTime { get => this.lblLoginStamp.Text; set => lblLoginStamp.Text = value; }

        private readonly ILogger _logger;

        public MainDashboard(SchedulerService scheduler, ILogger logger)
        {
            InitializeComponent();
            _logger = logger;
            _errorProvider = new ErrorProvider();
            Scheduler = scheduler;
            lblLoginStamp.Text = "Logged in at \n" + DateTime.Now.ToString();
            lblUserStamp.Text = UserContext.Name;
            _dashboardPresenter = new DashboardPresenter(this, _logger);
            cbReports.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void BindData()
        {
            dgvAppointments.AutoGenerateColumns = false;
            dgvWeekView.AutoGenerateColumns = false;
            dgvWeekView.ShowCellToolTips = false;
            dgvWeekView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvWeekView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            cbReports.DataSource = Reports;

            UpdateBindingSources();
        }

        public void ShowError(string message)
        {
            if (AddAppointmentForm != null)
            {
                AddAppointmentForm.ShowError(message);
            }
            else
            {
                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddAppt_Clicked(object sender, EventArgs e)
        {
            var AddAptForm = new AddAppointment(Clients);
            AddAppointmentForm = (IAddAppointment)AddAptForm;
            AddAptForm.Show();

            // prevent user from interacting with dashboard while adding appointment
            AddAptForm.FormClosed += (s, args) => 
            {
                this.Enabled = true;
                AddAppointmentForm = null;
            };
        }

        private void btnDeleteApt_Clicked(object sender, EventArgs e)
        {
            if (dgvAppointments.CurrentCell == null || !dgvAppointments.CurrentCell.Selected)
            {
                MessageBox.Show("Please select an appointment to delete.");
                return;
            }
            DialogResult result = MessageBox.Show("Are you sure you want to delete this appointment?", "Delete Appointment", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                AppointmentDeleted?.Invoke(this, new AppointmentEventArgs((Appointment)dgvAppointments.CurrentRow.DataBoundItem));
            }     
        }
        private void dgvAppointments_Changed(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAppointments.CurrentRow?.DataBoundItem is Appointment appointment)
            {
                AppointmentChanged?.Invoke(this, new AppointmentEventArgs(appointment));
            }
        }

        private void btnManageClients_Clicked(object sender, EventArgs e)
        {
            var manageClientsForm = new ManageClients(Scheduler);
            manageClientsForm.Show();

            // prevent user from interacting with dashboard while managing clients
            this.Enabled = false;
            manageClientsForm.FormClosed += (s, args) =>
            {
                this.Enabled = true;
                ClientsManaged?.Invoke(this, EventArgs.Empty);
            };
        }

        private void btnGenerateReport_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (cbReports.SelectedIndex == 0)
                {
                    MessageBox.Show("Please select a report format.");
                    return;
                }
                // to do in future: add report generation logic add report name in args?
                ReportRequested?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                _logger.Error("Error generating report: {Message}", ex.Message);
                ShowError("An error occurred while generating the report.");
            }
        }

        private void btnLogout_Clicked(object sender, EventArgs e)
        {
            LoggedOut?.Invoke(this, EventArgs.Empty);
        }

        private void monthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime dateSelected = monthCalendar.SelectionRange.Start;
            DateChanged?.Invoke(this, new DateRangeEventArgs(dateSelected, dateSelected));
        }

        private void dgvAppointments_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvAppointments.ClearSelection();
        }

        private void dgvWeekView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvWeekView.ClearSelection();
        }

        public void Logout()
        {
            this.Hide();
            var Login = new Login(Scheduler, _logger);
            Login.FormClosed += (s, args) => this.Close();
            Login.Show();
        }

        public void UpdateBindingSources()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(UpdateBindingSources));
                return;
            }

            dgvAppointments.DataSource = null;
            dgvAppointments.DataSource = Appointments;
            dgvWeekView.DataSource = null;
            dgvWeekView.DataSource = WeekSummary;
            lblHeadline.Text = $"{UserContext.Name}, you have {Appointments.Count} appointment{(Appointments.Count == 1 ? String.Empty : 's')} today";
        }

        private void dgvWeekView_DayClicked(object sender, DataGridViewCellMouseEventArgs e)
        {
            WeekDayChanged?.Invoke(this, new WeekDayChangedEventArgs(e.ColumnIndex));
        }
    }
}
