using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeWatcher.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BikeWatcher.Controllers
{
    public class BrokenBikeController : Controller
    {
        private readonly BikeWatcherContext _context;
        public BrokenBikeController(BikeWatcherContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index([Bind("IDBikeStation", "Commentaire")] Models.BrokenBike brokenBike)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(brokenBike);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                                             "Try again, and if the problem persists " +
                                             "see your system administrator.");
            }
            return View(brokenBike);
        }
    }
}