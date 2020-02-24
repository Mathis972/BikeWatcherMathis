using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Net.Http;
using BikeWatcher.Models;
using System.Diagnostics;

namespace BikeWatcher.Controllers
{
    public class ListeController : Controller
    {
        
        public async Task<IActionResult> Index()
        {
            var bikeStations = await BikeStation.ProcessBikeStations();
            bikeStations.Sort((x, y) => x.number.CompareTo(y.number));
            ViewBag.AllBikeStations = bikeStations;
            
            return View();
        }
    }
}