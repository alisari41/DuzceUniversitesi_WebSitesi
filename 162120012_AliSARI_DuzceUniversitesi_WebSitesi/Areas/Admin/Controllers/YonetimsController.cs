using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models;
using X.PagedList;//sayfalama yapmak için

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class YonetimsController : Controller
    {
        private readonly AndDB _context;

        public YonetimsController(AndDB context)
        {
            _context = context;
        }

        // GET: Admin/Yonetims
        public async Task<IActionResult> Index(int sayfa = 1, int eleman_sayisi = 3)
        {
            return View(_context.Yonetims.Include(y => y.Bolum).Include(y => y.Enstitu).Include(y => y.Fakulte).Include(y => y.YonetimKategori).ToPagedList(sayfa, eleman_sayisi));
        }

        // GET: Admin/Yonetims/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yonetim = await _context.Yonetims
                .Include(y => y.Bolum)
                .Include(y => y.Enstitu)
                .Include(y => y.Fakulte)
                .Include(y => y.YonetimKategori)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (yonetim == null)
            {
                return NotFound();
            }

            return View(yonetim);
        }

        // GET: Admin/Yonetims/Create
        public IActionResult Create()
        {
            ViewData["BolumID"] = new SelectList(_context.Bolums, "ID", "BolumAdi");
            ViewData["EnstituID"] = new SelectList(_context.Enstitus, "ID", "EnstituAdi");
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi");
            ViewData["YonetimKategoriID"] = new SelectList(_context.YonetimKategoris, "ID", "Gorevi");
            return View();
        }

        // POST: Admin/Yonetims/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,YonetimKategoriID,FakulteID,BolumID,EnstituID,Ad,Soyad,Unvan,Email,Telefon,BolumDali,BolumGorevi,FotografUrl,Aciklama1,Aciklama2,Aciklama3,Aciklama4,Aciklama5,Yayinlar1,Yayinlar2,Yayinlar3,Yayinlar4,Yayinlar5,Yayinlar6,Yayinlar7,Yayinlar8,Yayinlar9,Yayinlar10,Yayinlar11,Yayinlar12")] Yonetim yonetim)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yonetim);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BolumID"] = new SelectList(_context.Bolums, "ID", "BolumAdi", yonetim.BolumID);
            ViewData["EnstituID"] = new SelectList(_context.Enstitus, "ID", "EnstituAdi", yonetim.EnstituID);
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi", yonetim.FakulteID);
            ViewData["YonetimKategoriID"] = new SelectList(_context.YonetimKategoris, "ID", "Gorevi", yonetim.YonetimKategoriID);
            return View(yonetim);
        }

        // GET: Admin/Yonetims/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yonetim = await _context.Yonetims.FindAsync(id);
            if (yonetim == null)
            {
                return NotFound();
            }
            ViewData["BolumID"] = new SelectList(_context.Bolums, "ID", "BolumAdi", yonetim.BolumID);
            ViewData["EnstituID"] = new SelectList(_context.Enstitus, "ID", "EnstituAdi", yonetim.EnstituID);
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi", yonetim.FakulteID);
            ViewData["YonetimKategoriID"] = new SelectList(_context.YonetimKategoris, "ID", "Gorevi", yonetim.YonetimKategoriID);
            return View(yonetim);
        }

        // POST: Admin/Yonetims/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,YonetimKategoriID,FakulteID,BolumID,EnstituID,Ad,Soyad,Unvan,Email,Telefon,BolumDali,BolumGorevi,FotografUrl,Aciklama1,Aciklama2,Aciklama3,Aciklama4,Aciklama5,Yayinlar1,Yayinlar2,Yayinlar3,Yayinlar4,Yayinlar5,Yayinlar6,Yayinlar7,Yayinlar8,Yayinlar9,Yayinlar10,Yayinlar11,Yayinlar12")] Yonetim yonetim)
        {
            if (id != yonetim.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yonetim);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YonetimExists(yonetim.ID))
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
            ViewData["BolumID"] = new SelectList(_context.Bolums, "ID", "BolumAdi", yonetim.BolumID);
            ViewData["EnstituID"] = new SelectList(_context.Enstitus, "ID", "EnstituAdi", yonetim.EnstituID);
            ViewData["FakulteID"] = new SelectList(_context.Fakultes, "ID", "FakulteAdi", yonetim.FakulteID);
            ViewData["YonetimKategoriID"] = new SelectList(_context.YonetimKategoris, "ID", "Gorevi", yonetim.YonetimKategoriID);
            return View(yonetim);
        }

        // GET: Admin/Yonetims/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yonetim = await _context.Yonetims
                .Include(y => y.Bolum)
                .Include(y => y.Enstitu)
                .Include(y => y.Fakulte)
                .Include(y => y.YonetimKategori)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (yonetim == null)
            {
                return NotFound();
            }

            return View(yonetim);
        }

        // POST: Admin/Yonetims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var yonetim = await _context.Yonetims.FindAsync(id);
            _context.Yonetims.Remove(yonetim);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YonetimExists(int id)
        {
            return _context.Yonetims.Any(e => e.ID == id);
        }
        public ActionResult Cikis()
        {
            //Session.Remove("")
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}
