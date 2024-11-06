using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AirlineTicket
{
    public class Booking
    {

        private const string ticketFile = "C:\\Users\\soumy\\source\\repos\\AirlineTicket\\AirlineTicket\\tickets.json";

        private AirlineData airlineData = new AirlineData();

        public void ShowAvailableFlights(string departureLocation=null, string arrivalLocation = null)
        {
            List<Flight> flights = airlineData.GetAvailableFlights();


            //filter flight based on the user input

            if (!string.IsNullOrEmpty(departureLocation) && !string.IsNullOrEmpty(arrivalLocation)) 
            {
                flights = flights.FindAll(f => f.Origin.Equals(departureLocation, StringComparison.OrdinalIgnoreCase) &&
                                                f.Destination.Equals(arrivalLocation, StringComparison.OrdinalIgnoreCase)); 
            }

            if (flights.Count == 0) 
            {
                Console.WriteLine("No available flight for this route");
                return;
            }



            Console.WriteLine("Available flights");

            Console.WriteLine("......................................................................................");
            foreach (var flight in flights)
            {
                Console.WriteLine($"Flight Number: {flight.FlightNumber}, Departure:{flight.Origin} to {flight.Destination} , Date: {flight.DepartureDate.ToString("dd/MM/yyyy")}, Time:{flight.DepartureTime.ToShortTimeString()}, Seat:{flight.AvailableSeats}");
            }
        }

        public void BookTickets(string passengerName)
        {

            Console.WriteLine("Enter Departure Location");
            string departureLocation = Console.ReadLine();

            Console.WriteLine("Enetr Arrival Location");
            string arrivalLocation = Console.ReadLine();


            ShowAvailableFlights(departureLocation,arrivalLocation);


            Console.WriteLine("Enter Flight Number");
            string flightNumber = Console.ReadLine();

            List<Flight> flights = airlineData.GetAvailableFlights();

            Flight selectedFlight = flights.Find(f => f.FlightNumber.Equals(flightNumber, StringComparison.OrdinalIgnoreCase)&&
                                                      f.Origin.Equals(departureLocation, StringComparison.OrdinalIgnoreCase)&&
                                                      f.Destination.Equals(arrivalLocation, StringComparison.OrdinalIgnoreCase));

            if (selectedFlight == null)
            {

                Console.WriteLine("Invalid flight number, please try again");
                return;
            }

            if (selectedFlight.AvailableSeats <= 0)
            {
                Console.WriteLine("sorry, no seats available on this flight");
                return;
            }

            //Console.WriteLine("Enter Departure Date (yyyy-mm-dd)");
            //DateTime departureDate;

            //while (!DateTime.TryParse(Console.ReadLine(), out departureDate) || departureDate.Date != selectedFlight.DepartureDate.Date)
            //{
            //    Console.WriteLine($"Please enetr the exact date of {selectedFlight.DepartureDate.ToShortDateString()}");
            //}

            //Ticket newTicket = new Ticket(passengerName, selectedFlight.FlightNumber,selectedFlight.Departure,selectedFlight.Origin,selectedFlight.Destination);
            Ticket newTicket = new Ticket(passengerName, selectedFlight.FlightNumber, selectedFlight.DepartureDate,selectedFlight.DepartureTime, selectedFlight.Origin, selectedFlight.Destination);

            List<Ticket> tickets = LoadTicket();

            tickets.Add(newTicket);

            SaveTickets(tickets);

            selectedFlight.AvailableSeats--;

            airlineData.saveFlight(flights);

            


            Console.WriteLine($"Ticket booked SuccesFully! Your Ticket id is: {newTicket.TicketId}");

        }

        

        public void ViewTictes(string passengerName)
        {
            List<Ticket> tickets = LoadTicket();
            List<Ticket> userTickets = tickets.Where(t => t.PassengerName.Equals(passengerName, StringComparison.OrdinalIgnoreCase)).ToList();

            if(userTickets.Count == 0)
            {
                Console.WriteLine("No ticktes Found");
                return;
            }

            Console.WriteLine($"Tickets for {passengerName}:");

            foreach(var ticket in userTickets)
            {
                ticket.DisplayTicketInfo();
                Console.WriteLine("- - - - - - -");
            }

        }

        //Method to Load tickets form th JSON file into a list of Ticket object
    private List<Ticket> LoadTicket()
    {
            if (!File.Exists(ticketFile))
                return new List<Ticket>();

            var jsonData = File.ReadAllText(ticketFile);

            if (string.IsNullOrWhiteSpace(jsonData))
            {
                return new List<Ticket>();
            }

            return JsonSerializer.Deserialize<List<Ticket>>(jsonData); //Deserialize JSOn to a list of Ticket object

    }

        //Method to save the current list of tickets ot the json file

        private void SaveTickets(List<Ticket> tickets)
        {
            var jsonData = JsonSerializer.Serialize(tickets);// serialize the list of tickets to json format
            File.WriteAllText(ticketFile, jsonData);//write JSON data to the file
        }

    
    }

}

