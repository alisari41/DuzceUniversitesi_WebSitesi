using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Controllers
{
    public class KampüsYasamiController : Controller
    {
        public IActionResult BeslenmeHizmetleri()
        {
            return View();
        }
        public IActionResult SporHizmetleriBirimi()
        {
            return View();
        }
        public IActionResult Ulasim()
        {
            return View();
        }
        public IActionResult Barinma()
        {
            return View();
        }
    }
}
