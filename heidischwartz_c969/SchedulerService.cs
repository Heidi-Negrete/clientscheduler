using heidischwartz_c969.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heidischwartz_c969
{
    public class SchedulerService : ISchedulerService
    {
        // use an IClientSchedulerRepository instance to retrieve things needed from db
        // cache appointments after an initial GetAppointments
        public IClientSchedulerRepository _repository;
        public string? user;
        // appointments in local user time zone
        private List<Appointment> _appointments;

        public SchedulerService(IClientSchedulerRepository repository)
        {
            if (repository == null) throw new ArgumentNullException("repository");
            _repository = repository;
        }

        public bool Login(string username, string password)
        {
            // on login, need to get timestamp and append login info w Serilog
            // also start sleeps thread to check appointment time within 15 min

            // hardcoded atm, need to check w values returned from repository
            if (username == "test" &&  password == "test") return true;
            return false;
        }
        // GETS APPOINTMENTS IN UTC FROM REPOSITORY AND RETURNS AFTER CONVERTING TO USER TIME ZONE
        public List<Appointment> GetAppointments(int userId)
        {
            _appointments = _repository.GetAppointments(userId);
            foreach (Appointment appointment in _appointments)
            {
                appointment.Start = ConvertTimeToLocal(appointment.Start);
                appointment.End = ConvertTimeToLocal(appointment.End);
            }
            return _appointments;
        }

        public List<Appointment>? GetTodaysAppointment()
        {
            if (_appointments == null)
                return null;
            var TodaysAppointments = _appointments
                .Where(a => a.Start.Day == DateTime.Now.Day)
                .ToList();
            return TodaysAppointments;
        }

        public bool AddAppointment(Appointment appointment)
        {
            appointment.Start = ConvertTimeToLocal(appointment.Start);
            appointment.End = ConvertTimeToLocal(appointment.End);
            return false;
        }

        public bool DeleteAppointment(Appointment appointment)
        {
            _repository.DeleteAppointment(appointment);
            return false;
        }

        public bool UpdateAppointment(Appointment appointment)
        {
            appointment.Start = ConvertTimeToLocal(appointment.Start);
            appointment.End = ConvertTimeToLocal(appointment.End);
            _repository.UpdateAppointment(appointment);
            return false;
        }

        public DateTime ConvertTimeToLocal(DateTime time)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(time, System.TimeZoneInfo.Local);
        }

        public DateTime ConvertTimeToUtc(DateTime time)
        {
            return TimeZoneInfo.ConvertTimeToUtc(time, System.TimeZoneInfo.Utc);
        }
    }
}
