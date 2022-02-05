using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;//ekledim key kullanmak için
using System.ComponentModel.DataAnnotations.Schema;//databasegenerrate 
using System.Linq;
using System.Threading.Tasks;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models
{
    public class ButceBilgileri
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//ID yi ben değil kendi kendine arttırsın
        public int ID { get; set; }

        [Required(ErrorMessage = "Zorunlu alan")]
        public int ButceBilgileriKategoriID { get; set; }
        public ButceBilgileriKategori ButceBilgileriKategori { get; set; }//Bütçe Bilgileri Kategorileri ile ilişki kurdum


        [Required(ErrorMessage = "Zorunlu alan")]
        [StringLength(100)]
        public string Aciklama { get; set; }


        [Required(ErrorMessage = "Zorunlu alan")]
        public string Link { get; set; }
    }
}
