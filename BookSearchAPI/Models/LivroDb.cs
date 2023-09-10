using BookSearchAPI.Models;
using Microsoft.EntityFrameworkCore;
using static BookSearchAPI.Models.Livro;

namespace BookSearchAPI.Models
{
    class LivroDb : DbContext
    {
        public LivroDb(DbContextOptions options) : base(options) { }
        public DbSet<Livro> Livros { get; set; } = null!;
        /*
        public LivroDb(DbContextOptions<LivroDb> options)
            : base(options) { }

        public DbSet<Livro> Livros => Set<Livro>();
        */
    }
}