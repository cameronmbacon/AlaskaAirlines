using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using AlaskaAirlines.Models;
using AlaskaAirlines.ViewModels;
using CsvHelper;

namespace AlaskaAirlines.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string From, string To, string SortBy)
        {
            List<Flight> FilteredFlights = new List<Flight>();

            var csv = new CsvReader(new StreamReader("./Data/airports.csv"));
            var airports = csv.GetRecords<Airport>().ToList();

            csv = new CsvReader(new StreamReader("./Data/flights.csv"));
            var flights = csv.GetRecords<Flight>().ToList();

            foreach (var f in flights)
            {
                if (f.From == From && f.To == To)
                {
                    DateTime departs = DateTime.Parse(f.Departs);
                    DateTime arrives = DateTime.Parse(f.Arrives);

                    f.Departs = departs.ToString("HH:mm");
                    f.Arrives = arrives.ToString("HH:mm");

                    FilteredFlights.Add(f);
                }
            }

            if (!String.IsNullOrEmpty(SortBy))
            {
                switch (SortBy)
                {
                    case "Departs":
                        FilteredFlights.Sort((x, y) => x.Departs.CompareTo(y.Departs));
                        break;
                    case "Arrives":
                        FilteredFlights.Sort((x, y) => x.Arrives.CompareTo(y.Arrives));
                        break;
                    case "MainCabin":
                        FilteredFlights.Sort((x, y) => x.MainCabinPrice.CompareTo(y.MainCabinPrice));
                        break;
                    case "FirstClass":
                        FilteredFlights.Sort((x, y) => x.FirstClassPrice.CompareTo(y.FirstClassPrice));
                        break;
                }
            }

            var FlightVM = new FlightViewModel
            {
                Airports = airports,
                Flights = FilteredFlights
            };

            return View(FlightVM);
        }
    }
}
