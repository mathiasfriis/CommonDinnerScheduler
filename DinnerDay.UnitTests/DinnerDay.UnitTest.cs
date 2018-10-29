using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CommonDinnerScheduler;

namespace DinnerDay_UnitTests
{
    [TestFixture]
    public class DinnerDayUnitTest
    {
        private DinnerDay uut;
        private DateTime today;
        DateTime threeWeeksFromNow;

        [SetUp]
        public void Setup()
        {
            today = DateTime.Today;
            threeWeeksFromNow=DateTime.Today.AddDays(3*7);
            uut = new DinnerDay(DayOfWeek.Monday, today, threeWeeksFromNow);
        }

        [Test]
        public void Participants_NoneAddedGetNumber_Returns0()
        {
            Assert.That(()=>uut.GetNumberOfParticipants().Equals(0));
        }

        [Test]
        public void Participants_Add1GetNumber_Returns1()
        {
            uut.AddParticipant("340");
            Assert.That(() => uut.GetNumberOfParticipants().Equals(1));
        }

        [Test]
        public void Participants_Add2DifferentGetNumber_Returns2()
        {
            uut.AddParticipant("340");
            uut.AddParticipant("341");
            Assert.That(() => uut.GetNumberOfParticipants().Equals(2));
        }

        [Test]
        public void Participants_Add2SameGetNumber_Returns1()
        {
            uut.AddParticipant("340");
            uut.AddParticipant("340");
            Assert.That(() => uut.GetNumberOfParticipants().Equals(1));
        }

        [Test]
        public void Participants_AddExisting_ReturnsFalse()
        {
            uut.AddParticipant("340");
            Assert.That(() => uut.AddParticipant("340").Equals(false));
        }

        [Test]
        public void Participants_AddDifferent_ReturnsTrue()
        {
            uut.AddParticipant("340");
            Assert.That(() => uut.AddParticipant("341").Equals(true));
        }
    } 
}
