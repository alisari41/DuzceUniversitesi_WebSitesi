using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;//ekledim key kullanmak için
using System.ComponentModel.DataAnnotations.Schema;//databasegenerrate 
using System.Linq;
using System.Threading.Tasks;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models
{
    public class UniversiteIzlemeveDgrRapor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//ID yi ben değil kendi kendine arttırsın
        public int ID { get; set; }

        [Required(ErrorMessage = "Zorunlu alan")]
        public int UniversiteIzlemeveDgrRaporKategoriID { get; set; }
        public UniversiteIzlemeveDgrRaporKategori UniversiteIzlemeveDgrRaporKategori { get; set; }//Üniversite izleme ve değerlendirme Rapor Kategorileri ile ilişki kurdum

        [Required(ErrorMessage = "Zorunlu alan")]
        [StringLength(100)]
        public string Kriterler { get; set; }

        [Required(ErrorMessage = "Zorunlu alan")]

        [StringLength(10)]
        public string Say_Oran { get; set; }


    }
}
