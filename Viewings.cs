using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace HappyHomes_App
{
    public class Viewings
    {
        public Customers Customers { get; set; }
        public Properties Properties { get; set; }

        public Staff Staff { get; set; }
        public DateTime ViewingTime { get; set; }
        public string Status { get; set; }

        public Viewings(Customers customers, Properties properties, Staff staff, DateTime viewingTime)
        {
            Customers = customers;
            Properties = properties;
            Staff = staff;
            ViewingTime = viewingTime;
            Status = "Bookings";
        }

    }
}