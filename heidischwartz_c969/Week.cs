using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using heidischwartz_c969.Models;

namespace heidischwartz_c969
{
    public class Week
    {
        public List<Appointment> Monday { get; set; } = new List<Appointment>();
        public List<Appointment> Tuesday { get; set; } = new List<Appointment>();
        public List<Appointment> Wednesday { get; set; } = new List<Appointment>();
        public List<Appointment> Thursday { get; set; } = new List<Appointment>();
        public List<Appointment> Friday { get; set; } = new List<Appointment>();
        public List<Appointment> Saturday { get; set; } = new List<Appointment>();
        public List<Appointment> Sunday { get; set; } = new List<Appointment>();
    }
}
