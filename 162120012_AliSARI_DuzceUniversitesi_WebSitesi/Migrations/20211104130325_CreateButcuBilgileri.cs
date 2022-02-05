using Microsoft.EntityFrameworkCore.Migrations;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Migrations
{
    public partial class CreateButcuBilgileri : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ButceBilgileriKategoris",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YilKategori = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ButceBilgileriKategoris", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ButceBilgileris",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ButceBilgileriKategoriID = table.Column<int>(type: "int", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ButceBilgileris", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ButceBilgileris_ButceBilgileriKategoris_ButceBilgileriKategoriID",
                        column: x => x.ButceBilgileriKategoriID,
                        principalTable: "ButceBilgileriKategoris",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ButceBilgileris_ButceBilgileriKategoriID",
                table: "ButceBilgileris",
                column: "ButceBilgileriKategoriID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ButceBilgileris");

            migrationBuilder.DropTable(
                name: "ButceBilgileriKategoris");
        }
    }
}
