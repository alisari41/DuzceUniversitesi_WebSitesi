using _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.ViewComponents
{
    public class FakulteBolumleriListele : ViewComponent
    {
        private readonly AndDB _context;
        public FakulteBolumleriListele(AndDB context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke(int fakulteid)//girilen fakülte id'nin bölümlerini getirmeye çalışacağım
        {
            var menus = _context.Bolums.Where(x => x.ID >= 0 && x.FakulteID==fakulteid).ToList();
            return View(menus);
        }

    }
}
