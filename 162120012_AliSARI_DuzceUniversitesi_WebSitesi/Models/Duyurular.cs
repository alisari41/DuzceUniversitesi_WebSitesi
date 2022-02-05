using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;//ekledim key kullanmak için
using System.ComponentModel.DataAnnotations.Schema;//databasegenerrate 
using System.Linq;
using System.Threading.Tasks;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models
{
    public class Duyurular
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//ID yi ben değil kendi kendine arttırsın
        public int ID { get; set; }


        [StringLength(90)]
        public string? DuyuruKategori { get; set; }



        [StringLength(100)]
        public string? Baslik { get; set; }


        public string? Icerik { get; set; }

        [Required(ErrorMessage = "Zorunlu alan")]
        public DateTime Tarih { get; set; }

        [Required(ErrorMessage = "Zorunlu alan")]
        public bool AktifMi { get; set; }
        public string? Aciklama1 { get; set; }//? açıklama koymak zorunda değil. Boş Geçilebilir
        public string? Aciklama2 { get; set; }//? açıklama koymak zorunda değil. Boş Geçilebilir
        public string? Aciklama3 { get; set; }//? açıklama koymak zorunda değil. Boş Geçilebilir
        public string? Aciklama4 { get; set; }//? açıklama koymak zorunda değil. Boş Geçilebilir
        public string? Aciklama5 { get; set; }//? açıklama koymak zorunda değil. Boş Geçilebilir
        public string? Aciklama6 { get; set; }//? açıklama koymak zorunda değil. Boş Geçilebilir
        public string? ResimUrl1 { get; set; }//? açıklama koymak zorunda değil. Boş Geçilebilir
        public string? ResimUrl2 { get; set; }//? açıklama koymak zorunda değil. Boş Geçilebilir
        public string? ResimUrl3 { get; set; }//? açıklama koymak zorunda değil. Boş Geçilebilir
        public string? ResimUrl4 { get; set; }//? açıklama koymak zorunda değil. Boş Geçilebilir
        public string? ResimUrl5 { get; set; }//? açıklama koymak zorunda değil. Boş Geçilebilir
        public string? ResimUrl6 { get; set; }//? açıklama koymak zorunda değil. Boş Geçilebilir
        public string? ResimUrl7 { get; set; }//? açıklama koymak zorunda değil. Boş Geçilebilir
        public string? ResimUrl8 { get; set; }//? açıklama koymak zorunda değil. Boş Geçilebilir
    }
}
