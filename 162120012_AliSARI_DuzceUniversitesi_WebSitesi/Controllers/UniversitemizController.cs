using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Controllers
{
    public class UniversitemizController : Controller
    {
        public IActionResult Duzce()
        {
            return View();
        }
        public IActionResult Kurulus()
        {
            return View();
        }
    }
}
