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
    public class PersonelSayilariKategoriController : Controller
    {
        private readonly AndDB _context;

        public PersonelSayilariKategoriController(AndDB context)
        {
            _context = context;
        }

        // GET: Admin/PersonelSayilariKategori
        public async Task<IActionResult> Index()
        {
            return View(await _context.PersonelSayilariKategoris.ToListAsync());
        }

        // GET: Admin/PersonelSayilariKategori/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personelSayilariKategori = await _context.PersonelSayilariKategoris
                .FirstOrDefaultAsync(m => m.ID == id);
            if (personelSayilariKategori == null)
            {
                return NotFound();
            }

            return View(personelSayilariKategori);
        }

        // GET: Admin/PersonelSayilariKategori/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/PersonelSayilariKategori/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Kategori")] PersonelSayilariKategori personelSayilariKategori)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personelSayilariKategori);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personelSayilariKategori);
        }

        // GET: Admin/PersonelSayilariKategori/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personelSayilariKategori = await _context.PersonelSayilariKategoris.FindAsync(id);
            if (personelSayilariKategori == null)
            {
                return NotFound();
            }
            return View(personelSayilariKategori);
        }

        // POST: Admin/PersonelSayilariKategori/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Kategori")] PersonelSayilariKategori personelSayilariKategori)
        {
            if (id != personelSayilariKategori.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personelSayilariKategori);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonelSayilariKategoriExists(personelSayilariKategori.ID))
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
            return View(personelSayilariKategori);
        }

        // GET: Admin/PersonelSayilariKategori/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personelSayilariKategori = await _context.PersonelSayilariKategoris
                .FirstOrDefaultAsync(m => m.ID == id);
            if (personelSayilariKategori == null)
            {
                return NotFound();
            }

            return View(personelSayilariKategori);
        }

        // POST: Admin/PersonelSayilariKategori/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personelSayilariKategori = await _context.PersonelSayilariKategoris.FindAsync(id);
            _context.PersonelSayilariKategoris.Remove(personelSayilariKategori);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonelSayilariKategoriExists(int id)
        {
            return _context.PersonelSayilariKategoris.Any(e => e.ID == id);
        }
        public ActionResult Cikis()
        {
            //Session.Remove("")
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}
