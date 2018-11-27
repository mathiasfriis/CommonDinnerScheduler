using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CommonDinnerScheduler;

namespace Schedule_UnitTests
{
	[TestFixture]
    class ScheduleUnitTest
	{
	    private Schedule uut;

	    DateTime today;
	    DateTime threeWeeksFromNow;

        [SetUp]
        public void Setup()
        {
            uut = new Schedule();
            today = new DateTime(2018, 10, 29); //Monday 29th of October 2018
            threeWeeksFromNow = DateTime.Today.AddDays(3 * 7);
        }

	    [Test]
	    public void Schedule_JustInitializedGetDinnerDaysCount_Equals0()
	    {
			Assert.That(uut.dinnerDays.Count.Equals(0));
	    }

	    [Test]
	    public void Schedule_AddOneWeekdayGetDinnerDaysCount_Equals1()
	    {
	        uut.addDayToSchedule(DayOfWeek.Monday, today, threeWeeksFromNow);
	        Assert.That(uut.dinnerDays.Count.Equals(1));
	    }

	    [Test]
	    public void Schedule_AddSameWeekdayTwiceGetDinnerDaysCount_Equals1()
	    {
	        uut.addDayToSchedule(DayOfWeek.Monday, today, threeWeeksFromNow);
	        uut.addDayToSchedule(DayOfWeek.Monday, today, threeWeeksFromNow);
            Assert.That(uut.dinnerDays.Count.Equals(1));
	    }

	    [Test]
	    public void Schedule_AddTwoDifferentWeekdaysGetDinnerDaysCount_Equals2()
	    {
	        uut.addDayToSchedule(DayOfWeek.Monday, today, threeWeeksFromNow);
	        uut.addDayToSchedule(DayOfWeek.Tuesday, today, threeWeeksFromNow);
	        Assert.That(uut.dinnerDays.Count.Equals(2));
	    }

	    [Test]
	    public void Schedule_AddNothingGetNumberOfDaysUserIsResponsibleFor_Equals0()
	    {
	        Assert.That(uut.getNumberOfTimesPersonIsChef("340").Equals(0));
	    }

	    [Test]
	    public void Schedule_AssignOneDateAtOneWeekdayGetNumberOfDaysUserIsResponsibleFor_Equals1()
	    {
	        uut.addDayToSchedule(DayOfWeek.Monday, today, threeWeeksFromNow);

	        uut.dinnerDays[0].AddParticipant("340");

	        uut.dinnerDays[0].setPersonResponsibleForDate(uut.dinnerDays[0].specificDates[0],"340");
            Assert.That(uut.getNumberOfTimesPersonIsChef("340").Equals(1));
	    }

	    [Test]
	    public void Schedule_AssignTwoDatesAtTwoDifferentWeekdaysGetNumberOfDaysUserIsResponsibleFor_Equals2()
	    {
	        uut.addDayToSchedule(DayOfWeek.Monday, today, threeWeeksFromNow);
	        uut.addDayToSchedule(DayOfWeek.Tuesday, today, threeWeeksFromNow);

	        uut.dinnerDays[0].AddParticipant("340");
	        uut.dinnerDays[1].AddParticipant("340");

	        uut.dinnerDays[0].setPersonResponsibleForDate(uut.dinnerDays[0].specificDates[0], "340");
	        uut.dinnerDays[1].setPersonResponsibleForDate(uut.dinnerDays[1].specificDates[0], "340");
            Assert.That(uut.getNumberOfTimesPersonIsChef("340").Equals(2));
	    }

	    [Test]
	    public void Schedule_AssignThreeDatesAtTwoDifferentWeekdaysGetNumberOfDaysUserIsResponsibleFor_Equals3()
	    {
	        uut.addDayToSchedule(DayOfWeek.Monday, today, threeWeeksFromNow);
	        uut.addDayToSchedule(DayOfWeek.Tuesday, today, threeWeeksFromNow);

	        uut.dinnerDays[0].AddParticipant("340");
	        uut.dinnerDays[1].AddParticipant("340");

	        uut.dinnerDays[0].setPersonResponsibleForDate(uut.dinnerDays[0].specificDates[0], "340");
	        uut.dinnerDays[1].setPersonResponsibleForDate(uut.dinnerDays[1].specificDates[0], "340");
	        uut.dinnerDays[1].setPersonResponsibleForDate(uut.dinnerDays[1].specificDates[1], "340");
            Assert.That(uut.getNumberOfTimesPersonIsChef("340").Equals(3));
	    }

	    [Test]
	    public void Schedule_JustInitializedCheckIfAnyClashingDates_ReturnsFalse()
	    {
            Assert.That(uut.checkIfAnyoneCooks2WeeksAfterAnother().Equals(false));
	    }

	    [Test]
	    public void Schedule_SetSamePersonResponsibleForTwoDatesInSameWeekCheckIfAnyClashingDates_ReturnsTrue()
	    {
	        uut.addDayToSchedule(DayOfWeek.Monday, today, threeWeeksFromNow);
	        uut.addDayToSchedule(DayOfWeek.Tuesday, today, threeWeeksFromNow);

	        uut.dinnerDays[0].AddParticipant("340");
	        uut.dinnerDays[1].AddParticipant("340");

	        uut.dinnerDays[0].setPersonResponsibleForDate(uut.dinnerDays[0].specificDates[0], "340");
	        uut.dinnerDays[1].setPersonResponsibleForDate(uut.dinnerDays[1].specificDates[0], "340");

            Assert.That(uut.checkIfAnyoneCooks2WeeksAfterAnother().Equals(true));
	    }

	    [Test]
	    public void Schedule_SetSamePersonResponsibleForTwoDatesInWeek0And1DifferentWeekdaysCheckIfAnyClashingDates_ReturnsTrue()
	    {
	        uut.addDayToSchedule(DayOfWeek.Monday, today, threeWeeksFromNow);
	        uut.addDayToSchedule(DayOfWeek.Tuesday, today, threeWeeksFromNow);

	        uut.dinnerDays[0].AddParticipant("340");
	        uut.dinnerDays[1].AddParticipant("340");

	        uut.dinnerDays[0].setPersonResponsibleForDate(uut.dinnerDays[0].specificDates[0], "340");
	        uut.dinnerDays[1].setPersonResponsibleForDate(uut.dinnerDays[1].specificDates[1], "340");

	        Assert.That(uut.checkIfAnyoneCooks2WeeksAfterAnother().Equals(true));
	    }
    }
}
