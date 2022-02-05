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
    public class BolumveProgramSayilariController : Controller
    {
        private readonly AndDB _context;

        public BolumveProgramSayilariController(AndDB context)
        {
            _context = context;
        }

        // GET: Admin/BolumveProgramSayilari
        public async Task<IActionResult> Index()
        {
            var andDB = _context.BolumveProgramSayilaris.Include(b => b.BolumveProgramSayilariKategori);
            return View(await andDB.ToListAsync());
        }

        // GET: Admin/BolumveProgramSayilari/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bolumveProgramSayilari = await _context.BolumveProgramSayilaris
                .Include(b => b.BolumveProgramSayilariKategori)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bolumveProgramSayilari == null)
            {
                return NotFound();
            }

            return View(bolumveProgramSayilari);
        }

        // GET: Admin/BolumveProgramSayilari/Create
        public IActionResult Create()
        {
            ViewData["BolumveProgramSayilariKategoriID"] = new SelectList(_context.BolumveProgramSayilariKategoris, "ID", "Kategori");
            return View();
        }

        // POST: Admin/BolumveProgramSayilari/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,BolumveProgramSayilariKategoriID,Fakulte,OgrenimTuru,Sayisi")] BolumveProgramSayilari bolumveProgramSayilari)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bolumveProgramSayilari);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BolumveProgramSayilariKategoriID"] = new SelectList(_context.BolumveProgramSayilariKategoris, "ID", "Kategori", bolumveProgramSayilari.BolumveProgramSayilariKategoriID);
            return View(bolumveProgramSayilari);
        }

        // GET: Admin/BolumveProgramSayilari/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bolumveProgramSayilari = await _context.BolumveProgramSayilaris.FindAsync(id);
            if (bolumveProgramSayilari == null)
            {
                return NotFound();
            }
            ViewData["BolumveProgramSayilariKategoriID"] = new SelectList(_context.BolumveProgramSayilariKategoris, "ID", "Kategori", bolumveProgramSayilari.BolumveProgramSayilariKategoriID);
            return View(bolumveProgramSayilari);
        }

        // POST: Admin/BolumveProgramSayilari/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,BolumveProgramSayilariKategoriID,Fakulte,OgrenimTuru,Sayisi")] BolumveProgramSayilari bolumveProgramSayilari)
        {
            if (id != bolumveProgramSayilari.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bolumveProgramSayilari);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BolumveProgramSayilariExists(bolumveProgramSayilari.ID))
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
            ViewData["BolumveProgramSayilariKategoriID"] = new SelectList(_context.BolumveProgramSayilariKategoris, "ID", "Kategori", bolumveProgramSayilari.BolumveProgramSayilariKategoriID);
            return View(bolumveProgramSayilari);
        }

        // GET: Admin/BolumveProgramSayilari/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bolumveProgramSayilari = await _context.BolumveProgramSayilaris
                .Include(b => b.BolumveProgramSayilariKategori)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bolumveProgramSayilari == null)
            {
                return NotFound();
            }

            return View(bolumveProgramSayilari);
        }

        // POST: Admin/BolumveProgramSayilari/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bolumveProgramSayilari = await _context.BolumveProgramSayilaris.FindAsync(id);
            _context.BolumveProgramSayilaris.Remove(bolumveProgramSayilari);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BolumveProgramSayilariExists(int id)
        {
            return _context.BolumveProgramSayilaris.Any(e => e.ID == id);
        }

        public ActionResult Cikis()
        {
            //Session.Remove("")
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}
