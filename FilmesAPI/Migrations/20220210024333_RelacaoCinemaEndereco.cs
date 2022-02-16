using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace FilmesAPI.Migrations
{
    public partial class RelacaoCinemaEndereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EnderecoID",
                table: "Cinemas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Logradouro = table.Column<string>(type: "text", nullable: true),
                    Bairro = table.Column<string>(type: "text", nullable: true),
                    Numero = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cinemas_EnderecoID",
                table: "Cinemas",
                column: "EnderecoID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cinemas_Enderecos_EnderecoID",
                table: "Cinemas",
                column: "EnderecoID",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cinemas_Enderecos_EnderecoID",
                table: "Cinemas");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropIndex(
                name: "IX_Cinemas_EnderecoID",
                table: "Cinemas");

            migrationBuilder.DropColumn(
                name: "EnderecoID",
                table: "Cinemas");
        }
    }
}
