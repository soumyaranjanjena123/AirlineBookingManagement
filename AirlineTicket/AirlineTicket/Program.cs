// See https://aka.ms/new-console-template for more information

using AirlineTicket;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

public class Program
{
    public static void Main(string[] args)
    {

        string pathname = "C:\\Users\\soumy\\source\\repos\\AirlineTicket\\AirlineTicket\\User.json";

        Registration registration = new Registration();
        Login logoin = new Login();
        Booking booking = new Booking();


        Console.WriteLine("Welcome to the Airline Booking System");
        bool running = true;
        bool loggedIn = false;



        

        while (running)
        {
            Console.WriteLine("\nMain Menu");
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");

            if (loggedIn)
            {
                Console.WriteLine("3.Book a Ticket");
                Console.WriteLine("4.View Ticket");
            }
            //Console.WriteLine("3. Book a Ticket");
            //Console.WriteLine("4. View Booked Ticket");
            Console.WriteLine("5. Exit");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    registration.RegisterUser();
                break;

                case "2": 
                    logoin.LoginUser();
                    if(logoin.CurrentUser != null)
                    {
                        loggedIn = true;
                        Console.WriteLine("Logged in successfull");
                    }
                    else
                    {
                        Console.WriteLine("Login failed please try again");
                    } 
                break;

                case "3":
                    if(loggedIn)
                    {
                         booking.BookTickets(logoin.CurrentUser.Username);

                    }
                    else
                    {
                        Console.WriteLine("Please Login");
                    }
                break;

                case "4":
                    if (loggedIn)
                    {
                      booking.ViewTictes(logoin.CurrentUser.Username);

                    }
                break;

                case "5":
                    running = false;
                    Console.WriteLine("Exiting the application , Good Bye");
                break;

                default:
                    Console.WriteLine("Inavalid Option");
                break;

            }
        }



    }
}
