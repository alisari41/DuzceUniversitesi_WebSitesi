using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;//ekledim key kullanmak için
using System.ComponentModel.DataAnnotations.Schema;//databasegenerrate 
using System.Linq;
using System.Threading.Tasks;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models
{
    public class PersonelSayilari
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//ID yi ben değil kendi kendine arttırsın
        public int ID { get; set; }

        [Required(ErrorMessage = "Zorunlu alan")]
        public int PersonelSayilariKategoriID { get; set; }
        public PersonelSayilariKategori PersonelSayilariKategori { get; set; }//Personel Sayilari Kategorileri ile ilişki kurdum

        [StringLength(80)]
        public string Unvan { get; set; }

        [StringLength(80)]
        public string HizmetYeri { get; set; }

        [Required(ErrorMessage = "Zorunlu alan")]
        public int Sayi { get; set; }
    }
}
