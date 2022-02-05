using Microsoft.EntityFrameworkCore.Migrations;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Migrations
{
    public partial class CreateSayilar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sayilars",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FakulteSayisi = table.Column<int>(type: "int", nullable: true),
                    EnstituSayisi = table.Column<int>(type: "int", nullable: true),
                    YuksekOkulSayisi = table.Column<int>(type: "int", nullable: true),
                    MeslekYuksekOkulSayisi = table.Column<int>(type: "int", nullable: true),
                    LisansProgramiSayisi = table.Column<int>(type: "int", nullable: true),
                    LisansUstuProgramSayisi = table.Column<int>(type: "int", nullable: true),
                    UygulamaArastirmaMerkeziSayisi = table.Column<int>(type: "int", nullable: true),
                    KordinatorlukSayisi = table.Column<int>(type: "int", nullable: true),
                    TubitakProjeSayisi = table.Column<int>(type: "int", nullable: true),
                    BAPProjesiSayisi = table.Column<int>(type: "int", nullable: true),
                    SponsorluProjeSayisi = table.Column<int>(type: "int", nullable: true),
                    PatentSayisi = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sayilars", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sayilars");
        }
    }
}
