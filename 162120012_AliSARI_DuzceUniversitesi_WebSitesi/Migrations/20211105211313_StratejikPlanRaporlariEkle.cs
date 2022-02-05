using Microsoft.EntityFrameworkCore.Migrations;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Migrations
{
    public partial class StratejikPlanRaporlariEkle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StratejikPlanRaporlariKategoris",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kategori = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StratejikPlanRaporlariKategoris", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StratejikPlanRaporlariKategoris");
        }
    }
}
