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
    public class HizmetStandartlariveEnvanteriController : Controller
    {
        private readonly AndDB _context;

        public HizmetStandartlariveEnvanteriController(AndDB context)
        {
            _context = context;
        }

        // GET: Admin/HizmetStandartlariveEnvanteri
        public async Task<IActionResult> Index()
        {
            var andDB = _context.HizmetStandartlariveEnvanteris.Include(h => h.Fakulte);
            return View(await andDB.ToListAsync());
        }

        // GET: Admin/HizmetStandartlariveEnvanteri/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hizmetStandartlariveEnvanteri = await _context.HizmetStandartlariveEnvanteris
                .Include(h => h.Fakulte)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (hizmetStandartlariveEnvanteri == null)
            {
                return NotFound();
            }

            return View(hizmetStandartlariveEnvanteri);
        }

        // GET: Admin/HizmetStandartlariveEnvanteri/Create
        public IActionResult Create()
        {
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi");
            return View();
        }

        // POST: Admin/HizmetStandartlariveEnvanteri/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FakulteID,Aciklama,Link")] HizmetStandartlariveEnvanteri hizmetStandartlariveEnvanteri)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hizmetStandartlariveEnvanteri);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi", hizmetStandartlariveEnvanteri.FakulteID);
            return View(hizmetStandartlariveEnvanteri);
        }

        // GET: Admin/HizmetStandartlariveEnvanteri/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hizmetStandartlariveEnvanteri = await _context.HizmetStandartlariveEnvanteris.FindAsync(id);
            if (hizmetStandartlariveEnvanteri == null)
            {
                return NotFound();
            }
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi", hizmetStandartlariveEnvanteri.FakulteID);
            return View(hizmetStandartlariveEnvanteri);
        }

        // POST: Admin/HizmetStandartlariveEnvanteri/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FakulteID,Aciklama,Link")] HizmetStandartlariveEnvanteri hizmetStandartlariveEnvanteri)
        {
            if (id != hizmetStandartlariveEnvanteri.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hizmetStandartlariveEnvanteri);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HizmetStandartlariveEnvanteriExists(hizmetStandartlariveEnvanteri.ID))
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
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi", hizmetStandartlariveEnvanteri.FakulteID);
            return View(hizmetStandartlariveEnvanteri);
        }

        // GET: Admin/HizmetStandartlariveEnvanteri/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hizmetStandartlariveEnvanteri = await _context.HizmetStandartlariveEnvanteris
                .Include(h => h.Fakulte)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (hizmetStandartlariveEnvanteri == null)
            {
                return NotFound();
            }

            return View(hizmetStandartlariveEnvanteri);
        }

        // POST: Admin/HizmetStandartlariveEnvanteri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hizmetStandartlariveEnvanteri = await _context.HizmetStandartlariveEnvanteris.FindAsync(id);
            _context.HizmetStandartlariveEnvanteris.Remove(hizmetStandartlariveEnvanteri);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HizmetStandartlariveEnvanteriExists(int id)
        {
            return _context.HizmetStandartlariveEnvanteris.Any(e => e.ID == id);
        }
        public ActionResult Cikis()
        {
            //Session.Remove("")
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}
