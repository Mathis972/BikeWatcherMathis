using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeWatcher.Models;
using BikeWatcher.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BikeWatcher.Controllers
{
    public class CarteController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var bikeStations = await RepositoryBikeStations.ProcessBikeStations("https://download.data.grandlyon.com/ws/rdata/jcd_jcdecaux.jcdvelov/all.json");
            var bikeStationsBdx = await RepositoryBikeStations.ProcessBikeStationsBdx("https://api.alexandredubois.com/vcub-backend/vcub.php");
            ViewBag.AllBikeStations = bikeStations.Concat(bikeStationsBdx);
            ViewBag.Count = bikeStations.Count;
            return View();
        }
    }
}
