using System;
using System.Collections.Generic;
using System.Text;

namespace BerlinClock.Classes
{
    public class BerlinClockMinutes
    {
        private const int NumberOfMinutesLampsFirstRow = 11;
        private const int NumberOfMinutesLampsSecondRow = 4;
        private const char OnLampRedColor = 'R';
        private const string OnLampYellowColor = "Y";
        private const string OffLampColorStr = "O";
        private const char OffLampColorChar = 'O';

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
        // todo - Refactor
        private static string GetBerlinMinutesLampsFirstRow(int numberOfOnLamps)
        {
            var lampsSwitchBuilder = new StringBuilder();
            for (var i = 0; i < numberOfOnLamps; i++)
            {
                lampsSwitchBuilder.Append(1);
            }

            while (lampsSwitchBuilder.Length != NumberOfMinutesLampsFirstRow)
            {
                lampsSwitchBuilder.Append("0");
            }

            for (var i = 2; i < lampsSwitchBuilder.Length; i = i + 3)
            {
                var thirdMultipliedLamp = lampsSwitchBuilder[i];
                lampsSwitchBuilder[i] = thirdMultipliedLamp == '1' ? OnLampRedColor : OffLampColorChar;
            }

            return lampsSwitchBuilder.ToString().Replace("1", OnLampYellowColor).Replace("0", OffLampColorStr);
        }

        private static string GetBerlinMinutesLampsSecondRow(int numberOfOnLamps)
        {
            var lampsSwitchBuilder = new StringBuilder();
            for (var i = 0; i < numberOfOnLamps; i++)
            {
                lampsSwitchBuilder.Append(1);
            }
            
            while (lampsSwitchBuilder.Length < NumberOfMinutesLampsSecondRow)
            {
                lampsSwitchBuilder.Append("0");
            }

            return lampsSwitchBuilder.ToString().Replace("1", OnLampYellowColor).Replace("0", OffLampColorStr);
        }
    }
}