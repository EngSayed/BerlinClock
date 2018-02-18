using System;
using System.Text.RegularExpressions;
using BerlinClock.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace BerlinClock.BDD
{
    [Binding]
    public class TheBerlinClockSteps
    {
        private readonly ITimeConverter _berlinClock = new TimeConverter();
        private string _theTime;

        
        [When(@"the time is ""(.*)""")]
        public void WhenTheTimeIs(string time)
        {
            _theTime = time;
        }

        [Then(@"the clock should look like")]
        public void ThenTheClockShouldLookLike(string theExpectedBerlinClockOutput)
        {
            var theExpectedBerlinClockOutputFormatted = Regex.Replace(theExpectedBerlinClockOutput, @"\r\n?|\n", Environment.NewLine);
            Assert.AreEqual(_berlinClock.ConvertTime(_theTime), theExpectedBerlinClockOutputFormatted, true);
        }
    }
}