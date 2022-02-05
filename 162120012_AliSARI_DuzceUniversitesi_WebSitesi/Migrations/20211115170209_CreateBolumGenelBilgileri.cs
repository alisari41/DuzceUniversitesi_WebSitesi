using Microsoft.EntityFrameworkCore.Migrations;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Migrations
{
    public partial class CreateBolumGenelBilgileri : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BolumGenelBilgileris",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BolumID = table.Column<int>(type: "int", nullable: true),
                    Aciklama1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama7 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama8 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama9 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama10 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama11 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BolognaSureciLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email3 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BolumGenelBilgileris", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BolumGenelBilgileris_Bolums_BolumID",
                        column: x => x.BolumID,
                        principalTable: "Bolums",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BolumGenelBilgileris_BolumID",
                table: "BolumGenelBilgileris",
                column: "BolumID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BolumGenelBilgileris");
        }
    }
}
