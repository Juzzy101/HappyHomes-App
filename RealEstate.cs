using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyHomes_App
{
    public class RealEstate
    {
        public List<Properties> Properties { get; set; }
        public List<Customers> CustomersList { get; set; }
        public List<Staff> StaffMembers { get; set; }
        public List<Viewings> Viewings { get; set; }

        public RealEstate()
        {
            Properties = new List<Properties>();
            CustomersList = new List<Customers>();
            StaffMembers = new List<Staff>();
            Viewings = new List<Viewings>();
        }
        //Method to take in a Staff Object and store in the List StaffMembers
        public void AddStaff(Staff staff)
        {
            StaffMembers.Add(staff);
        }
        //Method to take in a Customer Object and store in the List Customers
        public void AddCustomer(Customers customer)
        {
            CustomersList.Add(customer);
        }
        //Method to take in a Property Object and store in the List Properties

        public void AddProperties(Properties properties)
        {

            Properties.Add(properties);
        }

        public Viewings BookViewing(string customerEmail, string PropertyId, string staffName, DateTime viewingTime)
        {
            //try to find the customer and the list of customers in realEstate object
            Customers customer = null;
            //loop through customer list
            foreach (Customers c in CustomersList)
            { //if the email is used when calling the method (BookViewing)
                if (c.Email == customerEmail)
                {
                    //copy all details of the customer to the blank customer object
                    customer = c;
                    break;
                }
            }
            Properties properties = null;
            //loop through properties list
            foreach (Properties p in Properties)
            { //if the PropertyID is used when calling the method (BookViewing)
                if (p.PropertyID == PropertyId)
                {
                    //copy all details of the properties to the blank properties object
                    properties = p;
                    break;
                }
            }
            Staff staff = null;
            //loop through staff list
            foreach (Staff s in StaffMembers)
            { //if the Name is used when calling the method (BookViewing)
                if (s.Name == staffName)
                {
                    //copy all details of the staff to the blank staff object
                    staff = s;
                    break;
                }
            }
            //we have now checked the staff, property and customer all real

            if (customer == null || properties == null || staff == null)
            {
                Console.WriteLine("Error, Customer, Property or Staff Member not found in RealEstate system");
                return null;
            }
            //check whether customer has missed too many previous viewings - 3 max
            if (!customer.CanBookViewing)

            {
                Console.WriteLine("Customer hass missed too many viewings. Cannot Book");
                return null;

            }
            //Check Staff to see if staff are free
            foreach (Viewings viewing in Viewings)
            {
                if (viewing.Staff.Name == staff.Name && viewing.ViewingTime == viewingTime)
                {
                    Console.WriteLine("Staff member is already booked for this time");
                    return null;
                }
            }

            //if all passess are checked, add new viewing
            Viewings newViewing = new Viewings(customer, properties, staff, viewingTime);
            Viewings.Add(newViewing); //add to viewing list in store object
            return newViewing; // return the successful booking
        }
        public void AdjustVievingStatus(int viewingID, string newStatus)
        {
            Viewings viewing = null;
            foreach (var v in Viewings)
            {
                if (v.Customers.CustomerId == viewingID)
                {
                    viewing = v;
                    break;
                }
            }
            if (viewing != null)
            {
                if (newStatus == "Booked" || newStatus == "Viewing Attended" || newStatus == "Viewing Missed" || newStatus == "Cancelled")
                {
                    viewing.Status = newStatus;
                    //viewing missed add one to customer
                    if (newStatus == "Viewing Missed")
                    {
                        viewing.Customers.MissedViewing++;
                        if (viewing.Customers.MissedViewing <= 3)
                        {
                            Console.WriteLine("Customer can no longer make bookings");
                        }
                    }
                    Console.WriteLine("Viewing status updated");

                }
                else
                {
                    Console.WriteLine("Invalid Status given)");
                }
            }
            else
            {
                Console.WriteLine("Viewing not found");
            }
        }
    }
}
