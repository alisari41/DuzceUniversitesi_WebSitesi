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
    public class FaliyetRaporuController : Controller
    {
        private readonly AndDB _context;

        public FaliyetRaporuController(AndDB context)
        {
            _context = context;
        }

        // GET: Admin/FaliyetRaporu
        public async Task<IActionResult> Index()
        {
            var andDB = _context.FaliyetRaporus.Include(f => f.Enstitu).Include(f => f.Fakulte);
            return View(await andDB.ToListAsync());
        }

        // GET: Admin/FaliyetRaporu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faliyetRaporu = await _context.FaliyetRaporus
                .Include(f => f.Enstitu)
                .Include(f => f.Fakulte)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (faliyetRaporu == null)
            {
                return NotFound();
            }

            return View(faliyetRaporu);
        }

        // GET: Admin/FaliyetRaporu/Create
        public IActionResult Create()
        {
            ViewData["EnstituID"] = new SelectList(_context.Enstitus, "ID", "EnstituAdi");
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi");
            return View();
        }

        // POST: Admin/FaliyetRaporu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FakulteID,EnstituID,Aciklama,Link")] FaliyetRaporu faliyetRaporu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(faliyetRaporu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EnstituID"] = new SelectList(_context.Enstitus, "ID", "EnstituAdi", faliyetRaporu.EnstituID);
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi", faliyetRaporu.FakulteID);
            return View(faliyetRaporu);
        }

        // GET: Admin/FaliyetRaporu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faliyetRaporu = await _context.FaliyetRaporus.FindAsync(id);
            if (faliyetRaporu == null)
            {
                return NotFound();
            }
            ViewData["EnstituID"] = new SelectList(_context.Enstitus, "ID", "EnstituAdi", faliyetRaporu.EnstituID);
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi", faliyetRaporu.FakulteID);
            return View(faliyetRaporu);
        }

        // POST: Admin/FaliyetRaporu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FakulteID,EnstituID,Aciklama,Link")] FaliyetRaporu faliyetRaporu)
        {
            if (id != faliyetRaporu.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(faliyetRaporu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FaliyetRaporuExists(faliyetRaporu.ID))
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
            ViewData["EnstituID"] = new SelectList(_context.Enstitus, "ID", "EnstituAdi", faliyetRaporu.EnstituID);
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi", faliyetRaporu.FakulteID);
            return View(faliyetRaporu);
        }

        // GET: Admin/FaliyetRaporu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faliyetRaporu = await _context.FaliyetRaporus
                .Include(f => f.Enstitu)
                .Include(f => f.Fakulte)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (faliyetRaporu == null)
            {
                return NotFound();
            }

            return View(faliyetRaporu);
        }

        // POST: Admin/FaliyetRaporu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var faliyetRaporu = await _context.FaliyetRaporus.FindAsync(id);
            _context.FaliyetRaporus.Remove(faliyetRaporu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FaliyetRaporuExists(int id)
        {
            return _context.FaliyetRaporus.Any(e => e.ID == id);
        }

        public ActionResult Cikis()
        {
            //Session.Remove("")
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}
