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
    public class KurumIcDegerlendirmeRaporlariController : Controller
    {
        private readonly AndDB _context;

        public KurumIcDegerlendirmeRaporlariController(AndDB context)
        {
            _context = context;
        }

        // GET: KurumIcDegerlendirmeRaporlari
        public async Task<IActionResult> Index()
        {
            return View(await _context.KurumIcDegerlendirmeRaporlaris.Where(x=>x.EnstituID==null).OrderByDescending(y=>y.Aciklama).ToListAsync());
        }

        private bool KurumIcDegerlendirmeRaporlariExists(int id)
        {
            return _context.KurumIcDegerlendirmeRaporlaris.Any(e => e.ID == id);
        }
    }
}
