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
    public class AkademikCalismalarController : Controller
    {
        private readonly AndDB _context;

        public AkademikCalismalarController(AndDB context)
        {
            _context = context;
        }

        // GET: Admin/AkademikCalismalar
        public async Task<IActionResult> Index()
        {
            var andDB = _context.AkademikCalismalars.Include(a => a.Fakulte);
            return View(await andDB.ToListAsync());
        }

        // GET: Admin/AkademikCalismalar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var akademikCalismalar = await _context.AkademikCalismalars
                .Include(a => a.Fakulte)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (akademikCalismalar == null)
            {
                return NotFound();
            }

            return View(akademikCalismalar);
        }

        // GET: Admin/AkademikCalismalar/Create
        public IActionResult Create()
        {
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi");
            return View();
        }

        // POST: Admin/AkademikCalismalar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FakulteID,Aciklama,Link")] AkademikCalismalar akademikCalismalar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(akademikCalismalar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi", akademikCalismalar.FakulteID);
            return View(akademikCalismalar);
        }

        // GET: Admin/AkademikCalismalar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var akademikCalismalar = await _context.AkademikCalismalars.FindAsync(id);
            if (akademikCalismalar == null)
            {
                return NotFound();
            }
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi", akademikCalismalar.FakulteID);
            return View(akademikCalismalar);
        }

        // POST: Admin/AkademikCalismalar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FakulteID,Aciklama,Link")] AkademikCalismalar akademikCalismalar)
        {
            if (id != akademikCalismalar.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(akademikCalismalar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AkademikCalismalarExists(akademikCalismalar.ID))
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
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi", akademikCalismalar.FakulteID);
            return View(akademikCalismalar);
        }

        // GET: Admin/AkademikCalismalar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var akademikCalismalar = await _context.AkademikCalismalars
                .Include(a => a.Fakulte)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (akademikCalismalar == null)
            {
                return NotFound();
            }

            return View(akademikCalismalar);
        }

        // POST: Admin/AkademikCalismalar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var akademikCalismalar = await _context.AkademikCalismalars.FindAsync(id);
            _context.AkademikCalismalars.Remove(akademikCalismalar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AkademikCalismalarExists(int id)
        {
            return _context.AkademikCalismalars.Any(e => e.ID == id);
        }
        public ActionResult Cikis()
        {
            //Session.Remove("")
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}
