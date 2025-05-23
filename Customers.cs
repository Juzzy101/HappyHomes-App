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
        public string FullName {  get; set; }
        public string Email { get; set; }
        public string Address   { get; set; }    
        public string PhoneNumber { get; set; }
        public int MissedViewing { get; set; }


        //Constructor to create Customer Object
        public Customers(string fullName, string email, string address, string phoneNumber)
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
        public string GetDetails()
        {
            return $"ID:{CustomerId} | Name: {FullName} | Email: {Email} | Address: {Address} | Phone Number {PhoneNumber} | MissedViewing: {MissedViewing}";
        }
        public bool CanBookViewing
        { get
            { return MissedViewing < 3;
            }
        }
    }
}
