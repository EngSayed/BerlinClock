using System.Collections.Generic;
using System.Text;

namespace BerlinClock.Classes
{
    public class BerlinClockHours
    {
        private const int NumberOfHoursLamps = 4;
        private const int NumberOfHourPerLamp = 5;
        private const string OnLampColor = "R";
        private const string OffLampColor = "O";

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
                lampsSwitchBuilder.Append(1);
            }

            while (lampsSwitchBuilder.Length < NumberOfHoursLamps)
            {
                lampsSwitchBuilder.Append("0");
            }

            return lampsSwitchBuilder.ToString().Replace("1", OnLampColor).Replace("0", OffLampColor);
        }
    }
}