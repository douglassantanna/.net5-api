using Microsoft.EntityFrameworkCore.Migrations;

namespace UsuariosAPI.Migrations
{
    public partial class UsuarioRegular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "f36ea640-e2c6-4e4c-876e-aa568ce8ed9d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 99997, "482ebf79-60d4-4a2b-99a7-98a1b020cd89", "regular", "REGULAR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "988fabec-8a25-474d-9cfb-a78f6ab763a1", "AQAAAAEAACcQAAAAEG17y0DHOUhmzfmIRappwMXSI5GNHKlR8TOVwVXM/jcuun2gI17PCDQRFuHnIAZTpQ==", "390adbef-6572-4b68-a432-8c94fc652787" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "4b669c36-26f4-482e-9c74-6a136a40c858");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b3989731-799b-4310-b1fd-4d694d5b5fef", "AQAAAAEAACcQAAAAEKzXyTy0fKYIHNk1RSC5EQDe8nqPNSaglPFg64DFlQmwBdC8WP8f96q8Zr62AftYSQ==", "467a8e1d-1031-4744-9cde-62419e01beec" });
        }
    }
}
