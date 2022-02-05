using Microsoft.EntityFrameworkCore.Migrations;

namespace _162120012_AliSARI_DuzceUniversitesi_WebSitesi.Migrations
{
    public partial class UpdateDuyurularZorunluAlansil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Icerik",
                table: "Duyurulars",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DuyuruKategori",
                table: "Duyurulars",
                type: "nvarchar(90)",
                maxLength: 90,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(90)",
                oldMaxLength: 90);

            migrationBuilder.AlterColumn<string>(
                name: "Baslik",
                table: "Duyurulars",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Icerik",
                table: "Duyurulars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DuyuruKategori",
                table: "Duyurulars",
                type: "nvarchar(90)",
                maxLength: 90,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(90)",
                oldMaxLength: 90,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Baslik",
                table: "Duyurulars",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
