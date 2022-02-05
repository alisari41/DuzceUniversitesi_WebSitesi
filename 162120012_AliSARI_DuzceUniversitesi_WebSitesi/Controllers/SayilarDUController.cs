using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Controllers
{
    public class SayilarDUController : Controller
    {
        public IActionResult ProjeSayilari()
        {
            return View();
        }
        public IActionResult FikriMulkiyet()
        {
            return View();
        }
    }
}
