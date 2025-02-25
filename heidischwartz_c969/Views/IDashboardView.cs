using heidischwartz_c969.Models;

namespace heidischwartz_c969.Views
{
    public interface IDashboardView
    {
        public SchedulerService Scheduler { get; set; }
        public event EventHandler<AppointmentEventArgs> AppointmentAdded;
        public event EventHandler<AppointmentEventArgs> AppointmentChanged;
        public event EventHandler<AppointmentEventArgs> AppointmentDeleted;
        public event EventHandler<DateRangeEventArgs> DateChanged;
        public event EventHandler<WeekDayChangedEventArgs> WeekDayChanged;
        public event EventHandler<EventArgs> LoggedOut;
        public event EventHandler<EventArgs> ReportRequested;
        public event EventHandler<EventArgs> ClientsManaged;

        public void Logout();

        public void UpdateBindingSources();

        public void ShowError(string message);

        public void BindData();
        public List<Appointment> Appointments { get; set; }
        public List<WeekSummaryView> WeekSummary { get; set; }
        public List<string> Reports { get; set; }

        public List<Customer> Clients { get; set; }
        public string Username {  get; set; }
        public string LoginTime { get; set; }
        public DateTime dateTime { get; set; }
    }
}
