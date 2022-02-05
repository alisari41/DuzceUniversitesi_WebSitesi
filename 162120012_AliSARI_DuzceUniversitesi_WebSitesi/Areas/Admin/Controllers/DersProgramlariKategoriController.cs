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
    public class DersProgramlariKategoriController : Controller
    {
        private readonly AndDB _context;

        public DersProgramlariKategoriController(AndDB context)
        {
            _context = context;
        }

        // GET: Admin/DersProgramlariKategori
        public async Task<IActionResult> Index()
        {
            return View(await _context.DersProgramlariKategoris.ToListAsync());
        }

        // GET: Admin/DersProgramlariKategori/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dersProgramlariKategori = await _context.DersProgramlariKategoris
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dersProgramlariKategori == null)
            {
                return NotFound();
            }

            return View(dersProgramlariKategori);
        }

        // GET: Admin/DersProgramlariKategori/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/DersProgramlariKategori/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Kategori")] DersProgramlariKategori dersProgramlariKategori)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dersProgramlariKategori);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dersProgramlariKategori);
        }

        // GET: Admin/DersProgramlariKategori/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dersProgramlariKategori = await _context.DersProgramlariKategoris.FindAsync(id);
            if (dersProgramlariKategori == null)
            {
                return NotFound();
            }
            return View(dersProgramlariKategori);
        }

        // POST: Admin/DersProgramlariKategori/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Kategori")] DersProgramlariKategori dersProgramlariKategori)
        {
            if (id != dersProgramlariKategori.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dersProgramlariKategori);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DersProgramlariKategoriExists(dersProgramlariKategori.ID))
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
            return View(dersProgramlariKategori);
        }

        // GET: Admin/DersProgramlariKategori/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dersProgramlariKategori = await _context.DersProgramlariKategoris
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dersProgramlariKategori == null)
            {
                return NotFound();
            }

            return View(dersProgramlariKategori);
        }

        // POST: Admin/DersProgramlariKategori/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dersProgramlariKategori = await _context.DersProgramlariKategoris.FindAsync(id);
            _context.DersProgramlariKategoris.Remove(dersProgramlariKategori);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DersProgramlariKategoriExists(int id)
        {
            return _context.DersProgramlariKategoris.Any(e => e.ID == id);
        }
        public ActionResult Cikis()
        {
            //Session.Remove("")
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}
