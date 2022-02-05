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
    public class UniversiteIzlemeveDgrRaporKategoriController : Controller
    {
        private readonly AndDB _context;

        public UniversiteIzlemeveDgrRaporKategoriController(AndDB context)
        {
            _context = context;
        }

        // GET: Admin/UniversiteIzlemeveDgrRaporKategori
        public async Task<IActionResult> Index()
        {
            return View(await _context.UniversiteIzlemeveDgrRaporKategoris.ToListAsync());
        }

        // GET: Admin/UniversiteIzlemeveDgrRaporKategori/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var universiteIzlemeveDgrRaporKategori = await _context.UniversiteIzlemeveDgrRaporKategoris
                .FirstOrDefaultAsync(m => m.ID == id);
            if (universiteIzlemeveDgrRaporKategori == null)
            {
                return NotFound();
            }

            return View(universiteIzlemeveDgrRaporKategori);
        }

        // GET: Admin/UniversiteIzlemeveDgrRaporKategori/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/UniversiteIzlemeveDgrRaporKategori/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Kategori")] UniversiteIzlemeveDgrRaporKategori universiteIzlemeveDgrRaporKategori)
        {
            if (ModelState.IsValid)
            {
                _context.Add(universiteIzlemeveDgrRaporKategori);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(universiteIzlemeveDgrRaporKategori);
        }

        // GET: Admin/UniversiteIzlemeveDgrRaporKategori/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var universiteIzlemeveDgrRaporKategori = await _context.UniversiteIzlemeveDgrRaporKategoris.FindAsync(id);
            if (universiteIzlemeveDgrRaporKategori == null)
            {
                return NotFound();
            }
            return View(universiteIzlemeveDgrRaporKategori);
        }

        // POST: Admin/UniversiteIzlemeveDgrRaporKategori/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Kategori")] UniversiteIzlemeveDgrRaporKategori universiteIzlemeveDgrRaporKategori)
        {
            if (id != universiteIzlemeveDgrRaporKategori.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(universiteIzlemeveDgrRaporKategori);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UniversiteIzlemeveDgrRaporKategoriExists(universiteIzlemeveDgrRaporKategori.ID))
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
            return View(universiteIzlemeveDgrRaporKategori);
        }

        // GET: Admin/UniversiteIzlemeveDgrRaporKategori/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var universiteIzlemeveDgrRaporKategori = await _context.UniversiteIzlemeveDgrRaporKategoris
                .FirstOrDefaultAsync(m => m.ID == id);
            if (universiteIzlemeveDgrRaporKategori == null)
            {
                return NotFound();
            }

            return View(universiteIzlemeveDgrRaporKategori);
        }

        // POST: Admin/UniversiteIzlemeveDgrRaporKategori/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var universiteIzlemeveDgrRaporKategori = await _context.UniversiteIzlemeveDgrRaporKategoris.FindAsync(id);
            _context.UniversiteIzlemeveDgrRaporKategoris.Remove(universiteIzlemeveDgrRaporKategori);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UniversiteIzlemeveDgrRaporKategoriExists(int id)
        {
            return _context.UniversiteIzlemeveDgrRaporKategoris.Any(e => e.ID == id);
        }

        public ActionResult Cikis()
        {
            //Session.Remove("")
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}
