using Microsoft.EntityFrameworkCore.Migrations;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Migrations
{
    public partial class PersonelTablosunaKolonEkle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FakulteID",
                table: "Personels",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonelKategoriID",
                table: "Personels",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PersonelLink",
                table: "Personels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personels_FakulteID",
                table: "Personels",
                column: "FakulteID");

            migrationBuilder.CreateIndex(
                name: "IX_Personels_PersonelKategoriID",
                table: "Personels",
                column: "PersonelKategoriID");

            migrationBuilder.AddForeignKey(
                name: "FK_Personels_Fakultes_FakulteID",
                table: "Personels",
                column: "FakulteID",
                principalTable: "Fakultes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Personels_PersonelKategoris_PersonelKategoriID",
                table: "Personels",
                column: "PersonelKategoriID",
                principalTable: "PersonelKategoris",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personels_Fakultes_FakulteID",
                table: "Personels");

            migrationBuilder.DropForeignKey(
                name: "FK_Personels_PersonelKategoris_PersonelKategoriID",
                table: "Personels");

            migrationBuilder.DropIndex(
                name: "IX_Personels_FakulteID",
                table: "Personels");

            migrationBuilder.DropIndex(
                name: "IX_Personels_PersonelKategoriID",
                table: "Personels");

            migrationBuilder.DropColumn(
                name: "FakulteID",
                table: "Personels");

            migrationBuilder.DropColumn(
                name: "PersonelKategoriID",
                table: "Personels");

            migrationBuilder.DropColumn(
                name: "PersonelLink",
                table: "Personels");
        }
    }
}
