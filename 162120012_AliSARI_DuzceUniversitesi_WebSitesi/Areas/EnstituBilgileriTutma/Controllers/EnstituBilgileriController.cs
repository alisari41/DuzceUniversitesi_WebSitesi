using _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Areas.EnstituBilgileriTutma.Controllers
{
    [Area("EnstituBilgileriTutma")]
    public class EnstituBilgileriController : Controller
    {
        private readonly AndDB _context;
        public EnstituBilgileriController(AndDB context)
        {
            _context = context;
        }
        // GET: EnstituBilgileri
        [Route("Enstituler/{isim}/{id}")]//altaki parametre ile aynı olacak
        public IActionResult GenelBilgiler(string isim, int id)
        {//GENEL BİLGİLERİ BURADA TUTUYORUM                    EnstitüID olacak burada
            var andDB = _context.GenelBilgilers.Where(b => b.EnstituID == id).ToList();
            ViewBag.Enstituler = _context.Enstitus.Where(x => x.ID == id).FirstOrDefault();
            return View(andDB);
        }

        public IActionResult EnstituKurulu(int id)
        {
            var andDB = _context.Yonetims.Include(s => s.YonetimKategori).Where(y => y.EnstituID == id).OrderBy(k => k.YonetimKategori.Gorevi).ToList();
            ViewBag.Enstituler = _context.Enstitus.Where(x => x.ID == id).FirstOrDefault();
            ViewBag.Yonetimler = _context.Yonetims.Where(x => x.ID == id).FirstOrDefault();
            return View(andDB);
        }
        public IActionResult YonetimKurulu(int id)
        {
            var andDB = _context.Yonetims.Include(s => s.YonetimKategori).Where(y => y.EnstituID == id).OrderBy(k => k.YonetimKategori.Gorevi).ToList();
            ViewBag.Enstituler = _context.Enstitus.Where(x => x.ID == id).FirstOrDefault();
            ViewBag.Yonetimler = _context.Yonetims.Where(x => x.ID == id).FirstOrDefault();
            return View(andDB);
        }
        public IActionResult YonetimdekiKisilerDetay(int id, int fakulteid)
        {
            var andDB = _context.Yonetims.Include(s => s.YonetimKategori).Where(y => y.ID == id).ToList();
            ViewBag.Enstituler = _context.Enstitus.Where(x => x.ID == fakulteid).FirstOrDefault();
            ViewBag.Yonetimler = _context.Yonetims.Where(x => x.ID == fakulteid).FirstOrDefault();
            return View(andDB);
        }
        public IActionResult AkademikPersoneller(int id)
        {
            var andDB = _context.Personels.Include(s => s.PersonelKategori).Include(s => s.Enstitu).Where(y => y.EnstituID == id && y.PersonelKategori.Kategori == "Akademik").ToList();
            ViewBag.Enstituler = _context.Enstitus.Where(x => x.ID == id).FirstOrDefault();
            ViewBag.Yonetimler = _context.Yonetims.Where(x => x.ID == id).FirstOrDefault();
            return View(andDB);
        }
        public IActionResult IdariPersoneller(int id)
        {
            var andDB = _context.Personels.Include(s => s.PersonelKategori).Include(s => s.Enstitu).Where(y => y.EnstituID == id && y.PersonelKategori.Kategori == "İdari").ToList();
            ViewBag.Enstituler = _context.Enstitus.Where(x => x.ID == id).FirstOrDefault();
            ViewBag.Yonetimler = _context.Yonetims.Where(x => x.ID == id).FirstOrDefault();
            return View(andDB);
        }
        public IActionResult PersonelDetay(int id, int enstituid)
        {
            var andDB = _context.Personels.Include(y => y.PersonelKategori).Include(s => s.Enstitu).Where(y => y.ID == id).ToList();
            ViewBag.Enstituler = _context.Enstitus.Where(x => x.ID == enstituid).FirstOrDefault();
            ViewBag.Yonetimler = _context.Yonetims.Where(x => x.ID == enstituid).FirstOrDefault();
            return View(andDB);
        }
        public IActionResult Formlar(int id)
        {//FORMLARI BURADA TUTUYORUM
            ViewBag.Enstituler = _context.Enstitus.Where(x => x.ID == id).FirstOrDefault();
            return View();
        }
        public IActionResult YuksekLisansFormlari(int id)
        {//FORMLARI BURADA TUTUYORUM
            var andDB = _context.FormlarOgrs.Include(s => s.Enstitu).Where(b => b.EnsitituicinYuksekLisansDoktara == "Yüksek Lisans Formları").OrderBy(k=>k.EnsitituicinYuksekLisansDoktara).ToList();
            ViewBag.Enstituler = _context.Enstitus.Where(x => x.ID == id).FirstOrDefault();
            return View(andDB);
        }
        public IActionResult DoktoraFormlari(int id)
        {//FORMLARI BURADA TUTUYORUM
            var andDB = _context.FormlarOgrs.Include(s => s.Enstitu).Where(b => b.EnsitituicinYuksekLisansDoktara == "Doktora Formları").OrderBy(k => k.EnsitituicinYuksekLisansDoktara).ToList();
            ViewBag.Enstituler = _context.Enstitus.Where(x => x.ID == id).FirstOrDefault();
            return View(andDB);
        }
        public IActionResult TezYazimKilavuzu(int id)//devam ettt
        {//Tez Yazım kılavuzlarını BURADA TUTUYORUM
            ViewBag.Enstituler = _context.Enstitus.Where(x => x.ID == id).FirstOrDefault();
            return View();
        }
        public IActionResult AskerlikIslemleri(int id)//devam ettt
        {//AskerlikIslemleri BURADA TUTUYORUM
            ViewBag.Enstituler = _context.Enstitus.Where(x => x.ID == id).FirstOrDefault();
            return View();
        }
        public IActionResult Mevzuat(int id)
        {
            var andDB = _context.Mevzuats.Include(s => s.Enstitu).Where(b => b.EnstituID == id).OrderBy(k=>k.Aciklama).ToList();
            ViewBag.Enstituler = _context.Enstitus.Where(x => x.ID == id).FirstOrDefault();
            return View(andDB);
        }
        public IActionResult OrganizasyonSemasi(int id)
        {
            var andDB = _context.OrganizasyonSemasis.Include(s => s.Enstitu).Where(b => b.EnstituID == id).ToList();
            ViewBag.Enstituler = _context.Enstitus.Where(x => x.ID == id).FirstOrDefault();
            return View(andDB);
        }
        public IActionResult KurullarVeKomisyonlar(int id)
        {
            var andDB = _context.KurullarVeKomisyonlars.Include(s => s.Enstitu).Where(b => b.EnstituID == id).OrderByDescending(k => k.Aciklama).ToList();
            ViewBag.Enstituler = _context.Enstitus.Where(x => x.ID == id).FirstOrDefault();
            return View(andDB);
        }
        public IActionResult IsAkisSemalari(int id)
        {
            var andDB = _context.ısAkisSemalaris.Include(s => s.Enstitu).Where(b => b.EnstituID == id).OrderBy(k => k.Departman).ToList();
            ViewBag.Enstituler = _context.Enstitus.Where(x => x.ID == id).FirstOrDefault();
            return View(andDB);
        }
        public IActionResult KurumIcDegerlendirmeRaporlari(int id)
        {
            var andDB = _context.KurumIcDegerlendirmeRaporlaris.Include(s => s.Enstitu).Where(b => b.EnstituID == id).OrderByDescending(k => k.Aciklama).ToList();
            ViewBag.Enstituler = _context.Enstitus.Where(x => x.ID == id).FirstOrDefault();
            return View(andDB);
        }
        public IActionResult FaliyetRaporlari(int id)
        {
            var andDB = _context.FaliyetRaporus.Include(s => s.Enstitu).Where(b => b.EnstituID == id).OrderByDescending(k => k.Aciklama).ToList();
            ViewBag.Enstituler = _context.Enstitus.Where(x => x.ID == id).FirstOrDefault();
            return View(andDB);
        }
    }
}
