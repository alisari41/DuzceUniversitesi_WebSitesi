using _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.ViewComponents
{
    public class FakulteleriListele : ViewComponent
    {
        private readonly AndDB _context;
        public FakulteleriListele(AndDB context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var menus = _context.Fakultes.Where(x => x.ID >= 0).ToList();
            return View(menus);
        }
    }
}
