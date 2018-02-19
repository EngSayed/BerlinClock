using System;
using System.Collections.Generic;
using System.Text;

namespace BerlinClock
{
    internal class BerlinClockMinutes
    {
        private const int NumberOfMinutesLampsFirstRow = 11;
        private const int NumberOfMinutesLampsSecondRow = 4;        

        public static List<string> GetBerlinClockMinutes(TimeSpan aTimeSpan)
        {
            var berlinMinutesFirstRow = GetBerlinMinutesFirstRow(aTimeSpan);
            var berlinMinutesSecondRow = GetBerlinMinutesSecondRow(aTimeSpan);

            return new List<string> { berlinMinutesFirstRow, berlinMinutesSecondRow };
        }

        private static string GetBerlinMinutesFirstRow(TimeSpan aTimeSpan)
        {
            var minutes = aTimeSpan.Minutes;
            var numberOfOnLamps = minutes / 5;

            return GetBerlinMinutesLampsFirstRow(numberOfOnLamps);
        }

        private static string GetBerlinMinutesSecondRow(TimeSpan aTimeSpan)
        {
            var minutes = aTimeSpan.Minutes;
            var numberOfOnLamps = minutes % 5;

            return GetBerlinMinutesLampsSecondRow(numberOfOnLamps);
        }
        
        private static string GetBerlinMinutesLampsFirstRow(int numberOfOnLamps)
        {
            var lampsSwitchBuilder = BuildMinuteRow(numberOfOnLamps, NumberOfMinutesLampsFirstRow);

            for (var i = 2; i < lampsSwitchBuilder.Length; i = i + 3)
            {
                var thirdMultipliedLamp = lampsSwitchBuilder[i];
                lampsSwitchBuilder[i] = thirdMultipliedLamp == Switch.ON_Char ? LampColor.OnRedChar : LampColor.OffChar;
            }

            return lampsSwitchBuilder.ToString().Replace(Switch.ON, LampColor.OnYellow).Replace(Switch.Off, LampColor.OffStr);
        }

        private static string GetBerlinMinutesLampsSecondRow(int numberOfOnLamps)
        {
            var lampsSwitchBuilder = BuildMinuteRow(numberOfOnLamps, NumberOfMinutesLampsSecondRow);

            return lampsSwitchBuilder.ToString().Replace(Switch.ON, LampColor.OnYellow).Replace(Switch.Off, LampColor.OffStr);
        }

        private static StringBuilder BuildMinuteRow(int numberOfOnLamps, int numberOfMinutesLamps)
        {
            var lampsSwitchBuilder = new StringBuilder();
            for (var i = 0; i < numberOfOnLamps; i++)
            {
                lampsSwitchBuilder.Append(Switch.ON);
            }

            while (lampsSwitchBuilder.Length < numberOfMinutesLamps)
            {
                lampsSwitchBuilder.Append(Switch.Off);
            }

            return lampsSwitchBuilder;
        }
    }
}