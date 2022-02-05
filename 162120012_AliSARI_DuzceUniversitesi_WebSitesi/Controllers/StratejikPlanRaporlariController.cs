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
    public class StratejikPlanRaporlariController : Controller
    {
        private readonly AndDB _context;

        public StratejikPlanRaporlariController(AndDB context)
        {
            _context = context;
        }

        // GET: StratejikPlanRaporlari
        public async Task<IActionResult> Index()
        {
            var andDB = _context.StratejikPlanRaporlaris.Include(s => s.StratejikPlanRaporlariKategori);
            return View(await andDB.ToListAsync());
        }

        private bool StratejikPlanRaporlariExists(int id)
        {
            return _context.StratejikPlanRaporlaris.Any(e => e.ID == id);
        }
    }
}
