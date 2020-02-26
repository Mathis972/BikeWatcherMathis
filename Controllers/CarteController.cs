using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeWatcher.Data;
using BikeWatcher.Models;
using BikeWatcher.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BikeWatcher.Controllers
{
    public class CarteController : Controller
    {
        private readonly BikeWatcherContext _context;
        public CarteController(BikeWatcherContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var bikeStations = await RepositoryBikeStations.ProcessBikeStations("https://download.data.grandlyon.com/ws/rdata/jcd_jcdecaux.jcdvelov/all.json");
            var bikeStationsBdx = await RepositoryBikeStations.ProcessBikeStationsBdx("https://api.alexandredubois.com/vcub-backend/vcub.php");
            ViewBag.AllBikeStations = bikeStations.Concat(bikeStationsBdx);
            return View();
        }
        public async Task<IActionResult> AddStationToFav(int id)
        {
            var favStation = new Favoris();
            favStation.IDBikeStation = id;
            _context.Favoris.Add(favStation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
