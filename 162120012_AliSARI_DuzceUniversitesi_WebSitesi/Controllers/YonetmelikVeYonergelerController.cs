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
    public class YonetmelikVeYonergelerController : Controller
    {
        private readonly AndDB _context;

        public YonetmelikVeYonergelerController(AndDB context)
        {
            _context = context;
        }

        // GET: YonetmelikVeYonergeler
        public async Task<IActionResult> Index()
        {
            var andDB = _context.YonetmelikVeYonergelers.Include(y => y.YonetmelikVeYonergelerKategori).OrderByDescending(y=>y.Tarih);//Tersten sırala
            return View(await andDB.ToListAsync());
        }
       
        private bool YonetmelikVeYonergelerExists(int id)
        {
            return _context.YonetmelikVeYonergelers.Any(e => e.ID == id);
        }
    }
}
