using Microsoft.EntityFrameworkCore.Migrations;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Migrations
{
    public partial class AddYonetimTablosunaEnstitu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EnstituID",
                table: "Yonetims",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Yonetims_EnstituID",
                table: "Yonetims",
                column: "EnstituID");

            migrationBuilder.AddForeignKey(
                name: "FK_Yonetims_Enstitus_EnstituID",
                table: "Yonetims",
                column: "EnstituID",
                principalTable: "Enstitus",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Yonetims_Enstitus_EnstituID",
                table: "Yonetims");

            migrationBuilder.DropIndex(
                name: "IX_Yonetims_EnstituID",
                table: "Yonetims");

            migrationBuilder.DropColumn(
                name: "EnstituID",
                table: "Yonetims");
        }
    }
}
