using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models
{
    public class AndDB : DbContext
    {
        public AndDB(DbContextOptions<AndDB> options):base(options)
        {

        }
        public DbSet<Kullanici> Kullanicis { get; set; }//oluşturduğum sınıfı ana database ekledim
        public DbSet<YonetimKategori> YonetimKategoris { get; set; }//oluşturduğum sınıfı ana database ekledim
        public DbSet<Yonetim> Yonetims { get; set; }//oluşturduğum sınıfı ana database ekledim
        public DbSet<OgrenciSayilari> OgrenciSayilaris { get; set; }//oluşturduğum sınıfı ana database ekledim
        public DbSet<PersonelSayilariKategori> PersonelSayilariKategoris { get; set; }//oluşturduğum sınıfı ana database ekledim
        public DbSet<PersonelSayilari> PersonelSayilaris { get; set; }//oluşturduğum sınıfı ana database ekledim
        public DbSet<BolumveProgramSayilariKategori> BolumveProgramSayilariKategoris { get; set; }//oluşturduğum sınıfı ana database ekledim
        public DbSet<BolumveProgramSayilari> BolumveProgramSayilaris { get; set; }//oluşturduğum sınıfı ana database ekledim
        public DbSet<Fakulte> Fakultes { get; set; }//oluşturduğum sınıfı ana database ekledim
        public DbSet<Bolum> Bolums { get; set; }//oluşturduğum sınıfı ana database ekledim
        public DbSet<Personel> Personels { get; set; }//oluşturduğum sınıfı ana database ekledim
        //public DbSet<DuyuruKategori> DuyuruKategoris { get; set; }//oluşturduğum sınıfı ana database ekledim
        public DbSet<Duyurular> Duyurulars { get; set; }//oluşturduğum sınıfı ana database ekledim
        public DbSet<Dukkan> Dukkans { get; set; }//oluşturduğum sınıfı ana database ekledim
        public DbSet<UniversiteIzlemeveDgrRaporKategori> UniversiteIzlemeveDgrRaporKategoris{ get; set; }//oluşturduğum sınıfı ana database ekledim
        public DbSet<UniversiteIzlemeveDgrRapor> UniversiteIzlemeveDgrRapors{ get; set; }//oluşturduğum sınıfı ana database ekledim
        public DbSet<ButceBilgileriKategori> ButceBilgileriKategoris{ get; set; }//oluşturduğum sınıfı ana database ekledim
        public DbSet<ButceBilgileri> ButceBilgileris{ get; set; }//oluşturduğum sınıfı ana database ekledim
        public DbSet<StratejikPlanRaporlariKategori> StratejikPlanRaporlariKategoris{ get; set; }//oluşturduğum sınıfı ana database ekledim
        public DbSet<StratejikPlanRaporlari> StratejikPlanRaporlaris{ get; set; }//oluşturduğum sınıfı ana database ekledim
        public DbSet<KurumIcDegerlendirmeRaporlari> KurumIcDegerlendirmeRaporlaris{ get; set; }//oluşturduğum sınıfı ana database ekledim
        public DbSet<Isbirlikleri> Isbirlikleris{ get; set; }//oluşturduğum sınıfı ana database ekledim
        public DbSet<YonetmelikVeYonergelerKategori> YonetmelikVeYonergelerKategoris{ get; set; }//oluşturduğum sınıfı ana database ekledim
        public DbSet<YonetmelikVeYonergeler> YonetmelikVeYonergelers{ get; set; }//oluşturduğum sınıfı ana database ekledim
        public DbSet<GenelBilgiler> GenelBilgilers{ get; set; }//oluşturduğum sınıfı ana database ekledim
        public DbSet<PersonelKategori> PersonelKategoris{ get; set; }//oluşturduğum sınıfı ana database ekledim
        public DbSet<BolumGenelBilgileri> BolumGenelBilgileris{ get; set; }//oluşturduğum sınıfı ana database ekledim
        public DbSet<DersProgramlariKategori> DersProgramlariKategoris{ get; set; }//oluşturduğum sınıfı ana database ekledim
        public DbSet<DersProgramlari> DersProgramlaris{ get; set; }//oluşturduğum sınıfı ana database ekledim
        public DbSet<OgrenciDanismanligi> OgrenciDanismanligis{ get; set; }//oluşturduğum sınıfı ana database ekledim
        public DbSet<OrganizasyonSemasi> OrganizasyonSemasis{ get; set; }//oluşturduğum sınıfı ana database ekledim
        public DbSet<GorevTanimlari> GorevTanimlaris{ get; set; }//oluşturduğum sınıfı ana database ekledim
        public DbSet<FaliyetRaporu> FaliyetRaporus{ get; set; }//oluşturduğum sınıfı ana database ekledim
        public DbSet<IcDegerlendirmeRaporu> IcDegerlendirmeRaporus{ get; set; }//oluşturduğum sınıfı ana database ekledim
        public DbSet<KurullarVeKomisyonlar> KurullarVeKomisyonlars{ get; set; }//oluşturduğum sınıfı ana database ekledim
        public DbSet<HizmetStandartlariveEnvanteri> HizmetStandartlariveEnvanteris{ get; set; }//oluşturduğum sınıfı ana database ekledim
        public DbSet<IsAkisSemalari> ısAkisSemalaris{ get; set; }//oluşturduğum sınıfı ana database ekledim
        public DbSet<AkademikCalismalar> AkademikCalismalars{ get; set; }//oluşturduğum sınıfı ana database ekledim
        public DbSet<Enstitu> Enstitus{ get; set; }//oluşturduğum sınıfı ana database ekledim
        public DbSet<FormlarOgr> FormlarOgrs{ get; set; }//oluşturduğum sınıfı ana database ekledim
        public DbSet<Mevzuat> Mevzuats{ get; set; }//oluşturduğum sınıfı ana database ekledim
        public DbSet<Sayilar> Sayilars{ get; set; }//oluşturduğum sınıfı ana database ekledim
        public DbSet<FotografGalerisi> FotografGalerisis{ get; set; }//oluşturduğum sınıfı ana database ekledim

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {//data base oluştururken hata vermesini engeller DECİMAL HATASINI ENGELLER
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Dukkan>()
                .Property(p => p.Fiyat)
                .HasColumnType("decimal(18,4)");
        }
    }
}
