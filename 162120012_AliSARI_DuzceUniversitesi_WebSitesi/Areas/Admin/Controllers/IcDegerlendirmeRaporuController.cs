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
    public class IcDegerlendirmeRaporuController : Controller
    {
        private readonly AndDB _context;

        public IcDegerlendirmeRaporuController(AndDB context)
        {
            _context = context;
        }

        // GET: Admin/IcDegerlendirmeRaporu
        public async Task<IActionResult> Index()
        {
            var andDB = _context.IcDegerlendirmeRaporus.Include(i => i.Fakulte);
            return View(await andDB.ToListAsync());
        }

        // GET: Admin/IcDegerlendirmeRaporu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var icDegerlendirmeRaporu = await _context.IcDegerlendirmeRaporus
                .Include(i => i.Fakulte)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (icDegerlendirmeRaporu == null)
            {
                return NotFound();
            }

            return View(icDegerlendirmeRaporu);
        }

        // GET: Admin/IcDegerlendirmeRaporu/Create
        public IActionResult Create()
        {
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi");
            return View();
        }

        // POST: Admin/IcDegerlendirmeRaporu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FakulteID,Aciklama,Link")] IcDegerlendirmeRaporu icDegerlendirmeRaporu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(icDegerlendirmeRaporu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi", icDegerlendirmeRaporu.FakulteID);
            return View(icDegerlendirmeRaporu);
        }

        // GET: Admin/IcDegerlendirmeRaporu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var icDegerlendirmeRaporu = await _context.IcDegerlendirmeRaporus.FindAsync(id);
            if (icDegerlendirmeRaporu == null)
            {
                return NotFound();
            }
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi", icDegerlendirmeRaporu.FakulteID);
            return View(icDegerlendirmeRaporu);
        }

        // POST: Admin/IcDegerlendirmeRaporu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FakulteID,Aciklama,Link")] IcDegerlendirmeRaporu icDegerlendirmeRaporu)
        {
            if (id != icDegerlendirmeRaporu.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(icDegerlendirmeRaporu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IcDegerlendirmeRaporuExists(icDegerlendirmeRaporu.ID))
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
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi", icDegerlendirmeRaporu.FakulteID);
            return View(icDegerlendirmeRaporu);
        }

        // GET: Admin/IcDegerlendirmeRaporu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var icDegerlendirmeRaporu = await _context.IcDegerlendirmeRaporus
                .Include(i => i.Fakulte)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (icDegerlendirmeRaporu == null)
            {
                return NotFound();
            }

            return View(icDegerlendirmeRaporu);
        }

        // POST: Admin/IcDegerlendirmeRaporu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var icDegerlendirmeRaporu = await _context.IcDegerlendirmeRaporus.FindAsync(id);
            _context.IcDegerlendirmeRaporus.Remove(icDegerlendirmeRaporu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IcDegerlendirmeRaporuExists(int id)
        {
            return _context.IcDegerlendirmeRaporus.Any(e => e.ID == id);
        }
        public ActionResult Cikis()
        {
            //Session.Remove("")
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}
