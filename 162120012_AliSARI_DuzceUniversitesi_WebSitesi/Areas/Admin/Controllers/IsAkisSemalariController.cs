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
    public class IsAkisSemalariController : Controller
    {
        private readonly AndDB _context;

        public IsAkisSemalariController(AndDB context)
        {
            _context = context;
        }

        // GET: Admin/IsAkisSemalari
        public async Task<IActionResult> Index()
        {
            var andDB = _context.ısAkisSemalaris.Include(i => i.Enstitu).Include(i => i.Fakulte);
            return View(await andDB.ToListAsync());
        }

        // GET: Admin/IsAkisSemalari/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var isAkisSemalari = await _context.ısAkisSemalaris
                .Include(i => i.Enstitu)
                .Include(i => i.Fakulte)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (isAkisSemalari == null)
            {
                return NotFound();
            }

            return View(isAkisSemalari);
        }

        // GET: Admin/IsAkisSemalari/Create
        public IActionResult Create()
        {
            ViewData["EnstituID"] = new SelectList(_context.Enstitus, "ID", "EnstituAdi");
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi");
            return View();
        }

        // POST: Admin/IsAkisSemalari/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FakulteID,EnstituID,Departman,Aciklama,Link")] IsAkisSemalari isAkisSemalari)
        {
            if (ModelState.IsValid)
            {
                _context.Add(isAkisSemalari);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EnstituID"] = new SelectList(_context.Enstitus, "ID", "EnstituAdi", isAkisSemalari.EnstituID);
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi", isAkisSemalari.FakulteID);
            return View(isAkisSemalari);
        }

        // GET: Admin/IsAkisSemalari/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var isAkisSemalari = await _context.ısAkisSemalaris.FindAsync(id);
            if (isAkisSemalari == null)
            {
                return NotFound();
            }
            ViewData["EnstituID"] = new SelectList(_context.Enstitus, "ID", "EnstituAdi", isAkisSemalari.EnstituID);
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi", isAkisSemalari.FakulteID);
            return View(isAkisSemalari);
        }

        // POST: Admin/IsAkisSemalari/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FakulteID,EnstituID,Departman,Aciklama,Link")] IsAkisSemalari isAkisSemalari)
        {
            if (id != isAkisSemalari.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(isAkisSemalari);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IsAkisSemalariExists(isAkisSemalari.ID))
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
            ViewData["EnstituID"] = new SelectList(_context.Enstitus, "ID", "EnstituAdi", isAkisSemalari.EnstituID);
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi", isAkisSemalari.FakulteID);
            return View(isAkisSemalari);
        }

        // GET: Admin/IsAkisSemalari/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var isAkisSemalari = await _context.ısAkisSemalaris
                .Include(i => i.Enstitu)
                .Include(i => i.Fakulte)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (isAkisSemalari == null)
            {
                return NotFound();
            }

            return View(isAkisSemalari);
        }

        // POST: Admin/IsAkisSemalari/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var isAkisSemalari = await _context.ısAkisSemalaris.FindAsync(id);
            _context.ısAkisSemalaris.Remove(isAkisSemalari);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IsAkisSemalariExists(int id)
        {
            return _context.ısAkisSemalaris.Any(e => e.ID == id);
        }
        public ActionResult Cikis()
        {
            //Session.Remove("")
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}
