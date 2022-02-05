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
    public class ButceBilgileriController : Controller
    {
        private readonly AndDB _context;

        public ButceBilgileriController(AndDB context)
        {
            _context = context;
        }

        // GET: ButceBilgileri
        public async Task<IActionResult> Index()
        {
            var andDB = _context.ButceBilgileris.Include(b => b.ButceBilgileriKategori);
            return View(await andDB.ToListAsync());
        }

        private bool ButceBilgileriExists(int id)
        {
            return _context.ButceBilgileris.Any(e => e.ID == id);
        }
    }
}
