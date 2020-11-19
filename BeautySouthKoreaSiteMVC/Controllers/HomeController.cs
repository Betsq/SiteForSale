using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BeautySouthKoreaSiteMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace BeautySouthKoreaSiteMVC.Controllers
{
    public class HomeController : Controller
    {

        private readonly CosmeticContext db;
        public HomeController(CosmeticContext context)
        {
            db = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await db.Cosmetics.ToListAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
