using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Controllers
{
    public class YonetimlerController : Controller
    {
        private readonly AndDB _context;

        public YonetimlerController(AndDB context)
        {
            _context = context;
        }

        // GET: Yonetimler
        public async Task<IActionResult> Rektor()
        {
            var andDB = _context.Yonetims.Where(y => y.YonetimKategoriID==1).ToList();
            
            return View(andDB);
        }
        public async Task<IActionResult> RektorYardimcisi()
        {
            var andDB = _context.Yonetims.Where(y => y.YonetimKategoriID == 2).ToList();

            return View(andDB);
        }
        public async Task<IActionResult> SenatoKurulu()
        {
            var andDB = _context.Yonetims.Include(y => y.YonetimKategori);
            return View(await andDB.ToListAsync());
        }
        

        // GET: Yonetimler/Details/5
        public async Task<IActionResult> YonetimdekiKisilerDetay(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yonetim = await _context.Yonetims
                .Include(y => y.YonetimKategori)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (yonetim == null)
            {
                return NotFound();
            }

            return View(yonetim);
        }

        public async Task<IActionResult> YonetimKurulu()
        {
            var andDB = _context.Yonetims.Include(y => y.YonetimKategori);
            return View(await andDB.ToListAsync());
        }

        public IActionResult GenelSekreter()
        {
            return View();
        }
        public IActionResult KurucuRektorumuz()
        {
            return View();
        }


        private bool YonetimExists(int id)
        {
            return _context.Yonetims.Any(e => e.ID == id);
        }
    }
}
