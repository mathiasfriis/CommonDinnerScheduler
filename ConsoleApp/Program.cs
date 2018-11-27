using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonDinnerScheduler;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Schedule schedule = new Schedule();

            DateTime mondayStart = new DateTime(2018, 11, 26);
            DateTime mondayEnd = mondayStart.AddDays(7 * 10);

            DateTime wednesdayStart = mondayStart.AddDays(2);
            DateTime wednesdayEnd = mondayEnd.AddDays(2);

            schedule.addDayToSchedule(DayOfWeek.Monday, mondayStart, mondayEnd);
            schedule.addDayToSchedule(DayOfWeek.Wednesday, wednesdayStart, wednesdayEnd);

            schedule.signPersonUpForDay("337", schedule.dinnerDays[0]);
            schedule.signPersonUpForDay("338", schedule.dinnerDays[0]);
            schedule.signPersonUpForDay("339", schedule.dinnerDays[0]);
            schedule.signPersonUpForDay("340", schedule.dinnerDays[0]);
            schedule.signPersonUpForDay("341", schedule.dinnerDays[0]);
            schedule.signPersonUpForDay("342", schedule.dinnerDays[0]);

            schedule.signPersonUpForDay("330", schedule.dinnerDays[1]);
            schedule.signPersonUpForDay("331", schedule.dinnerDays[1]);
            schedule.signPersonUpForDay("332", schedule.dinnerDays[1]);
            schedule.signPersonUpForDay("340", schedule.dinnerDays[1]);
            schedule.signPersonUpForDay("341", schedule.dinnerDays[1]);
            schedule.signPersonUpForDay("342", schedule.dinnerDays[1]);

            schedule.AssignDates();
            while (schedule.getMaxRatioDifference()>0.5)
            {
                schedule.AssignDates();
            }
            schedule.PrintScheduleToConsole();
            
            foreach(var p in schedule.participants)
            {
                Console.WriteLine(p + " - Cooked " + schedule.getNumberOfTimesPersonIsChef(p) + " times, participates in " + schedule.nDaysSignedUpFor[p] + " days - ratio=" + schedule.nDaysChefPrSignedUpDate[p]);
            }

            Console.ReadKey();
        }
    }
}
