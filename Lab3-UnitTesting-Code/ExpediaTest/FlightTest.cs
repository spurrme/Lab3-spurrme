using System;
using Expedia;
using NUnit.Framework;

namespace ExpediaTest
{
    [TestFixture()]
    public class FlightTest
    {
        DateTime dtstart = new DateTime(2005, 9, 17);
        DateTime dtend = new DateTime(2005, 9, 18);
        [Test()]
        public void TestThatFlightInitializes()
        {
            var target = new Flight(dtstart, dtend, 500);
            Assert.IsNotNull(target);
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceForOneDay()
        {
            DateTime start = new DateTime(2005, 9, 17);
            DateTime end = new DateTime(2005, 9, 18);
            var target = new Flight(start, end, 500);
            Assert.AreEqual(220, target.getBasePrice());
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceForTwoDays()
        {
            DateTime start = new DateTime(2005, 9, 17);
            DateTime end = new DateTime(2005, 9, 19);
            var target = new Flight(start, end, 500);
            Assert.AreEqual(240, target.getBasePrice());
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceForTenDays()
        {
            DateTime start = new DateTime(2005, 9, 17);
            DateTime end = new DateTime(2005, 9, 27);
            var target = new Flight(start, end, 500);
            Assert.AreEqual(400, target.getBasePrice());
        }

        [Test()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestThatFlightThrowsOnBackwardsDays()
        {
            DateTime start = new DateTime(2005, 9, 17);
            DateTime end = new DateTime(2005, 9, 16);
            new Flight(start, end, 500);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestThatFlightThrowsOnNegativeMiles()
        {
            DateTime start = new DateTime(2005, 9, 17);
            DateTime end = new DateTime(2005, 9, 19);
            new Flight(start, end, -100);
        }
    }
}

