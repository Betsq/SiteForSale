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

        public IActionResult Index(string[] color, string[] brand, string[] PurposeFor, string search, string sortOrder)
        {
            
            ViewBag.color = color;
            ViewBag.PurposeFor = PurposeFor;
            ViewBag.brand = brand;
            ViewBag.search = search;
            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "Price_desc" : "Price";

            var cosmetics = db.Cosmetics.ToList();
            var co_cars = new List<Cosmetic>();
            var ma_cars = new List<Cosmetic>();
            var purposeFor = new List<Cosmetic>();
            var schStr = new List<Cosmetic>();




            if (!string.IsNullOrEmpty(search))
            {
                    var sr = db.Cosmetics.Where(c => c.Name.Contains(search)).ToList();
                    schStr.AddRange(sr);
            }
            else
            {
                schStr = cosmetics;
            }



            if (color.Length != 0)
            {
                foreach (string co in color)
                {
                    var colorfiltercars = db.Cosmetics.Where(c => c.Color.Contains(co)).ToList();
                    co_cars.AddRange(colorfiltercars);
                }
            }
            else
            {
                co_cars = cosmetics;
            }

            if (PurposeFor.Length != 0)
            {
                foreach (string pf in PurposeFor)
                {
                    var purposefiltercars = db.Cosmetics.Where(c => c.PurposeFor.Contains(pf)).ToList();
                    purposeFor.AddRange(purposefiltercars);
                }
            }
            else    
            {
                purposeFor = cosmetics;
            }

            if (brand.Length != 0)
            {
                foreach (string ma in brand)
                {
                    var manufacturerfiltercars = db.Cosmetics.Where(c => c.Brand.Contains(ma)).ToList();
                    ma_cars.AddRange(manufacturerfiltercars);
                }
            }
            else
            {
                ma_cars = cosmetics;
            }

            var filtercars = co_cars.Intersect(ma_cars);
            filtercars = filtercars.Intersect(purposeFor);
            filtercars = filtercars.Intersect(schStr);
            
            


            switch (sortOrder)
            {
                case "Name_desc":
                    filtercars = filtercars.OrderByDescending(s => s.Name);
                    break;
                case "Price":
                    filtercars = filtercars.OrderBy(s => s.Price);
                    break;
                case "Price_desc":
                    filtercars = filtercars.OrderByDescending(s => s.Price);
                    break;
                default:
                    filtercars = filtercars.OrderBy(s => s.Name);
                    break;
            }

            return View(filtercars.ToList());
        }
      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
