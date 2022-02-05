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
    public class YonetmelikVeYonergelerKategoriController : Controller
    {
        private readonly AndDB _context;

        public YonetmelikVeYonergelerKategoriController(AndDB context)
        {
            _context = context;
        }

        // GET: Admin/YonetmelikVeYonergelerKategori
        public async Task<IActionResult> Index()
        {
            return View(await _context.YonetmelikVeYonergelerKategoris.ToListAsync());
        }

        // GET: Admin/YonetmelikVeYonergelerKategori/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yonetmelikVeYonergelerKategori = await _context.YonetmelikVeYonergelerKategoris
                .FirstOrDefaultAsync(m => m.ID == id);
            if (yonetmelikVeYonergelerKategori == null)
            {
                return NotFound();
            }

            return View(yonetmelikVeYonergelerKategori);
        }

        // GET: Admin/YonetmelikVeYonergelerKategori/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/YonetmelikVeYonergelerKategori/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Kategori")] YonetmelikVeYonergelerKategori yonetmelikVeYonergelerKategori)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yonetmelikVeYonergelerKategori);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(yonetmelikVeYonergelerKategori);
        }

        // GET: Admin/YonetmelikVeYonergelerKategori/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yonetmelikVeYonergelerKategori = await _context.YonetmelikVeYonergelerKategoris.FindAsync(id);
            if (yonetmelikVeYonergelerKategori == null)
            {
                return NotFound();
            }
            return View(yonetmelikVeYonergelerKategori);
        }

        // POST: Admin/YonetmelikVeYonergelerKategori/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Kategori")] YonetmelikVeYonergelerKategori yonetmelikVeYonergelerKategori)
        {
            if (id != yonetmelikVeYonergelerKategori.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yonetmelikVeYonergelerKategori);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YonetmelikVeYonergelerKategoriExists(yonetmelikVeYonergelerKategori.ID))
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
            return View(yonetmelikVeYonergelerKategori);
        }

        // GET: Admin/YonetmelikVeYonergelerKategori/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yonetmelikVeYonergelerKategori = await _context.YonetmelikVeYonergelerKategoris
                .FirstOrDefaultAsync(m => m.ID == id);
            if (yonetmelikVeYonergelerKategori == null)
            {
                return NotFound();
            }

            return View(yonetmelikVeYonergelerKategori);
        }

        // POST: Admin/YonetmelikVeYonergelerKategori/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var yonetmelikVeYonergelerKategori = await _context.YonetmelikVeYonergelerKategoris.FindAsync(id);
            _context.YonetmelikVeYonergelerKategoris.Remove(yonetmelikVeYonergelerKategori);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YonetmelikVeYonergelerKategoriExists(int id)
        {
            return _context.YonetmelikVeYonergelerKategoris.Any(e => e.ID == id);
        }
        public ActionResult Cikis()
        {
            //Session.Remove("")
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}
