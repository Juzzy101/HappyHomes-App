using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyHomes_App
{
    public class Staff
    {
        public string Name { get; set; }
        public List <DateTime> UnavailableTimes { get; set; }

        public Staff(string name)
        {
            Name = name;
            //create a list for that staff member
            UnavailableTimes = new List<DateTime>();
        }
        //Method to check if staff member is available at a specific time
        public bool IsAvailable(DateTime time) 
        {
            return !UnavailableTimes.Contains(time);
        }
    }
}
