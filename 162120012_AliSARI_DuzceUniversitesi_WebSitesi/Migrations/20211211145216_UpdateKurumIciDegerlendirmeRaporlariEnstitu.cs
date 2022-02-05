using Microsoft.EntityFrameworkCore.Migrations;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Migrations
{
    public partial class UpdateKurumIciDegerlendirmeRaporlariEnstitu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EnstituID",
                table: "KurumIcDegerlendirmeRaporlaris",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_KurumIcDegerlendirmeRaporlaris_EnstituID",
                table: "KurumIcDegerlendirmeRaporlaris",
                column: "EnstituID");

            migrationBuilder.AddForeignKey(
                name: "FK_KurumIcDegerlendirmeRaporlaris_Enstitus_EnstituID",
                table: "KurumIcDegerlendirmeRaporlaris",
                column: "EnstituID",
                principalTable: "Enstitus",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KurumIcDegerlendirmeRaporlaris_Enstitus_EnstituID",
                table: "KurumIcDegerlendirmeRaporlaris");

            migrationBuilder.DropIndex(
                name: "IX_KurumIcDegerlendirmeRaporlaris_EnstituID",
                table: "KurumIcDegerlendirmeRaporlaris");

            migrationBuilder.DropColumn(
                name: "EnstituID",
                table: "KurumIcDegerlendirmeRaporlaris");
        }
    }
}
