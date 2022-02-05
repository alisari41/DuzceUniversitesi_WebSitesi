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
    public class BolumGenelBilgileriController : Controller
    {
        private readonly AndDB _context;

        public BolumGenelBilgileriController(AndDB context)
        {
            _context = context;
        }

        // GET: Admin/BolumGenelBilgileri
        public async Task<IActionResult> Index()
        {
            var andDB = _context.BolumGenelBilgileris.Include(b => b.Bolum);
            return View(await andDB.ToListAsync());
        }

        // GET: Admin/BolumGenelBilgileri/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bolumGenelBilgileri = await _context.BolumGenelBilgileris
                .Include(b => b.Bolum)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bolumGenelBilgileri == null)
            {
                return NotFound();
            }

            return View(bolumGenelBilgileri);
        }

        // GET: Admin/BolumGenelBilgileri/Create
        public IActionResult Create()
        {
            ViewData["BolumID"] = new SelectList(_context.Bolums, "ID", "BolumAdi");
            return View();
        }

        // POST: Admin/BolumGenelBilgileri/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,BolumID,Aciklama1,Aciklama2,Aciklama3,Aciklama4,Aciklama5,Aciklama6,Aciklama7,Aciklama8,Aciklama9,Aciklama10,Aciklama11,BolognaSureciLink,Email1,Email2,Email3")] BolumGenelBilgileri bolumGenelBilgileri)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bolumGenelBilgileri);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BolumID"] = new SelectList(_context.Bolums, "ID", "BolumAdi", bolumGenelBilgileri.BolumID);
            return View(bolumGenelBilgileri);
        }

        // GET: Admin/BolumGenelBilgileri/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bolumGenelBilgileri = await _context.BolumGenelBilgileris.FindAsync(id);
            if (bolumGenelBilgileri == null)
            {
                return NotFound();
            }
            ViewData["BolumID"] = new SelectList(_context.Bolums, "ID", "BolumAdi", bolumGenelBilgileri.BolumID);
            return View(bolumGenelBilgileri);
        }

        // POST: Admin/BolumGenelBilgileri/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,BolumID,Aciklama1,Aciklama2,Aciklama3,Aciklama4,Aciklama5,Aciklama6,Aciklama7,Aciklama8,Aciklama9,Aciklama10,Aciklama11,BolognaSureciLink,Email1,Email2,Email3")] BolumGenelBilgileri bolumGenelBilgileri)
        {
            if (id != bolumGenelBilgileri.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bolumGenelBilgileri);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BolumGenelBilgileriExists(bolumGenelBilgileri.ID))
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
            ViewData["BolumID"] = new SelectList(_context.Bolums, "ID", "BolumAdi", bolumGenelBilgileri.BolumID);
            return View(bolumGenelBilgileri);
        }

        // GET: Admin/BolumGenelBilgileri/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bolumGenelBilgileri = await _context.BolumGenelBilgileris
                .Include(b => b.Bolum)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bolumGenelBilgileri == null)
            {
                return NotFound();
            }

            return View(bolumGenelBilgileri);
        }

        // POST: Admin/BolumGenelBilgileri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bolumGenelBilgileri = await _context.BolumGenelBilgileris.FindAsync(id);
            _context.BolumGenelBilgileris.Remove(bolumGenelBilgileri);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BolumGenelBilgileriExists(int id)
        {
            return _context.BolumGenelBilgileris.Any(e => e.ID == id);
        }
        public ActionResult Cikis()
        {
            //Session.Remove("")
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}
