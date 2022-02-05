using Microsoft.EntityFrameworkCore.Migrations;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Migrations
{
    public partial class UpdateGenelbilgiler3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenelBilgilers_Enstitus_EnstituID",
                table: "GenelBilgilers");

            migrationBuilder.DropForeignKey(
                name: "FK_GenelBilgilers_Fakultes_FakulteID",
                table: "GenelBilgilers");

            migrationBuilder.AlterColumn<int>(
                name: "FakulteID",
                table: "GenelBilgilers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EnstituID",
                table: "GenelBilgilers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_GenelBilgilers_Enstitus_EnstituID",
                table: "GenelBilgilers",
                column: "EnstituID",
                principalTable: "Enstitus",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GenelBilgilers_Fakultes_FakulteID",
                table: "GenelBilgilers",
                column: "FakulteID",
                principalTable: "Fakultes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenelBilgilers_Enstitus_EnstituID",
                table: "GenelBilgilers");

            migrationBuilder.DropForeignKey(
                name: "FK_GenelBilgilers_Fakultes_FakulteID",
                table: "GenelBilgilers");

            migrationBuilder.AlterColumn<int>(
                name: "FakulteID",
                table: "GenelBilgilers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EnstituID",
                table: "GenelBilgilers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GenelBilgilers_Enstitus_EnstituID",
                table: "GenelBilgilers",
                column: "EnstituID",
                principalTable: "Enstitus",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GenelBilgilers_Fakultes_FakulteID",
                table: "GenelBilgilers",
                column: "FakulteID",
                principalTable: "Fakultes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
