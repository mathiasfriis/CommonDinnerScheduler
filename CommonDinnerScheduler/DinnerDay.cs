using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDinnerScheduler
{
    public class DinnerDay
    {
        private List<String> Participants;
        private DayOfWeek dayOfWeek { get; set; }
        private DateTime startDate { get; set; }
        private DateTime endDate { get; set; }

        public DinnerDay(DayOfWeek weekDay, DateTime StartDate, DateTime EndDate)
        {
            Participants = new List<string>();
            dayOfWeek = weekDay;
            startDate = StartDate;
            endDate = EndDate;
        }

        public bool AddParticipant(String name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            //If name is not yet on list, add it
            if (!Participants.Contains(name))
            {
                Participants.Add(name);
                //Indicate that name has been added.
                return true;
            }
            else
            {
                //Indicate that name has not been added, since it's already on the list
                return false;
            }
        }

        public bool RemoveParticipant(String name)
        {
            //Check if name is in list
            if (Participants.Contains(name))
            {
                //Remove from list
                Participants.Remove(name);
                //return true, indicating name was removed
                return true;
            }
            else
            {
                //return false, indicating name was not removed
                return false;
            }
        }

        public int GetNumberOfParticipants()
        {
            return Participants.Count;
        }
    }
}
