using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;//ekledim key kullanmak için
using System.ComponentModel.DataAnnotations.Schema;//databasegenerrate 
using System.Linq;
using System.Threading.Tasks;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models
{
    public class BolumveProgramSayilari
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//ID yi ben değil kendi kendine arttırsın
        public int ID { get; set; }

        [Required(ErrorMessage = "Zorunlu alan")]
        public int BolumveProgramSayilariKategoriID { get; set; }
        public BolumveProgramSayilariKategori BolumveProgramSayilariKategori { get; set; }//Bölüm ve program Sayilar Kategorileri ile ilişki kurdum

        [Required(ErrorMessage = "Zorunlu alan")]
        [StringLength(100)]
        public string Fakulte { get; set; }

        [Required(ErrorMessage = "Zorunlu alan")]
        [StringLength(50)]
        public string OgrenimTuru { get; set; }

        [Required(ErrorMessage = "Zorunlu alan")]
        public int Sayisi { get; set; }
    }
}
