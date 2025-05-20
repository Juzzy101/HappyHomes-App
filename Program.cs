using System;
using System.Collections.Generic;
using System.Linq;
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
            { Console.WriteLine("\n ---------------- Main Menu----------");
                Console.WriteLine("Customer Options:");
                Console.WriteLine("1. Add Customer");
                Console.WriteLine("2. View All Customers");
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
                else if (option == "2") {
                        Console.WriteLine("All Customers");
                        foreach(Customers customer in realEstate1.CustomersList)
                        {
                            Console.WriteLine(customer.GetDetsils());
                        }
                    }

                }
             }

        }
    }

