using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StratejikPlanRaporlariKategoriController : Controller
    {
        private readonly AndDB _context;

        public StratejikPlanRaporlariKategoriController(AndDB context)
        {
            _context = context;
        }

        // GET: Admin/StratejikPlanRaporlariKategori
        public async Task<IActionResult> Index()
        {
            return View(await _context.StratejikPlanRaporlariKategoris.ToListAsync());
        }

        // GET: Admin/StratejikPlanRaporlariKategori/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stratejikPlanRaporlariKategori = await _context.StratejikPlanRaporlariKategoris
                .FirstOrDefaultAsync(m => m.ID == id);
            if (stratejikPlanRaporlariKategori == null)
            {
                return NotFound();
            }

            return View(stratejikPlanRaporlariKategori);
        }

        // GET: Admin/StratejikPlanRaporlariKategori/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/StratejikPlanRaporlariKategori/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Kategori")] StratejikPlanRaporlariKategori stratejikPlanRaporlariKategori)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stratejikPlanRaporlariKategori);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stratejikPlanRaporlariKategori);
        }

        // GET: Admin/StratejikPlanRaporlariKategori/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stratejikPlanRaporlariKategori = await _context.StratejikPlanRaporlariKategoris.FindAsync(id);
            if (stratejikPlanRaporlariKategori == null)
            {
                return NotFound();
            }
            return View(stratejikPlanRaporlariKategori);
        }

        // POST: Admin/StratejikPlanRaporlariKategori/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Kategori")] StratejikPlanRaporlariKategori stratejikPlanRaporlariKategori)
        {
            if (id != stratejikPlanRaporlariKategori.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stratejikPlanRaporlariKategori);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StratejikPlanRaporlariKategoriExists(stratejikPlanRaporlariKategori.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(stratejikPlanRaporlariKategori);
        }

        // GET: Admin/StratejikPlanRaporlariKategori/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stratejikPlanRaporlariKategori = await _context.StratejikPlanRaporlariKategoris
                .FirstOrDefaultAsync(m => m.ID == id);
            if (stratejikPlanRaporlariKategori == null)
            {
                return NotFound();
            }

            return View(stratejikPlanRaporlariKategori);
        }

        // POST: Admin/StratejikPlanRaporlariKategori/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stratejikPlanRaporlariKategori = await _context.StratejikPlanRaporlariKategoris.FindAsync(id);
            _context.StratejikPlanRaporlariKategoris.Remove(stratejikPlanRaporlariKategori);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StratejikPlanRaporlariKategoriExists(int id)
        {
            return _context.StratejikPlanRaporlariKategoris.Any(e => e.ID == id);
        }
        public ActionResult Cikis()
        {
            //Session.Remove("")
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}
