using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Text.Json.Serialization;


namespace AirlineTicket
{
    public class Flight
    {
        //public string FlightName { get; set; }

        public string FlightNumber { get; set; }

        public string Origin { get; set; }

        public string Destination { get; set; }

        public DateTime DepartureTime { get; set; }
        public DateTime DepartureDate { get; set; }

        public int AvailableSeats { get; set; }


    //public Flight(string flightname, string flightNumber, string origin, string destination, DateTime departureTime, int availableSeats,DateTime departureDate)
    //{
    //    FlightName = flightname;
    //    FlightNumber = flightNumber;
    //    Origin = origin;
    //    Destination = destination;
    //    DepartureTime = departureTime;
    //    AvailableSeats = availableSeats;
    //    DepartureDate = departureDate;
    //}

        public Flight(string flightNumber, string origin, string destination, DateTime departureDate, DateTime departureTime, int availableSeats)
        {
            FlightNumber = flightNumber;
            Origin = origin;
            Destination = destination;
            DepartureDate = departureDate;
            DepartureTime = departureTime;
            AvailableSeats = availableSeats;
        }
        


    }

    

}
