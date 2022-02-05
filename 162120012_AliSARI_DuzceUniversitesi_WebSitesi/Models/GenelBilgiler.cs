using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;//ekledim key kullanmak için
using System.ComponentModel.DataAnnotations.Schema;//databasegenerrate 
using System.Linq;
using System.Threading.Tasks;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models
{
    public class GenelBilgiler
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//ID yi ben değil kendi kendine arttırsın
        public int ID { get; set; }

        public int? FakulteID { get; set; }
        public Fakulte Fakulte{ get; set; }//Fakulte ile ilişki kurdum

        public int? EnstituID { get; set; }
        public Enstitu Enstitu { get; set; }//Enstitu ile ilişki kurdum

        public string ResimUrl { get; set; }
        public string? Aciklama1 { get; set; }//? açıklama koymak zorunda değil. Boş Geçilebilir
        public string? Aciklama2 { get; set; }//? açıklama koymak zorunda değil. Boş Geçilebilir
        public string? Aciklama3 { get; set; }//? açıklama koymak zorunda değil. Boş Geçilebilir
        public string? Aciklama4 { get; set; }//? açıklama koymak zorunda değil. Boş Geçilebilir
        public string? Aciklama5 { get; set; }//? açıklama koymak zorunda değil. Boş Geçilebilir
        

        [Required(ErrorMessage = "Zorunlu alan")]
        public string Misyonumuz { get; set; }


        [Required(ErrorMessage = "Zorunlu alan")]
        public string Vizyonumuz { get; set; }


        public string? EkBaslik { get; set; }
        public string? EkAciklama1 { get; set; }
        public string? EkAciklama2 { get; set; }
        public string? EkAciklama3 { get; set; }
        public string? EkAciklama4 { get; set; }
        public string? EkAciklama5 { get; set; }
        public string? EkAciklama6 { get; set; }
        public string? EkAciklama7 { get; set; }
        public string? EkAciklama8 { get; set; }
        public string? EkAciklama9 { get; set; }
        public string? EkAciklama10 { get; set; }
        public string? EkAciklama11 { get; set; }
        public string? EkAciklama12 { get; set; }
    }
}
