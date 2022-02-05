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
    public class GenelBilgilerController : Controller
    {
        private readonly AndDB _context;

        public GenelBilgilerController(AndDB context)
        {
            _context = context;
        }

        // GET: Admin/GenelBilgiler
        public async Task<IActionResult> Index()
        {
            var andDB = _context.GenelBilgilers.Include(g => g.Enstitu).Include(g => g.Fakulte);
            return View(await andDB.ToListAsync());
        }

        // GET: Admin/GenelBilgiler/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genelBilgiler = await _context.GenelBilgilers
                .Include(g => g.Enstitu)
                .Include(g => g.Fakulte)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (genelBilgiler == null)
            {
                return NotFound();
            }

            return View(genelBilgiler);
        }

        // GET: Admin/GenelBilgiler/Create
        public IActionResult Create()
        {
            ViewData["EnstituID"] = new SelectList(_context.Enstitus, "ID", "EnstituAdi");
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi");
            return View();
        }

        // POST: Admin/GenelBilgiler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FakulteID,EnstituID,ResimUrl,Aciklama1,Aciklama2,Aciklama3,Aciklama4,Aciklama5,Misyonumuz,Vizyonumuz,EkBaslik,EkAciklama1,EkAciklama2,EkAciklama3,EkAciklama4,EkAciklama5,EkAciklama6,EkAciklama7,EkAciklama8,EkAciklama9,EkAciklama10,EkAciklama11,EkAciklama12")] GenelBilgiler genelBilgiler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(genelBilgiler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EnstituID"] = new SelectList(_context.Enstitus, "ID", "EnstituAdi", genelBilgiler.EnstituID);
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi", genelBilgiler.FakulteID);
            return View(genelBilgiler);
        }

        // GET: Admin/GenelBilgiler/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genelBilgiler = await _context.GenelBilgilers.FindAsync(id);
            if (genelBilgiler == null)
            {
                return NotFound();
            }
            ViewData["EnstituID"] = new SelectList(_context.Enstitus, "ID", "EnstituAdi", genelBilgiler.EnstituID);
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi", genelBilgiler.FakulteID);
            return View(genelBilgiler);
        }

        // POST: Admin/GenelBilgiler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FakulteID,EnstituID,ResimUrl,Aciklama1,Aciklama2,Aciklama3,Aciklama4,Aciklama5,Misyonumuz,Vizyonumuz,EkBaslik,EkAciklama1,EkAciklama2,EkAciklama3,EkAciklama4,EkAciklama5,EkAciklama6,EkAciklama7,EkAciklama8,EkAciklama9,EkAciklama10,EkAciklama11,EkAciklama12")] GenelBilgiler genelBilgiler)
        {
            if (id != genelBilgiler.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(genelBilgiler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GenelBilgilerExists(genelBilgiler.ID))
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
            ViewData["EnstituID"] = new SelectList(_context.Enstitus, "ID", "EnstituAdi", genelBilgiler.EnstituID);
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi", genelBilgiler.FakulteID);
            return View(genelBilgiler);
        }

        // GET: Admin/GenelBilgiler/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genelBilgiler = await _context.GenelBilgilers
                .Include(g => g.Enstitu)
                .Include(g => g.Fakulte)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (genelBilgiler == null)
            {
                return NotFound();
            }

            return View(genelBilgiler);
        }

        // POST: Admin/GenelBilgiler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var genelBilgiler = await _context.GenelBilgilers.FindAsync(id);
            _context.GenelBilgilers.Remove(genelBilgiler);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GenelBilgilerExists(int id)
        {
            return _context.GenelBilgilers.Any(e => e.ID == id);
        }
        public ActionResult Cikis()
        {
            //Session.Remove("")
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}
