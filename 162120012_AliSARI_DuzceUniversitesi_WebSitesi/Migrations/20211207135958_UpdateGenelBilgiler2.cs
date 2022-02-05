using Microsoft.EntityFrameworkCore.Migrations;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Migrations
{
    public partial class UpdateGenelBilgiler2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ResimUrl",
                table: "GenelBilgilers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "EnstituID",
                table: "GenelBilgilers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_GenelBilgilers_EnstituID",
                table: "GenelBilgilers",
                column: "EnstituID");

            migrationBuilder.AddForeignKey(
                name: "FK_GenelBilgilers_Enstitus_EnstituID",
                table: "GenelBilgilers",
                column: "EnstituID",
                principalTable: "Enstitus",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenelBilgilers_Enstitus_EnstituID",
                table: "GenelBilgilers");

            migrationBuilder.DropIndex(
                name: "IX_GenelBilgilers_EnstituID",
                table: "GenelBilgilers");

            migrationBuilder.DropColumn(
                name: "EnstituID",
                table: "GenelBilgilers");

            migrationBuilder.AlterColumn<string>(
                name: "ResimUrl",
                table: "GenelBilgilers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
