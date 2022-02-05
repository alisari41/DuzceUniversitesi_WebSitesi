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
    public class DersProgramlariController : Controller
    {
        private readonly AndDB _context;

        public DersProgramlariController(AndDB context)
        {
            _context = context;
        }

        // GET: Admin/DersProgramlari
        public async Task<IActionResult> Index()
        {
            var andDB = _context.DersProgramlaris.Include(d => d.DersProgramlariKategori).Include(d => d.Fakulte);
            return View(await andDB.ToListAsync());
        }

        // GET: Admin/DersProgramlari/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dersProgramlari = await _context.DersProgramlaris
                .Include(d => d.DersProgramlariKategori)
                .Include(d => d.Fakulte)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dersProgramlari == null)
            {
                return NotFound();
            }

            return View(dersProgramlari);
        }

        // GET: Admin/DersProgramlari/Create
        public IActionResult Create()
        {
            ViewData["DersProgramlariKategoriID"] = new SelectList(_context.DersProgramlariKategoris, "ID", "Kategori");
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi");
            return View();
        }

        // POST: Admin/DersProgramlari/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,DersProgramlariKategoriID,FakulteID,Aciklama,Link")] DersProgramlari dersProgramlari)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dersProgramlari);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DersProgramlariKategoriID"] = new SelectList(_context.DersProgramlariKategoris, "ID", "Kategori", dersProgramlari.DersProgramlariKategoriID);
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi", dersProgramlari.FakulteID);
            return View(dersProgramlari);
        }

        // GET: Admin/DersProgramlari/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dersProgramlari = await _context.DersProgramlaris.FindAsync(id);
            if (dersProgramlari == null)
            {
                return NotFound();
            }
            ViewData["DersProgramlariKategoriID"] = new SelectList(_context.DersProgramlariKategoris, "ID", "Kategori", dersProgramlari.DersProgramlariKategoriID);
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi", dersProgramlari.FakulteID);
            return View(dersProgramlari);
        }

        // POST: Admin/DersProgramlari/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DersProgramlariKategoriID,FakulteID,Aciklama,Link")] DersProgramlari dersProgramlari)
        {
            if (id != dersProgramlari.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dersProgramlari);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DersProgramlariExists(dersProgramlari.ID))
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
            ViewData["DersProgramlariKategoriID"] = new SelectList(_context.DersProgramlariKategoris, "ID", "Kategori", dersProgramlari.DersProgramlariKategoriID);
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi", dersProgramlari.FakulteID);
            return View(dersProgramlari);
        }

        // GET: Admin/DersProgramlari/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dersProgramlari = await _context.DersProgramlaris
                .Include(d => d.DersProgramlariKategori)
                .Include(d => d.Fakulte)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dersProgramlari == null)
            {
                return NotFound();
            }

            return View(dersProgramlari);
        }

        // POST: Admin/DersProgramlari/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dersProgramlari = await _context.DersProgramlaris.FindAsync(id);
            _context.DersProgramlaris.Remove(dersProgramlari);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DersProgramlariExists(int id)
        {
            return _context.DersProgramlaris.Any(e => e.ID == id);
        }
        public ActionResult Cikis()
        {
            //Session.Remove("")
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}
