using Microsoft.EntityFrameworkCore.Migrations;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Migrations
{
    public partial class CreateFomrlarOgrenci : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FormlarOgrs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FakulteID = table.Column<int>(type: "int", nullable: true),
                    EnstituID = table.Column<int>(type: "int", nullable: true),
                    Baslik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormlarOgrs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FormlarOgrs_Enstitus_EnstituID",
                        column: x => x.EnstituID,
                        principalTable: "Enstitus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FormlarOgrs_Fakultes_FakulteID",
                        column: x => x.FakulteID,
                        principalTable: "Fakultes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FormlarOgrs_EnstituID",
                table: "FormlarOgrs",
                column: "EnstituID");

            migrationBuilder.CreateIndex(
                name: "IX_FormlarOgrs_FakulteID",
                table: "FormlarOgrs",
                column: "FakulteID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormlarOgrs");
        }
    }
}
