using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineTicket
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public string PassengerName { get; set; }

        public string FlightNumber { get; set; }

        public DateTime DepartureDate { get; set; }
        public DateTime DepartureTime { get; set; }

        public string DepartureLocation { get; set; }

        public string ArrivalLocation { get; set; }

        public bool isConfirmed { get; set; } = true;


        

        public Ticket(string passengerName, string flightNumber, DateTime departureDate,DateTime departureTime, string departureLocation, string arrivalLocation) 
        { 
            PassengerName = passengerName;
            FlightNumber = flightNumber;
            TicketId = new Random().Next(1000, 9999);
            DepartureDate = departureDate;
            DepartureTime = departureTime;
            DepartureLocation = departureLocation;
            ArrivalLocation = arrivalLocation;
        
        }

        public void DisplayTicketInfo()
        {
            Console.WriteLine($"Ticket ID: {TicketId} Passenger: {PassengerName} Flight: {FlightNumber}");
            Console.WriteLine($"Departure: {DepartureLocation} on {DepartureDate:yyyy-mm-dd} at {DepartureTime: HH:mm}");
            Console.WriteLine($"Arrival Location {ArrivalLocation} | Confirmed {isConfirmed}");

        }



        //public Ticket(string passengerName, string flightNumber, DateTime departureDate, string origin, string destination)
        //{
        //    PassengerName = passengerName;
        //    FlightNumber = flightNumber;
        //    DepartureDate = departureDate;
        //}
    }
}
