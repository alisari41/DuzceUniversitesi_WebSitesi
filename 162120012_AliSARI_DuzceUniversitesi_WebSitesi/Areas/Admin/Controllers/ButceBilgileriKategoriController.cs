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
    public class ButceBilgileriKategoriController : Controller
    {
        private readonly AndDB _context;

        public ButceBilgileriKategoriController(AndDB context)
        {
            _context = context;
        }

        // GET: Admin/ButceBilgileriKategori
        public async Task<IActionResult> Index()
        {
            return View(await _context.ButceBilgileriKategoris.ToListAsync());
        }

        // GET: Admin/ButceBilgileriKategori/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var butceBilgileriKategori = await _context.ButceBilgileriKategoris
                .FirstOrDefaultAsync(m => m.ID == id);
            if (butceBilgileriKategori == null)
            {
                return NotFound();
            }

            return View(butceBilgileriKategori);
        }

        // GET: Admin/ButceBilgileriKategori/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/ButceBilgileriKategori/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,YilKategori")] ButceBilgileriKategori butceBilgileriKategori)
        {
            if (ModelState.IsValid)
            {
                _context.Add(butceBilgileriKategori);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(butceBilgileriKategori);
        }

        // GET: Admin/ButceBilgileriKategori/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var butceBilgileriKategori = await _context.ButceBilgileriKategoris.FindAsync(id);
            if (butceBilgileriKategori == null)
            {
                return NotFound();
            }
            return View(butceBilgileriKategori);
        }

        // POST: Admin/ButceBilgileriKategori/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,YilKategori")] ButceBilgileriKategori butceBilgileriKategori)
        {
            if (id != butceBilgileriKategori.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(butceBilgileriKategori);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ButceBilgileriKategoriExists(butceBilgileriKategori.ID))
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
            return View(butceBilgileriKategori);
        }

        // GET: Admin/ButceBilgileriKategori/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var butceBilgileriKategori = await _context.ButceBilgileriKategoris
                .FirstOrDefaultAsync(m => m.ID == id);
            if (butceBilgileriKategori == null)
            {
                return NotFound();
            }

            return View(butceBilgileriKategori);
        }

        // POST: Admin/ButceBilgileriKategori/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var butceBilgileriKategori = await _context.ButceBilgileriKategoris.FindAsync(id);
            _context.ButceBilgileriKategoris.Remove(butceBilgileriKategori);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ButceBilgileriKategoriExists(int id)
        {
            return _context.ButceBilgileriKategoris.Any(e => e.ID == id);
        }
        public ActionResult Cikis()
        {
            //Session.Remove("")
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}
