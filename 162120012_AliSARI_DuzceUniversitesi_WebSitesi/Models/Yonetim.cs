using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;//ekledim key kullanmak için
using System.ComponentModel.DataAnnotations.Schema;//databasegenerrate 
using System.Linq;
using System.Threading.Tasks;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models
{
    public class Yonetim
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//ID yi ben değil kendi kendine arttırsın
        public int ID { get; set; }

        [Required(ErrorMessage = "Zorunlu alan")]
        public int YonetimKategoriID { get; set; }
        public YonetimKategori YonetimKategori { get; set; }//YonetimKategori ile ilişki kurdum
        
        public int? FakulteID { get; set; }
        public Fakulte Fakulte { get; set; }//Fakulte ile ilişki kurdum

        public int? BolumID { get; set; }
        public Bolum Bolum { get; set; }//Bolum ile ilişki kurdum

        public int? EnstituID { get; set; }
        public Enstitu Enstitu{ get; set; }//Enstitu ile ilişki kurdum

        [StringLength(75)]
        [Required(ErrorMessage = "Zorunlu alan")]
        public string Ad { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Zorunlu alan")]
        public string Soyad { get; set; }

        [StringLength(80)]
        [Required(ErrorMessage = "Zorunlu alan")]
        public string Unvan { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Zorunlu alan")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Zorunlu alan")]
        [DataType(DataType.PhoneNumber)]
        [MaxLength(11, ErrorMessage = "Telefon numarası 11 haneli olmalıdır"), MinLength(11, ErrorMessage = "Telefon numarası 11 haneli olmalıdır")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Telefon numarası format dışı")]
        public string Telefon { get; set; }


        public string? BolumDali { get; set; }
        public string? BolumGorevi { get; set; }
        public string FotografUrl { get; set; }
        public string? Aciklama1 { get; set; }//? açıklama koymak zorunda değil. Boş Geçilebilir
        public string? Aciklama2 { get; set; }//? açıklama koymak zorunda değil. Boş Geçilebilir
        public string? Aciklama3 { get; set; }//? açıklama koymak zorunda değil. Boş Geçilebilir
        public string? Aciklama4 { get; set; }//? açıklama koymak zorunda değil. Boş Geçilebilir
        public string? Aciklama5 { get; set; }//? açıklama koymak zorunda değil. Boş Geçilebilir
        public string? Yayinlar1 { get; set; }//? Yayın koymak zorunda değil. Boş Geçilebilir
        public string? Yayinlar2 { get; set; }//? Yayın koymak zorunda değil. Boş Geçilebilir
        public string? Yayinlar3 { get; set; }//? Yayın koymak zorunda değil. Boş Geçilebilir
        public string? Yayinlar4 { get; set; }//? Yayın koymak zorunda değil. Boş Geçilebilir
        public string? Yayinlar5 { get; set; }//? Yayın koymak zorunda değil. Boş Geçilebilir
        public string? Yayinlar6 { get; set; }//? Yayın koymak zorunda değil. Boş Geçilebilir
        public string? Yayinlar7 { get; set; }//? Yayın koymak zorunda değil. Boş Geçilebilir
        public string? Yayinlar8 { get; set; }//? Yayın koymak zorunda değil. Boş Geçilebilir
        public string? Yayinlar9 { get; set; }//? Yayın koymak zorunda değil. Boş Geçilebilir
        public string? Yayinlar10 { get; set; }//? Yayın koymak zorunda değil. Boş Geçilebilir
        public string? Yayinlar11 { get; set; }//? Yayın koymak zorunda değil. Boş Geçilebilir
        public string? Yayinlar12 { get; set; }//? Yayın koymak zorunda değil. Boş Geçilebilir
    }
}
