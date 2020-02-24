using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BikeWatcher.Controllers
{
    public class FavorisController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}