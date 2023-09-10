using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookSearchAPI.Migrations
{
    public partial class FavoritosAtualizados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Favoritos",
                table: "Favoritos");

            migrationBuilder.AddColumn<int>(
                name: "Id_favorito",
                table: "Favoritos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Favoritos",
                table: "Favoritos",
                column: "Id_favorito");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Favoritos",
                table: "Favoritos");

            migrationBuilder.DropColumn(
                name: "Id_favorito",
                table: "Favoritos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Favoritos",
                table: "Favoritos",
                columns: new[] { "Email", "Id_livro" });
        }
    }
}
