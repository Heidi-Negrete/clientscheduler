using heidischwartz_c969.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heidischwartz_c969
{
    public interface IClientSchedulerRepository
    {
        public ClientSchedulerContext _context { get; }
        public List<Appointment> GetAppointments(int userId);
        // return raw entities from the persistence store, and
        // ISchedulerService will apply business logic such as time zone conversions
        public void UpdateAppointment(Appointment appointment);
        public void DeleteAppointment(Appointment appointment);
        public void AddAppointment(Appointment appointment);
        public List<Customer> GetCustomers();
        public void AddCustomer(Customer customer);
        public void DeleteCustomer(Customer customer);
        public void UpdateCustomer(Customer customer);
    }
}
