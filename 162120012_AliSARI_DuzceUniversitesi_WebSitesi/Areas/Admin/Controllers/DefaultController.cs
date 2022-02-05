using _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Areas.Admin.Controllers
{
    [Area("Admin")]//Admin paneli için oluşturduğum area'ya isim vermek zorundayım
    public class DefaultController : AdminControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Cikis()
        {
            //Session.Remove("")
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}
