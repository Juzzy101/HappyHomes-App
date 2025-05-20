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
            CustomersList = new List<Customers >();
            StaffMembers = new List<Staff >();
            Viewings = new List<Viewings >();
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
    }
}
