using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TimeIntervalCounter
{
    class TimeIntervalProcessing
    {
        public List<TimeCollection> TimeCollection { get; set; }
        //public List<TimeInterval> interval { get; set; }

        private List<TimeInterval> interval = new List<TimeInterval>();
        public List<TimeInterval> ProcessFrequencyInterval()
        {
            var start = DateTime.Today;
            var clockQuery = from offset in Enumerable.Range(0, 48)
                             select start.AddMinutes(30 * offset);

            foreach (var time in clockQuery)
                interval.Add(new TimeInterval
                {
                    Hour = Int32.Parse(time.ToString("HH")),
                    Minutes = Int32.Parse(time.ToString("mm"))
                });
            foreach(var s in TimeCollection)
            {
                ComputeFrequency(s.startDateTime, s.endDateTime);
            }
            return interval;
        }

        private void ComputeFrequency(DateTime employeeStart, DateTime employeeEnd)
        {
            int startMinute = 0;
            int endMinute = 0;
            int startHour = Int32.Parse(employeeStart.ToString("HH"));
            int endHour = Int32.Parse(employeeEnd.ToString("HH"));
            if (employeeStart.Minute > 29)
            {
                startMinute = 30;
            }
            else
            {
                startMinute = 0;
            }

            if (employeeEnd.Minute >29)
            {
                endMinute = 30;
            }
            else
            {
                endMinute = 0;
            }

            while (startHour<endHour)
            {

                UpdateFrequency(startHour, startMinute);

                if (startMinute == 0)
                    {
                        startMinute = 30;
                    }
                    else
                    {
                        startMinute = 0;
                        startHour++;
                    }

            }
            if (startHour == endHour)
            {
                //check the end minute
                UpdateFrequency(startHour, startMinute);
                if(startMinute!=endMinute)
                UpdateFrequency(startHour, endMinute);
            }

        }
        private void UpdateFrequency(int hr, int min)
        {
            foreach(var ti in interval.Where(w=>w.Hour == hr && w.Minutes == min))
            {
                ti.Frequency += 1;
            }
        }
    }
}
