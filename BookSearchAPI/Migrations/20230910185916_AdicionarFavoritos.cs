using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookSearchAPI.Migrations
{
    public partial class AdicionarFavoritos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Favorito",
                table: "Livros");

            migrationBuilder.CreateTable(
                name: "Favoritos",
                columns: table => new
                {
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Id_livro = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favoritos", x => new { x.Email, x.Id_livro });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favoritos");

            migrationBuilder.AddColumn<bool>(
                name: "Favorito",
                table: "Livros",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }
    }
}
