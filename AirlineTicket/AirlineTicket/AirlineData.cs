using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AirlineTicket
{
    public class AirlineData
    {
        public string flightFile = "C:\\Users\\soumy\\source\\repos\\AirlineTicket\\AirlineTicket\\flightdata.json";



        public List<Flight> GetAvailableFlights()
        {
            if (File.Exists(flightFile))
            {
                var jsonData = File.ReadAllText(flightFile);

                
                if (!string.IsNullOrWhiteSpace(jsonData))
                {
                    try
                    {
                        return JsonSerializer.Deserialize<List<Flight>>(jsonData);

                    }
                    catch (JsonException)
                    {
                        Console.WriteLine("Error: file not found.");
                    }
                }
            }

            var defaultFlight= new List<Flight>
            {
                new Flight("AA101","Jk","LAX",new DateTime(2024, 12,15), new DateTime(2024,12,15,9,0,0),10),
                new Flight("AA102","BBS","NDL",new DateTime(2024, 12,16), new DateTime(2024,12,16,14,30,0),5),
                new Flight("AA103","MH","BGl",new DateTime(2024, 12,17), new DateTime(2024,12,17,18,15,0),7),

            };
            saveFlight(defaultFlight);
            return defaultFlight;
        }
    public void saveFlight(List<Flight> flights)
    {
        var jsonData = JsonSerializer.Serialize(flights);
        File.WriteAllText(flightFile, jsonData);
    }

    }

}
