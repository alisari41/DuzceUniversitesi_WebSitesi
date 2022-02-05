using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.TagHelpers
{
    public class EmailTagHelper : TagHelper
    {
        public string Mail { get; set; }
        public string Display { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";//çıktı olarak ne vereceğini belirliyorum
            output.Attributes.Add("href",$"mailto:{Mail}");//nitelik ekledim
            output.Content.Append(Display);//görünüşte içinde gözükecek kısım değerini verdim
        }
    }
}
