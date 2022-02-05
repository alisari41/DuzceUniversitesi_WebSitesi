using _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models
{
    public class SayilarService
    {
        //Oluşturulan servisin Adını start.up dan servis verimeyi unutma

        private readonly AndDB _context;
        public SayilarService(AndDB context)
        {
            _context = context;
        }

        //Get All Sayilar 
        public List<Sayilar> GetSayilar()
        {
            var slist = _context.Sayilars.ToList();
            return slist;
        }

        //Insert Sayilar 
        public string Create(Sayilar sayilar)
        {
            _context.Sayilars.Add(sayilar);
            _context.SaveChanges();
            return "Save Successfully";
        }

        //Get Sayilar  By ID
        public Sayilar GetSayilarById(int id)
        {
            Sayilar sayilar = _context.Sayilars.FirstOrDefault(s => s.ID == id);
            return sayilar;
        }

        //Update Sayilar 
        public string UpdateSayilar(Sayilar sayilar)
        {
            _context.Sayilars.Update(sayilar);
            _context.SaveChanges();
            return "Update Successfully";
        }

        //Delete Sayilar 
        public string DeleteSayilar(Sayilar sayilar)
        {
            _context.Remove(sayilar);
            _context.SaveChanges();
            return "Delete Successfully";
        }
    }
}
