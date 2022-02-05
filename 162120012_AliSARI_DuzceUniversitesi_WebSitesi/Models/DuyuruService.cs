using _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models
{
    public class DuyuruService
    {
        //Oluşturulan servisin Adını start.up dan servis verimeyi unutma

        private readonly AndDB _context;
        public DuyuruService(AndDB context)
        {
            _context = context;
        }
        //Get All Duyuru 
        public List<Duyurular> GetDuyuru()
        {
            var dlist = _context.Duyurulars.ToList();
            return dlist;
        }
        //Insert duyuru 
        public string Create(Duyurular duyurular)
        {

            duyurular.Tarih = DateTime.Now;//Bugün ki Tarih Girilsin
            duyurular.AktifMi = true;// İlk Duyuru eklediğimde aktif olsun

            _context.Duyurulars.Add(duyurular);
            _context.SaveChanges();
            return "Save Successfully";
        }

        //Get Duyuru  By ID
        public Duyurular GetDuyuruById(int id)
        {
            Duyurular duyurular = _context.Duyurulars.FirstOrDefault(s => s.ID == id);
            return duyurular;
        }

        //Update Duyuru 
        public string UpdateDuyuru(Duyurular duyurular)
        {
            _context.Duyurulars.Update(duyurular);
            _context.SaveChanges();
            return "Update Successfully";
        }

        //Delete Duyuru 
        public string DeleteDuyuru(Duyurular duyurular)
        {
            _context.Remove(duyurular);
            _context.SaveChanges();
            return "Delete Successfully";
        }
    }
}
