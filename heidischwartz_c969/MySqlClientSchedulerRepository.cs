using heidischwartz_c969.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace heidischwartz_c969
{
    public class MySqlClientSchedulerRepository : IClientSchedulerRepository
    {
        public ClientSchedulerContext _context { get; }

        public MySqlClientSchedulerRepository(ClientSchedulerContext context)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;
        }

        // RETURNS APPOINTMENTS IN UTC
        public List<Appointment> GetAppointments(int userId, DateTime startDate, DateTime endDate)
        {
            // todo constrain results within start and end date.

            // TEMP HARDCODED DATA for testing.
            List<Appointment> appointments = new List<Appointment>();
            Appointment appointment = new Appointment();
            appointment.AppointmentId = 1;
            appointment.CustomerId = 1;
            appointment.UserId = userId;
            appointment.Start = DateTime.Now.AddMinutes(-20);
            appointment.End = DateTime.Now.AddMinutes(30);
            appointment.Description = "SOJIOEJ AMAZING";
            appointments.Add(appointment);
            return appointments;


            //return _context.Appointments
            //    .Where(appointment => appointment.UserId == userId)
            //    .OrderBy(appointment => appointment.Start)
            //    .ToList();
        }

        public void AddAppointment(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
        }

        public void DeleteAppointment(Appointment appointment)
        {
            _context.Appointments.Remove(appointment);
            _context.SaveChanges();
        }

        public void UpdateAppointment(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
            _context.SaveChanges();
        }

        public List<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        public void AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void DeleteCustomer(Customer customer)
        {
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }

        public void UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
        }

        // the number of appointment types by month
        //	the schedule for each user
        // one additional report of your choice Clients by active / inactive?

        // thoughts for after basic implementation: caching to reduce load on db?
        // Get new appointments after deleting (put logic in presenter)
    }
}
