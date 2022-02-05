using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;//ekledim key kullanmak için
using System.ComponentModel.DataAnnotations.Schema;//databasegenerrate 
using System.Linq;
using System.Threading.Tasks;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models
{
    public class BolumGenelBilgileri
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//ID yi ben değil kendi kendine arttırsın
        public int ID { get; set; }

        public int? BolumID { get; set; }
        public Bolum Bolum { get; set; }//Fakulte ile ilişki kurdum

        public string? Aciklama1 { get; set; }//? açıklama koymak zorunda değil. Boş Geçilebilir
        public string? Aciklama2 { get; set; }//? açıklama koymak zorunda değil. Boş Geçilebilir
        public string? Aciklama3 { get; set; }//? açıklama koymak zorunda değil. Boş Geçilebilir
        public string? Aciklama4 { get; set; }//? açıklama koymak zorunda değil. Boş Geçilebilir
        public string? Aciklama5 { get; set; }//? açıklama koymak zorunda değil. Boş Geçilebilir
        public string? Aciklama6 { get; set; }//? açıklama koymak zorunda değil. Boş Geçilebilir
        public string? Aciklama7 { get; set; }//? açıklama koymak zorunda değil. Boş Geçilebilir
        public string? Aciklama8 { get; set; }//? açıklama koymak zorunda değil. Boş Geçilebilir
        public string? Aciklama9 { get; set; }//? açıklama koymak zorunda değil. Boş Geçilebilir
        public string? Aciklama10 { get; set; }//? açıklama koymak zorunda değil. Boş Geçilebilir
        public string? Aciklama11 { get; set; }//? açıklama koymak zorunda değil. Boş Geçilebilir
        public string? BolognaSureciLink { get; set; }//? açıklama koymak zorunda değil. Boş Geçilebilir
        public string? Email1 { get; set; }//? açıklama koymak zorunda değil. Boş Geçilebilir
        public string? Email2 { get; set; }//? açıklama koymak zorunda değil. Boş Geçilebilir
        public string? Email3 { get; set; }//? açıklama koymak zorunda değil. Boş Geçilebilir

    }
}
