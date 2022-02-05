using _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models;//database için ekledim
using Microsoft.AspNetCore.Http;//Sessinda SetString için kullandım 
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Areas.Admin.Controllers
{
    // GET: Admin/AdminLogin

    [Area("Admin")]//Admin paneli için oluşturduğum area'ya isim vermek zorundayım
    public class AdminLoginController : Controller
    {
        private readonly AndDB _andDB;
        public AdminLoginController(AndDB andDB)
        {
            _andDB = andDB;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string Email, string Sifre)
        {
            //veri ataması yapıyorum
            var data = _andDB.Kullanicis.Where(x => x.Email == Email && x.Sifre == Sifre).ToList();//tablodaki email ve sifre ile benim giridiğim email ve sifre aynı mı
            //ToList() sorguyu çalıştırmak için
            if (data.Count == 1)// Gelen Eleman sayısı 1 e eşit mi yani doğru mu girdi
            {
                //doğru giriş
                HttpContext.Session.SetString("AdminLoginKullaniciEmailSession", Email);//Sessions Sayesinde girilen Email adresini hafızada tutuyorum 
                HttpContext.Session.SetString("AdminLoginKullaniciSifreSession", Sifre);//Sessions Sayesinde girilen Şifreyi hafızada tutuyorum 

                return Redirect("/admin");//kendini admin sayfasına gönder
            }
            else
            {
                //yanlış giriş
                ViewBag.Error = "E-mail adresiniz veya şifreniz yanlış olduğu için giriş yapamazsınız!";
                return View();//yanlış giriş yapıldıysa aynı sayfaya dön
            }
        }
        public ActionResult Cikis()
        {
            //Session.Remove("")
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}
