﻿using heidischwartz_c969.Presenters;
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
        public event EventHandler<EventArgs> AppointmentAdded;
        public event EventHandler<EventArgs> AppointmentChanged;
        public event EventHandler<EventArgs> AppointmentDeleted;
        public event EventHandler<EventArgs> DateChanged;
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
        public string[] WeekDays { get; set; } // watch
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
            var AppointmentBindingList = new BindingList<Appointment>(Appointments);
            dgvAppointments.DataSource = AppointmentBindingList;


            // TODO setup week view
            //var WeekDaysBindingList = new BindingList<string>(WeekDays);
            //dgvWeekView.DataSource = WeekDays;

            // TODO add combobox of reports

            lblHeadline.Text = $"{UserContext.Name}, you have {Appointments.Count} appointment{(Appointments.Count == 1 ? String.Empty : 's')} today";
        }

        private void btnAddAppt_Clicked(object sender, EventArgs e)
        {
            // TODO APPT OBJECT IN ARGS
            AppointmentAdded?.Invoke(this, EventArgs.Empty);
        }

        private void btnDeleteApt_Clicked(object sender, EventArgs e)
        {
            if (dgvAppointments.CurrentRow == null || !dgvAppointments.CurrentRow.Selected)
            {
                MessageBox.Show("Please select an appointment to delete.");
                return;
            }
            // TODO APPT OBJECT IN ARGS
            AppointmentDeleted?.Invoke(this, EventArgs.Empty);
        }
        private void dgvAppointments_Changed(object sender, DataGridViewCellEventArgs e)
        {
            // TODO APPT OBJECT IN ARGS
            AppointmentChanged?.Invoke(this, EventArgs.Empty);
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
            // TODO send dateSelected w event args
            DateChanged?.Invoke(this, EventArgs.Empty);
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
    }
}
