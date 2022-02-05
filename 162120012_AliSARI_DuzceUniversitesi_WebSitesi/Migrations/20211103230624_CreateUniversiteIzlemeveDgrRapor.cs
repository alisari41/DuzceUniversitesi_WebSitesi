using Microsoft.EntityFrameworkCore.Migrations;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Migrations
{
    public partial class CreateUniversiteIzlemeveDgrRapor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UniversiteIzlemeveDgrRaporKategoris",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kategori = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniversiteIzlemeveDgrRaporKategoris", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UniversiteIzlemeveDgrRapors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniversiteIzlemeveDgrRaporKategoriID = table.Column<int>(type: "int", nullable: false),
                    Kriterler = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Say_Oran = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniversiteIzlemeveDgrRapors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UniversiteIzlemeveDgrRapors_UniversiteIzlemeveDgrRaporKategoris_UniversiteIzlemeveDgrRaporKategoriID",
                        column: x => x.UniversiteIzlemeveDgrRaporKategoriID,
                        principalTable: "UniversiteIzlemeveDgrRaporKategoris",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UniversiteIzlemeveDgrRapors_UniversiteIzlemeveDgrRaporKategoriID",
                table: "UniversiteIzlemeveDgrRapors",
                column: "UniversiteIzlemeveDgrRaporKategoriID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UniversiteIzlemeveDgrRapors");

            migrationBuilder.DropTable(
                name: "UniversiteIzlemeveDgrRaporKategoris");
        }
    }
}
