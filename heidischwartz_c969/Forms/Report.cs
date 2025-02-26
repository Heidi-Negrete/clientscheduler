using System.Text;
using heidischwartz_c969.Models;

namespace heidischwartz_c969.Forms
{
    public partial class Report : Form
    {
        private readonly IClientSchedulerRepository _repository;
        private string reportType;
        private List<Appointment> appointments;
        
        public Report(IClientSchedulerRepository repository, string reportType)
        {
            InitializeComponent();
            _repository = repository;
            this.reportType = reportType;
            Console.WriteLine(reportType);
            tbReportInfo.Enabled = false;
            InitializeReport();
        }
        public async Task InitializeReport()
        {
            // the number of appointment types by month
            if (reportType == "Appointment Types")
            {
                lblReportTitle.Text = "Appointment Types by Month";
                await GetAptTypeByMonth();
            }
            //	the schedule for each unique user
            else if (reportType == "Full Schedule")
            {
                lblReportTitle.Text = "Schedule for Each User";
                await GetScheduleForEachUser();
            }
            // one additional report of your choice Clients by active / inactive? basically, if they have appointments scheduled.
            else if (reportType == "Customer Activity")
            {
                lblReportTitle.Text = "Clients by Active/Inactive";
                await GetClientsByActiveInactive();
            }
        }
        
        // the number of appointment types by month
        private async Task GetAptTypeByMonth()
        {
            appointments = await _repository.GetAppointments(UserContext.UserId, DateTime.Now.AddMonths(-12), DateTime.Now.AddMonths(12));
            var appointmentTypesByMonth = appointments
                .GroupBy(a => new { a.Start.Year, a.Start.Month, a.Type })
                .Select(g => new { g.Key.Year, g.Key.Month, g.Key.Type, Count = g.Count() })
                .OrderBy(g => g.Year).ThenBy(g => g.Month)
                .ToList();

            var report = new StringBuilder();
            int currentYear = 0;
            int currentMonth = 0;

            foreach (var appointmentType in appointmentTypesByMonth)
            {
                if (appointmentType.Year != currentYear || appointmentType.Month != currentMonth)
                {
                    currentYear = appointmentType.Year;
                    currentMonth = appointmentType.Month;
                    report.AppendLine($"{new DateTime(currentYear, currentMonth, 1):MMMM yyyy}");
                }
                report.AppendLine($"\t{appointmentType.Type}: {appointmentType.Count}");
            }

            tbReportInfo.Text = report.ToString();
        }

        private async Task GetScheduleForEachUser()
        {
            // get all the users. get all appointments for each user within this month.
            // the final result should be setting tbReportInfo.Text to a string with a list grouped by users with their appointments.
            var users = await _repository.GetUsers();
            appointments = new List<Appointment>();
            foreach (var user in users)
            {
                var userAppointments = await _repository.GetAppointments(user.UserId, new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1), new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)));
                appointments.AddRange(userAppointments);
            }
            var groupedAppointments = appointments.GroupBy(a => a.UserId)
                .Select(g => new { UserId = g.Key, Appointments = g.ToList() })
                .ToList();
            var report = new StringBuilder();
            foreach (var group in groupedAppointments)
            {
                var user = users.FirstOrDefault(u => u.UserId == group.UserId);
                report.AppendLine($"User: {user?.UserName}");
                foreach (var appointment in group.Appointments)
                {
                    report.AppendLine($"  Appointment: {appointment.Title} on {appointment.Start:MM/dd/yyyy h:mm tt}");
                }
            }
            tbReportInfo.Text = report.ToString();
            
        }

        private async Task GetClientsByActiveInactive()
        {
            var customers = await _repository.GetCustomers();
            var activeCustomers = customers.Where(c => c.Active).ToList();
            var inactiveCustomers = customers.Where(c => !c.Active).ToList();

            var report = new StringBuilder();
            report.AppendLine("ACTIVE CLIENTS");
            foreach (var customer in activeCustomers)
            {
                report.AppendLine(customer.CustomerName);
            }
            report.AppendLine();
            report.AppendLine("INACTIVE CLIENTS");
            foreach (var customer in inactiveCustomers)
            {
                report.AppendLine(customer.CustomerName);
            }

            tbReportInfo.Text = report.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}