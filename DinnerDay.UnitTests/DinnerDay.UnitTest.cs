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
            //today = DateTime.Today;
            today = new DateTime(2018,10,29); //Monday 29th of October 2018
            threeWeeksFromNow=DateTime.Today.AddDays(3*7);
            uut = new DinnerDay(DayOfWeek.Monday, today, threeWeeksFromNow);
            uut.AddParticipant("340");
            uut.AddParticipant("341");
        }

        [Test]
        public void Participants_NoneAddedGetNumber_Returns2()
        {
            Assert.That(()=>uut.GetNumberOfParticipants().Equals(2));
        }

        [Test]
        public void Participants_Add1GetNumber_Returns3()
        {
            uut.AddParticipant("342");
            Assert.That(() => uut.GetNumberOfParticipants().Equals(3));
        }

        [Test]
        public void Participants_Add2DifferentGetNumber_Returns4()
        {
            uut.AddParticipant("342");
            uut.AddParticipant("343");
            Assert.That(() => uut.GetNumberOfParticipants().Equals(4));
        }

        [Test]
        public void Participants_Add2SameGetNumber_Returns3()
        {
            uut.AddParticipant("342");
            uut.AddParticipant("342");
            Assert.That(() => uut.GetNumberOfParticipants().Equals(3));
        }

        [Test]
        public void Participants_AddExisting_ReturnsFalse()
        {
            Assert.That(() => uut.AddParticipant("340").Equals(false));
        }

        [Test]
        public void Participants_AddDifferent_ReturnsTrue()
        {
            Assert.That(() => uut.AddParticipant("343").Equals(true));
        }

        [Test]
        public void Dates_DinnerDayInitialized_NumberOfDatesIs4()
        {
            Assert.That(()=>uut.specificDates.Count.Equals(4));
        }

        [Test]
        public void Dates_DinnerDayInitializedWithWeekDaySetOneDayLater_NumberOfDatesIs3()
        {
            uut = new DinnerDay(DayOfWeek.Tuesday, today, threeWeeksFromNow);
            Assert.That(() => uut.specificDates.Count.Equals(3));
        }

        [Test]
        public void Dates_DinnerDayInitializedWithWeekDaySetTwoDaysLater_NumberOfDatesIs3()
        {
            uut = new DinnerDay(DayOfWeek.Wednesday, today, threeWeeksFromNow);
            Assert.That(() => uut.specificDates.Count.Equals(3));
        }

        [Test]
        public void Dates_DinnerDayInitializedWithWeekDaySetThreeDaysLater_NumberOfDatesIs3()
        {
            uut = new DinnerDay(DayOfWeek.Thursday, today, threeWeeksFromNow);
            Assert.That(() => uut.specificDates.Count.Equals(3));
        }

        [Test]
        public void Dates_DinnerDayInitializedWithWeekDaySetFourDaysLater_NumberOfDatesIs3()
        {
            uut = new DinnerDay(DayOfWeek.Friday, today, threeWeeksFromNow);
            Assert.That(() => uut.specificDates.Count.Equals(3));
        }

        [Test]
        public void Dates_DinnerDayInitializedWithWeekDaySetFiveDaysLater_NumberOfDatesIs3()
        {
            uut = new DinnerDay(DayOfWeek.Saturday, today, threeWeeksFromNow);
            Assert.That(() => uut.specificDates.Count.Equals(3));
        }

        [Test]
        public void Dates_DinnerDayInitializedWithWeekDaySetSixDaysLater_NumberOfDatesIs3()
        {
            uut = new DinnerDay(DayOfWeek.Sunday, today, threeWeeksFromNow);
            Assert.That(() => uut.specificDates.Count.Equals(3));
        }

        [Test]
        public void AssignResponsibleUser_AssignNameNotInListOfParticipants_ThrowsError()
        {
            Assert.Throws(typeof(ArgumentException), ()=>uut.setPersonResponsibleForDate(uut.specificDates[0],"123"), "Name not found in list of participants");
        }

        [Test]
        public void AssignResponsibleUser_AssignNothingGetDaysReponsibleFor_Returns0()
        {
            Assert.That(uut.daysResponsibleFor[uut.Participants[0]].Equals(0));
        }

        [Test]
        public void AssignResponsibleUser_AssignADayToUserGetDaysReponsibleFor_Returns1()
        {
            uut.setPersonResponsibleForDate(uut.specificDates[0],uut.Participants[0]);
            Assert.That(uut.daysResponsibleFor[uut.Participants[0]].Equals(1));
        }

        [Test]
        public void AssignResponsibleUser_AssignSameDayToNewUserGetDaysOldUserReponsibleFor_Returns0()
        {
            uut.setPersonResponsibleForDate(uut.specificDates[0], uut.Participants[0]);
            uut.setPersonResponsibleForDate(uut.specificDates[0], uut.Participants[1]);
            Assert.That(uut.daysResponsibleFor[uut.Participants[0]].Equals(0));
        }

        [Test]
        public void AssignResponsibleUser_AssignSameDayToNewUserGetDaysNewUserReponsibleFor_Returns1()
        {
            uut.setPersonResponsibleForDate(uut.specificDates[0], uut.Participants[0]);
            uut.setPersonResponsibleForDate(uut.specificDates[0], uut.Participants[1]);
            Assert.That(uut.daysResponsibleFor[uut.Participants[1]].Equals(1));
        }
    }
}
