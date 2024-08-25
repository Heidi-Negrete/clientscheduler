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
        private readonly IClientSchedulerRepository _repository;

        // cache appointments every session
        private List<Appointment> _appointments = new List<Appointment>();

        public SchedulerService(IClientSchedulerRepository repository)
        {
            if (repository == null) throw new ArgumentNullException("repository");
            _repository = repository;  
        }

        public bool Login(string username, string password)
        {
            // hardcoded for assessment, irl would validate against values from repository
            UserContext.Name = "test";
            UserContext.UserId = 1;
            if (username == "test" &&  password == "test") return true;
            return false;
        }

        public List<Appointment> GetAppointments(int userId, DateTime today)
        {
            // request appointments from repository based on filter constraints to return all apts within month of current date so that it does not pull ALL apts (ex 10 years worth)
            // cache results in _appointments

            // using local time to set the constraints
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
            
            // dates converted to utc before requesting from repo
            // TODO if this is called a second time (e.g after new Date picked on calendar), it should not overwrite cache!
            //if (_appointments.Count == 0)
            //{
                _appointments = _repository.GetAppointments(userId, firstDate.ToUniversalTime(), lastDate.ToUniversalTime());
            //}
            //else
            //{
                // just use the ids from these appointments ugh :< poco? projection? new type inline?
                //var newAppointments = _repository.UpdateCache(userId, _appointments);
            //}
            
            // convert apts back to local time before returning to presenter
            foreach (Appointment appointment in _appointments)
            {
                appointment.Start = appointment.Start.ToLocalTime();
                appointment.End = appointment.End.ToLocalTime();
            }
            return _appointments;
        }

        public List<Appointment> GetTodaysAppointment(Appointment? appointment)
        {
            if (_appointments.Count == 0)
                return new List<Appointment>();

            // FIX THIS ISN't DAY OF MONTH
            int today = DateTime.Now.Day;
            
            if (appointment != null)
            {
                today = appointment.Start.Day;
            }
            
            var todaysAppointments = _appointments
                .Where(a => a.Start.Day == today)
                .ToList();
            return todaysAppointments;
        }

        public Week GetWeekAppointments(Appointment? appointment)
        {
            if (_appointments.Count == 0) return new Week();
            
            DateTime today = DateTime.Now;
            
            if (appointment != null)
            {
                today = appointment.Start;
            }

            // actually consider using recursion to solve this problem.
            while (today.DayOfWeek != DayOfWeek.Sunday)
            {
                today = today.AddDays(-1);
            }
            var weekAppointments = _appointments
                .Where(a => a.Start.Day >= today.Day && a.Start.Day <= today.AddDays(6).Day)
                .ToList();
            
            Week week = new Week();
            week.Sunday = weekAppointments.Where(a => a.Start.Day == today.Day).ToList();
            week.Tuesday = weekAppointments.Where(a => a.Start.Day == today.AddDays(1).Day).ToList();
            week.Wednesday = weekAppointments.Where(a => a.Start.Day == today.AddDays(2).Day).ToList();
            week.Thursday = weekAppointments.Where(a => a.Start.Day == today.AddDays(3).Day).ToList();
            week.Friday = weekAppointments.Where(a => a.Start.Day == today.AddDays(4).Day).ToList();
            week.Saturday = weekAppointments.Where(a => a.Start.Day == today.AddDays(5).Day).ToList();

            return week;
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
