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
    public class PersonelController : Controller
    {
        private readonly AndDB _context;

        public PersonelController(AndDB context)
        {
            _context = context;
        }

        // GET: Admin/Personel
        public async Task<IActionResult> Index()
        {
            var andDB = _context.Personels.Include(p => p.Bolum).Include(p => p.Enstitu).Include(p => p.Fakulte).Include(p => p.PersonelKategori);
            return View(await andDB.ToListAsync());
        }

        // GET: Admin/Personel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personel = await _context.Personels
                .Include(p => p.Bolum)
                .Include(p => p.Enstitu)
                .Include(p => p.Fakulte)
                .Include(p => p.PersonelKategori)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (personel == null)
            {
                return NotFound();
            }

            return View(personel);
        }

        // GET: Admin/Personel/Create
        public IActionResult Create()
        {
            ViewData["BolumID"] = new SelectList(_context.Bolums, "ID", "BolumAdi");
            ViewData["EnstituID"] = new SelectList(_context.Enstitus, "ID", "EnstituAdi");
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi");
            ViewData["PersonelKategoriID"] = new SelectList(_context.PersonelKategoris, "ID", "Kategori");
            return View();
        }

        // POST: Admin/Personel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,BolumID,PersonelKategoriID,FakulteID,EnstituID,Ad,Soyad,Unvan,Email,Telefon,TCKimlikNumarasi,PersonelLink,FotografUrl,Aciklama1,Aciklama2,Aciklama3,Aciklama4,Aciklama5,Yayinlar1,Yayinlar2,Yayinlar3,Yayinlar4,Yayinlar5,Yayinlar6,Yayinlar7,Yayinlar8,Yayinlar9,Yayinlar10,Yayinlar11,Yayinlar12")] Personel personel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BolumID"] = new SelectList(_context.Bolums, "ID", "BolumAdi", personel.BolumID);
            ViewData["EnstituID"] = new SelectList(_context.Enstitus, "ID", "EnstituAdi", personel.EnstituID);
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi", personel.FakulteID);
            ViewData["PersonelKategoriID"] = new SelectList(_context.PersonelKategoris, "ID", "Kategori", personel.PersonelKategoriID);
            return View(personel);
        }

        // GET: Admin/Personel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personel = await _context.Personels.FindAsync(id);
            if (personel == null)
            {
                return NotFound();
            }
            ViewData["BolumID"] = new SelectList(_context.Bolums, "ID", "BolumAdi", personel.BolumID);
            ViewData["EnstituID"] = new SelectList(_context.Enstitus, "ID", "EnstituAdi", personel.EnstituID);
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi", personel.FakulteID);
            ViewData["PersonelKategoriID"] = new SelectList(_context.PersonelKategoris, "ID", "Kategori", personel.PersonelKategoriID);
            return View(personel);
        }

        // POST: Admin/Personel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,BolumID,PersonelKategoriID,FakulteID,EnstituID,Ad,Soyad,Unvan,Email,Telefon,TCKimlikNumarasi,PersonelLink,FotografUrl,Aciklama1,Aciklama2,Aciklama3,Aciklama4,Aciklama5,Yayinlar1,Yayinlar2,Yayinlar3,Yayinlar4,Yayinlar5,Yayinlar6,Yayinlar7,Yayinlar8,Yayinlar9,Yayinlar10,Yayinlar11,Yayinlar12")] Personel personel)
        {
            if (id != personel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonelExists(personel.ID))
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
            ViewData["BolumID"] = new SelectList(_context.Bolums, "ID", "BolumAdi", personel.BolumID);
            ViewData["EnstituID"] = new SelectList(_context.Enstitus, "ID", "EnstituAdi", personel.EnstituID);
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi", personel.FakulteID);
            ViewData["PersonelKategoriID"] = new SelectList(_context.PersonelKategoris, "ID", "Kategori", personel.PersonelKategoriID);
            return View(personel);
        }

        // GET: Admin/Personel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personel = await _context.Personels
                .Include(p => p.Bolum)
                .Include(p => p.Enstitu)
                .Include(p => p.Fakulte)
                .Include(p => p.PersonelKategori)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (personel == null)
            {
                return NotFound();
            }

            return View(personel);
        }

        // POST: Admin/Personel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personel = await _context.Personels.FindAsync(id);
            _context.Personels.Remove(personel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonelExists(int id)
        {
            return _context.Personels.Any(e => e.ID == id);
        }

        public ActionResult Cikis()
        {
            //Session.Remove("")
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}
