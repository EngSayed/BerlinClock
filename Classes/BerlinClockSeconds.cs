using System;

namespace BerlinClock.Classes
{
    public class BerlinClockSeconds
    {
        private const string OnLampColor = "Y";
        private const string OffLampColor = "O";
        private const int NumberOfSecondsPerLamp = 2;

        public static string GetBerlinSeconds(TimeSpan aTimeSpan)
        {
            var seconds = aTimeSpan.Seconds;
            return seconds % NumberOfSecondsPerLamp == 0 ? OnLampColor : OffLampColor;
        }
    }
}