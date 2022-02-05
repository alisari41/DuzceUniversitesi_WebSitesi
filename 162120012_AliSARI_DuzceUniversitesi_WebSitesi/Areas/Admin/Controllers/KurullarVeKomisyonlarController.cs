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
    public class KurullarVeKomisyonlarController : Controller
    {
        private readonly AndDB _context;

        public KurullarVeKomisyonlarController(AndDB context)
        {
            _context = context;
        }

        // GET: Admin/KurullarVeKomisyonlar
        public async Task<IActionResult> Index()
        {
            var andDB = _context.KurullarVeKomisyonlars.Include(k => k.Enstitu).Include(k => k.Fakulte);
            return View(await andDB.ToListAsync());
        }

        // GET: Admin/KurullarVeKomisyonlar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kurullarVeKomisyonlar = await _context.KurullarVeKomisyonlars
                .Include(k => k.Enstitu)
                .Include(k => k.Fakulte)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (kurullarVeKomisyonlar == null)
            {
                return NotFound();
            }

            return View(kurullarVeKomisyonlar);
        }

        // GET: Admin/KurullarVeKomisyonlar/Create
        public IActionResult Create()
        {
            ViewData["EnstituID"] = new SelectList(_context.Enstitus, "ID", "EnstituAdi");
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi");
            return View();
        }

        // POST: Admin/KurullarVeKomisyonlar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FakulteID,EnstituID,Aciklama,Link")] KurullarVeKomisyonlar kurullarVeKomisyonlar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kurullarVeKomisyonlar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EnstituID"] = new SelectList(_context.Enstitus, "ID", "EnstituAdi", kurullarVeKomisyonlar.EnstituID);
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi", kurullarVeKomisyonlar.FakulteID);
            return View(kurullarVeKomisyonlar);
        }

        // GET: Admin/KurullarVeKomisyonlar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kurullarVeKomisyonlar = await _context.KurullarVeKomisyonlars.FindAsync(id);
            if (kurullarVeKomisyonlar == null)
            {
                return NotFound();
            }
            ViewData["EnstituID"] = new SelectList(_context.Enstitus, "ID", "EnstituAdi", kurullarVeKomisyonlar.EnstituID);
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi", kurullarVeKomisyonlar.FakulteID);
            return View(kurullarVeKomisyonlar);
        }

        // POST: Admin/KurullarVeKomisyonlar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FakulteID,EnstituID,Aciklama,Link")] KurullarVeKomisyonlar kurullarVeKomisyonlar)
        {
            if (id != kurullarVeKomisyonlar.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kurullarVeKomisyonlar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KurullarVeKomisyonlarExists(kurullarVeKomisyonlar.ID))
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
            ViewData["EnstituID"] = new SelectList(_context.Enstitus, "ID", "EnstituAdi", kurullarVeKomisyonlar.EnstituID);
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi", kurullarVeKomisyonlar.FakulteID);
            return View(kurullarVeKomisyonlar);
        }

        // GET: Admin/KurullarVeKomisyonlar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kurullarVeKomisyonlar = await _context.KurullarVeKomisyonlars
                .Include(k => k.Enstitu)
                .Include(k => k.Fakulte)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (kurullarVeKomisyonlar == null)
            {
                return NotFound();
            }

            return View(kurullarVeKomisyonlar);
        }

        // POST: Admin/KurullarVeKomisyonlar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kurullarVeKomisyonlar = await _context.KurullarVeKomisyonlars.FindAsync(id);
            _context.KurullarVeKomisyonlars.Remove(kurullarVeKomisyonlar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KurullarVeKomisyonlarExists(int id)
        {
            return _context.KurullarVeKomisyonlars.Any(e => e.ID == id);
        }
        public ActionResult Cikis()
        {
            //Session.Remove("")
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}
