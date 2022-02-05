using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;//ekledim key kullanmak için
using System.ComponentModel.DataAnnotations.Schema;//databasegenerrate 
using System.Linq;
using System.Threading.Tasks;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models
{
    public class Sayilar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//ID yi ben değil kendi kendine arttırsın
        public int ID { get; set; }

        public int? FakulteSayisi { get; set; }
        public int? EnstituSayisi { get; set; }
        public int? YuksekOkulSayisi { get; set; }
        public int? MeslekYuksekOkulSayisi { get; set; }
        public int? LisansProgramiSayisi { get; set; }
        public int? LisansUstuProgramSayisi { get; set; }
        public int? UygulamaArastirmaMerkeziSayisi { get; set; }
        public int? KordinatorlukSayisi { get; set; }
        public int? TubitakProjeSayisi { get; set; }
        public int? BAPProjesiSayisi { get; set; }
        public int? SponsorluProjeSayisi { get; set; }
        public int? PatentSayisi { get; set; }

    }
}
