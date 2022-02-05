using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models
{
    public class IsAkisSemalari
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//ID yi ben değil kendi kendine arttırsın
        public int ID { get; set; }



        public int? FakulteID { get; set; }
        public Fakulte Fakulte { get; set; }//Fakülte ile ilişki kurdum


        public int? EnstituID { get; set; }
        public Enstitu Enstitu { get; set; }//Enstitu ile ilişki kurdum

        public string? Departman { get; set; }


        public string? Aciklama { get; set; }



        public string? Link { get; set; }
    }
}
