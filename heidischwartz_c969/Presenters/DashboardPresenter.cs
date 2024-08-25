using heidischwartz_c969.Views;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using heidischwartz_c969.Models;

namespace heidischwartz_c969.Presenters
{
    internal class DashboardPresenter : Presenter
    {
        private readonly IDashboardView _view;

        private readonly ILogger _logger;

        public DashboardPresenter(IDashboardView view, ILogger logger)
        {
            _view = view;
            _logger = logger;
            _view.AppointmentAdded += AddAppointment;
            _view.AppointmentChanged += ChangeAppointment;
            _view.AppointmentDeleted += DeleteAppointment;
            _view.DateChanged += ChangeCurrentDate;
            _view.LoggedOut += Logout;
            _view.ReportRequested += GenerateReport;
            _view.ClientsManaged += ManageClients;

            PopulateView();
            
            // also start sleeps thread to check if any appointment time within 15 minutes
        }

        private void PopulateView()
        {
            // report options hardcoded for now
            List<string> availableReports = new List<string>{"Appointment Types", "Full Schedule", "Customer Activity" };
            _view.Reports.AddRange(availableReports);
            // fix this with new implementation.
            _view.Scheduler.GetAppointments(UserContext.UserId, DateTime.Now);
            
            // This is a hack to get the week to update when the date changes
            Appointment tempApp = new Appointment();
            tempApp.Start = DateTime.Now;
            
            _view.Appointments.AddRange(_view.Scheduler.GetTodaysAppointment(tempApp));

            _view.WeekDays.Add(_view.Scheduler.GetWeekAppointments(tempApp));
            _view.BindData();
        }
    private void AddAppointment(object sender, AppointmentEventArgs e)
        {
            // Currently doesn't make any sense since this is not how appt added and no appontment is passed into args
            _view.Scheduler.AddAppointment(e.Appointment);
            _view.Appointments.Clear();
            _view.Appointments.AddRange(_view.Scheduler.GetTodaysAppointment(e.Appointment));
            _view.WeekDays[0] = _view.Scheduler.GetWeekAppointments(e.Appointment);
            _view.UpdateBindingSources();
        }

        private void ChangeAppointment(object sender, AppointmentEventArgs e)
        {
            _view.Scheduler.UpdateAppointment(e.Appointment);
            _view.Appointments.Clear();
            _view.Appointments.AddRange(_view.Scheduler.GetTodaysAppointment(e.Appointment));
            _view.WeekDays[0] = _view.Scheduler.GetWeekAppointments(e.Appointment);
            _view.UpdateBindingSources();
        }

        private void DeleteAppointment(object sender, AppointmentEventArgs e)
        {
            _view.Scheduler.DeleteAppointment(e.Appointment);
            _view.Appointments.Clear();
            _view.Appointments.AddRange(_view.Scheduler.GetTodaysAppointment(e.Appointment));
            _view.WeekDays[0] = _view.Scheduler.GetWeekAppointments(e.Appointment);
            _view.UpdateBindingSources();
        }

        private void ChangeCurrentDate(object sender, DateRangeEventArgs e)
        {
            _view.Scheduler.GetAppointments(UserContext.UserId, e.Start);
            // This is a hack to get the week to update when the date changes
            Appointment tempApp = new Appointment();
            tempApp.Start = e.Start;
            _view.Appointments.Clear();
            _view.Appointments.AddRange(_view.Scheduler.GetTodaysAppointment(tempApp));
            _view.WeekDays[0] = _view.Scheduler.GetWeekAppointments(tempApp);
            _view.UpdateBindingSources();
        }

        private void Logout(object sender, EventArgs e)
        {
            _view.AppointmentAdded -= AddAppointment;
            _view.AppointmentChanged -= ChangeAppointment;
            _view.AppointmentDeleted -= DeleteAppointment;
            _view.DateChanged -= ChangeCurrentDate;
            _view.LoggedOut -= Logout;
            _view.ReportRequested -= GenerateReport;
            _view.ClientsManaged -= ManageClients;

            UserContext.Name = null;

            _view.Logout();
        }

        private void GenerateReport(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ManageClients(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public bool IsWithinBusinessHours(DateTime start, DateTime end)
        {
            // TODO between 9AM - 5pm Monday - Friday, Eastern Standard Time
            return false;
        }

        public bool IsOverlappingAppointment(DateTime start)
        {
            // TODO Making an assumption that 1hr appointment slots, get appointments from db sorted by start date/time and use binary search to check?
            return false;
        }

    }
}
