using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BolumveProgramSayilariKategoris",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kategori = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BolumveProgramSayilariKategoris", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Dukkans",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResimUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Baslık = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false),
                    Renkler = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fiyat = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dukkans", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DuyuruKategoris",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kategori = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuyuruKategoris", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Fakultes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FakulteAdi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fakultes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Kullanicis",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TCKimlikNumarasi = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicis", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OgrenciSayilaris",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OgrenimDuzeyi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AkademikBirim = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    KadinSayisi = table.Column<int>(type: "int", nullable: false),
                    ErkekSayisi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OgrenciSayilaris", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PersonelSayilariKategoris",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kategori = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonelSayilariKategoris", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "YonetimKategoris",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gorevi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YonetimKategoris", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BolumveProgramSayilaris",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BolumveProgramSayilariKategoriID = table.Column<int>(type: "int", nullable: false),
                    Fakulte = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OgrenimTuru = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sayisi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BolumveProgramSayilaris", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BolumveProgramSayilaris_BolumveProgramSayilariKategoris_BolumveProgramSayilariKategoriID",
                        column: x => x.BolumveProgramSayilariKategoriID,
                        principalTable: "BolumveProgramSayilariKategoris",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Duyurulars",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DuyuruKategoriID = table.Column<int>(type: "int", nullable: false),
                    Baslik = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Icerik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false),
                    Aciklama1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResimUrl1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResimUrl2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResimUrl3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResimUrl4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResimUrl5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResimUrl6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResimUrl7 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResimUrl8 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Duyurulars", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Duyurulars_DuyuruKategoris_DuyuruKategoriID",
                        column: x => x.DuyuruKategoriID,
                        principalTable: "DuyuruKategoris",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bolums",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FakulteID = table.Column<int>(type: "int", nullable: false),
                    BolumAdi = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bolums", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Bolums_Fakultes_FakulteID",
                        column: x => x.FakulteID,
                        principalTable: "Fakultes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonelSayilaris",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonelSayilariKategoriID = table.Column<int>(type: "int", nullable: false),
                    Unvan = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    HizmetYeri = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Sayi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonelSayilaris", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PersonelSayilaris_PersonelSayilariKategoris_PersonelSayilariKategoriID",
                        column: x => x.PersonelSayilariKategoriID,
                        principalTable: "PersonelSayilariKategoris",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Yonetims",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YonetimKategoriID = table.Column<int>(type: "int", nullable: false),
                    Ad = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Unvan = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    FotografUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Yayinlar1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Yayinlar2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Yayinlar3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Yayinlar4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Yayinlar5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Yayinlar6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Yayinlar7 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Yayinlar8 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Yayinlar9 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Yayinlar10 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Yayinlar11 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Yayinlar12 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yonetims", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Yonetims_YonetimKategoris_YonetimKategoriID",
                        column: x => x.YonetimKategoriID,
                        principalTable: "YonetimKategoris",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Personels",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BolumID = table.Column<int>(type: "int", nullable: false),
                    Ad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Unvan = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    TCKimlikNumarasi = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    FotografUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Yayinlar1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Yayinlar2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Yayinlar3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Yayinlar4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Yayinlar5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Yayinlar6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Yayinlar7 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Yayinlar8 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Yayinlar9 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Yayinlar10 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Yayinlar11 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Yayinlar12 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personels", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Personels_Bolums_BolumID",
                        column: x => x.BolumID,
                        principalTable: "Bolums",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bolums_FakulteID",
                table: "Bolums",
                column: "FakulteID");

            migrationBuilder.CreateIndex(
                name: "IX_BolumveProgramSayilaris_BolumveProgramSayilariKategoriID",
                table: "BolumveProgramSayilaris",
                column: "BolumveProgramSayilariKategoriID");

            migrationBuilder.CreateIndex(
                name: "IX_Duyurulars_DuyuruKategoriID",
                table: "Duyurulars",
                column: "DuyuruKategoriID");

            migrationBuilder.CreateIndex(
                name: "IX_Personels_BolumID",
                table: "Personels",
                column: "BolumID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonelSayilaris_PersonelSayilariKategoriID",
                table: "PersonelSayilaris",
                column: "PersonelSayilariKategoriID");

            migrationBuilder.CreateIndex(
                name: "IX_Yonetims_YonetimKategoriID",
                table: "Yonetims",
                column: "YonetimKategoriID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BolumveProgramSayilaris");

            migrationBuilder.DropTable(
                name: "Dukkans");

            migrationBuilder.DropTable(
                name: "Duyurulars");

            migrationBuilder.DropTable(
                name: "Kullanicis");

            migrationBuilder.DropTable(
                name: "OgrenciSayilaris");

            migrationBuilder.DropTable(
                name: "Personels");

            migrationBuilder.DropTable(
                name: "PersonelSayilaris");

            migrationBuilder.DropTable(
                name: "Yonetims");

            migrationBuilder.DropTable(
                name: "BolumveProgramSayilariKategoris");

            migrationBuilder.DropTable(
                name: "DuyuruKategoris");

            migrationBuilder.DropTable(
                name: "Bolums");

            migrationBuilder.DropTable(
                name: "PersonelSayilariKategoris");

            migrationBuilder.DropTable(
                name: "YonetimKategoris");

            migrationBuilder.DropTable(
                name: "Fakultes");
        }
    }
}
