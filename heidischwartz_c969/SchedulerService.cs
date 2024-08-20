using heidischwartz_c969.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace heidischwartz_c969
{
    public class SchedulerService : ISchedulerService
    {
        // use an IClientSchedulerRepository instance to retrieve things needed from db
        private readonly IClientSchedulerRepository _repository;

        // cache appointments
        private List<Appointment> _appointments = new List<Appointment>();

        public SchedulerService(IClientSchedulerRepository repository)
        {
            if (repository == null) throw new ArgumentNullException("repository");
            _repository = repository;  
        }

        public bool Login(string username, string password)
        {
            // hardcoded for assessment, would validate against values from repository
            UserContext.Name = "test";
            UserContext.UserId = 1;
            if (username == "test" &&  password == "test") return true;
            return false;
        }

        public List<Appointment> GetAppointments(int userId)
        {
            // request appointments from repository in UTC time, based on filter constraints
            // filters and constrains within month of current date so that it does not pull ALL apts (ex 10 years worth)
            // cache results in _appointments

            DateTime today = DateTime.Now;
            DateTime firstDate = new DateTime(today.Year, today.Month, 1); // set to first day of this month
            DateTime lastDate = firstDate.AddMonths(1).AddTicks(-1); // set to last day of this month
            
            
            // is today the 6th or earlier of the month? if so, pull last week of previous month + this month
            // is today the last day of the month - 7? if so, pull next week of next month + this month
            // else just pull dates within this month.
            if (today.AddDays(-7).Month != today.Month)
            {
                firstDate = firstDate.AddDays(-7);
            }
            if (today.AddDays(7).Month != today.Month)
            {
                lastDate = lastDate.AddDays(7);
            } 
            
            _appointments = _repository.GetAppointments(userId, firstDate.ToUniversalTime(), lastDate.ToUniversalTime());
            
            // convert appts to local time
            foreach (Appointment appointment in _appointments)
            {
                appointment.Start = appointment.Start.ToLocalTime();
                appointment.End = appointment.End.ToLocalTime();
            }
            return _appointments;
        }

        public List<Appointment> GetTodaysAppointment()
        {
            // return local todays appts
            if (_appointments == null)
                return new List<Appointment>();
            var todaysAppointments = _appointments
                .Where(a => a.Start.Day == DateTime.Now.Day)
                .ToList();
            return todaysAppointments;
        }

        public List<Appointment>? GetWeekAppointments()
        {
            if (_appointments == null) return null;

            DateTime today = DateTime.Now;
            if (today.DayOfWeek == DayOfWeek.Sunday)
            {
                // return today and the next 6 days
            }
            else
            {
                // check yesterday is sunday?
                // actually consider using recursion to solve this problem.
            }
           
            return _appointments;
            // TODO
            // rethink format on data for the dgv, currently making no sense
            // also return null or empty list if no appointments?
        }

        public bool AddAppointment(Appointment appointment)
        {
            appointment.Start = appointment.Start.ToUniversalTime();
            appointment.End = appointment.End.ToUniversalTime();
            return false;
        }

        public bool DeleteAppointment(Appointment appointment)
        {
            _repository.DeleteAppointment(appointment);
            return false;
        }

        public bool UpdateAppointment(Appointment appointment)
        {
            appointment.Start = appointment.Start.ToUniversalTime();
            appointment.End = appointment.End.ToUniversalTime();
            _repository.UpdateAppointment(appointment);
            return false;
        }
    }
}
