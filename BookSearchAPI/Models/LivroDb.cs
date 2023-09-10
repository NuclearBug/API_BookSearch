using BookSearchAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookSearchAPI.Models
{
    class LivroDb : DbContext
    {
        public LivroDb(DbContextOptions options) : base(options) { }
        public DbSet<Livro> Livros { get; set; } = null!;
        public DbSet<Usuario> Usuarios { get; set; } = null!;
        public DbSet<Favorito> Favoritos { get; set; } = null!;
    }
}