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
    public class YonetimKategoriController : Controller
    {
        private readonly AndDB _context;

        public YonetimKategoriController(AndDB context)
        {
            _context = context;
        }

        // GET: Admin/YonetimKategori
        public async Task<IActionResult> Index()
        {
            return View(await _context.YonetimKategoris.ToListAsync());
        }

        // GET: Admin/YonetimKategori/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yonetimKategori = await _context.YonetimKategoris
                .FirstOrDefaultAsync(m => m.ID == id);
            if (yonetimKategori == null)
            {
                return NotFound();
            }

            return View(yonetimKategori);
        }

        // GET: Admin/YonetimKategori/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/YonetimKategori/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Gorevi")] YonetimKategori yonetimKategori)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yonetimKategori);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(yonetimKategori);
        }

        // GET: Admin/YonetimKategori/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yonetimKategori = await _context.YonetimKategoris.FindAsync(id);
            if (yonetimKategori == null)
            {
                return NotFound();
            }
            return View(yonetimKategori);
        }

        // POST: Admin/YonetimKategori/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Gorevi")] YonetimKategori yonetimKategori)
        {
            if (id != yonetimKategori.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yonetimKategori);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YonetimKategoriExists(yonetimKategori.ID))
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
            return View(yonetimKategori);
        }

        // GET: Admin/YonetimKategori/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yonetimKategori = await _context.YonetimKategoris
                .FirstOrDefaultAsync(m => m.ID == id);
            if (yonetimKategori == null)
            {
                return NotFound();
            }

            return View(yonetimKategori);
        }

        // POST: Admin/YonetimKategori/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var yonetimKategori = await _context.YonetimKategoris.FindAsync(id);
            _context.YonetimKategoris.Remove(yonetimKategori);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YonetimKategoriExists(int id)
        {
            return _context.YonetimKategoris.Any(e => e.ID == id);
        }
        public ActionResult Cikis()
        {
            //Session.Remove("")
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}
