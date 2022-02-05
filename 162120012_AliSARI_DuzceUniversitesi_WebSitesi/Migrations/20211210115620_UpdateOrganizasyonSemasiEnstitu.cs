using Microsoft.EntityFrameworkCore.Migrations;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Migrations
{
    public partial class UpdateOrganizasyonSemasiEnstitu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizasyonSemasis_Fakultes_FakulteID",
                table: "OrganizasyonSemasis");

            migrationBuilder.AlterColumn<int>(
                name: "FakulteID",
                table: "OrganizasyonSemasis",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "EnstituID",
                table: "OrganizasyonSemasis",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrganizasyonSemasis_EnstituID",
                table: "OrganizasyonSemasis",
                column: "EnstituID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizasyonSemasis_Enstitus_EnstituID",
                table: "OrganizasyonSemasis",
                column: "EnstituID",
                principalTable: "Enstitus",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizasyonSemasis_Fakultes_FakulteID",
                table: "OrganizasyonSemasis",
                column: "FakulteID",
                principalTable: "Fakultes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizasyonSemasis_Enstitus_EnstituID",
                table: "OrganizasyonSemasis");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizasyonSemasis_Fakultes_FakulteID",
                table: "OrganizasyonSemasis");

            migrationBuilder.DropIndex(
                name: "IX_OrganizasyonSemasis_EnstituID",
                table: "OrganizasyonSemasis");

            migrationBuilder.DropColumn(
                name: "EnstituID",
                table: "OrganizasyonSemasis");

            migrationBuilder.AlterColumn<int>(
                name: "FakulteID",
                table: "OrganizasyonSemasis",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizasyonSemasis_Fakultes_FakulteID",
                table: "OrganizasyonSemasis",
                column: "FakulteID",
                principalTable: "Fakultes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
