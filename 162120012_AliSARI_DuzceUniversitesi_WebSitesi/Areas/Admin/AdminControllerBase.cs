using Microsoft.AspNetCore.Http;// Get String için kullandım
using Microsoft.AspNetCore.Mvc;//controller nesnesinden türetmek için kalıtım için using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Areas.Admin
{
    public class AdminControllerBase : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var IsLogin = false;
            if ((context.HttpContext.Session.GetString("AdminLoginKullaniciEmailSession") == null) && (context.HttpContext.Session.GetString("AdminLoginKullaniciSifreSession") == null))
            {
                //admin girişi yapılmamış
                context.HttpContext.Response.Redirect("Admin/AdminLogin/Index");
                //admin girişe sayfayı yönlendir.
                //redirect("....")bunu kullanamadık redirectte ezme işlemi yaptık override sayfa yönlendirir.
            }
            else
            {
                //sorun yok admin ieçerde
                //sayfayı çalıştır
                base.OnActionExecuting(context);

            }
        }
    }
}
