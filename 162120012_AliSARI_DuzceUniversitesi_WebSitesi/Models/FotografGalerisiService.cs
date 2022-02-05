using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models
{
    public class FotografGalerisiService
    {
        //Oluşturulan servisin Adını start.up dan servis verimeyi unutma

        private readonly IDbContextFactory<AndDB> _contextFactory;
        //private readonly AndDB _contextFactory;
        public FotografGalerisiService(IDbContextFactory<AndDB> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task UploadFiles(IList<FotografGalerisi> fotografs)
        {
            using(var _context=_contextFactory.CreateDbContext())
            {
                foreach (var file in fotografs)
                {
                    if (file.ID==0)
                    {  
                        _context.FotografGalerisis.Add(file);
                    }                    
                }
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IList<FotografGalerisi>> GetUploadFiles()
        {
            using (var _context=_contextFactory.CreateDbContext())
            {
                var uploadFiles = await _context.FotografGalerisis.ToListAsync();
                return uploadFiles;
            }
        }



        ////Get All FotografGalerisi 
        //public List<FotografGalerisi> GetFotograflar()
        //{
        //    var flist = _context.FotografGalerisis.ToList();
        //    return flist;
        //}

        ////Insert FotografGalerisi 
        //public string Create(FotografEkle p)
        //{
        //    FotografGalerisi f = new FotografGalerisi();
        //    if (p.Image != null)
        //    {
        //        var extension = Path.GetExtension(p.Image.FileName);
        //        var newimagename = Guid.NewGuid() + extension;
        //        var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/resimler/", newimagename);
        //        var stream = new FileStream(location, FileMode.Create);
        //        p.Image.CopyTo(stream);
        //        f.Image = newimagename;
        //    }

        //    f.FotografAdı = p.FotografAdı;

        //    _context.FotografGalerisis.Add(f);
        //    _context.SaveChanges();
        //    return "Save Successfully";
        //}

        ////Get FotografGalerisi  By ID
        //public FotografGalerisi GetFotograflarById(int id)
        //{
        //    FotografGalerisi fotograflar = _context.FotografGalerisis.FirstOrDefault(s => s.ID == id);
        //    return fotograflar;
        //}
        ////Delete FotografGalerisi 
        //public string DeleteSayilar(FotografGalerisi fotograflar)
        //{
        //    _context.Remove(fotograflar);
        //    _context.SaveChanges();
        //    return "Delete Successfully";
        //}
    }
}
