using Aircompany.Models;
using Aircompany.Planes;
using System;
using System.Collections.Generic;

namespace Aircompany
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Runner runner = new Runner();

            Airport airport = new Airport(runner.GetPlanes());
            Airport militaryAirport = new Airport(airport.GetMilitaryPlanes());
            Airport passengerAirport = new Airport(airport.GetPassengerPlanes());
            Console.WriteLine(militaryAirport
                              .SortByMaxFlightDistance()
                              .ToString());
            Console.WriteLine(passengerAirport
                              .SortByMaxSpeed()
                              .ToString());
            Console.WriteLine(passengerAirport.GetPassengerPlaneWithMaxPassengersCapacity());
        }
    }
}