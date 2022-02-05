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
    public class FakulteController : Controller
    {
        private readonly AndDB _context;

        public FakulteController(AndDB context)
        {
            _context = context;
        }

        // GET: Admin/Fakulte
        public async Task<IActionResult> Index()
        {
            return View(await _context.Fakultes.ToListAsync());
        }

        // GET: Admin/Fakulte/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fakulte = await _context.Fakultes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (fakulte == null)
            {
                return NotFound();
            }

            return View(fakulte);
        }

        // GET: Admin/Fakulte/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Fakulte/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FakulteAdi")] Fakulte fakulte)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fakulte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fakulte);
        }

        // GET: Admin/Fakulte/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fakulte = await _context.Fakultes.FindAsync(id);
            if (fakulte == null)
            {
                return NotFound();
            }
            return View(fakulte);
        }

        // POST: Admin/Fakulte/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FakulteAdi")] Fakulte fakulte)
        {
            if (id != fakulte.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fakulte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FakulteExists(fakulte.ID))
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
            return View(fakulte);
        }

        // GET: Admin/Fakulte/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fakulte = await _context.Fakultes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (fakulte == null)
            {
                return NotFound();
            }

            return View(fakulte);
        }

        // POST: Admin/Fakulte/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fakulte = await _context.Fakultes.FindAsync(id);
            _context.Fakultes.Remove(fakulte);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FakulteExists(int id)
        {
            return _context.Fakultes.Any(e => e.ID == id);
        }

        public ActionResult Cikis()
        {
            //Session.Remove("")
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}
