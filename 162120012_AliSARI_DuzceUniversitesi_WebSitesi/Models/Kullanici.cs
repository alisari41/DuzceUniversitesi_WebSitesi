using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;//ekledim key kullanmak için
using System.ComponentModel.DataAnnotations.Schema;//databasegenerrate 
using System.Linq;
using System.Threading.Tasks;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models
{
    public class Kullanici
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//ID yi ben değil kendi kendine arttırsın
        public int ID { get; set; }

        [Required(ErrorMessage = "Zorunlu alan")]
        [StringLength(50)]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Zorunlu alan")]
        [StringLength(75)]
        public string Soyad { get; set; }

        [Required(ErrorMessage = "Zorunlu alan")]
        [StringLength(100)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Zorunlu alan")]
        [DataType(DataType.PhoneNumber)]
        [MaxLength(11, ErrorMessage = "Telefon numarası 11 haneli olmalıdır"), MinLength(11, ErrorMessage = "Telefon numarası 11 haneli olmalıdır")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Telefon numarası format dışı")]
        public string Telefon { get; set; }

        [Required(ErrorMessage = "Zorunlu alan")]
        [StringLength(50)]
        public string Sifre { get; set; }

        [Required(ErrorMessage = "Zorunlu alan")]
        [DataType(DataType.Text)]
        [MaxLength(11, ErrorMessage = "TC Kimlik numarası 11 haneli olmalıdır"), MinLength(11, ErrorMessage = "TC Kimlik numarası 11 haneli olmalıdır")]
        public string TCKimlikNumarasi { get; set; }


    }
}
