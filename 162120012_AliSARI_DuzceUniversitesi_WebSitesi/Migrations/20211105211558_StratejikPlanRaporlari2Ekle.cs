using Microsoft.EntityFrameworkCore.Migrations;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Migrations
{
    public partial class StratejikPlanRaporlari2Ekle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StratejikPlanRaporlaris",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StratejikPlanRaporlariKategoriID = table.Column<int>(type: "int", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StratejikPlanRaporlaris", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StratejikPlanRaporlaris_StratejikPlanRaporlariKategoris_StratejikPlanRaporlariKategoriID",
                        column: x => x.StratejikPlanRaporlariKategoriID,
                        principalTable: "StratejikPlanRaporlariKategoris",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StratejikPlanRaporlaris_StratejikPlanRaporlariKategoriID",
                table: "StratejikPlanRaporlaris",
                column: "StratejikPlanRaporlariKategoriID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StratejikPlanRaporlaris");
        }
    }
}
