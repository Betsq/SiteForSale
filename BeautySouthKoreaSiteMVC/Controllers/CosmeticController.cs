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


        public ActionResult Goods()
        {
            return PartialView("_Goods");
        }



        public async Task<IActionResult> Face()
        {
            var cosmetics = from s in db.Cosmetics select s;
            cosmetics = cosmetics.Where(c => c.PurposeFor.Contains("Face"));
            return View(cosmetics);
        }
        public IActionResult Eyes()
        {
            var cosmetics = from s in db.Cosmetics select s;
            cosmetics = cosmetics.Where(c => c.PurposeFor.Contains("Eyes"));
            return View(cosmetics);
        }
        public async Task<IActionResult> Lips()
        {
            var cosmetics = from s in db.Cosmetics select s;
            cosmetics = cosmetics.Where(c => c.PurposeFor.Contains("Lips"));
            return View(cosmetics);
        }
        public async Task<IActionResult> Fingernails()
        {
            var cosmetics = from s in db.Cosmetics select s;
            cosmetics = cosmetics.Where(c => c.PurposeFor.Contains("Fingernails"));
            return View(cosmetics);
        }
        public async Task<IActionResult> RemovingMakeup()
        {
            var cosmetics = from s in db.Cosmetics select s;
            cosmetics = cosmetics.Where(c => c.PurposeFor.Contains("RemovingMakeup"));
            return View(cosmetics);
        }
    }
}
