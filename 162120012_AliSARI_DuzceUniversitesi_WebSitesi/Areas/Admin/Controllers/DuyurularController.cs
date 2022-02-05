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
    public class DuyurularController : Controller
    {
        private readonly AndDB _context;

        public DuyurularController(AndDB context)
        {
            _context = context;
        }

        // GET: Admin/Duyurular
        public async Task<IActionResult> Index()
        {
            return View(await _context.Duyurulars.ToListAsync());
        }

        // GET: Admin/Duyurular/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duyurular = await _context.Duyurulars
                .FirstOrDefaultAsync(m => m.ID == id);
            if (duyurular == null)
            {
                return NotFound();
            }

            return View(duyurular);
        }

        // GET: Admin/Duyurular/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Duyurular/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,DuyuruKategori,Baslik,Icerik,Tarih,AktifMi,Aciklama1,Aciklama2,Aciklama3,Aciklama4,Aciklama5,Aciklama6,ResimUrl1,ResimUrl2,ResimUrl3,ResimUrl4,ResimUrl5,ResimUrl6,ResimUrl7,ResimUrl8")] Duyurular duyurular)
        {
            if (ModelState.IsValid)
            {

                duyurular.Tarih = DateTime.Now;//Bugün ki Tarih Girilsin
                duyurular.AktifMi = true;// İlk Duyuru eklediğimde aktif olsun

                _context.Add(duyurular);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(duyurular);
        }

        // GET: Admin/Duyurular/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duyurular = await _context.Duyurulars.FindAsync(id);
            if (duyurular == null)
            {
                return NotFound();
            }
            return View(duyurular);
        }

        // POST: Admin/Duyurular/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DuyuruKategori,Baslik,Icerik,Tarih,AktifMi,Aciklama1,Aciklama2,Aciklama3,Aciklama4,Aciklama5,Aciklama6,ResimUrl1,ResimUrl2,ResimUrl3,ResimUrl4,ResimUrl5,ResimUrl6,ResimUrl7,ResimUrl8")] Duyurular duyurular)
        {
            if (id != duyurular.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(duyurular);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DuyurularExists(duyurular.ID))
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
            return View(duyurular);
        }

        // GET: Admin/Duyurular/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duyurular = await _context.Duyurulars
                .FirstOrDefaultAsync(m => m.ID == id);
            if (duyurular == null)
            {
                return NotFound();
            }

            return View(duyurular);
        }

        // POST: Admin/Duyurular/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var duyurular = await _context.Duyurulars.FindAsync(id);
            _context.Duyurulars.Remove(duyurular);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DuyurularExists(int id)
        {
            return _context.Duyurulars.Any(e => e.ID == id);
        }
        public ActionResult Cikis()
        {
            //Session.Remove("")
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}
