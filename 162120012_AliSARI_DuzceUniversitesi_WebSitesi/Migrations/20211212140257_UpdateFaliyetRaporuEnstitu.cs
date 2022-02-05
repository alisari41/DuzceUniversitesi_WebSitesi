using Microsoft.EntityFrameworkCore.Migrations;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Migrations
{
    public partial class UpdateFaliyetRaporuEnstitu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FaliyetRaporus_Fakultes_FakulteID",
                table: "FaliyetRaporus");

            migrationBuilder.AlterColumn<int>(
                name: "FakulteID",
                table: "FaliyetRaporus",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "EnstituID",
                table: "FaliyetRaporus",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FaliyetRaporus_EnstituID",
                table: "FaliyetRaporus",
                column: "EnstituID");

            migrationBuilder.AddForeignKey(
                name: "FK_FaliyetRaporus_Enstitus_EnstituID",
                table: "FaliyetRaporus",
                column: "EnstituID",
                principalTable: "Enstitus",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FaliyetRaporus_Fakultes_FakulteID",
                table: "FaliyetRaporus",
                column: "FakulteID",
                principalTable: "Fakultes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FaliyetRaporus_Enstitus_EnstituID",
                table: "FaliyetRaporus");

            migrationBuilder.DropForeignKey(
                name: "FK_FaliyetRaporus_Fakultes_FakulteID",
                table: "FaliyetRaporus");

            migrationBuilder.DropIndex(
                name: "IX_FaliyetRaporus_EnstituID",
                table: "FaliyetRaporus");

            migrationBuilder.DropColumn(
                name: "EnstituID",
                table: "FaliyetRaporus");

            migrationBuilder.AlterColumn<int>(
                name: "FakulteID",
                table: "FaliyetRaporus",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FaliyetRaporus_Fakultes_FakulteID",
                table: "FaliyetRaporus",
                column: "FakulteID",
                principalTable: "Fakultes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
