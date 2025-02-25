using heidischwartz_c969.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<List<Appointment>> GetAppointmentsByCustomerId(int customerId)
        {
            try 
            {
                return await _context.Appointments
                    .Where(a => a.CustomerId == customerId)
                    .ToListAsync();
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
                return _context.Appointments
                    .Where(appointment => appointment.UserId == userId && appointment.Start >= startDate && appointment.End <= endDate)
                    .OrderBy(appointment => appointment.Start)
                    .ToList();
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception("Error retrieving appointments", ex);
            }
        }

        public async Task AddAppointment(string userName, Appointment appointment)
        {
            appointment.CreateDate = DateTime.UtcNow;
            appointment.CreatedBy = userName;

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

        public async Task UpdateAppointment(string userName, Appointment appointment)
        {
            appointment.LastUpdate = DateTime.UtcNow;
            appointment.LastUpdateBy = userName;
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

        public async Task<List<Customer>> GetCustomers()
        {
            try
            {
                return await _context.Customers
                    .Include(c => c.Address)
                    .ThenInclude(a => a.City)
                    .ThenInclude(ci => ci.Country)
                    .ToListAsync();
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
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception("Error updating customer", ex);
            }
        }

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

        public void Dispose()
        {
            _context?.Dispose();
        }
        
        // THere is invalid data in some of the existing test data in the database.
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
    }
}
        // REPORTS
        // the number of appointment types by month
        //	the schedule for each user
        // one additional report of your choice Clients by active / inactive?

        // thoughts for after basic implementation: caching to reduce load on db?
        // Get new appointments after deleting (put logic in presenter)