using System;
namespace FlightSchedule
{
	public class FlightScheduler
    {
        public List<Order> Orders;
        public List<Flight> Flights;


        public FlightScheduler(List<Flight> flights, List<Order> orders)
		{
			this.Orders = orders;
			this.Flights = flights;
        }

		public void DisplayFlightItineraries()
		{
            foreach (var flight in this.Flights)
            {
                foreach (var order in this.Orders)
                {
                    if (order.FlightNumber == 0 && order.Destination == flight.Arrival && order.Departure == flight.Departure && flight.Capacity > 0)
                    {
                        order.FlightNumber = flight.FlightNumber;
                        order.Day = flight.Day;
                        flight.Capacity --;
                    }
                }
            }
            foreach (var order in Orders)
            {
                Console.WriteLine(order.ToString());
            }
        }
	}
}

