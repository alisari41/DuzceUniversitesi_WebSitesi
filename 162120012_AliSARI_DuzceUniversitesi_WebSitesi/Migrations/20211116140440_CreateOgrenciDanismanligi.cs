using Microsoft.EntityFrameworkCore.Migrations;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Migrations
{
    public partial class CreateOgrenciDanismanligi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OgrenciDanismanligis",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FakulteID = table.Column<int>(type: "int", nullable: false),
                    Aciklama1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aciklama2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aciklama3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkAciklama1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkAciklama2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkAciklama3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BolumAdi = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Sinif = table.Column<int>(type: "int", nullable: false),
                    DanismanUnvan = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    DanismanAd = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DanismanSoyad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OgrenciDanismanligis", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OgrenciDanismanligis_Fakultes_FakulteID",
                        column: x => x.FakulteID,
                        principalTable: "Fakultes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OgrenciDanismanligis_FakulteID",
                table: "OgrenciDanismanligis",
                column: "FakulteID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OgrenciDanismanligis");
        }
    }
}
