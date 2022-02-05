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
    public class DukkansController : Controller
    {
        private readonly AndDB _context;

        public DukkansController(AndDB context)
        {
            _context = context;
        }

        // GET: Dukkans
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dukkans.ToListAsync());
        }

        private bool DukkanExists(int id)
        {
            return _context.Dukkans.Any(e => e.ID == id);
        }
    }
}
