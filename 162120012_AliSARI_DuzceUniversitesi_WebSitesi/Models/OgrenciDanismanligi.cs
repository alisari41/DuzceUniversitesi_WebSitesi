using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;//ekledim key kullanmak için
using System.ComponentModel.DataAnnotations.Schema;//databasegenerrate 
using System.Linq;
using System.Threading.Tasks;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models
{
    public class OgrenciDanismanligi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//ID yi ben değil kendi kendine arttırsın
        public int ID { get; set; }

        [Required(ErrorMessage = "Zorunlu alan")]
        public int FakulteID { get; set; }
        public Fakulte Fakulte { get; set; }//Fakülte ile ilişki kurdum

        

        [Required(ErrorMessage = "Zorunlu alan")]
        [StringLength(120)]
        public string BolumAdi { get; set; }

        [Required(ErrorMessage = "Zorunlu alan")]
        public int Sinif{ get; set; }


        [Required(ErrorMessage = "Zorunlu alan")]
        [StringLength(15)]
        public string DanismanUnvan { get; set; }


        [Required(ErrorMessage = "Zorunlu alan")]
        [StringLength(50)]
        public string DanismanAd { get; set; }



        [Required(ErrorMessage = "Zorunlu alan")]
        [StringLength(100)]
        public string DanismanSoyad { get; set; }
    }
}
