using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Net.Http;
using BikeWatcher.Models;
using BikeWatcher.Repository;
using System.Diagnostics;
using BikeWatcher.Utils;

namespace BikeWatcher.Controllers
{
    public class ListeController : Controller
    {
        public const float parisLat = 48.8f, parisLon = 2.3f;
        private const string defaultString = "Lyon";
        public static float lat, lon;
        public async Task<IActionResult> Index(float lat = parisLat, float lon = parisLon, string ville = defaultString)
        {
            if (ville == "Lyon")
            {
                var bikeStations = await RepositoryBikeStations.ProcessBikeStations("https://download.data.grandlyon.com/ws/rdata/jcd_jcdecaux.jcdvelov/all.json");
                ListeController.lat = lat;
                ListeController.lon = lon;
                bikeStations.Sort();
                ViewBag.AllBikeStations = bikeStations;
            }
            else if (ville == "Bordeaux")
            {
                var bikeStations = await RepositoryBikeStations.ProcessBikeStationsBdx("https://api.alexandredubois.com/vcub-backend/vcub.php");
                //bikeStations.Sort((x, y) => x.SortByNumberAscending(x.number, y.number));
                ViewBag.AllBikeStations = bikeStations;
            }

            return View();
            
        }
    }
}