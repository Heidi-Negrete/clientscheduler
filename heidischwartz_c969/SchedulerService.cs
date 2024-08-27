using heidischwartz_c969.Models;
using Microsoft.VisualBasic.ApplicationServices;
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

        public Week getSchedule(DateTime date)
        {
            Week thisWeek = new Week();

            thisWeek.TargetDate = date;

            DateTime firstDayOfWeek = new DateTime(date.Year, date.Month, date.Day);

            while (firstDayOfWeek.DayOfWeek != DayOfWeek.Sunday)
            {
                firstDayOfWeek = firstDayOfWeek.AddDays(-1);
            }

            // get appointments from repository
            List<Appointment> appointments = _repository.GetAppointments(UserContext.UserId, firstDayOfWeek.ToUniversalTime(), firstDayOfWeek.AddDays(6).ToUniversalTime());

            // convert apts back to local time before assigning to week, which is local time
            foreach (Appointment appointment in appointments)
            {
                appointment.Start = appointment.Start.ToLocalTime();
                appointment.End = appointment.End.ToLocalTime();
            }

            thisWeek.Sunday = appointments.Where(a => a.Start.Day == firstDayOfWeek.Day).ToList();
            thisWeek.Tuesday = appointments.Where(a => a.Start.Day == firstDayOfWeek.AddDays(1).Day).ToList();
            thisWeek.Wednesday = appointments.Where(a => a.Start.Day == firstDayOfWeek.AddDays(2).Day).ToList();
            thisWeek.Thursday = appointments.Where(a => a.Start.Day == firstDayOfWeek.AddDays(3).Day).ToList();
            thisWeek.Friday = appointments.Where(a => a.Start.Day == firstDayOfWeek.AddDays(4).Day).ToList();
            thisWeek.Saturday = appointments.Where(a => a.Start.Day == firstDayOfWeek.AddDays(5).Day).ToList();

            switch (date.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    thisWeek.Today = thisWeek.Sunday;
                    break;
                case DayOfWeek.Monday:
                    thisWeek.Today = thisWeek.Monday;
                    break;
                case DayOfWeek.Tuesday:
                    thisWeek.Today = thisWeek.Tuesday;
                    break;
                case DayOfWeek.Wednesday:
                    thisWeek.Today = thisWeek.Wednesday;
                    break;
                case DayOfWeek.Thursday:
                    thisWeek.Today = thisWeek.Thursday;
                    break;
                case DayOfWeek.Friday:
                    thisWeek.Today = thisWeek.Friday;
                    break;
                case DayOfWeek.Saturday:
                    thisWeek.Today = thisWeek.Saturday;
                    break;
                default:
                    break;
            }

            thisWeek.CreateWeekSummary();

            return thisWeek;
        }

        public void AddAppointment(Appointment appointment)
        {
            appointment.Start = appointment.Start.ToUniversalTime();
            appointment.End = appointment.End.ToUniversalTime();
            try
            {
                _repository.AddAppointment(UserContext.Name, appointment);
            }
            catch
            {
                throw;
            }
        }

        public void DeleteAppointment(Appointment appointment)
        {
            try
            {
                _repository.DeleteAppointment(appointment);
            }
            catch
            {
                throw;
            }
        }

        public void UpdateAppointment(Appointment appointment)
        {
            appointment.Start = appointment.Start.ToUniversalTime();
            appointment.End = appointment.End.ToUniversalTime();
            try
            {
                _repository.UpdateAppointment(UserContext.Name, appointment);
            }
            catch
            {
                throw;
            }
        }
    }
}
