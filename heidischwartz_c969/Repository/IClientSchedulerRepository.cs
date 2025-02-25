using heidischwartz_c969.Models;

namespace heidischwartz_c969
{
    public interface IClientSchedulerRepository
    {
        public Task<List<Appointment>> GetAppointments(int userId, DateTime startDate, DateTime endDate);
        public Task UpdateAppointment(Appointment appointment);
        public Task DeleteAppointment(Appointment appointment);
        public Task AddAppointment(Appointment appointment);
        public Task<List<Customer>> GetCustomers();
        public Task AddCustomer(Customer customer);
        public Task DeleteCustomer(Customer customer);
        public Task UpdateCustomer(Customer customer);
        public Task AddAddress(Address address);
        public Task SeedTestData();
        public Task<List<Appointment>> GetAppointmentsByCustomerId(int customerId);
        public bool Login(string username, string password);
        public Task<List<Appointment>> GetDaysAppointments(DateTime date);
    }
}
