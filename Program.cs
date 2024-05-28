using FlightSchedule;
using Newtonsoft.Json;

public class Program
{
    public static void Main(string[] args)
    {
        // USER STORY #1
        List<Flight> flights = new List<Flight>
        {
            new Flight { FlightNumber = 1, Departure = "YUL", Arrival = "YYZ", Day = 1 },
            new Flight { FlightNumber = 2, Departure = "YUL", Arrival = "YYC", Day = 1 },
            new Flight { FlightNumber = 3, Departure = "YUL", Arrival = "YVR", Day = 1 },
            new Flight { FlightNumber = 4, Departure = "YUL", Arrival = "YYZ", Day = 2 },
            new Flight { FlightNumber = 5, Departure = "YUL", Arrival = "YYC", Day = 2 },
            new Flight { FlightNumber = 6, Departure = "YUL", Arrival = "YVR", Day = 2 }
        };

        foreach (var flight in flights)
        {
            Console.WriteLine(flight.ToString());
        }

        // USER STORY #2
        List<Order> orders = ParseJsonFile();
        FlightScheduler flightScheduler = new FlightScheduler(flights, orders);
        flightScheduler.DisplayFlightItineraries();
    }

    private static List<Order> ParseJsonFile()
    {
        // Get the current directory (under bin/Debug/net7.0)
        string currentDirectory = Directory.GetCurrentDirectory();
        string projectRoot = Directory.GetParent(currentDirectory).Parent.Parent.FullName;// make sure the root folder is correct, parent could be null here. 

        // Combine the project root path with the file name
        string filePath = Path.Combine(projectRoot, "OrderDetail.json");
        if (File.Exists(filePath))
        {
            var json = File.ReadAllText(filePath);
            var dictionary = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(json);
            var orders = new List<Order>();
            if (dictionary != null)
            {
                foreach (var dict in dictionary)
                {
                    orders.Add(new Order { OrderId = dict.Key, Destination = dict.Value["destination"] });
                }
            }
            return orders;
        }
        else
        {
            throw new FileNotFoundException();
        }
    }

}