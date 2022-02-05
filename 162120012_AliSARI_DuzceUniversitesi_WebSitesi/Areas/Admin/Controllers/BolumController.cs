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
    public class BolumController : Controller
    {
        private readonly AndDB _context;

        public BolumController(AndDB context)
        {
            _context = context;
        }

        // GET: Admin/Bolum
        public async Task<IActionResult> Index()
        {
            var andDB = _context.Bolums.Include(b => b.Fakulte);
            return View(await andDB.ToListAsync());
        }

        // GET: Admin/Bolum/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bolum = await _context.Bolums
                .Include(b => b.Fakulte)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bolum == null)
            {
                return NotFound();
            }

            return View(bolum);
        }

        // GET: Admin/Bolum/Create
        public IActionResult Create()
        {
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi");
            return View();
        }

        // POST: Admin/Bolum/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FakulteID,BolumAdi")] Bolum bolum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bolum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi", bolum.FakulteID);
            return View(bolum);
        }

        // GET: Admin/Bolum/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bolum = await _context.Bolums.FindAsync(id);
            if (bolum == null)
            {
                return NotFound();
            }
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi", bolum.FakulteID);
            return View(bolum);
        }

        // POST: Admin/Bolum/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FakulteID,BolumAdi")] Bolum bolum)
        {
            if (id != bolum.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bolum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BolumExists(bolum.ID))
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
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi", bolum.FakulteID);
            return View(bolum);
        }

        // GET: Admin/Bolum/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bolum = await _context.Bolums
                .Include(b => b.Fakulte)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bolum == null)
            {
                return NotFound();
            }

            return View(bolum);
        }

        // POST: Admin/Bolum/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bolum = await _context.Bolums.FindAsync(id);
            _context.Bolums.Remove(bolum);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BolumExists(int id)
        {
            return _context.Bolums.Any(e => e.ID == id);
        }

        public ActionResult Cikis()
        {
            //Session.Remove("")
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}
