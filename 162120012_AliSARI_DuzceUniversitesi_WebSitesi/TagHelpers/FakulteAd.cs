using _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.TagHelpers
{
    [HtmlTargetElement("getirFakulteAd")]//tag helpersı kullanacağım etiket adını belirliyorum
    public class FakulteAd : TagHelper
    {
        private readonly AndDB _context;
        public FakulteAd(AndDB context)
        {
            _context = context;
        }
        public int FakulteId { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string data = "";
            //var gelenFakulteler = _context.Personels(FakulteId).Select(y => y.Ad);
            base.Process(context, output);
        }

    }
}
