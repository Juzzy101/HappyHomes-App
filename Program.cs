using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HappyHomes_App
{
    internal class Program
    {
        static void Main(string[] args)
        {// Create a Real Estate
            RealEstate realEstate1 = new RealEstate();

            //add staff members to store using AddStaff method and the constructor from staff.cs
            realEstate1.AddStaff(new Staff("Alice"));
            realEstate1.AddStaff(new Staff("Bart"));
            Console.WriteLine("Welcome to Happy Homes Estate");

            //Menu Stystem
            //flag use to exit the program
            bool exitMenu = false;
            while (!exitMenu)
            {
                Console.WriteLine("\n ---------------- Main Menu----------");
                Console.WriteLine("----Customer Options: ");
                Console.WriteLine("1. Add Customer ");
                Console.WriteLine("2. View All Customers ");
                Console.WriteLine("3. Filter Customer by name ");
                Console.WriteLine("----Properties Options: ");
                Console.WriteLine("4. Add Properties ");
                Console.WriteLine("5. View all Properties ");
                Console.WriteLine("6. Filter Property By Name ");

                Console.WriteLine("----Viewing Options:");
                Console.WriteLine("7. Add new booking");
                Console.WriteLine("8. View all bookings");
                Console.WriteLine("9. Adjust booking");
                Console.WriteLine("10. Find booking");
                Console.WriteLine("11. Quit");
                string option = Console.ReadLine();
                //Allows user to add new customer
                if (option == "1")
                {
                    Console.WriteLine("Enter Full Name");
                    string name = Console.ReadLine();

                    Console.WriteLine("Enter Email:");
                    string email = Console.ReadLine();

                    Console.WriteLine("Enter Address:");
                    string address = Console.ReadLine();
                    Console.WriteLine("Enter Phone Number:");
                    string phoneNumber = Console.ReadLine();
                    Customers newCustomer = new Customers(name, email, address, phoneNumber);
                    realEstate1.AddCustomer(newCustomer);
                    Console.WriteLine("Customer has been added");
                }
                else if (option == "2")
                {
                    Console.WriteLine("All Customers");
                    foreach (Customers customer in realEstate1.CustomersList)
                    {
                        Console.WriteLine(customer.GetDetails());
                        if (customer.CanBookViewing)
                        {
                            Console.WriteLine("Status: Can make Booking");
                        }
                        else
                        {
                            Console.WriteLine("Status: Blocked from Bookings");
                        }
                    }
                }
                else if (option == "3")
                {
                    Console.WriteLine("Enter customer full name");
                    string name = Console.ReadLine();
                    foreach (Customers customer in realEstate1.CustomersList)
                    {
                        if (customer.FullName == name)
                        {
                            Console.WriteLine(customer.GetDetails());
                        }
                    }
                }
                else if (option == "4")
                {
                    Console.WriteLine("Property ID:");
                    string id = Console.ReadLine();
                    Console.WriteLine("Property Type (choose from: detached, semi-detached, bungalow, flat, terrace or enterprise property)");
                    string type = Console.ReadLine();
                    Console.WriteLine("Address");
                    string address = Console.ReadLine();

                    realEstate1.AddProperties(new Properties(id, type, address));

                }
                else if (option == "5")
                {
                    foreach (Properties properties in realEstate1.Properties)
                    {
                        Console.WriteLine(properties.GetDetails());
                    }
                }
                else if (option == "6")
                {
                    {
                        Console.WriteLine("Enter property address");
                        string address = Console.ReadLine();
                        foreach (Properties properties in realEstate1.Properties)
                        {
                            if (properties.Address == address)
                            {
                                Console.WriteLine(properties.GetDetails());
                            }
                        }
                    }
                }
                else if (option == "7")
                {
                    Console.WriteLine("Customer Email: ");
                    string email = Console.ReadLine();
                    Console.WriteLine("Property Id");
                    string PropertyId = Console.ReadLine();
                    Console.WriteLine("Staff name: ");
                    string staffName = Console.ReadLine();
                    Console.WriteLine("Viewing Time (yyyy-mm-dd HH:mm)");
                    string timeInput = Console.ReadLine();
                    DateTime viewingTime = DateTime.Parse(timeInput);

                    //Method to create booking
                    realEstate1.BookViewing(email, PropertyId, staffName, viewingTime);


                }
                else if (option == "8")
                {
                    foreach (Viewings viewing in realEstate1.Viewings)
                    {
                        Console.WriteLine($"{viewing.Customers.FullName} - {viewing.Properties.Address} - {viewing.Staff.Name} - {viewing.ViewingTime} | {viewing.Status}");
                    }
                }
                else if (option == "9")
                {

                    Console.WriteLine("Enter Customer ID of the viewing to adjust ");
                    int customerID;
                    bool parsed = Int32.TryParse(Console.ReadLine(), out customerID);
                    if (!parsed)
                    {
                        Console.WriteLine("Invalid ID");
                        continue;
                    }
                    //Find vieving
                    Viewings viewing = null;
                    foreach (var v in realEstate1.Viewings)
                    {
                        if (v.Customers.CustomerId == customerID)
                        {
                            viewing = v;
                            break;
                        }
                    }
                    if (viewing!= null)
                    {
                        Console.WriteLine("Current Status: " + viewing.Status);
                        Console.WriteLine("Enter new status (Booked, Viewing Attended, Viewing Missed, Cancelled: ");
                        string newStatus = Console.ReadLine();

                        realEstate1.AdjustVievingStatus(viewing.Customers.CustomerId, newStatus);
                    }
                    else
                    {
                        Console.WriteLine("Viewing not found");
                    }

                }
                else if (option =="10")
                {
                    Console.WriteLine("Enter Customer ID");
                    int customerID;
                    bool validID = Int32.TryParse(Console.ReadLine(),out customerID);
                    if (!validID)
                    {
                        Console.WriteLine("Invalid ID");
                        continue;
                    }
                    Viewings  foundviewing = null;
                    foreach (var v in realEstate1.Viewings)
                    {
                        if (v.Customers.CustomerId == customerID)
                        {
                            foundviewing = v;
                            break;

                        }
                    }
                    if (foundviewing != null)
                    {
                        Console.WriteLine($"Vieving for Custome: {foundviewing.Customers.FullName}");
                        Console.WriteLine($"Property: {foundviewing.Properties.GetDetails()}");
                        Console.WriteLine($"Staff: {foundviewing.Staff.Name}");
                        Console.WriteLine($"Time: {foundviewing.ViewingTime}");
                        Console.WriteLine($"Status: {foundviewing.Status}"); 
                    }
                    else
                    {
                        Console.WriteLine("No viewings found for Customer Id");
                    }
                }
                else if(option =="11")
                {
                    exitMenu = true;
                    Console.WriteLine("Exiting system");
                }
            }
        }
    }
}

