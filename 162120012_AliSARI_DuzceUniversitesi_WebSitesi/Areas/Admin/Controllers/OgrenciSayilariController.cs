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
    public class OgrenciSayilariController : Controller
    {
        private readonly AndDB _context;

        public OgrenciSayilariController(AndDB context)
        {
            _context = context;
        }

        // GET: Admin/OgrenciSayilari
        public async Task<IActionResult> Index()
        {
            return View(await _context.OgrenciSayilaris.ToListAsync());
        }

        // GET: Admin/OgrenciSayilari/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ogrenciSayilari = await _context.OgrenciSayilaris
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ogrenciSayilari == null)
            {
                return NotFound();
            }

            return View(ogrenciSayilari);
        }

        // GET: Admin/OgrenciSayilari/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/OgrenciSayilari/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,OgrenimDuzeyi,AkademikBirim,KadinSayisi,ErkekSayisi")] OgrenciSayilari ogrenciSayilari)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ogrenciSayilari);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ogrenciSayilari);
        }

        // GET: Admin/OgrenciSayilari/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ogrenciSayilari = await _context.OgrenciSayilaris.FindAsync(id);
            if (ogrenciSayilari == null)
            {
                return NotFound();
            }
            return View(ogrenciSayilari);
        }

        // POST: Admin/OgrenciSayilari/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,OgrenimDuzeyi,AkademikBirim,KadinSayisi,ErkekSayisi")] OgrenciSayilari ogrenciSayilari)
        {
            if (id != ogrenciSayilari.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ogrenciSayilari);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OgrenciSayilariExists(ogrenciSayilari.ID))
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
            return View(ogrenciSayilari);
        }

        // GET: Admin/OgrenciSayilari/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ogrenciSayilari = await _context.OgrenciSayilaris
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ogrenciSayilari == null)
            {
                return NotFound();
            }

            return View(ogrenciSayilari);
        }

        // POST: Admin/OgrenciSayilari/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ogrenciSayilari = await _context.OgrenciSayilaris.FindAsync(id);
            _context.OgrenciSayilaris.Remove(ogrenciSayilari);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OgrenciSayilariExists(int id)
        {
            return _context.OgrenciSayilaris.Any(e => e.ID == id);
        }

        public ActionResult Cikis()
        {
            //Session.Remove("")
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}
