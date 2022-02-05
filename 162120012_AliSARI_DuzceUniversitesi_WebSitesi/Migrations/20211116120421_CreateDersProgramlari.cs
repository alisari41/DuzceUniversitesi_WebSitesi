using Microsoft.EntityFrameworkCore.Migrations;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Migrations
{
    public partial class CreateDersProgramlari : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DersProgramlariKategoris",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kategori = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DersProgramlariKategoris", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DersProgramlaris",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DersProgramlariKategoriID = table.Column<int>(type: "int", nullable: false),
                    FakulteID = table.Column<int>(type: "int", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DersProgramlaris", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DersProgramlaris_DersProgramlariKategoris_DersProgramlariKategoriID",
                        column: x => x.DersProgramlariKategoriID,
                        principalTable: "DersProgramlariKategoris",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DersProgramlaris_Fakultes_FakulteID",
                        column: x => x.FakulteID,
                        principalTable: "Fakultes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DersProgramlaris_DersProgramlariKategoriID",
                table: "DersProgramlaris",
                column: "DersProgramlariKategoriID");

            migrationBuilder.CreateIndex(
                name: "IX_DersProgramlaris_FakulteID",
                table: "DersProgramlaris",
                column: "FakulteID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DersProgramlaris");

            migrationBuilder.DropTable(
                name: "DersProgramlariKategoris");
        }
    }
}
