using Microsoft.EntityFrameworkCore.Migrations;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Migrations
{
    public partial class DeleteDuyuruKategori : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Duyurulars_DuyuruKategoris_DuyuruKategoriID",
                table: "Duyurulars");

            migrationBuilder.DropTable(
                name: "DuyuruKategoris");

            migrationBuilder.DropIndex(
                name: "IX_Duyurulars_DuyuruKategoriID",
                table: "Duyurulars");

            migrationBuilder.DropColumn(
                name: "DuyuruKategoriID",
                table: "Duyurulars");

            migrationBuilder.AddColumn<string>(
                name: "DuyuruKategori",
                table: "Duyurulars",
                type: "nvarchar(90)",
                maxLength: 90,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DuyuruKategori",
                table: "Duyurulars");

            migrationBuilder.AddColumn<int>(
                name: "DuyuruKategoriID",
                table: "Duyurulars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DuyuruKategoris",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kategori = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuyuruKategoris", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Duyurulars_DuyuruKategoriID",
                table: "Duyurulars",
                column: "DuyuruKategoriID");

            migrationBuilder.AddForeignKey(
                name: "FK_Duyurulars_DuyuruKategoris_DuyuruKategoriID",
                table: "Duyurulars",
                column: "DuyuruKategoriID",
                principalTable: "DuyuruKategoris",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
