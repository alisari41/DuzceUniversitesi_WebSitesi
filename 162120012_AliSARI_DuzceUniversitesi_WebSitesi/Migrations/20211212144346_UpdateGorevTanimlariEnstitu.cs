using Microsoft.EntityFrameworkCore.Migrations;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Migrations
{
    public partial class UpdateGorevTanimlariEnstitu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GorevTanimlaris_Fakultes_FakulteID",
                table: "GorevTanimlaris");

            migrationBuilder.AlterColumn<int>(
                name: "FakulteID",
                table: "GorevTanimlaris",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "EnstituID",
                table: "GorevTanimlaris",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GorevTanimlaris_EnstituID",
                table: "GorevTanimlaris",
                column: "EnstituID");

            migrationBuilder.AddForeignKey(
                name: "FK_GorevTanimlaris_Enstitus_EnstituID",
                table: "GorevTanimlaris",
                column: "EnstituID",
                principalTable: "Enstitus",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GorevTanimlaris_Fakultes_FakulteID",
                table: "GorevTanimlaris",
                column: "FakulteID",
                principalTable: "Fakultes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GorevTanimlaris_Enstitus_EnstituID",
                table: "GorevTanimlaris");

            migrationBuilder.DropForeignKey(
                name: "FK_GorevTanimlaris_Fakultes_FakulteID",
                table: "GorevTanimlaris");

            migrationBuilder.DropIndex(
                name: "IX_GorevTanimlaris_EnstituID",
                table: "GorevTanimlaris");

            migrationBuilder.DropColumn(
                name: "EnstituID",
                table: "GorevTanimlaris");

            migrationBuilder.AlterColumn<int>(
                name: "FakulteID",
                table: "GorevTanimlaris",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GorevTanimlaris_Fakultes_FakulteID",
                table: "GorevTanimlaris",
                column: "FakulteID",
                principalTable: "Fakultes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
