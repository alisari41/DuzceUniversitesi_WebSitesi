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
    public class SayilarController : Controller
    {
        private readonly AndDB _context;

        public SayilarController(AndDB context)
        {
            _context = context;
        }

        // GET: Admin/Sayilar
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sayilars.ToListAsync());
        }

        // GET: Admin/Sayilar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sayilar = await _context.Sayilars
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sayilar == null)
            {
                return NotFound();
            }

            return View(sayilar);
        }

        // GET: Admin/Sayilar/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Sayilar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FakulteSayisi,EnstituSayisi,YuksekOkulSayisi,MeslekYuksekOkulSayisi,LisansProgramiSayisi,LisansUstuProgramSayisi,UygulamaArastirmaMerkeziSayisi,KordinatorlukSayisi,TubitakProjeSayisi,BAPProjesiSayisi,SponsorluProjeSayisi,PatentSayisi")] Sayilar sayilar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sayilar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sayilar);
        }

        // GET: Admin/Sayilar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sayilar = await _context.Sayilars.FindAsync(id);
            if (sayilar == null)
            {
                return NotFound();
            }
            return View(sayilar);
        }

        // POST: Admin/Sayilar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FakulteSayisi,EnstituSayisi,YuksekOkulSayisi,MeslekYuksekOkulSayisi,LisansProgramiSayisi,LisansUstuProgramSayisi,UygulamaArastirmaMerkeziSayisi,KordinatorlukSayisi,TubitakProjeSayisi,BAPProjesiSayisi,SponsorluProjeSayisi,PatentSayisi")] Sayilar sayilar)
        {
            if (id != sayilar.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sayilar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SayilarExists(sayilar.ID))
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
            return View(sayilar);
        }

        // GET: Admin/Sayilar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sayilar = await _context.Sayilars
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sayilar == null)
            {
                return NotFound();
            }

            return View(sayilar);
        }

        // POST: Admin/Sayilar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sayilar = await _context.Sayilars.FindAsync(id);
            _context.Sayilars.Remove(sayilar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SayilarExists(int id)
        {
            return _context.Sayilars.Any(e => e.ID == id);
        }
        public ActionResult Cikis()
        {
            //Session.Remove("")
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}
