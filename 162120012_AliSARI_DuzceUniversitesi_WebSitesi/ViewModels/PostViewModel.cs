using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;//ekledim key kullanmak için
using System.ComponentModel.DataAnnotations.Schema;//databasegenerrate 
using System.Linq;
using System.Threading.Tasks;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.ViewModels
{
    public class PostViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//ID yi ben değil kendi kendine arttırsın
        public int ID { get; set; }

        public string? FotografAdı { get; set; }
        public IFormFile Image { get; set; } = null;
    }
}
