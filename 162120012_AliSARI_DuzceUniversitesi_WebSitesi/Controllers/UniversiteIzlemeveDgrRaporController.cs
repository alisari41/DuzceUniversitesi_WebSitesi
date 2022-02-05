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
    public class UniversiteIzlemeveDgrRaporController : Controller
    {
        private readonly AndDB _context;

        public UniversiteIzlemeveDgrRaporController(AndDB context)
        {
            _context = context;
        }

        // GET: UniversiteIzlemeveDgrRapor
        public async Task<IActionResult> Index()
        {
            var andDB = _context.UniversiteIzlemeveDgrRapors.Include(u => u.UniversiteIzlemeveDgrRaporKategori);
            return View(await andDB.ToListAsync());
        }              

        private bool UniversiteIzlemeveDgrRaporExists(int id)
        {
            return _context.UniversiteIzlemeveDgrRapors.Any(e => e.ID == id);
        }
    }
}
