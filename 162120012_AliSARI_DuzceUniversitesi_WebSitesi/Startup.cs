using _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Session;//Sessin kullanmak i�in nuget paketinin k�t�phanesini ekledim
using System.Threading.Tasks;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            ////DbContext eklemek için kullandım
            //services.AddDbContext<AndDB>(options =>
            //options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));//UseSqlServer İçin Microsoft.EntityFrameworkCore.SqlServer NuGet Paketini kuruyorum
            ////DevConnection appsetting.json dakullandığım ad
          


            ////DbContext eklemek için kullandım
            var cs = Configuration.GetConnectionString("DevConnection");
            ////DevConnection appsetting.json dakullandığım ad
            services.AddDbContextFactory<AndDB>(option => option.UseSqlServer(cs));
            services.AddDbContext<AndDB>(option => option.UseSqlServer(cs));
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




            // asagidaki ikisini Session icin kullandim 
            services.AddDistributedMemoryCache();
            services.AddSession();

            //Blazor Admin için Oluşturduğum servisleri buraya eklemek zorundayım
            services.AddScoped<DuyuruService>();
            services.AddScoped<SayilarService>();
            services.AddScoped<FotografGalerisiService>();


            //Blazor Admin Servisi
            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddHealthChecks();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            //Sessim icin kullandim hafizida deger tutmak
            app.UseSession();


            //resim eklemesi için
            app.UseStaticFiles();



            //Blazor Admin için aktif hale getirme

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(// Area paneli icin olusturdum ilk seferde Default kismi acilsin
                     name: "Admin_Default",
                     pattern: "{area:exists}/{controller=Default}/{action=Index}"

                    );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");


                //Blazor Admin için aktif hale getirme
                endpoints.MapBlazorHub();

                // Parantez içinde hangi sayfada çalışcağını yazıyoruz blazoradmin diye klasör oluşturcam
                endpoints.MapFallbackToPage("/blazoradmin/{*catchall}", "/BlazorAdmin/Index"); 
            });
        }
    }
}
