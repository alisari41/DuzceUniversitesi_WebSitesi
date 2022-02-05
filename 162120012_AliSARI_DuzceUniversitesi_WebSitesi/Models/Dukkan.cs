using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;//ekledim key kullanmak için
using System.ComponentModel.DataAnnotations.Schema;//databasegenerrate 
using System.Linq;
using System.Threading.Tasks;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models
{
    public class Dukkan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//ID yi ben değil kendi kendine arttırsın
        public int ID { get; set; }


        [Required(ErrorMessage = "Zorunlu alan")]
        public string ResimUrl { get; set; }

        [Required(ErrorMessage = "Zorunlu alan")]
        [StringLength(90)]
        public string Baslık { get; set; }

        [Required(ErrorMessage = "Zorunlu alan")]
        public string Renkler { get; set; }

        [Column(TypeName = "decimal(18,4)")]//18,4 olmak zorunda tanımlamasını yaptıktan sonra AndDB de metot oluşturdum sql hata vermesin diye
        public decimal Fiyat { get; set; }

    }
}
