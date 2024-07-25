using heidischwartz_c969.Views;
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

        public DashboardPresenter(IDashboardView view)
        {
            _view = view;
            _view.AppointmentAdded += AddAppointment;
            _view.AppointmentChanged += ChangeAppointment;
            _view.AppointmentDeleted += DeleteAppointment;
            _view.DateChanged += ChangeCurrentDate;
            _view.LoggedOut += Logout;
            _view.ReportRequested += GenerateReport;
            _view.ClientsManaged += ManageClients;

            SchedulerService = _view.Scheduler;
            // _view.Username = "GetLoggedInUser(?)"
            // on login, need to get timestamp and append login info to
            // get reports (from CONFIG?), get Appointments, get days and set that data in view -> then call _view.BindData();
            // Weekdays is a list of strings each formatted w date and List of Appointments based on that time zone :/
        }

        private void AddAppointment(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ChangeAppointment(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DeleteAppointment(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ChangeCurrentDate(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Logout(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void GenerateReport(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ManageClients(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

    }
}
