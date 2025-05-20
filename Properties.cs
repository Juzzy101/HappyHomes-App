using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyHomes_App
{
    public class Properties
    {
        public string PropertyID { get; set; }
        public string PropertyType { get; set; }
        public string Address { get; set; }
        //Constructor to create any Property Objects
        public Properties(string propertyID, string propertyType, string address)
        {
            PropertyID = propertyID;
            PropertyType = propertyType;
            Address = address;
        }
        //Method to get details of Property
        public string GetDetails()
        {
            return PropertyType + " - " + Address + " - " + PropertyID;
        }

    }
}
