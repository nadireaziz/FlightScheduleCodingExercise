using System;
namespace FlightSchedule
{
    public class Order
    {
        public string? OrderId { get; set; }
        public string Departure { get; set; } = "YUL"; // set default as YUL
        public string? Destination { get; set; }
        public int FlightNumber { get; set; } = 0; // not scheduled by default
        public int Day { get; set; }

        public override string ToString()
        {
            return $"order: {OrderId}, {((FlightNumber == 0) ? "flightNumber: not scheduled" : $"flightNumber: {FlightNumber}, departure: {Departure}, arrival: {Destination}, day: {Day} ")}";
        }
    }
}

