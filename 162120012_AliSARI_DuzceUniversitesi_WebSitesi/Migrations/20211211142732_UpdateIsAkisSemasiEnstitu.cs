using Microsoft.EntityFrameworkCore.Migrations;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Migrations
{
    public partial class UpdateIsAkisSemasiEnstitu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ısAkisSemalaris_Fakultes_FakulteID",
                table: "ısAkisSemalaris");

            migrationBuilder.AlterColumn<int>(
                name: "FakulteID",
                table: "ısAkisSemalaris",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "EnstituID",
                table: "ısAkisSemalaris",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ısAkisSemalaris_EnstituID",
                table: "ısAkisSemalaris",
                column: "EnstituID");

            migrationBuilder.AddForeignKey(
                name: "FK_ısAkisSemalaris_Enstitus_EnstituID",
                table: "ısAkisSemalaris",
                column: "EnstituID",
                principalTable: "Enstitus",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ısAkisSemalaris_Fakultes_FakulteID",
                table: "ısAkisSemalaris",
                column: "FakulteID",
                principalTable: "Fakultes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ısAkisSemalaris_Enstitus_EnstituID",
                table: "ısAkisSemalaris");

            migrationBuilder.DropForeignKey(
                name: "FK_ısAkisSemalaris_Fakultes_FakulteID",
                table: "ısAkisSemalaris");

            migrationBuilder.DropIndex(
                name: "IX_ısAkisSemalaris_EnstituID",
                table: "ısAkisSemalaris");

            migrationBuilder.DropColumn(
                name: "EnstituID",
                table: "ısAkisSemalaris");

            migrationBuilder.AlterColumn<int>(
                name: "FakulteID",
                table: "ısAkisSemalaris",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ısAkisSemalaris_Fakultes_FakulteID",
                table: "ısAkisSemalaris",
                column: "FakulteID",
                principalTable: "Fakultes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
