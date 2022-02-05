using Microsoft.EntityFrameworkCore.Migrations;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Migrations
{
    public partial class DeleteOgrenciDanismanDeger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aciklama1",
                table: "OgrenciDanismanligis");

            migrationBuilder.DropColumn(
                name: "Aciklama2",
                table: "OgrenciDanismanligis");

            migrationBuilder.DropColumn(
                name: "Aciklama3",
                table: "OgrenciDanismanligis");

            migrationBuilder.DropColumn(
                name: "Link1",
                table: "OgrenciDanismanligis");

            migrationBuilder.DropColumn(
                name: "Link2",
                table: "OgrenciDanismanligis");

            migrationBuilder.DropColumn(
                name: "Link3",
                table: "OgrenciDanismanligis");

            migrationBuilder.DropColumn(
                name: "LinkAciklama1",
                table: "OgrenciDanismanligis");

            migrationBuilder.DropColumn(
                name: "LinkAciklama2",
                table: "OgrenciDanismanligis");

            migrationBuilder.DropColumn(
                name: "LinkAciklama3",
                table: "OgrenciDanismanligis");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Aciklama1",
                table: "OgrenciDanismanligis",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Aciklama2",
                table: "OgrenciDanismanligis",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Aciklama3",
                table: "OgrenciDanismanligis",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Link1",
                table: "OgrenciDanismanligis",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Link2",
                table: "OgrenciDanismanligis",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Link3",
                table: "OgrenciDanismanligis",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LinkAciklama1",
                table: "OgrenciDanismanligis",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LinkAciklama2",
                table: "OgrenciDanismanligis",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LinkAciklama3",
                table: "OgrenciDanismanligis",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
