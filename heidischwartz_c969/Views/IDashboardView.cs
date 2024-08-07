using heidischwartz_c969.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heidischwartz_c969.Views
{
    public interface IDashboardView : IView
    {
        public event EventHandler<EventArgs> AppointmentAdded;
        public event EventHandler<EventArgs> AppointmentChanged;
        public event EventHandler<EventArgs> AppointmentDeleted;
        public event EventHandler<EventArgs> DateChanged;
        public event EventHandler<EventArgs> LoggedOut;
        public event EventHandler<EventArgs> ReportRequested;
        public event EventHandler<EventArgs> ClientsManaged;

        public void Logout();

        public void BindData();
        public List<Appointment> Appointments { get; set; } // ?
        public string[] WeekDays { get; set; } // ?
        public List<string> Reports { get; set; }

        public List<Customer> Clients { get; set; } // for the dropdown combobox in appointment
        public string Username {  get; set; }
        public string LoginTime { get; set; }
        public DateTime dateTime { get; set; }
    }
}
