using Microsoft.EntityFrameworkCore.Migrations;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Migrations
{
    public partial class BolumVeDalBaskanliklariIcınYonetimeKolonEkle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BolumDali",
                table: "Yonetims",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BolumGorevi",
                table: "Yonetims",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BolumDali",
                table: "Yonetims");

            migrationBuilder.DropColumn(
                name: "BolumGorevi",
                table: "Yonetims");
        }
    }
}
