using Microsoft.EntityFrameworkCore;
using static BookAPI.Livro;

class LivroDb : DbContext
{
    public LivroDb(DbContextOptions<LivroDb> options)
        : base(options) { }

    public DbSet<BookAPI.Livro> Livros => Set<BookAPI.Livro>();
}