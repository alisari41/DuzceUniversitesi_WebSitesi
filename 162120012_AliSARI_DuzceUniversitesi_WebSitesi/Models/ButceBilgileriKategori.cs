﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;//ekledim key kullanmak için
using System.ComponentModel.DataAnnotations.Schema;//databasegenerrate 
using System.Linq;
using System.Threading.Tasks;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models
{
    public class ButceBilgileriKategori
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//ID yi ben değil kendi kendine arttırsın
        public int ID { get; set; }

        [Required(ErrorMessage = "Zorunlu alan")]
        [StringLength(5)]
        public string YilKategori { get; set; }
    }
}
