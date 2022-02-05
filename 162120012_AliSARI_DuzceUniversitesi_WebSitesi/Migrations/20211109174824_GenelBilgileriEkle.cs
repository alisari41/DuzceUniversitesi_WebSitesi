using Microsoft.EntityFrameworkCore.Migrations;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Migrations
{
    public partial class GenelBilgileriEkle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GenelBilgilers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FakulteID = table.Column<int>(type: "int", nullable: false),
                    ResimUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aciklama1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Misyonumuz = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vizyonumuz = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EkBaslik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EkAciklama1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EkAciklama2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EkAciklama3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EkAciklama4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EkAciklama5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EkAciklama6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EkAciklama7 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EkAciklama8 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EkAciklama9 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EkAciklama10 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EkAciklama11 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EkAciklama12 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenelBilgilers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GenelBilgilers_Fakultes_FakulteID",
                        column: x => x.FakulteID,
                        principalTable: "Fakultes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenelBilgilers_FakulteID",
                table: "GenelBilgilers",
                column: "FakulteID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenelBilgilers");
        }
    }
}
