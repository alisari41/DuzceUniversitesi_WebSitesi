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
    public class IsbirlikleriController : Controller
    {
        private readonly AndDB _context;

        public IsbirlikleriController(AndDB context)
        {
            _context = context;
        }

        // GET: Isbirlikleri
        public async Task<IActionResult> Index()
        {
            return View(await _context.Isbirlikleris.OrderBy(y=>y.ProtokolImzalananFirmalar).ToListAsync());
        }       

        private bool IsbirlikleriExists(int id)
        {
            return _context.Isbirlikleris.Any(e => e.ID == id);
        }
    }
}
