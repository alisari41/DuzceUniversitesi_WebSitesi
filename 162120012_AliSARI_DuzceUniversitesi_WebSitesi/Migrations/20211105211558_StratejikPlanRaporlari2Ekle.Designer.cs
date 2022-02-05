﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Migrations
{
    [DbContext(typeof(AndDB))]
    [Migration("20211105211558_StratejikPlanRaporlari2Ekle")]
    partial class StratejikPlanRaporlari2Ekle
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("_162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models.Bolum", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BolumAdi")
                        .IsRequired()
                        .HasMaxLength(90)
                        .HasColumnType("nvarchar(90)");

                    b.Property<int>("FakulteID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("FakulteID");

                    b.ToTable("Bolums");
                });

            modelBuilder.Entity("_162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models.BolumveProgramSayilari", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BolumveProgramSayilariKategoriID")
                        .HasColumnType("int");

                    b.Property<string>("Fakulte")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("OgrenimTuru")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Sayisi")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("BolumveProgramSayilariKategoriID");

                    b.ToTable("BolumveProgramSayilaris");
                });

            modelBuilder.Entity("_162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models.BolumveProgramSayilariKategori", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Kategori")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.ToTable("BolumveProgramSayilariKategoris");
                });

            modelBuilder.Entity("_162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models.ButceBilgileri", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Aciklama")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ButceBilgileriKategoriID")
                        .HasColumnType("int");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("ButceBilgileriKategoriID");

                    b.ToTable("ButceBilgileris");
                });

            modelBuilder.Entity("_162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models.ButceBilgileriKategori", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("YilKategori")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("ID");

                    b.ToTable("ButceBilgileriKategoris");
                });

            modelBuilder.Entity("_162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models.Dukkan", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Baslık")
                        .IsRequired()
                        .HasMaxLength(90)
                        .HasColumnType("nvarchar(90)");

                    b.Property<decimal>("Fiyat")
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("Renkler")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResimUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Dukkans");
                });

            modelBuilder.Entity("_162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models.DuyuruKategori", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Kategori")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("ID");

                    b.ToTable("DuyuruKategoris");
                });

            modelBuilder.Entity("_162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models.Duyurular", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Aciklama1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Aciklama2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Aciklama3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Aciklama4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Aciklama5")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Aciklama6")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("AktifMi")
                        .HasColumnType("bit");

                    b.Property<string>("Baslik")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("DuyuruKategoriID")
                        .HasColumnType("int");

                    b.Property<string>("Icerik")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResimUrl1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResimUrl2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResimUrl3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResimUrl4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResimUrl5")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResimUrl6")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResimUrl7")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResimUrl8")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("DuyuruKategoriID");

                    b.ToTable("Duyurulars");
                });

            modelBuilder.Entity("_162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models.Fakulte", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FakulteAdi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.ToTable("Fakultes");
                });

            modelBuilder.Entity("_162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models.Kullanici", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Soyad")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<string>("TCKimlikNumarasi")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("ID");

                    b.ToTable("Kullanicis");
                });

            modelBuilder.Entity("_162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models.OgrenciSayilari", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AkademikBirim")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ErkekSayisi")
                        .HasColumnType("int");

                    b.Property<int>("KadinSayisi")
                        .HasColumnType("int");

                    b.Property<string>("OgrenimDuzeyi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.ToTable("OgrenciSayilaris");
                });

            modelBuilder.Entity("_162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models.Personel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Aciklama1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Aciklama2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Aciklama3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Aciklama4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Aciklama5")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("BolumID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("FotografUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Soyad")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TCKimlikNumarasi")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Unvan")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Yayinlar1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Yayinlar10")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Yayinlar11")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Yayinlar12")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Yayinlar2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Yayinlar3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Yayinlar4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Yayinlar5")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Yayinlar6")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Yayinlar7")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Yayinlar8")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Yayinlar9")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("BolumID");

                    b.ToTable("Personels");
                });

            modelBuilder.Entity("_162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models.PersonelSayilari", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("HizmetYeri")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<int>("PersonelSayilariKategoriID")
                        .HasColumnType("int");

                    b.Property<int>("Sayi")
                        .HasColumnType("int");

                    b.Property<string>("Unvan")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("ID");

                    b.HasIndex("PersonelSayilariKategoriID");

                    b.ToTable("PersonelSayilaris");
                });

            modelBuilder.Entity("_162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models.PersonelSayilariKategori", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Kategori")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("ID");

                    b.ToTable("PersonelSayilariKategoris");
                });

            modelBuilder.Entity("_162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models.StratejikPlanRaporlari", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Aciklama")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StratejikPlanRaporlariKategoriID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("StratejikPlanRaporlariKategoriID");

                    b.ToTable("StratejikPlanRaporlaris");
                });

            modelBuilder.Entity("_162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models.StratejikPlanRaporlariKategori", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Kategori")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("ID");

                    b.ToTable("StratejikPlanRaporlariKategoris");
                });

            modelBuilder.Entity("_162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models.UniversiteIzlemeveDgrRapor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Kriterler")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Say_Oran")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("UniversiteIzlemeveDgrRaporKategoriID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UniversiteIzlemeveDgrRaporKategoriID");

                    b.ToTable("UniversiteIzlemeveDgrRapors");
                });

            modelBuilder.Entity("_162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models.UniversiteIzlemeveDgrRaporKategori", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Kategori")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.ToTable("UniversiteIzlemeveDgrRaporKategoris");
                });

            modelBuilder.Entity("_162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models.Yonetim", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Aciklama1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Aciklama2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Aciklama3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Aciklama4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Aciklama5")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FotografUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Soyad")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Unvan")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Yayinlar1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Yayinlar10")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Yayinlar11")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Yayinlar12")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Yayinlar2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Yayinlar3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Yayinlar4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Yayinlar5")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Yayinlar6")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Yayinlar7")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Yayinlar8")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Yayinlar9")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YonetimKategoriID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("YonetimKategoriID");

                    b.ToTable("Yonetims");
                });

            modelBuilder.Entity("_162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models.YonetimKategori", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Gorevi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.ToTable("YonetimKategoris");
                });

            modelBuilder.Entity("_162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models.Bolum", b =>
                {
                    b.HasOne("_162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models.Fakulte", "Fakulte")
                        .WithMany()
                        .HasForeignKey("FakulteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fakulte");
                });

            modelBuilder.Entity("_162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models.BolumveProgramSayilari", b =>
                {
                    b.HasOne("_162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models.BolumveProgramSayilariKategori", "BolumveProgramSayilariKategori")
                        .WithMany()
                        .HasForeignKey("BolumveProgramSayilariKategoriID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BolumveProgramSayilariKategori");
                });

            modelBuilder.Entity("_162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models.ButceBilgileri", b =>
                {
                    b.HasOne("_162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models.ButceBilgileriKategori", "ButceBilgileriKategori")
                        .WithMany()
                        .HasForeignKey("ButceBilgileriKategoriID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ButceBilgileriKategori");
                });

            modelBuilder.Entity("_162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models.Duyurular", b =>
                {
                    b.HasOne("_162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models.DuyuruKategori", "DuyuruKategori")
                        .WithMany()
                        .HasForeignKey("DuyuruKategoriID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DuyuruKategori");
                });

            modelBuilder.Entity("_162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models.Personel", b =>
                {
                    b.HasOne("_162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models.Bolum", "Bolum")
                        .WithMany()
                        .HasForeignKey("BolumID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bolum");
                });

            modelBuilder.Entity("_162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models.PersonelSayilari", b =>
                {
                    b.HasOne("_162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models.PersonelSayilariKategori", "PersonelSayilariKategori")
                        .WithMany()
                        .HasForeignKey("PersonelSayilariKategoriID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonelSayilariKategori");
                });

            modelBuilder.Entity("_162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models.StratejikPlanRaporlari", b =>
                {
                    b.HasOne("_162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models.StratejikPlanRaporlariKategori", "StratejikPlanRaporlariKategori")
                        .WithMany()
                        .HasForeignKey("StratejikPlanRaporlariKategoriID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StratejikPlanRaporlariKategori");
                });

            modelBuilder.Entity("_162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models.UniversiteIzlemeveDgrRapor", b =>
                {
                    b.HasOne("_162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models.UniversiteIzlemeveDgrRaporKategori", "UniversiteIzlemeveDgrRaporKategori")
                        .WithMany()
                        .HasForeignKey("UniversiteIzlemeveDgrRaporKategoriID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UniversiteIzlemeveDgrRaporKategori");
                });

            modelBuilder.Entity("_162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models.Yonetim", b =>
                {
                    b.HasOne("_162120012_AliSARI_DuzceUniversitesi_WebSitesi.Models.YonetimKategori", "YonetimKategori")
                        .WithMany()
                        .HasForeignKey("YonetimKategoriID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("YonetimKategori");
                });
#pragma warning restore 612, 618
        }
    }
}
