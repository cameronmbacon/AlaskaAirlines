using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlaskaAirlines.Models;
using CsvHelper;

namespace AlaskaAirlines.Controllers
{
    public class FlightController : Controller
    {
        public ActionResult Index()
        {
            var csv = new CsvReader(new StreamReader("./Data/flights.csv"));
            var flights = csv.GetRecords<Flight>();

            return View (flights.ToList());
        }
    }
}
