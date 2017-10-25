﻿using System;
namespace AlaskaAirlines.Models
{
    public class Flight
    {
        public string From { get; set; }
        public string To { get; set; }
        public int FlightNumber { get; set; }
        public string Departs { get; set; }
        public string Arrives { get; set; }
        public int MainCabinPrice { get; set; }
        public int FirstClassPrice { get; set; }
    }
}
