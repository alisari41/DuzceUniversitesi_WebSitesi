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
    public class PersonelKategoriController : Controller
    {
        private readonly AndDB _context;

        public PersonelKategoriController(AndDB context)
        {
            _context = context;
        }

        // GET: Admin/PersonelKategori
        public async Task<IActionResult> Index()
        {
            return View(await _context.PersonelKategoris.ToListAsync());
        }

        // GET: Admin/PersonelKategori/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personelKategori = await _context.PersonelKategoris
                .FirstOrDefaultAsync(m => m.ID == id);
            if (personelKategori == null)
            {
                return NotFound();
            }

            return View(personelKategori);
        }

        // GET: Admin/PersonelKategori/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/PersonelKategori/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Kategori")] PersonelKategori personelKategori)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personelKategori);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personelKategori);
        }

        // GET: Admin/PersonelKategori/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personelKategori = await _context.PersonelKategoris.FindAsync(id);
            if (personelKategori == null)
            {
                return NotFound();
            }
            return View(personelKategori);
        }

        // POST: Admin/PersonelKategori/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Kategori")] PersonelKategori personelKategori)
        {
            if (id != personelKategori.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personelKategori);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonelKategoriExists(personelKategori.ID))
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
            return View(personelKategori);
        }

        // GET: Admin/PersonelKategori/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personelKategori = await _context.PersonelKategoris
                .FirstOrDefaultAsync(m => m.ID == id);
            if (personelKategori == null)
            {
                return NotFound();
            }

            return View(personelKategori);
        }

        // POST: Admin/PersonelKategori/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personelKategori = await _context.PersonelKategoris.FindAsync(id);
            _context.PersonelKategoris.Remove(personelKategori);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonelKategoriExists(int id)
        {
            return _context.PersonelKategoris.Any(e => e.ID == id);
        }

        public ActionResult Cikis()
        {
            //Session.Remove("")
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}
