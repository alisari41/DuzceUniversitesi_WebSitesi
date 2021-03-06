using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models
{
    public class HizmetStandartlariveEnvanteri
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//ID yi ben değil kendi kendine arttırsın
        public int ID { get; set; }

        [Required(ErrorMessage = "Zorunlu alan")]
        public int FakulteID { get; set; }
        public Fakulte Fakulte { get; set; }//Fakülte ile ilişki kurdum

        [Required(ErrorMessage = "Zorunlu alan")]
        public string Aciklama { get; set; }


        [Required(ErrorMessage = "Zorunlu alan")]
        public string Link { get; set; }
    }
}
