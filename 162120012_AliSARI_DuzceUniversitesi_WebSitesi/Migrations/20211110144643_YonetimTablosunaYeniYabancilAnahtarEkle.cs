using Microsoft.EntityFrameworkCore.Migrations;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Migrations
{
    public partial class YonetimTablosunaYeniYabancilAnahtarEkle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FakulteID",
                table: "Yonetims",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Yonetims_FakulteID",
                table: "Yonetims",
                column: "FakulteID");

            migrationBuilder.AddForeignKey(
                name: "FK_Yonetims_Fakultes_FakulteID",
                table: "Yonetims",
                column: "FakulteID",
                principalTable: "Fakultes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Yonetims_Fakultes_FakulteID",
                table: "Yonetims");

            migrationBuilder.DropIndex(
                name: "IX_Yonetims_FakulteID",
                table: "Yonetims");

            migrationBuilder.DropColumn(
                name: "FakulteID",
                table: "Yonetims");
        }
    }
}
