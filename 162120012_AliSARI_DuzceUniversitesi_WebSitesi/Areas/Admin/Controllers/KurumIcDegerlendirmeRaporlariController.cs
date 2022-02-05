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
    public class KurumIcDegerlendirmeRaporlariController : Controller
    {
        private readonly AndDB _context;

        public KurumIcDegerlendirmeRaporlariController(AndDB context)
        {
            _context = context;
        }

        // GET: Admin/KurumIcDegerlendirmeRaporlari
        public async Task<IActionResult> Index()
        {
            var andDB = _context.KurumIcDegerlendirmeRaporlaris.Include(k => k.Enstitu);
            return View(await andDB.ToListAsync());
        }

        // GET: Admin/KurumIcDegerlendirmeRaporlari/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kurumIcDegerlendirmeRaporlari = await _context.KurumIcDegerlendirmeRaporlaris
                .Include(k => k.Enstitu)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (kurumIcDegerlendirmeRaporlari == null)
            {
                return NotFound();
            }

            return View(kurumIcDegerlendirmeRaporlari);
        }

        // GET: Admin/KurumIcDegerlendirmeRaporlari/Create
        public IActionResult Create()
        {
            ViewData["EnstituID"] = new SelectList(_context.Enstitus, "ID", "EnstituAdi");
            return View();
        }

        // POST: Admin/KurumIcDegerlendirmeRaporlari/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,EnstituID,Aciklama,Link,YılAyrintilari")] KurumIcDegerlendirmeRaporlari kurumIcDegerlendirmeRaporlari)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kurumIcDegerlendirmeRaporlari);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EnstituID"] = new SelectList(_context.Enstitus, "ID", "EnstituAdi", kurumIcDegerlendirmeRaporlari.EnstituID);
            return View(kurumIcDegerlendirmeRaporlari);
        }

        // GET: Admin/KurumIcDegerlendirmeRaporlari/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kurumIcDegerlendirmeRaporlari = await _context.KurumIcDegerlendirmeRaporlaris.FindAsync(id);
            if (kurumIcDegerlendirmeRaporlari == null)
            {
                return NotFound();
            }
            ViewData["EnstituID"] = new SelectList(_context.Enstitus, "ID", "EnstituAdi", kurumIcDegerlendirmeRaporlari.EnstituID);
            return View(kurumIcDegerlendirmeRaporlari);
        }

        // POST: Admin/KurumIcDegerlendirmeRaporlari/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,EnstituID,Aciklama,Link,YılAyrintilari")] KurumIcDegerlendirmeRaporlari kurumIcDegerlendirmeRaporlari)
        {
            if (id != kurumIcDegerlendirmeRaporlari.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kurumIcDegerlendirmeRaporlari);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KurumIcDegerlendirmeRaporlariExists(kurumIcDegerlendirmeRaporlari.ID))
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
            ViewData["EnstituID"] = new SelectList(_context.Enstitus, "ID", "EnstituAdi", kurumIcDegerlendirmeRaporlari.EnstituID);
            return View(kurumIcDegerlendirmeRaporlari);
        }

        // GET: Admin/KurumIcDegerlendirmeRaporlari/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kurumIcDegerlendirmeRaporlari = await _context.KurumIcDegerlendirmeRaporlaris
                .Include(k => k.Enstitu)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (kurumIcDegerlendirmeRaporlari == null)
            {
                return NotFound();
            }

            return View(kurumIcDegerlendirmeRaporlari);
        }

        // POST: Admin/KurumIcDegerlendirmeRaporlari/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kurumIcDegerlendirmeRaporlari = await _context.KurumIcDegerlendirmeRaporlaris.FindAsync(id);
            _context.KurumIcDegerlendirmeRaporlaris.Remove(kurumIcDegerlendirmeRaporlari);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KurumIcDegerlendirmeRaporlariExists(int id)
        {
            return _context.KurumIcDegerlendirmeRaporlaris.Any(e => e.ID == id);
        }
        public ActionResult Cikis()
        {
            //Session.Remove("")
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}
