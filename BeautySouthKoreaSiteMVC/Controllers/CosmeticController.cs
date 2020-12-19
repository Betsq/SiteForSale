using BeautySouthKoreaSiteMVC.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BeautySouthKoreaSiteMVC.Controllers
{
    public class CosmeticController : Controller
    {
        private readonly CosmeticContext db;
        public CosmeticController(CosmeticContext context)
        {
            db = context;
        }
        public async Task<IActionResult> Index()
        {
            
            return View(await db.Cosmetics.ToListAsync());
        }

        #region Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Cosmetic cosmetic)
        {
            db.Cosmetics.Add(cosmetic);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion

        #region Details
        public async Task<IActionResult> Details(int? id)
        {


            if (id != null)
            {
                Cosmetic cosmetic = await db.Cosmetics.FirstOrDefaultAsync(p => p.Id == id);
                if (cosmetic != null)
                    return View(cosmetic);
            }
            return NotFound();
        }
        #endregion

        #region Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if(id != null)
            {
                Cosmetic cosmetic = await db.Cosmetics.FirstOrDefaultAsync(p => p.Id == id);
                if (cosmetic != null)
                return View(cosmetic);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Cosmetic cosmetic)
        {
            db.Cosmetics.Update(cosmetic);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion

        #region Delete
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if(id != null)
            {
                Cosmetic cosmetic = await db.Cosmetics.FirstOrDefaultAsync(p => p.Id == id);
                if (cosmetic != null)
                    return View(cosmetic);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if(id !=null)
            {
                Cosmetic cosmetic = await db.Cosmetics.FirstOrDefaultAsync(p => p.Id == id);
                if(cosmetic != null)
                {
                    db.Cosmetics.Remove(cosmetic);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
        #endregion

        public async Task<IActionResult> Product(int? id)
        {
            if (id != null)
                {
                    Cosmetic cosmetic = await db.Cosmetics.FirstOrDefaultAsync(p => p.Id == id);
                    if (cosmetic != null)
                        return View(cosmetic);
            }
            return NotFound();
        }

        #region PartialView
        public ActionResult Goods()
        {
            return PartialView("_Goods");
        }

        public ActionResult InputFilter()
        {
            return PartialView("_inputFilter");
        }

        #endregion

        public IActionResult Face(string[] color, string[] brand, string[] PurposeFor, string sortOrder)
        {

            ViewBag.color = color;
            ViewBag.PurposeFor = PurposeFor;
            ViewBag.brand = brand;
            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "Price_desc" : "Price";

            var cosmetics = db.Cosmetics.Where(c => c.PurposeFor.Contains("Face")).ToList();
            var co_cars = new List<Cosmetic>();
            var ma_cars = new List<Cosmetic>();
            var purposeFor = new List<Cosmetic>();


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

        public IActionResult Eyes()
        {
            var cosmetics = from s in db.Cosmetics select s;
            cosmetics = cosmetics.Where(c => c.PurposeFor.Contains("Eyes"));
            return View(cosmetics);
        }
        public IActionResult Lips()
        {
            var cosmetics = from s in db.Cosmetics select s;
            cosmetics = cosmetics.Where(c => c.PurposeFor.Contains("Lips"));
            return View(cosmetics);
        }
        public IActionResult Fingernails()
        {
            var cosmetics = from s in db.Cosmetics select s;
            cosmetics = cosmetics.Where(c => c.PurposeFor.Contains("Fingernails"));
            return View(cosmetics);
        }
        public IActionResult RemovingMakeup()
        {
            var cosmetics = from s in db.Cosmetics select s;
            cosmetics = cosmetics.Where(c => c.PurposeFor.Contains("RemovingMakeup"));
            return View(cosmetics);
        }
    }
}
