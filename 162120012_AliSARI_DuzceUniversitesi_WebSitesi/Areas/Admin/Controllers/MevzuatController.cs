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
    public class MevzuatController : Controller
    {
        private readonly AndDB _context;

        public MevzuatController(AndDB context)
        {
            _context = context;
        }

        // GET: Admin/Mevzuat
        public async Task<IActionResult> Index()
        {
            var andDB = _context.Mevzuats.Include(m => m.Enstitu).Include(m => m.Fakulte);
            return View(await andDB.ToListAsync());
        }

        // GET: Admin/Mevzuat/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mevzuat = await _context.Mevzuats
                .Include(m => m.Enstitu)
                .Include(m => m.Fakulte)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mevzuat == null)
            {
                return NotFound();
            }

            return View(mevzuat);
        }

        // GET: Admin/Mevzuat/Create
        public IActionResult Create()
        {
            ViewData["EnstituID"] = new SelectList(_context.Enstitus, "ID", "EnstituAdi");
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi");
            return View();
        }

        // POST: Admin/Mevzuat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FakulteID,EnstituID,Aciklama,Link")] Mevzuat mevzuat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mevzuat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EnstituID"] = new SelectList(_context.Enstitus, "ID", "EnstituAdi", mevzuat.EnstituID);
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi", mevzuat.FakulteID);
            return View(mevzuat);
        }

        // GET: Admin/Mevzuat/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mevzuat = await _context.Mevzuats.FindAsync(id);
            if (mevzuat == null)
            {
                return NotFound();
            }
            ViewData["EnstituID"] = new SelectList(_context.Enstitus, "ID", "EnstituAdi", mevzuat.EnstituID);
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi", mevzuat.FakulteID);
            return View(mevzuat);
        }

        // POST: Admin/Mevzuat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FakulteID,EnstituID,Aciklama,Link")] Mevzuat mevzuat)
        {
            if (id != mevzuat.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mevzuat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MevzuatExists(mevzuat.ID))
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
            ViewData["EnstituID"] = new SelectList(_context.Enstitus, "ID", "EnstituAdi", mevzuat.EnstituID);
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi", mevzuat.FakulteID);
            return View(mevzuat);
        }

        // GET: Admin/Mevzuat/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mevzuat = await _context.Mevzuats
                .Include(m => m.Enstitu)
                .Include(m => m.Fakulte)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mevzuat == null)
            {
                return NotFound();
            }

            return View(mevzuat);
        }

        // POST: Admin/Mevzuat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mevzuat = await _context.Mevzuats.FindAsync(id);
            _context.Mevzuats.Remove(mevzuat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MevzuatExists(int id)
        {
            return _context.Mevzuats.Any(e => e.ID == id);
        }
        public ActionResult Cikis()
        {
            //Session.Remove("")
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}
