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
    public class EnstituController : Controller
    {
        private readonly AndDB _context;

        public EnstituController(AndDB context)
        {
            _context = context;
        }

        // GET: Admin/Enstitu
        public async Task<IActionResult> Index()
        {
            return View(await _context.Enstitus.ToListAsync());
        }

        // GET: Admin/Enstitu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enstitu = await _context.Enstitus
                .FirstOrDefaultAsync(m => m.ID == id);
            if (enstitu == null)
            {
                return NotFound();
            }

            return View(enstitu);
        }

        // GET: Admin/Enstitu/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Enstitu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,EnstituAdi")] Enstitu enstitu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enstitu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(enstitu);
        }

        // GET: Admin/Enstitu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enstitu = await _context.Enstitus.FindAsync(id);
            if (enstitu == null)
            {
                return NotFound();
            }
            return View(enstitu);
        }

        // POST: Admin/Enstitu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,EnstituAdi")] Enstitu enstitu)
        {
            if (id != enstitu.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enstitu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnstituExists(enstitu.ID))
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
            return View(enstitu);
        }

        // GET: Admin/Enstitu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enstitu = await _context.Enstitus
                .FirstOrDefaultAsync(m => m.ID == id);
            if (enstitu == null)
            {
                return NotFound();
            }

            return View(enstitu);
        }

        // POST: Admin/Enstitu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enstitu = await _context.Enstitus.FindAsync(id);
            _context.Enstitus.Remove(enstitu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnstituExists(int id)
        {
            return _context.Enstitus.Any(e => e.ID == id);
        }
        public ActionResult Cikis()
        {
            //Session.Remove("")
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}
