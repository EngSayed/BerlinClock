using System;
using System.Text.RegularExpressions;
using BerlinClock.Classes;
using NUnit.Framework;

namespace BerlinClock.UnitTest
{
    [TestFixture]
    public class TimeConverterTests
    {
        [Test]
        public void TimeConverterThrowsExceptionWhenInputIsEmpty()
        {
            ITimeConverter timeConverter = new TimeConverter();
            Assert.Throws<ArgumentException>(() => timeConverter.ConvertTime(string.Empty));
        }

        [Test]
        public void TimeConverterThrowsExceptionWhenInputIsNull()
        {
            ITimeConverter timeConverter = new TimeConverter();
            Assert.Throws<ArgumentException>(() => timeConverter.ConvertTime(null));
        }

        [Test]
        public void TimeConverterThrowsExceptionWhenInputNotTimeFormat()
        {
            ITimeConverter timeConverter = new TimeConverter();
            Assert.Throws<ArgumentException>(() => timeConverter.ConvertTime("52:52:01"));
        }

        [Test]
        public void TimeConverterJustBeforeMidnightNoSeconds()
        {
            const string aTime = "23:59";
            ITimeConverter timeConverter = new TimeConverter();
            var expectedBerlinClockOutput = "Y\r\nRRRR\r\nRRRO\r\nYYRYYRYYRYY\r\nYYYY";
            expectedBerlinClockOutput = Regex.Replace(expectedBerlinClockOutput, @"\r\n?|\n", Environment.NewLine);

            var actualBerlinClockOutput = timeConverter.ConvertTime(aTime);

            Assert.AreEqual(expectedBerlinClockOutput, actualBerlinClockOutput);
        }

        [Test]
        public void TimeConverterJustBefore10()
        {
            const string aTime = "9:59";
            ITimeConverter timeConverter = new TimeConverter();
            var expectedBerlinClockOutput = "Y\r\nROOO\r\nRRRR\r\nYYRYYRYYRYY\r\nYYYY";
            expectedBerlinClockOutput = Regex.Replace(expectedBerlinClockOutput, @"\r\n?|\n", Environment.NewLine);

            var actualBerlinClockOutput = timeConverter.ConvertTime(aTime);

            Assert.AreEqual(expectedBerlinClockOutput, actualBerlinClockOutput);
        }

        [Test]
        public void TimeConverterJustBeforeMidnight()
        {
            const string aTime = "23:59:59";
            var expectedBerlinClockOutput = "O\nRRRR\nRRRO\nYYRYYRYYRYY\nYYYY";
            expectedBerlinClockOutput = Regex.Replace(expectedBerlinClockOutput, @"\r\n?|\n", Environment.NewLine);
            ITimeConverter timeConverter = new TimeConverter();
            var actualBerlinClockOutput = timeConverter.ConvertTime(aTime);

            Assert.AreEqual(expectedBerlinClockOutput, actualBerlinClockOutput);
        }
    }
}
