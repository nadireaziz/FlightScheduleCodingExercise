using System;
namespace FlightSchedule
{
    public class Flight
    {
        public int FlightNumber { get; set; }
        public int Day { get; set; }
        public string? Departure { get; set; }
        public string? Arrival { get; set; }
        public int Capacity = 20;

        public override string ToString()
        {
            return $"Flight: {FlightNumber}, departure: {Departure}, arrival: {Arrival}, day: {Day}";
        }
    }
}

