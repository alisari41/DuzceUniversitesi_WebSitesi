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
    public class PersonelSayilariController : Controller
    {
        private readonly AndDB _context;

        public PersonelSayilariController(AndDB context)
        {
            _context = context;
        }

        // GET: Admin/PersonelSayilari
        public async Task<IActionResult> Index()
        {
            var andDB = _context.PersonelSayilaris.Include(p => p.PersonelSayilariKategori);
            return View(await andDB.ToListAsync());
        }

        // GET: Admin/PersonelSayilari/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personelSayilari = await _context.PersonelSayilaris
                .Include(p => p.PersonelSayilariKategori)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (personelSayilari == null)
            {
                return NotFound();
            }

            return View(personelSayilari);
        }

        // GET: Admin/PersonelSayilari/Create
        public IActionResult Create()
        {
            ViewData["PersonelSayilariKategoriID"] = new SelectList(_context.PersonelSayilariKategoris, "ID", "Kategori");
            return View();
        }

        // POST: Admin/PersonelSayilari/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,PersonelSayilariKategoriID,Unvan,HizmetYeri,Sayi")] PersonelSayilari personelSayilari)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personelSayilari);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonelSayilariKategoriID"] = new SelectList(_context.PersonelSayilariKategoris, "ID", "Kategori", personelSayilari.PersonelSayilariKategoriID);
            return View(personelSayilari);
        }

        // GET: Admin/PersonelSayilari/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personelSayilari = await _context.PersonelSayilaris.FindAsync(id);
            if (personelSayilari == null)
            {
                return NotFound();
            }
            ViewData["PersonelSayilariKategoriID"] = new SelectList(_context.PersonelSayilariKategoris, "ID", "Kategori", personelSayilari.PersonelSayilariKategoriID);
            return View(personelSayilari);
        }

        // POST: Admin/PersonelSayilari/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,PersonelSayilariKategoriID,Unvan,HizmetYeri,Sayi")] PersonelSayilari personelSayilari)
        {
            if (id != personelSayilari.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personelSayilari);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonelSayilariExists(personelSayilari.ID))
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
            ViewData["PersonelSayilariKategoriID"] = new SelectList(_context.PersonelSayilariKategoris, "ID", "Kategori", personelSayilari.PersonelSayilariKategoriID);
            return View(personelSayilari);
        }

        // GET: Admin/PersonelSayilari/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personelSayilari = await _context.PersonelSayilaris
                .Include(p => p.PersonelSayilariKategori)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (personelSayilari == null)
            {
                return NotFound();
            }

            return View(personelSayilari);
        }

        // POST: Admin/PersonelSayilari/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personelSayilari = await _context.PersonelSayilaris.FindAsync(id);
            _context.PersonelSayilaris.Remove(personelSayilari);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonelSayilariExists(int id)
        {
            return _context.PersonelSayilaris.Any(e => e.ID == id);
        }
        public ActionResult Cikis()
        {
            //Session.Remove("")
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}
