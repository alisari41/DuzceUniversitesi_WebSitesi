using Microsoft.EntityFrameworkCore.Migrations;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Migrations
{
    public partial class UpdateKomisyonlarEnstitu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KurullarVeKomisyonlars_Fakultes_FakulteID",
                table: "KurullarVeKomisyonlars");

            migrationBuilder.AlterColumn<int>(
                name: "FakulteID",
                table: "KurullarVeKomisyonlars",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "EnstituID",
                table: "KurullarVeKomisyonlars",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_KurullarVeKomisyonlars_EnstituID",
                table: "KurullarVeKomisyonlars",
                column: "EnstituID");

            migrationBuilder.AddForeignKey(
                name: "FK_KurullarVeKomisyonlars_Enstitus_EnstituID",
                table: "KurullarVeKomisyonlars",
                column: "EnstituID",
                principalTable: "Enstitus",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_KurullarVeKomisyonlars_Fakultes_FakulteID",
                table: "KurullarVeKomisyonlars",
                column: "FakulteID",
                principalTable: "Fakultes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KurullarVeKomisyonlars_Enstitus_EnstituID",
                table: "KurullarVeKomisyonlars");

            migrationBuilder.DropForeignKey(
                name: "FK_KurullarVeKomisyonlars_Fakultes_FakulteID",
                table: "KurullarVeKomisyonlars");

            migrationBuilder.DropIndex(
                name: "IX_KurullarVeKomisyonlars_EnstituID",
                table: "KurullarVeKomisyonlars");

            migrationBuilder.DropColumn(
                name: "EnstituID",
                table: "KurullarVeKomisyonlars");

            migrationBuilder.AlterColumn<int>(
                name: "FakulteID",
                table: "KurullarVeKomisyonlars",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_KurullarVeKomisyonlars_Fakultes_FakulteID",
                table: "KurullarVeKomisyonlars",
                column: "FakulteID",
                principalTable: "Fakultes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
