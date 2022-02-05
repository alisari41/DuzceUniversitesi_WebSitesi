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
    public class FormlarController : Controller
    {
        private readonly AndDB _context;

        public FormlarController(AndDB context)
        {
            _context = context;
        }

        // GET: Admin/Formlar
        public async Task<IActionResult> Index()
        {
            var andDB = _context.FormlarOgrs.Include(f => f.Enstitu).Include(f => f.Fakulte);
            return View(await andDB.ToListAsync());
        }

        // GET: Admin/Formlar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formlarOgr = await _context.FormlarOgrs
                .Include(f => f.Enstitu)
                .Include(f => f.Fakulte)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (formlarOgr == null)
            {
                return NotFound();
            }

            return View(formlarOgr);
        }

        // GET: Admin/Formlar/Create
        public IActionResult Create()
        {
            ViewData["EnstituID"] = new SelectList(_context.Enstitus, "ID", "EnstituAdi");
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi");
            return View();
        }

        // POST: Admin/Formlar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FakulteID,EnstituID,EnsitituicinYuksekLisansDoktara,Baslik,Link")] FormlarOgr formlarOgr)
        {
            if (ModelState.IsValid)
            {
                _context.Add(formlarOgr);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EnstituID"] = new SelectList(_context.Enstitus, "ID", "EnstituAdi", formlarOgr.EnstituID);
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi", formlarOgr.FakulteID);
            return View(formlarOgr);
        }

        // GET: Admin/Formlar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formlarOgr = await _context.FormlarOgrs.FindAsync(id);
            if (formlarOgr == null)
            {
                return NotFound();
            }
            ViewData["EnstituID"] = new SelectList(_context.Enstitus, "ID", "EnstituAdi", formlarOgr.EnstituID);
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi", formlarOgr.FakulteID);
            return View(formlarOgr);
        }

        // POST: Admin/Formlar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FakulteID,EnstituID,EnsitituicinYuksekLisansDoktara,Baslik,Link")] FormlarOgr formlarOgr)
        {
            if (id != formlarOgr.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formlarOgr);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormlarOgrExists(formlarOgr.ID))
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
            ViewData["EnstituID"] = new SelectList(_context.Enstitus, "ID", "EnstituAdi", formlarOgr.EnstituID);
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi", formlarOgr.FakulteID);
            return View(formlarOgr);
        }

        // GET: Admin/Formlar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formlarOgr = await _context.FormlarOgrs
                .Include(f => f.Enstitu)
                .Include(f => f.Fakulte)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (formlarOgr == null)
            {
                return NotFound();
            }

            return View(formlarOgr);
        }

        // POST: Admin/Formlar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var formlarOgr = await _context.FormlarOgrs.FindAsync(id);
            _context.FormlarOgrs.Remove(formlarOgr);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormlarOgrExists(int id)
        {
            return _context.FormlarOgrs.Any(e => e.ID == id);
        }

        public ActionResult Cikis()
        {
            //Session.Remove("")
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}
