using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BeautySouthKoreaSiteMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace BeautySouthKoreaSiteMVC.Controllers
{
    public class HomeController : Controller
    {

        private readonly CosmeticContext db;
        public HomeController(CosmeticContext context)
        {
            db = context;
        }
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name desc" : "";
            ViewBag.BrandSortParm = sortOrder == "Brand" ? "Brand desc" : "Brand";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "Price desc" : "Price";
            var cosmetics = from s in db.Cosmetics
                           select s;
            switch (sortOrder)
            {
                case "Name desc":
                    cosmetics = cosmetics.OrderByDescending(s => s.Name);
                    break;
                case "Brand":
                    cosmetics = cosmetics.OrderBy(s => s.Brand);
                    break;
                case "Brand desc":
                    cosmetics = cosmetics.OrderByDescending(s => s.Brand);
                    break;
                case "Price":
                    cosmetics = cosmetics.OrderBy(s => s.Price);
                    break;
                case "Price desc":
                    cosmetics = cosmetics.OrderByDescending(s => s.Price);
                    break;
                default:
                    cosmetics = cosmetics.OrderBy(s => s.Name);
                    break;
            }
            return View(await cosmetics.ToListAsync());
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
