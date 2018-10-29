using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDinnerScheduler
{
    public class CommonDinnerDate
    {
        public String responsiblePerson { get; set; }
        private DateTime date { get; set; }

        public CommonDinnerDate(DateTime Date)
        {
            responsiblePerson = "None";
            date = Date;
        }
    }
}
