﻿using heidischwartz_c969.Models;
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

        // Receives and returns apts in UTC
        public List<Appointment> GetAppointments(int userId, DateTime startDate, DateTime endDate)
        {
            return _context.Appointments
                .Where(appointment => appointment.UserId == userId && appointment.Start >= startDate && appointment.End <= endDate)
                .OrderBy(appointment => appointment.Start)
                .ToList();
        }

        public void AddAppointment(string userName, Appointment appointment)
        {
            appointment.CreateDate = DateTime.UtcNow;
            appointment.CreatedBy = userName;

            try
            {
                _context.Appointments.Add(appointment);
                _context.SaveChanges();
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
                _context.Appointments.Remove(appointment);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void UpdateAppointment(string userName, Appointment appointment)
        {
            appointment.LastUpdate = DateTime.UtcNow;
            appointment.LastUpdateBy = userName;
            try
            {
                _context.Appointments.Update(appointment);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
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

        // REPORTS
        // the number of appointment types by month
        //	the schedule for each user
        // one additional report of your choice Clients by active / inactive?

        // thoughts for after basic implementation: caching to reduce load on db?
        // Get new appointments after deleting (put logic in presenter)
    }
}
