using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UsuariosAPI.Migrations
{
    public partial class AdicionandoCustomIdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataDeNascimento",
                table: "AspNetUsers",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997,
                column: "ConcurrencyStamp",
                value: "28761be1-2c9a-45ca-b491-3f5758824b1d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "bedf2d78-333a-4ac8-8596-097583d08725");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cd1f31e6-e444-4ab8-942d-649241ddedc1", "AQAAAAEAACcQAAAAEOoz7RMn1O99qGWH0tp15+P1EB7ZhMK5OUrhLd8XPhBLEYmbmVEIDWqN4IiQCy4KHQ==", "fe4d44d8-84a0-4efc-9139-44a7308f2921" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataDeNascimento",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997,
                column: "ConcurrencyStamp",
                value: "482ebf79-60d4-4a2b-99a7-98a1b020cd89");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "f36ea640-e2c6-4e4c-876e-aa568ce8ed9d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "988fabec-8a25-474d-9cfb-a78f6ab763a1", "AQAAAAEAACcQAAAAEG17y0DHOUhmzfmIRappwMXSI5GNHKlR8TOVwVXM/jcuun2gI17PCDQRFuHnIAZTpQ==", "390adbef-6572-4b68-a432-8c94fc652787" });
        }
    }
}
