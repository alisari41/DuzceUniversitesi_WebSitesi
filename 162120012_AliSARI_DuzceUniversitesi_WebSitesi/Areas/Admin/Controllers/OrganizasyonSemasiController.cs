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
    public class OrganizasyonSemasiController : Controller
    {
        private readonly AndDB _context;

        public OrganizasyonSemasiController(AndDB context)
        {
            _context = context;
        }

        // GET: Admin/OrganizasyonSemasi
        public async Task<IActionResult> Index()
        {
            var andDB = _context.OrganizasyonSemasis.Include(o => o.Enstitu).Include(o => o.Fakulte);
            return View(await andDB.ToListAsync());
        }

        // GET: Admin/OrganizasyonSemasi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizasyonSemasi = await _context.OrganizasyonSemasis
                .Include(o => o.Enstitu)
                .Include(o => o.Fakulte)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (organizasyonSemasi == null)
            {
                return NotFound();
            }

            return View(organizasyonSemasi);
        }

        // GET: Admin/OrganizasyonSemasi/Create
        public IActionResult Create()
        {
            ViewData["EnstituID"] = new SelectList(_context.Enstitus, "ID", "EnstituAdi");
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi");
            return View();
        }

        // POST: Admin/OrganizasyonSemasi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FakulteID,EnstituID,ResimUrl")] OrganizasyonSemasi organizasyonSemasi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(organizasyonSemasi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EnstituID"] = new SelectList(_context.Enstitus, "ID", "EnstituAdi", organizasyonSemasi.EnstituID);
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi", organizasyonSemasi.FakulteID);
            return View(organizasyonSemasi);
        }

        // GET: Admin/OrganizasyonSemasi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizasyonSemasi = await _context.OrganizasyonSemasis.FindAsync(id);
            if (organizasyonSemasi == null)
            {
                return NotFound();
            }
            ViewData["EnstituID"] = new SelectList(_context.Enstitus, "ID", "EnstituAdi", organizasyonSemasi.EnstituID);
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi", organizasyonSemasi.FakulteID);
            return View(organizasyonSemasi);
        }

        // POST: Admin/OrganizasyonSemasi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FakulteID,EnstituID,ResimUrl")] OrganizasyonSemasi organizasyonSemasi)
        {
            if (id != organizasyonSemasi.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(organizasyonSemasi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrganizasyonSemasiExists(organizasyonSemasi.ID))
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
            ViewData["EnstituID"] = new SelectList(_context.Enstitus, "ID", "EnstituAdi", organizasyonSemasi.EnstituID);
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi", organizasyonSemasi.FakulteID);
            return View(organizasyonSemasi);
        }

        // GET: Admin/OrganizasyonSemasi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizasyonSemasi = await _context.OrganizasyonSemasis
                .Include(o => o.Enstitu)
                .Include(o => o.Fakulte)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (organizasyonSemasi == null)
            {
                return NotFound();
            }

            return View(organizasyonSemasi);
        }

        // POST: Admin/OrganizasyonSemasi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var organizasyonSemasi = await _context.OrganizasyonSemasis.FindAsync(id);
            _context.OrganizasyonSemasis.Remove(organizasyonSemasi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrganizasyonSemasiExists(int id)
        {
            return _context.OrganizasyonSemasis.Any(e => e.ID == id);
        }
        public ActionResult Cikis()
        {
            //Session.Remove("")
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}
