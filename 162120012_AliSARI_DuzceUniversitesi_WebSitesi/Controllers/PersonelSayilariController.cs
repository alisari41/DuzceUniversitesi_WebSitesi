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
    public class PersonelSayilariController : Controller
    {
        private readonly AndDB _context;

        public PersonelSayilariController(AndDB context)
        {
            _context = context;
        }

        // GET: PersonelSayilari
        public async Task<IActionResult> Index()
        {
            var andDB = _context.PersonelSayilaris.Include(p => p.PersonelSayilariKategori);
            return View(await andDB.ToListAsync());
        }        

        private bool PersonelSayilariExists(int id)
        {
            return _context.PersonelSayilaris.Any(e => e.ID == id);
        }
    }
}
