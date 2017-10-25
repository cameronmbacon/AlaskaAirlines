using System;
using System.Collections.Generic;
using AlaskaAirlines.Models;

namespace AlaskaAirlines.ViewModels
{
    public class FlightViewModel
    {
        public List<Airport> Airports { get; set; }
        public List<Flight> Flights { get; set; }
    }
}
