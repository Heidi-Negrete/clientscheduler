using System.Globalization;
using heidischwartz_c969.Models;
using Microsoft.EntityFrameworkCore;

namespace heidischwartz_c969
{
    public class MySqlClientSchedulerRepository : IClientSchedulerRepository, IDisposable
    {
        public ClientSchedulerContext _context { get; }

        public MySqlClientSchedulerRepository(ClientSchedulerContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        
        public bool Login(string username, string password)
        {
            // hardcoded for assessment, irl would validate against values from repository
            UserContext.Name = "test";
            UserContext.UserId = 1;
            if (username == "test" &&  password == "test") return true;
            return false;
        }
        
        // SEED TEST DATA
        public async Task SeedTestData()
        {
            // Clear existing data
            _context.Appointments.RemoveRange(_context.Appointments);
            _context.Customers.RemoveRange(_context.Customers);
            _context.Addresses.RemoveRange(_context.Addresses);
            await _context.SaveChangesAsync();

            // Seed Addresses
            var addresses = new List<Address>
            {
                new Address
                {
                    Address1 = "123 Main St",
                    Address2 = "Apt 4B",
                    CityId = 1,
                    PostalCode = "12345",
                    Phone = "555-555-1234",
                    CreateDate = DateTime.Now,
                    CreatedBy = "admin",
                    LastUpdate = DateTime.Now,
                    LastUpdateBy = "admin"
                },
                new Address
                {
                    Address1 = "456 Elm St",
                    Address2 = "Suite 2A",
                    CityId = 2,
                    PostalCode = "67890",
                    Phone = "555-555-5678",
                    CreateDate = DateTime.Now,
                    CreatedBy = "admin",
                    LastUpdate = DateTime.Now,
                    LastUpdateBy = "admin"
                }
            };

            foreach (var address in addresses)
            {
                await _context.Addresses.AddAsync(address);
            }

            await _context.SaveChangesAsync();

            // Seed Customers
            var customers = new List<Customer>
            {
                new Customer
                {
                    CustomerName = "John Doe",
                    AddressId = addresses[0].AddressId,
                    CreateDate = DateTime.Now,
                    CreatedBy = "admin",
                    LastUpdate = DateTime.Now,
                    LastUpdateBy = "admin"
                },
                new Customer
                {
                    CustomerName = "Jane Smith",
                    AddressId = addresses[1].AddressId,
                    CreateDate = DateTime.Now,
                    CreatedBy = "admin",
                    LastUpdate = DateTime.Now,
                    LastUpdateBy = "admin"
                }
            };

            foreach (var customer in customers)
            {
                await _context.Customers.AddAsync(customer);
            }

            await _context.SaveChangesAsync();

            // Seed Appointments
            var appointments = new List<Appointment>
            {
                new Appointment
                {
                    CustomerId = customers[0].CustomerId,
                    UserId = 1,
                    Title = "Meeting with Client",
                    Description = "Discuss project requirements",
                    Location = "Office",
                    Contact = "client@example.com",
                    Type = "Business",
                    Url = "http://example.com",
                    Start = DateTime.Now.AddHours(1),
                    End = DateTime.Now.AddHours(2),
                    CreateDate = DateTime.Now,
                    CreatedBy = "admin",
                    LastUpdate = DateTime.Now,
                    LastUpdateBy = "admin"
                },
                new Appointment
                {
                    CustomerId = customers[1].CustomerId,
                    UserId = 1,
                    Title = "Follow-up Call",
                    Description = "Check on project progress",
                    Location = "Phone",
                    Contact = "client2@example.com",
                    Type = "Business",
                    Url = "http://example.com",
                    Start = DateTime.Now.AddDays(1).AddHours(1),
                    End = DateTime.Now.AddDays(1).AddHours(2),
                    CreateDate = DateTime.Now,
                    CreatedBy = "admin",
                    LastUpdate = DateTime.Now,
                    LastUpdateBy = "admin"
                }
            };

            foreach (var appointment in appointments)
            {
                await _context.Appointments.AddAsync(appointment);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<List<Appointment>> GetDaysAppointments(DateTime date)
        {
            // convert date parameter to utc
            DateTime startDate = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, DateTimeKind.Utc);
            
            // get appointments from repository that are in the same day
            List<Appointment> appointments = await GetAppointments(UserContext.UserId, startDate, startDate.AddDays(1));
            // convert apts back to local time before returning
            
            return ConvertAppointmentsToLocalTime(appointments);
        }
                
        // APPOINTMENTS
        public async Task<List<Appointment>> GetAppointmentsByCustomerId(int customerId)
        {
            try
            {
                var appointments = await _context.Appointments
                    .Include(a => a.Customer)
                    .ThenInclude(c => c.Address)
                    .ThenInclude(a => a.City)
                    .ThenInclude(ci => ci.Country)
                    .Where(a => a.CustomerId == customerId)
                    .ToListAsync();
                return ConvertAppointmentsToLocalTime(appointments);
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception("Error retrieving appointments by customer ID", ex);
            }
        }

        //returns apts in utc time
        public async Task<List<Appointment>> GetAppointments(int userId, DateTime startDate, DateTime endDate)
        {
            if (userId <= 0)
            {
                throw new ArgumentException("Invalid user ID", nameof(userId));
            }

            if (startDate > endDate)
            {
                throw new ArgumentException("Start date must be earlier than end date");
            }

            try
            {
                var appointments = await _context.Appointments
                    .Include(a => a.Customer)
                    .ThenInclude(c => c.Address)
                    .ThenInclude(a => a.City)
                    .ThenInclude(ci => ci.Country)
                    .Where(appointment => appointment.UserId == userId && appointment.Start >= startDate && appointment.End <= endDate)
                    .OrderBy(appointment => appointment.Start)
                    .ToListAsync();
                return ConvertAppointmentsToLocalTime(appointments);
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception("Error retrieving appointments", ex);
            }
        }

        public async Task AddAppointment(Appointment appointment)
        {
            appointment.UserId = UserContext.UserId;
            appointment.Type = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(appointment.Type.Trim().ToLower());
            appointment.Start = TimeZoneInfo.ConvertTimeToUtc(appointment.Start);
            appointment.End = appointment.Start.AddMinutes(30);
            appointment.CreateDate = DateTime.UtcNow;
            appointment.CreatedBy = UserContext.Name;
            appointment.LastUpdate = DateTime.UtcNow;
            appointment.LastUpdateBy = UserContext.Name;

            try
            {
                await _context.Appointments.AddAsync(appointment);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception("Error adding appointment", ex);
            }
        }

        public async Task DeleteAppointment(Appointment appointment)
        {
            try
            {
                _context.Appointments.Remove(appointment);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception("Error deleting appointment", ex);
            }
        }

        public async Task UpdateAppointment(Appointment appointment)
        {
            appointment.Type = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(appointment.Type.Trim().ToLower());
            appointment.Start = TimeZoneInfo.ConvertTimeToUtc(appointment.Start);
            appointment.End = appointment.Start.AddMinutes(30);
            appointment.LastUpdate = DateTime.UtcNow;
            appointment.LastUpdateBy = UserContext.Name;

            try
            {
                _context.Appointments.Update(appointment);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception("Error updating appointment", ex);
            }
        }
        
        // USERS
        public async Task<List<User>> GetUsers()
        {
            try
            {
                return await _context.Users.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception("Error retrieving users", ex);
            }
        }

        // CUSTOMERS
        public async Task<List<Customer>> GetCustomers()
        {
            try
            {
                var customers = await _context.Customers
                    .Include(c => c.Address)
                    .ThenInclude(a => a.City)
                    .ThenInclude(ci => ci.Country)
                    .ToListAsync();
                
                // Check if each customer has appointments in the last or next 6 months and mark as active 
                foreach (var customer in customers)
                {
                    var sixMonthsAgo = DateTime.UtcNow.AddMonths(-6);
                    var sixMonthsAhead = DateTime.UtcNow.AddMonths(6);
                    customer.Active = await _context.Appointments.AnyAsync(a => a.CustomerId == customer.CustomerId && a.Start >= sixMonthsAgo && a.Start <= sixMonthsAhead);
                }

                return customers;
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception("Error retrieving customers", ex);
            }
        }

        public async Task AddCustomer(Customer customer)
        {
            customer.CreateDate = DateTime.UtcNow;
            customer.CreatedBy = UserContext.Name;
            customer.Address.City.CreateDate = DateTime.UtcNow;
            customer.Address.City.CreatedBy = UserContext.Name;
            customer.Address.CreateDate = DateTime.UtcNow;
            customer.Address.CreatedBy = UserContext.Name;

            customer.LastUpdate = DateTime.UtcNow;
            customer.LastUpdateBy = UserContext.Name;
            customer.Address.LastUpdate = DateTime.UtcNow;
            customer.Address.LastUpdateBy = UserContext.Name;
            customer.Address.City.LastUpdate = DateTime.UtcNow;
            customer.Address.City.LastUpdateBy = UserContext.Name;
            ValidateAndSetDefaults(customer);

            try
            {
                await _context.Customers.AddAsync(customer);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception("Error adding customer", ex);
            }
        }

        public async Task DeleteCustomer(Customer customer)
        {
            try
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception("Error deleting customer", ex);
            }
        }

        public async Task UpdateCustomer(Customer customer)
        {
            customer.LastUpdate = DateTime.UtcNow;
            customer.LastUpdateBy = UserContext.Name;

            ValidateAndSetDefaults(customer);

            try
            {
                _context.Customers.Update(customer);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception("Error updating customer", ex);
            }
        }
        
        // ADDRESSES
        public async Task AddAddress(Address address)
        {
            try
            {
                await _context.Addresses.AddAsync(address);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception("Error adding address", ex);
            }
        }

        public async Task UpdateAddress(Address address)
        {
            try
            {
                _context.Addresses.Update(address);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception("Error updating address", ex);
            }
        }

        // CITIES
        public async Task AddCity(City city)
        {
            try
            {
                await _context.Cities.AddAsync(city);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception("Error adding city", ex);
            }
        }

        public async Task UpdateCity(City city)
        {
            try
            {
                _context.Cities.Update(city);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception("Error updating city", ex);
            }
        }

        // COUNTRIES
        public async Task AddCountry(Country country)
        {
            try
            {
                await _context.Countries.AddAsync(country);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception("Error adding country", ex);
            }
        }

        public async Task UpdateCountry(Country country)
        {
            try
            {
                _context.Countries.Update(country);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception("Error updating country", ex);
            }
        }
        
        // GET AVAILABLE TIMES and return list of these times.
        // we need to ensure that the available times are between 9:00 AM and 4:30 PM EST. If the date is today, the available times should start from the nearest half-hour to the current time and end at 4:30 PM EST. If the date is in the past, there should be no available times.
        public async Task<List<DateTime>> GetAvailableTimes(DateTime date)
        {
            // Convert date parameter to UTC
            DateTime startDate = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, DateTimeKind.Utc);
            List<Appointment> appointments = await GetAppointments(UserContext.UserId, startDate, startDate.AddDays(1));
            List<DateTime> availableTimes = new List<DateTime>();

            // Get all the times between 9:00 AM and 4:30 PM EST
            TimeZoneInfo estZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            DateTime estStart = TimeZoneInfo.ConvertTimeToUtc(new DateTime(date.Year, date.Month, date.Day, 9, 0, 0), estZone);
            DateTime estEnd = TimeZoneInfo.ConvertTimeToUtc(new DateTime(date.Year, date.Month, date.Day, 16, 30, 0), estZone);

            DateTime nowEst = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, estZone);
            if (date.Date == nowEst.Date)
            {
                // If the date is today, start from the nearest half-hour to the current time
                DateTime nearestHalfHour = nowEst.Minute < 30
                    ? new DateTime(nowEst.Year, nowEst.Month, nowEst.Day, nowEst.Hour, 30, 0)
                    : new DateTime(nowEst.Year, nowEst.Month, nowEst.Day, nowEst.Hour + 1, 0, 0);

                estStart = TimeZoneInfo.ConvertTimeToUtc(nearestHalfHour, estZone);
            }
            else if (date.Date < nowEst.Date)
            {
                // If the date is in the past, return no available times
                return availableTimes;
            }

            for (DateTime time = estStart; time <= estEnd; time = time.AddMinutes(30))
            {
                availableTimes.Add(TimeZoneInfo.ConvertTimeFromUtc(time, estZone));
            }

            // Remove the times that are already booked
            foreach (Appointment appointment in appointments)
            {
                availableTimes.Remove(appointment.Start.ToLocalTime());
            }

            return availableTimes;
        }
        

        // HELPER METHODS
        // There is invalid data in some of the existing test data in the database.
        private void ValidateAndSetDefaults(Customer customer)
        {
            if (customer.Address != null)
            {
                if (customer.Address.CreateDate == default)
                {
                    customer.Address.CreateDate = DateTime.UtcNow;
                    customer.Address.CreatedBy = UserContext.Name;
                }
                customer.Address.LastUpdate = DateTime.UtcNow;
                customer.Address.LastUpdateBy = UserContext.Name;

                if (customer.Address.City != null)
                {
                    if (customer.Address.City.CreateDate == default)
                    {
                        customer.Address.City.CreateDate = DateTime.UtcNow;
                        customer.Address.City.CreatedBy = UserContext.Name;
                    }
                    customer.Address.City.LastUpdate = DateTime.UtcNow;
                    customer.Address.City.LastUpdateBy = UserContext.Name;

                    if (customer.Address.City.Country != null)
                    {
                        if (customer.Address.City.Country.CreateDate == default)
                        {
                            customer.Address.City.Country.CreateDate = DateTime.UtcNow;
                            customer.Address.City.Country.CreatedBy = UserContext.Name;
                        }
                        customer.Address.City.Country.LastUpdate = DateTime.UtcNow;
                        customer.Address.City.Country.LastUpdateBy = UserContext.Name;
                    }
                }
            }
        }
        
        private List<Appointment> ConvertAppointmentsToLocalTime(List<Appointment> appointments)
        {
            foreach (Appointment appointment in appointments)
            {
                appointment.Start = appointment.Start.ToLocalTime();
                appointment.End = appointment.End.ToLocalTime();
            }
            return appointments;
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
        
