using Microsoft.EntityFrameworkCore.Migrations;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Migrations
{
    public partial class UpdatePersonelEnstitu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EnstituID",
                table: "Personels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personels_EnstituID",
                table: "Personels",
                column: "EnstituID");

            migrationBuilder.AddForeignKey(
                name: "FK_Personels_Enstitus_EnstituID",
                table: "Personels",
                column: "EnstituID",
                principalTable: "Enstitus",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personels_Enstitus_EnstituID",
                table: "Personels");

            migrationBuilder.DropIndex(
                name: "IX_Personels_EnstituID",
                table: "Personels");

            migrationBuilder.DropColumn(
                name: "EnstituID",
                table: "Personels");
        }
    }
}
