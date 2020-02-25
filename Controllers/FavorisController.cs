using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeWatcher.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BikeWatcher.Controllers
{
    public class FavorisController : Controller
    {
        private readonly BikeWatcherContext _context;
        public FavorisController(BikeWatcherContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Favoris.ToListAsync());
        }
    }
}