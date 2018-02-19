using System;

namespace BerlinClock
{
    internal class BerlinClockSeconds
    {
        private const int NumberOfSecondsPerLamp = 2;

        public static string GetBerlinSeconds(TimeSpan aTimeSpan)
        {
            var seconds = aTimeSpan.Seconds;
            return seconds % NumberOfSecondsPerLamp == 0 ? LampColor.OnYellow : LampColor.OffStr;
        }
    }
}