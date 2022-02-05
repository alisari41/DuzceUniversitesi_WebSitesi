using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;//ekledim key kullanmak için
using System.ComponentModel.DataAnnotations.Schema;//databasegenerrate 
using System.Linq;
using System.Threading.Tasks;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models
{
    public class Personel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//ID yi ben değil kendi kendine arttırsın
        public int ID { get; set; }

        public int? BolumID { get; set; }
        public Bolum Bolum { get; set; }//Bolum ile ilişki kurdum


        public int? PersonelKategoriID { get; set; }
        public PersonelKategori PersonelKategori { get; set; }//Personel kategori ile ilişki kurdum


        public int? FakulteID { get; set; }
        public Fakulte Fakulte{ get; set; }//Fakülte ile ilişki kurdum

        public int? EnstituID { get; set; }
        public Enstitu Enstitu { get; set; }//Enstitu ile ilişki kurdum



        [Required(ErrorMessage = "Zorunlu alan")]
        [StringLength(100)]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Zorunlu alan")]
        [StringLength(100)]
        public string Soyad { get; set; }

        [Required(ErrorMessage = "Zorunlu alan")]
        [StringLength(80)]
        public string Unvan { get; set; }

        [Required(ErrorMessage = "Zorunlu alan")]
        [StringLength(80)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Zorunlu alan")]
        [DataType(DataType.PhoneNumber)]
        [MaxLength(11, ErrorMessage = "Telefon numarası 11 haneli olmalıdır"), MinLength(11, ErrorMessage = "Telefon numarası 11 haneli olmalıdır")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Telefon numarası format dışı")]
        public string Telefon { get; set; }

        [Required(ErrorMessage = "Zorunlu alan")]
        [DataType(DataType.Text)]
        [MaxLength(11, ErrorMessage = "TC Kimlik numarası 11 haneli olmalıdır"), MinLength(11, ErrorMessage = "TC Kimlik numarası 11 haneli olmalıdır")]
        public string TCKimlikNumarasi { get; set; }

        public string PersonelLink { get; set; }


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
