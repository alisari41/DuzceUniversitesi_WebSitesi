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
    public class BolumveProgramSayilariController : Controller
    {
        private readonly AndDB _context;

        public BolumveProgramSayilariController(AndDB context)
        {
            _context = context;
        }

        // GET: BolumveProgramSayilari
        public async Task<IActionResult> Index()
        {
            var andDB = _context.BolumveProgramSayilaris.Include(b => b.BolumveProgramSayilariKategori);
            return View(await andDB.ToListAsync());
        }
        
        private bool BolumveProgramSayilariExists(int id)
        {
            return _context.BolumveProgramSayilaris.Any(e => e.ID == id);
        }
    }
}
