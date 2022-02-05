using Microsoft.EntityFrameworkCore.Migrations;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Migrations
{
    public partial class YonetimTablosunaBolumIliskisiEkle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BolumID",
                table: "Yonetims",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Yonetims_BolumID",
                table: "Yonetims",
                column: "BolumID");

            migrationBuilder.AddForeignKey(
                name: "FK_Yonetims_Bolums_BolumID",
                table: "Yonetims",
                column: "BolumID",
                principalTable: "Bolums",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Yonetims_Bolums_BolumID",
                table: "Yonetims");

            migrationBuilder.DropIndex(
                name: "IX_Yonetims_BolumID",
                table: "Yonetims");

            migrationBuilder.DropColumn(
                name: "BolumID",
                table: "Yonetims");
        }
    }
}
