﻿using heidischwartz_c969.Views;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heidischwartz_c969.Presenters
{
    internal class DashboardPresenter : Presenter
    {
        IDashboardView _view { get; set; }
        SchedulerService SchedulerService { get; set; }

        private ILogger _logger;

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

            SchedulerService = _view.Scheduler;

            PopulateView();
        }

        private void PopulateView()
        {
            // get reports (from CONFIG?), get Appointments, get days and set that data in view -> then call _view.BindData();
            // Weekdays is a list of strings each formatted w date and List of Appointments based on that time zone formating done in scheduler :/
            //_view.BindData();
        }
    private void AddAppointment(object sender, EventArgs e)
        {
            // update _view.Appointments
            throw new NotImplementedException();
        }

        private void ChangeAppointment(object sender, EventArgs e)
        {
            // update _view.Appointments
            throw new NotImplementedException();
        }

        private void DeleteAppointment(object sender, EventArgs e)
        {
            // update _view.Appointments
            throw new NotImplementedException();
        }

        private void ChangeCurrentDate(object sender, EventArgs e)
        {
            // update _view.Appointments
            throw new NotImplementedException();
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
