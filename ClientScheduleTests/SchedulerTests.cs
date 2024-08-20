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
            Appointment appointment = new Appointment();
            DateTime dateTimeUTC = DateTime.UtcNow;
            DateTime dateTimeLocal = dateTimeUTC.ToLocalTime();
            appointment.AppointmentId = 1;
            appointment.CustomerId = 1;
            appointment.UserId = userId;
            appointment.Start = dateTimeUTC;
            appointment.End = dateTimeUTC.AddMinutes(30);
            appointments.Add(appointment);
            _repository.GetAppointments(1).Returns(appointments);

            // Act
            var appointmentResults = _sut.GetAppointments(userId);
            // Assert
            Assert.Equal(appointments[0].Start, dateTimeLocal);

        }

        [Fact]
        public void GetAppointments_ShouldReturnEmptyListIfNoneFound()
        {
            // Arrange
            _repository.GetAppointments(1).Returns(new List<Appointment>());
            List<Appointment> appointments;
            List<Appointment> expected = new List<Appointment>();

            // Act
            appointments = _sut.GetAppointments(1);

            // Assert
            Assert.Equal(appointments, expected);
        }

        [Fact]
        public void GetTodaysAppointment_Should()
        {
        }
    }
}
