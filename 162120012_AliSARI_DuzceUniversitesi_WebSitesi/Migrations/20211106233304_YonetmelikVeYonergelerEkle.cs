using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Migrations
{
    public partial class YonetmelikVeYonergelerEkle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "YonetmelikVeYonergelerKategoris",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kategori = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YonetmelikVeYonergelerKategoris", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "YonetmelikVeYonergelers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YonetmelikVeYonergelerKategoriID = table.Column<int>(type: "int", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YonetmelikVeYonergelers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_YonetmelikVeYonergelers_YonetmelikVeYonergelerKategoris_YonetmelikVeYonergelerKategoriID",
                        column: x => x.YonetmelikVeYonergelerKategoriID,
                        principalTable: "YonetmelikVeYonergelerKategoris",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_YonetmelikVeYonergelers_YonetmelikVeYonergelerKategoriID",
                table: "YonetmelikVeYonergelers",
                column: "YonetmelikVeYonergelerKategoriID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "YonetmelikVeYonergelers");

            migrationBuilder.DropTable(
                name: "YonetmelikVeYonergelerKategoris");
        }
    }
}
