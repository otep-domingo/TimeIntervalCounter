using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
namespace TimeIntervalCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            //to run using json file
            var s = File.ReadAllText(@"C:\Users\FRANCIS TILLA-IN\Downloads\response_1644000938355v2.json");
            //deserialize json based n fields available. see Timecolection class
            var tc = JsonConvert.DeserializeObject<List<TimeCollection>>(s);
            //to run using manual time entry
            //var tc = new List<TimeCollection>();
            //tc.Add(new TimeCollection { StartTime = DateTime.Parse("2022-01-25T10:08:00Z").ToUniversalTime(), EndTime = DateTime.Parse("2022-01-25T11:15:00Z").ToUniversalTime() });
            //tc.Add(new TimeCollection { StartTime = DateTime.Parse("2022-01-25T11:30:00Z").ToUniversalTime(), EndTime = DateTime.Parse("2022-01-25T13:00:00Z").ToUniversalTime() });
            //tc.Add(new TimeCollection { StartTime = DateTime.Parse("2022-01-25T13:30:00Z").ToUniversalTime(), EndTime = DateTime.Parse("2022-01-25T15:45:00Z").ToUniversalTime() });
            //tc.Add(new TimeCollection { StartTime = DateTime.Parse("2022-01-25T16:00:00Z").ToUniversalTime(), EndTime = DateTime.Parse("2022-01-25T17:30:00Z").ToUniversalTime() });
            //tc.Add(new TimeCollection { StartTime = DateTime.Parse("2022-01-25T10:45:00Z").ToUniversalTime(), EndTime = DateTime.Parse("2022-01-25T11:30:00Z").ToUniversalTime() });
            //tc.Add(new TimeCollection { StartTime = DateTime.Parse("2022-01-25T11:45:00Z").ToUniversalTime(), EndTime = DateTime.Parse("2022-01-25T13:30:00Z").ToUniversalTime() });




            TimeIntervalProcessing tip = new TimeIntervalProcessing();
            tip.TimeCollection = tc;
            var interval = tip.ProcessFrequencyInterval();
            foreach (var i in interval)
            {
                Console.WriteLine(string.Format("{0:00}:{1:00} - {2}", i.Hour, i.Minutes, i.Frequency));
            }
        }
    }
}
