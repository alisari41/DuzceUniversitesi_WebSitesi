using _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Areas.FakulteBilgileriTutma.Controllers
{
    [Area("FakulteBilgileriTutma")]
    public class FakulteBilgileriController : Controller
    {
        private readonly AndDB _context;
        public FakulteBilgileriController(AndDB context)
        {
            _context = context;
        }

        // GET: FakulteBilgileri
        [Route("Fakulteler/{isim}/{id}")]//altaki parametre ile aynı olacak
        public IActionResult Index(string isim, int id)
        {//GENEL BİLGİLERİ BURADA TUTUYORUM
            var andDB = _context.GenelBilgilers.Where(b => b.FakulteID == id).ToList();
            ViewBag.Fakulteler = _context.Fakultes.Where(x => x.ID == id).FirstOrDefault();
            return View(andDB);
        }
        // GET: FakulteBilgileri
        [Route("Bolumler/{isim}/{id}/{fakulteid}")]//altaki parametre ile aynı olacak
        public IActionResult BolumGenelBilgileri(string isim, int id,int fakulteid)
        {//BÖLÜM GENEL BİLGİLERİ BURADA TUTUYORUM
            var andDB = _context.BolumGenelBilgileris.Include(s=>s.Bolum).Where(b => b.BolumID == id).ToList();
            ViewBag.Fakulteler = _context.Fakultes.Where(x => x.ID == fakulteid).FirstOrDefault();
            ViewBag.Bolumler = _context.Bolums.Where(x => x.ID == id).FirstOrDefault();
            return View(andDB);
        }
        public IActionResult YonetimdekiKisiler(int id)
        {
            var andDB = _context.Yonetims.Include(s => s.YonetimKategori).Where(y => y.FakulteID == id).ToList();
            ViewBag.Fakulteler = _context.Fakultes.Where(x => x.ID == id).FirstOrDefault();
            ViewBag.Yonetimler = _context.Yonetims.Where(x => x.ID == id).FirstOrDefault();
            return View(andDB);
        }
        public IActionResult YonetimdekiKisilerDetay(int id, int fakulteid)
        {
            var andDB = _context.Yonetims.Include(s => s.YonetimKategori).Where(y => y.ID == id).ToList();
            ViewBag.Fakulteler = _context.Fakultes.Where(x => x.ID == fakulteid).FirstOrDefault();
            ViewBag.Yonetimler = _context.Yonetims.Where(x => x.ID == fakulteid).FirstOrDefault();
            return View(andDB);
        }
        public IActionResult BolumVeAnabilimDaliBaskanliklari(int id)
        {
            /* SIRALAMA İŞLEMİ YAPILIR BOLUM ADINA GÖRE SIRALANRAK YAZILIR*/

            var andDB = _context.Yonetims.Include(y => y.Bolum).Include(s => s.YonetimKategori).Where(y => y.FakulteID == id).OrderBy(k => k.Bolum.BolumAdi).ToList();
            ViewBag.Fakulteler = _context.Fakultes.Where(x => x.ID == id).FirstOrDefault();
            return View(andDB);
        }
        public IActionResult AkademikPersoneller(int id)
        {
            var andDB = _context.Personels.Include(s => s.PersonelKategori).Include(s => s.Fakulte).Where(y => y.FakulteID == id && y.PersonelKategori.Kategori == "Akademik").ToList();
            ViewBag.Fakulteler = _context.Fakultes.Where(x => x.ID == id).FirstOrDefault();
            ViewBag.Yonetimler = _context.Yonetims.Where(x => x.ID == id).FirstOrDefault();

            return View(andDB);
        }
        public IActionResult IdariPersoneller(int id)
        {
            var andDB = _context.Personels.Include(s => s.PersonelKategori).Include(s => s.Fakulte).Where(y => y.FakulteID == id && y.PersonelKategori.Kategori == "İdari").ToList();
            ViewBag.Fakulteler = _context.Fakultes.Where(x => x.ID == id).FirstOrDefault();
            ViewBag.Yonetimler = _context.Yonetims.Where(x => x.ID == id).FirstOrDefault();

            return View(andDB);
        }
        public IActionResult PersonelDetay(int id, int fakulteid)
        {
            var andDB = _context.Personels.Include(y => y.PersonelKategori).Include(s => s.Fakulte).Where(y => y.ID == id).ToList();
            ViewBag.Fakulteler = _context.Fakultes.Where(x => x.ID == fakulteid).FirstOrDefault();
            ViewBag.Yonetimler = _context.Yonetims.Where(x => x.ID == fakulteid).FirstOrDefault();
            return View(andDB);
        }
        public IActionResult Formlar(int id)
        {//FORMLARI BURADA TUTUYORUM
            var andDB = _context.FormlarOgrs.Include(s => s.Fakulte).Where(b => b.FakulteID == id).ToList();
            ViewBag.Fakulteler = _context.Fakultes.Where(x => x.ID == id).FirstOrDefault();
            return View(andDB);
        }
        public IActionResult LisansDersProgrami(int id)
        {
            var andDB = _context.DersProgramlaris.Include(s => s.Fakulte).Where(b => b.FakulteID == id && b.DersProgramlariKategori.Kategori== "Lisans Ders Programları").OrderBy(k=>k.Aciklama).ToList();
            ViewBag.Fakulteler = _context.Fakultes.Where(x => x.ID == id).FirstOrDefault();
            return View(andDB);
        }
        public IActionResult LisansustuDersProgrami(int id)
        {
            var andDB = _context.DersProgramlaris.Include(s => s.Fakulte)
                .Where(b => b.FakulteID == id && b.DersProgramlariKategori.Kategori == "Lisansüstü Ders Programı")
                .OrderBy(k => k.Aciklama).ToList();
            ViewBag.Fakulteler = _context.Fakultes.Where(x => x.ID == id).FirstOrDefault();
            return View(andDB);
        }
        public IActionResult OgrenciDanisman(int id)
        {
            var andDB = _context.OgrenciDanismanligis.Include(s => s.Fakulte).Where(b => b.FakulteID == id).OrderBy(k => k.BolumAdi).ToList();
            ViewBag.Fakulteler = _context.Fakultes.Where(x => x.ID == id).FirstOrDefault();
            return View(andDB);
        }
        public IActionResult OrganizasyonSemasi(int id)
        {
            var andDB = _context.OrganizasyonSemasis.Include(s => s.Fakulte).Where(b => b.FakulteID == id).ToList();
            ViewBag.Fakulteler = _context.Fakultes.Where(x => x.ID == id).FirstOrDefault();
            return View(andDB);
        }
        public IActionResult GorevTanimlari(int id)
        {
            var andDB = _context.GorevTanimlaris.Include(s => s.Fakulte).Where(b => b.FakulteID == id).ToList();
            ViewBag.Fakulteler = _context.Fakultes.Where(x => x.ID == id).FirstOrDefault();
            return View(andDB);
        }
        public IActionResult FaliyetRaporlari(int id)
        {
            var andDB = _context.FaliyetRaporus.Include(s => s.Fakulte).Where(b => b.FakulteID == id).OrderByDescending(k=>k.Aciklama).ToList();
            ViewBag.Fakulteler = _context.Fakultes.Where(x => x.ID == id).FirstOrDefault();
            return View(andDB);
        }
        public IActionResult IcDegerlendirmeRaporu(int id)
        {
            var andDB = _context.IcDegerlendirmeRaporus.Include(s => s.Fakulte).Where(b => b.FakulteID == id).OrderByDescending(k => k.Aciklama).ToList();
            ViewBag.Fakulteler = _context.Fakultes.Where(x => x.ID == id).FirstOrDefault();
            return View(andDB);
        }
        public IActionResult KurullarVeKomisyonlar(int id)
        {
            var andDB = _context.KurullarVeKomisyonlars.Include(s => s.Fakulte).Where(b => b.FakulteID == id).OrderByDescending(k => k.Aciklama).ToList();
            ViewBag.Fakulteler = _context.Fakultes.Where(x => x.ID == id).FirstOrDefault();
            return View(andDB);
        }
        public IActionResult HizmetStandartlariveEnvanteri(int id)
        {
            var andDB = _context.HizmetStandartlariveEnvanteris.Include(s => s.Fakulte).Where(b => b.FakulteID == id).OrderByDescending(k => k.Aciklama).ToList();
            ViewBag.Fakulteler = _context.Fakultes.Where(x => x.ID == id).FirstOrDefault();
            return View(andDB);
        }
        public IActionResult IsAkisSemalari(int id)
        {
            var andDB = _context.ısAkisSemalaris.Include(s => s.Fakulte).Where(b => b.FakulteID == id).OrderBy(k => k.Departman).ToList();
            ViewBag.Fakulteler = _context.Fakultes.Where(x => x.ID == id).FirstOrDefault();
            return View(andDB);
        }
        public IActionResult AkademikCalismalar(int id)
        {
            var andDB = _context.AkademikCalismalars.Include(s => s.Fakulte).Where(b => b.FakulteID == id).OrderBy(k => k.Aciklama).ToList();
            ViewBag.Fakulteler = _context.Fakultes.Where(x => x.ID == id).FirstOrDefault();
            return View(andDB);
        }
    }
}
