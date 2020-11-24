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
    }
}
