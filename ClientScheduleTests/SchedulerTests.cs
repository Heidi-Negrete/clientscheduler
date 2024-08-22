using heidischwartz_c969;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using heidischwartz_c969.Models;

namespace ClientScheduleTests
{
    public class SchedulerTests
    {
        private readonly IClientSchedulerRepository _repository = Substitute.For<IClientSchedulerRepository>();
        private readonly SchedulerService _sut;

        public SchedulerTests()
        {
            _sut = new SchedulerService(_repository);      
            
        }

        [Fact]
        public void GetAppointments_ShouldReturnAppointmentsInLocalTime()
        {
            // Arrange
            int userId = 1;
            List<Appointment> appointments = new List<Appointment>();
            DateTime dateTimeUTC = DateTime.UtcNow;
            DateTime dateTimeLocal = dateTimeUTC.ToLocalTime();

            // mockup appointments
            Appointment appointment = new Appointment();
            appointment.AppointmentId = 1;
            appointment.CustomerId = 1;
            appointment.UserId = userId;
            appointment.Start = DateTime.UtcNow.AddMinutes(-20);
            appointment.End = DateTime.UtcNow.AddMinutes(30);
            appointment.Description = "SOJIOEJ AMAZING";
            appointments.Add(appointment);
            _repository.GetAppointments(1, dateTimeLocal, dateTimeLocal.AddMonths(1).AddTicks(-1)).ReturnsForAnyArgs(appointments); // tell substitute to return a value for a call

            // Act
            var appointmentResults = _sut.GetAppointments(userId, dateTimeLocal);
            // Assert
            Assert.Equal(appointmentResults[0].Start.Kind, dateTimeLocal.Kind);

        }

        [Fact]
        public void GetAppointments_ShouldReturnEmptyListIfNoneFound()
        {
            // Arrange
            _repository.GetAppointments(1, DateTime.Now, DateTime.Now.AddDays(1)).ReturnsForAnyArgs(new List<Appointment>());
            List<Appointment> appointments;
            List<Appointment> expected = new List<Appointment>();

            // Act
            appointments = _sut.GetAppointments(1, DateTime.Now);

            // Assert
            Assert.Equal(appointments, expected);
        }

        [Fact]
        public void GetTodaysAppointment_Should()
        {
        }
    }
}
