using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CommonDinnerScheduler
{
    public class Schedule
    {
        public List<DinnerDay> dinnerDays;

        public Schedule()
        {
            dinnerDays=new List<DinnerDay>();
        }

        public bool addDayToSchedule(DayOfWeek weekday,DateTime startDate, DateTime endDate)
        {
            //Check whether day is already added
            if (dinnerDays.All(x => x.dayOfWeek != weekday))
            {
                //If day is not in schedule yet, add it and return true, indicating that day was added.
                dinnerDays.Add(new DinnerDay(weekday,startDate,endDate));
                return true;
            }
            else
            {
                //Return false, indicating that day was not added, since it was already in list
                return false;
            }
        }

        public int getNumberOfTimesPersonIsChef(string name)
        {
            int nDays = 0;
            foreach (DinnerDay weekDay in dinnerDays)
            {
                foreach (CommonDinnerDate date in weekDay.specificDates)
                {
                    if (date.responsiblePerson.Equals(name))
                    {
                        nDays++;
                    }
                }
            }

            return nDays;
        }
    }
}
