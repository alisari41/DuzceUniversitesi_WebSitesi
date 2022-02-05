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
    public class ButceBilgileriController : Controller
    {
        private readonly AndDB _context;

        public ButceBilgileriController(AndDB context)
        {
            _context = context;
        }

        // GET: Admin/ButceBilgileri
        public async Task<IActionResult> Index()
        {
            var andDB = _context.ButceBilgileris.Include(b => b.ButceBilgileriKategori);
            return View(await andDB.ToListAsync());
        }

        // GET: Admin/ButceBilgileri/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var butceBilgileri = await _context.ButceBilgileris
                .Include(b => b.ButceBilgileriKategori)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (butceBilgileri == null)
            {
                return NotFound();
            }

            return View(butceBilgileri);
        }

        // GET: Admin/ButceBilgileri/Create
        public IActionResult Create()
        {
            ViewData["ButceBilgileriKategoriID"] = new SelectList(_context.ButceBilgileriKategoris, "ID", "YilKategori");
            return View();
        }

        // POST: Admin/ButceBilgileri/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ButceBilgileriKategoriID,Aciklama,Link")] ButceBilgileri butceBilgileri)
        {
            if (ModelState.IsValid)
            {
                _context.Add(butceBilgileri);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ButceBilgileriKategoriID"] = new SelectList(_context.ButceBilgileriKategoris, "ID", "YilKategori", butceBilgileri.ButceBilgileriKategoriID);
            return View(butceBilgileri);
        }

        // GET: Admin/ButceBilgileri/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var butceBilgileri = await _context.ButceBilgileris.FindAsync(id);
            if (butceBilgileri == null)
            {
                return NotFound();
            }
            ViewData["ButceBilgileriKategoriID"] = new SelectList(_context.ButceBilgileriKategoris, "ID", "YilKategori", butceBilgileri.ButceBilgileriKategoriID);
            return View(butceBilgileri);
        }

        // POST: Admin/ButceBilgileri/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ButceBilgileriKategoriID,Aciklama,Link")] ButceBilgileri butceBilgileri)
        {
            if (id != butceBilgileri.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(butceBilgileri);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ButceBilgileriExists(butceBilgileri.ID))
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
            ViewData["ButceBilgileriKategoriID"] = new SelectList(_context.ButceBilgileriKategoris, "ID", "YilKategori", butceBilgileri.ButceBilgileriKategoriID);
            return View(butceBilgileri);
        }

        // GET: Admin/ButceBilgileri/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var butceBilgileri = await _context.ButceBilgileris
                .Include(b => b.ButceBilgileriKategori)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (butceBilgileri == null)
            {
                return NotFound();
            }

            return View(butceBilgileri);
        }

        // POST: Admin/ButceBilgileri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var butceBilgileri = await _context.ButceBilgileris.FindAsync(id);
            _context.ButceBilgileris.Remove(butceBilgileri);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ButceBilgileriExists(int id)
        {
            return _context.ButceBilgileris.Any(e => e.ID == id);
        }
        public ActionResult Cikis()
        {
            //Session.Remove("")
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}
