using Microsoft.EntityFrameworkCore.Migrations;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Migrations
{
    public partial class CreateKurumsal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FaliyetRaporus",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FakulteID = table.Column<int>(type: "int", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaliyetRaporus", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FaliyetRaporus_Fakultes_FakulteID",
                        column: x => x.FakulteID,
                        principalTable: "Fakultes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GorevTanimlaris",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FakulteID = table.Column<int>(type: "int", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GorevTanimlaris", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GorevTanimlaris_Fakultes_FakulteID",
                        column: x => x.FakulteID,
                        principalTable: "Fakultes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HizmetStandartlariveEnvanteris",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FakulteID = table.Column<int>(type: "int", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HizmetStandartlariveEnvanteris", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HizmetStandartlariveEnvanteris_Fakultes_FakulteID",
                        column: x => x.FakulteID,
                        principalTable: "Fakultes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IcDegerlendirmeRaporus",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FakulteID = table.Column<int>(type: "int", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IcDegerlendirmeRaporus", x => x.ID);
                    table.ForeignKey(
                        name: "FK_IcDegerlendirmeRaporus_Fakultes_FakulteID",
                        column: x => x.FakulteID,
                        principalTable: "Fakultes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ısAkisSemalaris",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FakulteID = table.Column<int>(type: "int", nullable: false),
                    Departman = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ısAkisSemalaris", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ısAkisSemalaris_Fakultes_FakulteID",
                        column: x => x.FakulteID,
                        principalTable: "Fakultes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KurullarVeKomisyonlars",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FakulteID = table.Column<int>(type: "int", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KurullarVeKomisyonlars", x => x.ID);
                    table.ForeignKey(
                        name: "FK_KurullarVeKomisyonlars_Fakultes_FakulteID",
                        column: x => x.FakulteID,
                        principalTable: "Fakultes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrganizasyonSemasis",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FakulteID = table.Column<int>(type: "int", nullable: false),
                    ResimUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizasyonSemasis", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrganizasyonSemasis_Fakultes_FakulteID",
                        column: x => x.FakulteID,
                        principalTable: "Fakultes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FaliyetRaporus_FakulteID",
                table: "FaliyetRaporus",
                column: "FakulteID");

            migrationBuilder.CreateIndex(
                name: "IX_GorevTanimlaris_FakulteID",
                table: "GorevTanimlaris",
                column: "FakulteID");

            migrationBuilder.CreateIndex(
                name: "IX_HizmetStandartlariveEnvanteris_FakulteID",
                table: "HizmetStandartlariveEnvanteris",
                column: "FakulteID");

            migrationBuilder.CreateIndex(
                name: "IX_IcDegerlendirmeRaporus_FakulteID",
                table: "IcDegerlendirmeRaporus",
                column: "FakulteID");

            migrationBuilder.CreateIndex(
                name: "IX_ısAkisSemalaris_FakulteID",
                table: "ısAkisSemalaris",
                column: "FakulteID");

            migrationBuilder.CreateIndex(
                name: "IX_KurullarVeKomisyonlars_FakulteID",
                table: "KurullarVeKomisyonlars",
                column: "FakulteID");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizasyonSemasis_FakulteID",
                table: "OrganizasyonSemasis",
                column: "FakulteID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FaliyetRaporus");

            migrationBuilder.DropTable(
                name: "GorevTanimlaris");

            migrationBuilder.DropTable(
                name: "HizmetStandartlariveEnvanteris");

            migrationBuilder.DropTable(
                name: "IcDegerlendirmeRaporus");

            migrationBuilder.DropTable(
                name: "ısAkisSemalaris");

            migrationBuilder.DropTable(
                name: "KurullarVeKomisyonlars");

            migrationBuilder.DropTable(
                name: "OrganizasyonSemasis");
        }
    }
}
