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
    public class OgrenciSayilariController : Controller
    {
        private readonly AndDB _context;

        public OgrenciSayilariController(AndDB context)
        {
            _context = context;
        }

        // GET: OgrenciSayilari
        public async Task<IActionResult> Index()
        {
            return View(await _context.OgrenciSayilaris.ToListAsync());
        }

        private bool OgrenciSayilariExists(int id)
        {
            return _context.OgrenciSayilaris.Any(e => e.ID == id);
        }
    }
}
