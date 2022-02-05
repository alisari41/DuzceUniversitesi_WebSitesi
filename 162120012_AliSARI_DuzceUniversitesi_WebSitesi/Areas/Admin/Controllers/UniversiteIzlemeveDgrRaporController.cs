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
    public class UniversiteIzlemeveDgrRaporController : Controller
    {
        private readonly AndDB _context;

        public UniversiteIzlemeveDgrRaporController(AndDB context)
        {
            _context = context;
        }

        // GET: Admin/UniversiteIzlemeveDgrRapor
        public async Task<IActionResult> Index()
        {
            var andDB = _context.UniversiteIzlemeveDgrRapors.Include(u => u.UniversiteIzlemeveDgrRaporKategori);
            return View(await andDB.ToListAsync());
        }

        // GET: Admin/UniversiteIzlemeveDgrRapor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var universiteIzlemeveDgrRapor = await _context.UniversiteIzlemeveDgrRapors
                .Include(u => u.UniversiteIzlemeveDgrRaporKategori)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (universiteIzlemeveDgrRapor == null)
            {
                return NotFound();
            }

            return View(universiteIzlemeveDgrRapor);
        }

        // GET: Admin/UniversiteIzlemeveDgrRapor/Create
        public IActionResult Create()
        {
            ViewData["UniversiteIzlemeveDgrRaporKategoriID"] = new SelectList(_context.UniversiteIzlemeveDgrRaporKategoris, "ID", "Kategori");
            return View();
        }

        // POST: Admin/UniversiteIzlemeveDgrRapor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,UniversiteIzlemeveDgrRaporKategoriID,Kriterler,Say_Oran")] UniversiteIzlemeveDgrRapor universiteIzlemeveDgrRapor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(universiteIzlemeveDgrRapor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UniversiteIzlemeveDgrRaporKategoriID"] = new SelectList(_context.UniversiteIzlemeveDgrRaporKategoris, "ID", "Kategori", universiteIzlemeveDgrRapor.UniversiteIzlemeveDgrRaporKategoriID);
            return View(universiteIzlemeveDgrRapor);
        }

        // GET: Admin/UniversiteIzlemeveDgrRapor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var universiteIzlemeveDgrRapor = await _context.UniversiteIzlemeveDgrRapors.FindAsync(id);
            if (universiteIzlemeveDgrRapor == null)
            {
                return NotFound();
            }
            ViewData["UniversiteIzlemeveDgrRaporKategoriID"] = new SelectList(_context.UniversiteIzlemeveDgrRaporKategoris, "ID", "Kategori", universiteIzlemeveDgrRapor.UniversiteIzlemeveDgrRaporKategoriID);
            return View(universiteIzlemeveDgrRapor);
        }

        // POST: Admin/UniversiteIzlemeveDgrRapor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,UniversiteIzlemeveDgrRaporKategoriID,Kriterler,Say_Oran")] UniversiteIzlemeveDgrRapor universiteIzlemeveDgrRapor)
        {
            if (id != universiteIzlemeveDgrRapor.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(universiteIzlemeveDgrRapor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UniversiteIzlemeveDgrRaporExists(universiteIzlemeveDgrRapor.ID))
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
            ViewData["UniversiteIzlemeveDgrRaporKategoriID"] = new SelectList(_context.UniversiteIzlemeveDgrRaporKategoris, "ID", "Kategori", universiteIzlemeveDgrRapor.UniversiteIzlemeveDgrRaporKategoriID);
            return View(universiteIzlemeveDgrRapor);
        }

        // GET: Admin/UniversiteIzlemeveDgrRapor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var universiteIzlemeveDgrRapor = await _context.UniversiteIzlemeveDgrRapors
                .Include(u => u.UniversiteIzlemeveDgrRaporKategori)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (universiteIzlemeveDgrRapor == null)
            {
                return NotFound();
            }

            return View(universiteIzlemeveDgrRapor);
        }

        // POST: Admin/UniversiteIzlemeveDgrRapor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var universiteIzlemeveDgrRapor = await _context.UniversiteIzlemeveDgrRapors.FindAsync(id);
            _context.UniversiteIzlemeveDgrRapors.Remove(universiteIzlemeveDgrRapor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UniversiteIzlemeveDgrRaporExists(int id)
        {
            return _context.UniversiteIzlemeveDgrRapors.Any(e => e.ID == id);
        }
        public ActionResult Cikis()
        {
            //Session.Remove("")
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}
