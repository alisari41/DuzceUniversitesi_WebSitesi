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
    public class BolumveProgramSayilariKategoriController : Controller
    {
        private readonly AndDB _context;

        public BolumveProgramSayilariKategoriController(AndDB context)
        {
            _context = context;
        }

        // GET: Admin/BolumveProgramSayilariKategori
        public async Task<IActionResult> Index()
        {
            return View(await _context.BolumveProgramSayilariKategoris.ToListAsync());
        }

        // GET: Admin/BolumveProgramSayilariKategori/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bolumveProgramSayilariKategori = await _context.BolumveProgramSayilariKategoris
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bolumveProgramSayilariKategori == null)
            {
                return NotFound();
            }

            return View(bolumveProgramSayilariKategori);
        }

        // GET: Admin/BolumveProgramSayilariKategori/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/BolumveProgramSayilariKategori/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Kategori")] BolumveProgramSayilariKategori bolumveProgramSayilariKategori)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bolumveProgramSayilariKategori);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bolumveProgramSayilariKategori);
        }

        // GET: Admin/BolumveProgramSayilariKategori/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bolumveProgramSayilariKategori = await _context.BolumveProgramSayilariKategoris.FindAsync(id);
            if (bolumveProgramSayilariKategori == null)
            {
                return NotFound();
            }
            return View(bolumveProgramSayilariKategori);
        }

        // POST: Admin/BolumveProgramSayilariKategori/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Kategori")] BolumveProgramSayilariKategori bolumveProgramSayilariKategori)
        {
            if (id != bolumveProgramSayilariKategori.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bolumveProgramSayilariKategori);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BolumveProgramSayilariKategoriExists(bolumveProgramSayilariKategori.ID))
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
            return View(bolumveProgramSayilariKategori);
        }

        // GET: Admin/BolumveProgramSayilariKategori/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bolumveProgramSayilariKategori = await _context.BolumveProgramSayilariKategoris
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bolumveProgramSayilariKategori == null)
            {
                return NotFound();
            }

            return View(bolumveProgramSayilariKategori);
        }

        // POST: Admin/BolumveProgramSayilariKategori/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bolumveProgramSayilariKategori = await _context.BolumveProgramSayilariKategoris.FindAsync(id);
            _context.BolumveProgramSayilariKategoris.Remove(bolumveProgramSayilariKategori);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BolumveProgramSayilariKategoriExists(int id)
        {
            return _context.BolumveProgramSayilariKategoris.Any(e => e.ID == id);
        }

        public ActionResult Cikis()
        {
            //Session.Remove("")
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}
