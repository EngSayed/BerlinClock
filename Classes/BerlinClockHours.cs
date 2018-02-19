using System.Collections.Generic;
using System.Text;

namespace BerlinClock
{
    internal class BerlinClockHours
    {
        private const int NumberOfHoursLamps = 4;
        private const int NumberOfHourPerLamp = 5;

        public static List<string> GetBerlinClockHours(int timeHours)
        {
            var berlinHoursFirstRow = GetBerlinHoursFirstRow(timeHours);
            var berlinHoursSecondRow = GetBerlinHoursSecondRow(timeHours);

            return new List<string> { berlinHoursFirstRow, berlinHoursSecondRow };
        }

        private static string GetBerlinHoursFirstRow(int hours)
        {
            var numberOfOnLamps = hours / NumberOfHourPerLamp;

            return GetBerlinHoursLamps(numberOfOnLamps);
        }

        private static string GetBerlinHoursSecondRow(int hours)
        {
            var numberOfOnLamps = hours % NumberOfHourPerLamp;

            return GetBerlinHoursLamps(numberOfOnLamps);
        }

        private static string GetBerlinHoursLamps(int numberOfOnLamps)
        {
            var lampsSwitchBuilder = new StringBuilder();
            for (var i = 0; i < numberOfOnLamps; i++)
            {
                lampsSwitchBuilder.Append(Switch.ON);
            }

            while (lampsSwitchBuilder.Length < NumberOfHoursLamps)
            {
                lampsSwitchBuilder.Append(Switch.Off);
            }

            return lampsSwitchBuilder.ToString().Replace(Switch.ON, LampColor.OnRedStr).Replace(Switch.Off, LampColor.OffStr);
        }
    }
}