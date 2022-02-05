using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;//ekledim key kullanmak için
using System.ComponentModel.DataAnnotations.Schema;//databasegenerrate 
using System.Linq;
using System.Threading.Tasks;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models
{
    public class OgrenciSayilari
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//ID yi ben değil kendi kendine arttırsın
        public int ID { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Zorunlu alan")]
        public string OgrenimDuzeyi { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Zorunlu alan")]
        public string AkademikBirim { get; set; }

        [Required(ErrorMessage = "Zorunlu alan")]
        public int KadinSayisi { get; set; }

        [Required(ErrorMessage = "Zorunlu alan")]
        public int ErkekSayisi { get; set; }
        public int Toplam
        {
            get
            {
                return KadinSayisi + ErkekSayisi;
            }
        }
        //public int? Toplam { get; set; }


    }
}
