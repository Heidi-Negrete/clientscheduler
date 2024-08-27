using heidischwartz_c969.Views;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using heidischwartz_c969.Models;
using Microsoft.EntityFrameworkCore.Query;

namespace heidischwartz_c969.Presenters
{
    internal class DashboardPresenter : Presenter
    {
        private readonly IDashboardView _view;

        private readonly ILogger _logger;

        private Week week;

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
            _view.WeekDayChanged += ChangeWeekDay;

            week = _view.Scheduler.getSchedule(DateTime.Now);

            _view.Appointments = week.Today;
            _view.WeekSummary = week.WeekSummary;

            // report options hardcoded for now
            List<string> availableReports = new List<string> { "Appointment Types", "Full Schedule", "Customer Activity" };
            _view.Reports.AddRange(availableReports);

            _view.BindData();

            // also start sleeps thread to check if any appointment time within 15 minutes
        }

        private void ChangeWeekDay(object? sender, WeekDayChangedEventArgs e)
        {
            switch (e.weekDayIndex)
            {
                case 0:
                    week.Today = week.Sunday;
                    break;
                case 1:
                    week.Today = week.Monday;
                    break;
                case 2:
                    week.Today = week.Tuesday;
                    break;
                case 3:
                    week.Today = week.Wednesday;
                    break;
                case 4:
                    week.Today = week.Thursday;
                    break;
                case 5:
                    week.Today = week.Friday;
                    break;
                case 6:
                    week.Today = week.Saturday;
                    break;
                default: break;
            }
            _view.Appointments = week.Today;
            _view.UpdateBindingSources();

        }
    private void AddAppointment(object sender, AppointmentEventArgs e)
        {
            _view.Scheduler.AddAppointment(e.Appointment);
            week = _view.Scheduler.getSchedule(week.TargetDate);
            _view.Appointments = week.Today;
            _view.WeekSummary = week.WeekSummary;
            _view.UpdateBindingSources();
        }

        private void ChangeAppointment(object sender, AppointmentEventArgs e)
        {

            _view.Scheduler.UpdateAppointment(e.Appointment);
            week = _view.Scheduler.getSchedule(week.TargetDate);
            _view.Appointments = week.Today;
            _view.WeekSummary = week.WeekSummary;
            _view.UpdateBindingSources();
        }

        private void DeleteAppointment(object sender, AppointmentEventArgs e)
        {
            _view.Scheduler.DeleteAppointment(e.Appointment);
            week = _view.Scheduler.getSchedule(week.TargetDate);
            _view.Appointments = week.Today;
            _view.WeekSummary = week.WeekSummary;
            _view.UpdateBindingSources();
        }

        private void ChangeCurrentDate(object sender, DateRangeEventArgs e)
        {
            week = _view.Scheduler.getSchedule(e.Start);
            _view.Appointments = week.Today;
            _view.WeekSummary = week.WeekSummary;
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

            // TODO add try/catch on add/update/delete apt, log error and display error in view
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
            // this shouldn't be necessary here, available start times will be given to form for validation
            return false;
        }

        public bool IsOverlappingAppointment(DateTime start)
        {
            // TODO Making an assumption that 1hr appointment slots, get appointments from db sorted by start date/time and use binary search to check?
            // again handled elsewhere
            return false;
        }

    }
}
