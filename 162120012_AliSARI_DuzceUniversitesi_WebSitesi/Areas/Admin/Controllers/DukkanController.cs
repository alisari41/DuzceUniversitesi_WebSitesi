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
    public class DukkanController : Controller
    {
        private readonly AndDB _context;

        public DukkanController(AndDB context)
        {
            _context = context;
        }

        // GET: Admin/Dukkan
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dukkans.ToListAsync());
        }

        // GET: Admin/Dukkan/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dukkan = await _context.Dukkans
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dukkan == null)
            {
                return NotFound();
            }

            return View(dukkan);
        }

        // GET: Admin/Dukkan/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Dukkan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ResimUrl,Baslık,Renkler,Fiyat")] Dukkan dukkan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dukkan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dukkan);
        }

        // GET: Admin/Dukkan/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dukkan = await _context.Dukkans.FindAsync(id);
            if (dukkan == null)
            {
                return NotFound();
            }
            return View(dukkan);
        }

        // POST: Admin/Dukkan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ResimUrl,Baslık,Renkler,Fiyat")] Dukkan dukkan)
        {
            if (id != dukkan.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dukkan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DukkanExists(dukkan.ID))
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
            return View(dukkan);
        }

        // GET: Admin/Dukkan/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dukkan = await _context.Dukkans
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dukkan == null)
            {
                return NotFound();
            }

            return View(dukkan);
        }

        // POST: Admin/Dukkan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dukkan = await _context.Dukkans.FindAsync(id);
            _context.Dukkans.Remove(dukkan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DukkanExists(int id)
        {
            return _context.Dukkans.Any(e => e.ID == id);
        }

        public ActionResult Cikis()
        {
            //Session.Remove("")
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}
