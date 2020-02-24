using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeWatcher.Models;
using Microsoft.AspNetCore.Mvc;

namespace BikeWatcher.Controllers
{
    public class CarteController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var bikeStations = await BikeStation.ProcessBikeStations();
            ViewBag.AllBikeStations = bikeStations;
            ViewBag.Count = bikeStations.Count;
            return View();
        }
    }
}
