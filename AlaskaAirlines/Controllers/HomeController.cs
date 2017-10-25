using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using AlaskaAirlines.Models;
using CsvHelper;

namespace AlaskaAirlines.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var csv = new CsvReader(new StreamReader("./Data/airports.csv"));
            var airports = csv.GetRecords<Airport>();

            return View(airports.ToList());
        }
    }
}
