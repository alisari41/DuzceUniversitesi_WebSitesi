using Microsoft.EntityFrameworkCore.Migrations;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Migrations
{
    public partial class UpdatePersonelBolum2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personels_Bolums_BolumID",
                table: "Personels");

            migrationBuilder.AlterColumn<int>(
                name: "BolumID",
                table: "Personels",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Personels_Bolums_BolumID",
                table: "Personels",
                column: "BolumID",
                principalTable: "Bolums",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personels_Bolums_BolumID",
                table: "Personels");

            migrationBuilder.AlterColumn<int>(
                name: "BolumID",
                table: "Personels",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Personels_Bolums_BolumID",
                table: "Personels",
                column: "BolumID",
                principalTable: "Bolums",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
