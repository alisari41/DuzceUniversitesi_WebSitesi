using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;//ekledim key kullanmak için
using System.ComponentModel.DataAnnotations.Schema;//databasegenerrate 
using System.Linq;
using System.Threading.Tasks;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models
{
    public class FormlarOgr
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//ID yi ben değil kendi kendine arttırsın
        public int ID { get; set; }

        public int? FakulteID { get; set; }
        public Fakulte Fakulte { get; set; }//Fakülte ile ilişki kurdum


        public int? EnstituID { get; set; }
        public Enstitu Enstitu { get; set; }//Enstitu ile ilişki kurdum

        public string? EnsitituicinYuksekLisansDoktara { get; set; }

        [Required(ErrorMessage = "Zorunlu alan")]
        public string Baslik { get; set; }


        [Required(ErrorMessage = "Zorunlu alan")]
        public string Link { get; set; }
    }
}
