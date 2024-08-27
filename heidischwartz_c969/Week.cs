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

        public List<Appointment> Today { get; set; } = new List<Appointment>();

        public DateTime TargetDate { get; set; } = DateTime.Now;

        public List<WeekSummaryView> WeekSummary { get; set; } = new List<WeekSummaryView>();

        private string ToDaySummary(List<Appointment> day)
        {  
            StringBuilder sb = new StringBuilder();
            foreach (var appointment in day)
            {
                sb.AppendFormat("{0} {1}\r\n", appointment.Title,
                appointment.Start.ToString("hh:mm"));
            }
            return sb.ToString();
        }

        public void CreateWeekSummary()
        {
            WeekSummaryView week = new WeekSummaryView();
            week.Sunday = ToDaySummary(Sunday);
            week.Monday = ToDaySummary(Monday);
            week.Tuesday = ToDaySummary(Tuesday);
            week.Wednesday = ToDaySummary(Wednesday);
            week.Thursday = ToDaySummary(Thursday);
            week.Friday = ToDaySummary(Friday);
            week.Saturday = ToDaySummary(Saturday);

            WeekSummary.Add(week);
        }

        // get a list of available appointment times assuming every appointment is 30 min for today based on business hours and existing appointments
    }
}
