using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyHomes_App
{
    public class Customers
    {
        // static variable to generate unique customer ID's
        private static int nextId = 1;

        public int CustomerId { get; set; }
        public int FullName {  get; set; }
        public int Email { get; set; }
        public int Address   { get; set; }    
        public int PhoneNumber { get; set; }
        public int MissedViewing { get; set; }


        //Constructor to create Customer Object
        public Customers(int fullName, int email, int address, int phoneNumber)
        {
            //Increased customer Id by 1 each time a new customer is added
            CustomerId = nextId;
            nextId = nextId + 1;

            FullName = fullName;
            Email = email;
            Address = address;
            PhoneNumber = phoneNumber;
            //new customer so no missed bookings
            MissedViewing = 0;
        }
        //method to return all Customer details
        public string GetDetsils()
        {
            return $"ID:{CustomerId} Name: {FullName} Email: {Email} + MissedViewing: {MissedViewing}";
        }
        public bool CanBookViewing
        { get
            { return MissedViewing < 3;
            }
        }
    }
}
