using heidischwartz_c969.Models;

namespace heidischwartz_c969;

public class AppointmentEventArgs
{
    public Appointment Appointment { get; private set; }
    
    public AppointmentEventArgs(Appointment appointment)
    {
        Appointment = appointment;
    }
}