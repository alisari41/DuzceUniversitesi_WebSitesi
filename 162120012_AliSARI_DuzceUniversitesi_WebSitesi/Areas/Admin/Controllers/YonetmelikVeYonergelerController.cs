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
    public class YonetmelikVeYonergelerController : Controller
    {
        private readonly AndDB _context;

        public YonetmelikVeYonergelerController(AndDB context)
        {
            _context = context;
        }

        // GET: Admin/YonetmelikVeYonergeler
        public async Task<IActionResult> Index()
        {
            var andDB = _context.YonetmelikVeYonergelers.Include(y => y.YonetmelikVeYonergelerKategori);
            return View(await andDB.ToListAsync());
        }

        // GET: Admin/YonetmelikVeYonergeler/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yonetmelikVeYonergeler = await _context.YonetmelikVeYonergelers
                .Include(y => y.YonetmelikVeYonergelerKategori)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (yonetmelikVeYonergeler == null)
            {
                return NotFound();
            }

            return View(yonetmelikVeYonergeler);
        }

        // GET: Admin/YonetmelikVeYonergeler/Create
        public IActionResult Create()
        {
            ViewData["YonetmelikVeYonergelerKategoriID"] = new SelectList(_context.YonetmelikVeYonergelerKategoris, "ID", "Kategori");
            return View();
        }

        // POST: Admin/YonetmelikVeYonergeler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,YonetmelikVeYonergelerKategoriID,Tarih,Aciklama,Link")] YonetmelikVeYonergeler yonetmelikVeYonergeler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yonetmelikVeYonergeler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["YonetmelikVeYonergelerKategoriID"] = new SelectList(_context.YonetmelikVeYonergelerKategoris, "ID", "Kategori", yonetmelikVeYonergeler.YonetmelikVeYonergelerKategoriID);
            return View(yonetmelikVeYonergeler);
        }

        // GET: Admin/YonetmelikVeYonergeler/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yonetmelikVeYonergeler = await _context.YonetmelikVeYonergelers.FindAsync(id);
            if (yonetmelikVeYonergeler == null)
            {
                return NotFound();
            }
            ViewData["YonetmelikVeYonergelerKategoriID"] = new SelectList(_context.YonetmelikVeYonergelerKategoris, "ID", "Kategori", yonetmelikVeYonergeler.YonetmelikVeYonergelerKategoriID);
            return View(yonetmelikVeYonergeler);
        }

        // POST: Admin/YonetmelikVeYonergeler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,YonetmelikVeYonergelerKategoriID,Tarih,Aciklama,Link")] YonetmelikVeYonergeler yonetmelikVeYonergeler)
        {
            if (id != yonetmelikVeYonergeler.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yonetmelikVeYonergeler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YonetmelikVeYonergelerExists(yonetmelikVeYonergeler.ID))
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
            ViewData["YonetmelikVeYonergelerKategoriID"] = new SelectList(_context.YonetmelikVeYonergelerKategoris, "ID", "Kategori", yonetmelikVeYonergeler.YonetmelikVeYonergelerKategoriID);
            return View(yonetmelikVeYonergeler);
        }

        // GET: Admin/YonetmelikVeYonergeler/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yonetmelikVeYonergeler = await _context.YonetmelikVeYonergelers
                .Include(y => y.YonetmelikVeYonergelerKategori)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (yonetmelikVeYonergeler == null)
            {
                return NotFound();
            }

            return View(yonetmelikVeYonergeler);
        }

        // POST: Admin/YonetmelikVeYonergeler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var yonetmelikVeYonergeler = await _context.YonetmelikVeYonergelers.FindAsync(id);
            _context.YonetmelikVeYonergelers.Remove(yonetmelikVeYonergeler);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YonetmelikVeYonergelerExists(int id)
        {
            return _context.YonetmelikVeYonergelers.Any(e => e.ID == id);
        }

        public ActionResult Cikis()
        {
            //Session.Remove("")
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}
