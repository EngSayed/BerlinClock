using System;
using System.Collections.Generic;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        public string ConvertTime(string aTime)
        {
            if (string.IsNullOrEmpty(aTime))
            {
                throw new ArgumentException("Time cannot be empty nor null", aTime);
            }

            if (!TimeSpan.TryParse(aTime, out var aTimeSpan))
            {
                throw new ArgumentException("The passed input is not a correct time format", aTime);
            }

            var timeArray = aTime.Split(':');
            var timeHours = int.Parse(timeArray[0]);

            var berlinTime = new List<string>();
            berlinTime.Add(BerlinClockSeconds.GetBerlinSeconds(aTimeSpan));
            berlinTime.AddRange(BerlinClockHours.GetBerlinClockHours(timeHours));
            berlinTime.AddRange(BerlinClockMinutes.GetBerlinClockMinutes(aTimeSpan));

            var output = string.Join(Environment.NewLine, berlinTime);

            return output;
        }
    }
}