using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models;
using System.IO;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FotografGalerisiController : Controller
    {
        private readonly AndDB _context;

        public FotografGalerisiController(AndDB context)
        {
            _context = context;
        }

        // GET: Admin/FotografGalerisi
        public async Task<IActionResult> Index()
        {
            return View(await _context.FotografGalerisis.ToListAsync());
        }

        // GET: Admin/FotografGalerisi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fotografGalerisi = await _context.FotografGalerisis
                .FirstOrDefaultAsync(m => m.ID == id);
            if (fotografGalerisi == null)
            {
                return NotFound();
            }

            return View(fotografGalerisi);
        }

        // GET: Admin/FotografGalerisi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/FotografGalerisi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FotografAdı,Image")] FotografEkle p)
        {
            FotografGalerisi f = new FotografGalerisi();
            if (p.Image!=null)
            {
                var extension = Path.GetExtension(p.Image.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/resimler/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                p.Image.CopyTo(stream);
                f.Image = newimagename;
            }

            f.FotografAdı = p.FotografAdı;

            if (ModelState.IsValid)
            {
                _context.Add(f);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(f);
        }
        // GET: Admin/FotografGalerisis2121/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fotografGalerisi = await _context.FotografGalerisis.FindAsync(id);
            if (fotografGalerisi == null)
            {
                return NotFound();
            }
            return View(fotografGalerisi);
        }

        // POST: Admin/FotografGalerisis2121/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FotografAdı,Image")] FotografGalerisi fotografGalerisi)
        {
            if (id != fotografGalerisi.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    fotografGalerisi.Image = fotografGalerisi.Image;

                    _context.Update(fotografGalerisi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FotografGalerisiExists(fotografGalerisi.ID))
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
            return View(fotografGalerisi);
        }


        // GET: Admin/FotografGalerisi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fotografGalerisi = await _context.FotografGalerisis
                .FirstOrDefaultAsync(m => m.ID == id);
            if (fotografGalerisi == null)
            {
                return NotFound();
            }

            return View(fotografGalerisi);
        }

        // POST: Admin/FotografGalerisi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fotografGalerisi = await _context.FotografGalerisis.FindAsync(id);
            _context.FotografGalerisis.Remove(fotografGalerisi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FotografGalerisiExists(int id)
        {
            return _context.FotografGalerisis.Any(e => e.ID == id);
        }
        public ActionResult Cikis()
        {
            //Session.Remove("")
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}
