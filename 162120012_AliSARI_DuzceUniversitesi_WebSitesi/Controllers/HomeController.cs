using _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Controllers
{
    public class HomeController : Controller
    {
        private readonly AndDB _context;

        public HomeController(AndDB context)
        {
            _context = context;
        }

       

        public ActionResult Index()
        {
            ViewModel model = new ViewModel();
            model.DuyurularList = _context.Duyurulars.Where(x=>x.AktifMi==true).OrderByDescending(k=>k.Tarih).ToList(); // Duyuru hala aktif mi diye sorguladım ve en yakın Tarihine göre sıraladım.
            model.SayilarList = _context.Sayilars.ToList();
            model.FotografGalerisiList = _context.FotografGalerisis.ToList();
            return View(model);
        }
        public async Task<IActionResult> Duyurular()
        {
            var andDB = _context.Duyurulars.Where(x => x.AktifMi == true).OrderByDescending(y => y.Tarih);// Duyuru hala aktif mi diye sorguladım ve en yakın Tarihine göre sıraladım.
            return View(await andDB.ToListAsync());
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
