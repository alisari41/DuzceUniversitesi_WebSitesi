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
    public class GorevTanimlariController : Controller
    {
        private readonly AndDB _context;

        public GorevTanimlariController(AndDB context)
        {
            _context = context;
        }

        // GET: Admin/GorevTanimlari
        public async Task<IActionResult> Index()
        {
            var andDB = _context.GorevTanimlaris.Include(g => g.Enstitu).Include(g => g.Fakulte);
            return View(await andDB.ToListAsync());
        }

        // GET: Admin/GorevTanimlari/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gorevTanimlari = await _context.GorevTanimlaris
                .Include(g => g.Enstitu)
                .Include(g => g.Fakulte)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (gorevTanimlari == null)
            {
                return NotFound();
            }

            return View(gorevTanimlari);
        }

        // GET: Admin/GorevTanimlari/Create
        public IActionResult Create()
        {
            ViewData["EnstituID"] = new SelectList(_context.Enstitus, "ID", "EnstituAdi");
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi");
            return View();
        }

        // POST: Admin/GorevTanimlari/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FakulteID,EnstituID,Aciklama,Link")] GorevTanimlari gorevTanimlari)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gorevTanimlari);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EnstituID"] = new SelectList(_context.Enstitus, "ID", "EnstituAdi", gorevTanimlari.EnstituID);
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi", gorevTanimlari.FakulteID);
            return View(gorevTanimlari);
        }

        // GET: Admin/GorevTanimlari/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gorevTanimlari = await _context.GorevTanimlaris.FindAsync(id);
            if (gorevTanimlari == null)
            {
                return NotFound();
            }
            ViewData["EnstituID"] = new SelectList(_context.Enstitus, "ID", "EnstituAdi", gorevTanimlari.EnstituID);
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi", gorevTanimlari.FakulteID);
            return View(gorevTanimlari);
        }

        // POST: Admin/GorevTanimlari/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FakulteID,EnstituID,Aciklama,Link")] GorevTanimlari gorevTanimlari)
        {
            if (id != gorevTanimlari.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gorevTanimlari);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GorevTanimlariExists(gorevTanimlari.ID))
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
            ViewData["EnstituID"] = new SelectList(_context.Enstitus, "ID", "EnstituAdi", gorevTanimlari.EnstituID);
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi", gorevTanimlari.FakulteID);
            return View(gorevTanimlari);
        }

        // GET: Admin/GorevTanimlari/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gorevTanimlari = await _context.GorevTanimlaris
                .Include(g => g.Enstitu)
                .Include(g => g.Fakulte)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (gorevTanimlari == null)
            {
                return NotFound();
            }

            return View(gorevTanimlari);
        }

        // POST: Admin/GorevTanimlari/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gorevTanimlari = await _context.GorevTanimlaris.FindAsync(id);
            _context.GorevTanimlaris.Remove(gorevTanimlari);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GorevTanimlariExists(int id)
        {
            return _context.GorevTanimlaris.Any(e => e.ID == id);
        }
        public ActionResult Cikis()
        {
            //Session.Remove("")
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}
