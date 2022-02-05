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
    public class StratejikPlanRaporlariController : Controller
    {
        private readonly AndDB _context;

        public StratejikPlanRaporlariController(AndDB context)
        {
            _context = context;
        }

        // GET: Admin/StratejikPlanRaporlari
        public async Task<IActionResult> Index()
        {
            var andDB = _context.StratejikPlanRaporlaris.Include(s => s.StratejikPlanRaporlariKategori);
            return View(await andDB.ToListAsync());
        }

        // GET: Admin/StratejikPlanRaporlari/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stratejikPlanRaporlari = await _context.StratejikPlanRaporlaris
                .Include(s => s.StratejikPlanRaporlariKategori)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (stratejikPlanRaporlari == null)
            {
                return NotFound();
            }

            return View(stratejikPlanRaporlari);
        }

        // GET: Admin/StratejikPlanRaporlari/Create
        public IActionResult Create()
        {
            ViewData["StratejikPlanRaporlariKategoriID"] = new SelectList(_context.StratejikPlanRaporlariKategoris, "ID", "Kategori");
            return View();
        }

        // POST: Admin/StratejikPlanRaporlari/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,StratejikPlanRaporlariKategoriID,Aciklama,Link")] StratejikPlanRaporlari stratejikPlanRaporlari)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stratejikPlanRaporlari);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StratejikPlanRaporlariKategoriID"] = new SelectList(_context.StratejikPlanRaporlariKategoris, "ID", "Kategori", stratejikPlanRaporlari.StratejikPlanRaporlariKategoriID);
            return View(stratejikPlanRaporlari);
        }

        // GET: Admin/StratejikPlanRaporlari/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stratejikPlanRaporlari = await _context.StratejikPlanRaporlaris.FindAsync(id);
            if (stratejikPlanRaporlari == null)
            {
                return NotFound();
            }
            ViewData["StratejikPlanRaporlariKategoriID"] = new SelectList(_context.StratejikPlanRaporlariKategoris, "ID", "Kategori", stratejikPlanRaporlari.StratejikPlanRaporlariKategoriID);
            return View(stratejikPlanRaporlari);
        }

        // POST: Admin/StratejikPlanRaporlari/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,StratejikPlanRaporlariKategoriID,Aciklama,Link")] StratejikPlanRaporlari stratejikPlanRaporlari)
        {
            if (id != stratejikPlanRaporlari.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stratejikPlanRaporlari);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StratejikPlanRaporlariExists(stratejikPlanRaporlari.ID))
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
            ViewData["StratejikPlanRaporlariKategoriID"] = new SelectList(_context.StratejikPlanRaporlariKategoris, "ID", "Kategori", stratejikPlanRaporlari.StratejikPlanRaporlariKategoriID);
            return View(stratejikPlanRaporlari);
        }

        // GET: Admin/StratejikPlanRaporlari/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stratejikPlanRaporlari = await _context.StratejikPlanRaporlaris
                .Include(s => s.StratejikPlanRaporlariKategori)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (stratejikPlanRaporlari == null)
            {
                return NotFound();
            }

            return View(stratejikPlanRaporlari);
        }

        // POST: Admin/StratejikPlanRaporlari/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stratejikPlanRaporlari = await _context.StratejikPlanRaporlaris.FindAsync(id);
            _context.StratejikPlanRaporlaris.Remove(stratejikPlanRaporlari);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StratejikPlanRaporlariExists(int id)
        {
            return _context.StratejikPlanRaporlaris.Any(e => e.ID == id);
        }

        public ActionResult Cikis()
        {
            //Session.Remove("")
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}
