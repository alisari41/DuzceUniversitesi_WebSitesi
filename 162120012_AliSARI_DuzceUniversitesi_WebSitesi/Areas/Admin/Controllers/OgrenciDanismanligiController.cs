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
    public class OgrenciDanismanligiController : Controller
    {
        private readonly AndDB _context;

        public OgrenciDanismanligiController(AndDB context)
        {
            _context = context;
        }

        // GET: Admin/OgrenciDanismanligi
        public async Task<IActionResult> Index()
        {
            var andDB = _context.OgrenciDanismanligis.Include(o => o.Fakulte);
            return View(await andDB.ToListAsync());
        }

        // GET: Admin/OgrenciDanismanligi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ogrenciDanismanligi = await _context.OgrenciDanismanligis
                .Include(o => o.Fakulte)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ogrenciDanismanligi == null)
            {
                return NotFound();
            }

            return View(ogrenciDanismanligi);
        }

        // GET: Admin/OgrenciDanismanligi/Create
        public IActionResult Create()
        {
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi");
            return View();
        }

        // POST: Admin/OgrenciDanismanligi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FakulteID,Aciklama1,Aciklama2,Aciklama3,LinkAciklama1,Link1,LinkAciklama2,Link2,LinkAciklama3,Link3,BolumAdi,Sinif,DanismanUnvan,DanismanAd,DanismanSoyad")] OgrenciDanismanligi ogrenciDanismanligi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ogrenciDanismanligi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi", ogrenciDanismanligi.FakulteID);
            return View(ogrenciDanismanligi);
        }

        // GET: Admin/OgrenciDanismanligi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ogrenciDanismanligi = await _context.OgrenciDanismanligis.FindAsync(id);
            if (ogrenciDanismanligi == null)
            {
                return NotFound();
            }
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi", ogrenciDanismanligi.FakulteID);
            return View(ogrenciDanismanligi);
        }

        // POST: Admin/OgrenciDanismanligi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FakulteID,Aciklama1,Aciklama2,Aciklama3,LinkAciklama1,Link1,LinkAciklama2,Link2,LinkAciklama3,Link3,BolumAdi,Sinif,DanismanUnvan,DanismanAd,DanismanSoyad")] OgrenciDanismanligi ogrenciDanismanligi)
        {
            if (id != ogrenciDanismanligi.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ogrenciDanismanligi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OgrenciDanismanligiExists(ogrenciDanismanligi.ID))
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
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi", ogrenciDanismanligi.FakulteID);
            return View(ogrenciDanismanligi);
        }

        // GET: Admin/OgrenciDanismanligi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ogrenciDanismanligi = await _context.OgrenciDanismanligis
                .Include(o => o.Fakulte)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ogrenciDanismanligi == null)
            {
                return NotFound();
            }

            return View(ogrenciDanismanligi);
        }

        // POST: Admin/OgrenciDanismanligi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ogrenciDanismanligi = await _context.OgrenciDanismanligis.FindAsync(id);
            _context.OgrenciDanismanligis.Remove(ogrenciDanismanligi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OgrenciDanismanligiExists(int id)
        {
            return _context.OgrenciDanismanligis.Any(e => e.ID == id);
        }
        public ActionResult Cikis()
        {
            //Session.Remove("")
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}
