using heidischwartz_c969.Presenters;
using heidischwartz_c969.Views;
using heidischwartz_c969.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Serilog;

namespace heidischwartz_c969.Forms
{
    public partial class MainDashboard : Form, IDashboardView
    {
        public event EventHandler<AppointmentEventArgs> AppointmentAdded;
        public event EventHandler<AppointmentEventArgs> AppointmentChanged;
        public event EventHandler<AppointmentEventArgs> AppointmentDeleted;
        public event EventHandler<DateRangeEventArgs> DateChanged;
        public event EventHandler<EventArgs> LoggedOut;
        public event EventHandler<EventArgs> ReportRequested;
        public event EventHandler<EventArgs> ClientsManaged;

        public SchedulerService Scheduler {  get; set; }
        private DashboardPresenter _dashboardPresenter;
        private ErrorProvider _errorProvider;
        public List<string> Reports { get; set; } = new List<string>();
        
        // Today's Appointments
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();

        // This Week's Appointments
        public List<Week> WeekDays { get; set; } = new List<Week>();
        
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
        }

        public void BindData()
        {
            cbReports.Items.Add(Reports);

            dgvAppointments.AutoGenerateColumns = false;
            dgvWeekView.AutoGenerateColumns = false;

            // TODO add combobox of reports

            UpdateBindingSources();
        }

        private void btnAddAppt_Clicked(object sender, EventArgs e)
        {
            // TODO Add Apt form w all necessary validation
            AppointmentAdded?.Invoke(this, new AppointmentEventArgs(new Appointment()));
        }

        private void btnDeleteApt_Clicked(object sender, EventArgs e)
        {
            if (dgvAppointments.CurrentCell == null || !dgvAppointments.CurrentCell.Selected)
            {
                MessageBox.Show("Please select an appointment to delete.");
                return;
            }
            AppointmentDeleted?.Invoke(this, new AppointmentEventArgs((Appointment)dgvAppointments.CurrentRow.DataBoundItem));
        }
        private void dgvAppointments_Changed(object sender, DataGridViewCellEventArgs e)
        {
            AppointmentChanged?.Invoke(this, new AppointmentEventArgs((Appointment)dgvAppointments.CurrentRow.DataBoundItem));
        }

        private void btnManageClients_Clicked(object sender, EventArgs e)
        {
            // TODO new client/manage client form
            throw new NotImplementedException();
        }

        private void btnGenerateReport_Clicked(object sender, EventArgs e)
        {
            if (cbReports.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a report format.");
                return;
            }
            // TODO Include name of report in args
            ReportRequested?.Invoke(this, EventArgs.Empty);
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
            dgvAppointments.DataSource = null;
            dgvAppointments.DataSource = Appointments;
            dgvWeekView.DataSource = null;
            dgvWeekView.DataSource = WeekDays;
            lblHeadline.Text = $"{UserContext.Name}, you have {Appointments.Count} appointment{(Appointments.Count == 1 ? String.Empty : 's')} today";
}
    }
}
