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
    public class IsbirlikleriController : Controller
    {
        private readonly AndDB _context;

        public IsbirlikleriController(AndDB context)
        {
            _context = context;
        }

        // GET: Admin/Isbirlikleri
        public async Task<IActionResult> Index()
        {
            return View(await _context.Isbirlikleris.ToListAsync());
        }

        // GET: Admin/Isbirlikleri/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var isbirlikleri = await _context.Isbirlikleris
                .FirstOrDefaultAsync(m => m.ID == id);
            if (isbirlikleri == null)
            {
                return NotFound();
            }

            return View(isbirlikleri);
        }

        // GET: Admin/Isbirlikleri/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Isbirlikleri/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ProtokolImzalananFirmalar")] Isbirlikleri isbirlikleri)
        {
            if (ModelState.IsValid)
            {
                _context.Add(isbirlikleri);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(isbirlikleri);
        }

        // GET: Admin/Isbirlikleri/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var isbirlikleri = await _context.Isbirlikleris.FindAsync(id);
            if (isbirlikleri == null)
            {
                return NotFound();
            }
            return View(isbirlikleri);
        }

        // POST: Admin/Isbirlikleri/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ProtokolImzalananFirmalar")] Isbirlikleri isbirlikleri)
        {
            if (id != isbirlikleri.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(isbirlikleri);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IsbirlikleriExists(isbirlikleri.ID))
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
            return View(isbirlikleri);
        }

        // GET: Admin/Isbirlikleri/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var isbirlikleri = await _context.Isbirlikleris
                .FirstOrDefaultAsync(m => m.ID == id);
            if (isbirlikleri == null)
            {
                return NotFound();
            }

            return View(isbirlikleri);
        }

        // POST: Admin/Isbirlikleri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var isbirlikleri = await _context.Isbirlikleris.FindAsync(id);
            _context.Isbirlikleris.Remove(isbirlikleri);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IsbirlikleriExists(int id)
        {
            return _context.Isbirlikleris.Any(e => e.ID == id);
        }
        public ActionResult Cikis()
        {
            //Session.Remove("")
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}
