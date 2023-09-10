using BookSearchAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Livros") ?? "Data Source=Livros.db";
builder.Services.AddSqlite<LivroDb>(connectionString);

// builder.Services.AddDbContext<LivroDb>(opt => opt.UseInMemoryDatabase("BookList"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<LivroDb>(options => options.UseInMemoryDatabase("items"));
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "BookSearch API",
        Description = "Pesquisas de Livros com nossa API",
        Version = "v1"
    });
});


// builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookSearch API V1");
});

app.MapGet("/", () => "Hello World!");

// Endpoints;

app.MapGet("/books", async (LivroDb db) => await db.Livros.ToListAsync());

app.MapGet("/books/{id}", async (LivroDb db, int id) => await db.Livros.FindAsync(id));

app.MapPost("/books", async (LivroDb db, Livro livro) =>
{
    await db.Livros.AddAsync(livro);
    await db.SaveChangesAsync();
    return Results.Created($"/livro/{livro.Id}", livro);
});

app.MapPut("/books/{id}", async (LivroDb db, Livro updatedbook, int id) =>
{
    var livro = await db.Livros.FindAsync(id);
    if (livro is null) return Results.NotFound();
    livro.Nome = updatedbook.Nome;
    livro.Sinopse= updatedbook.Sinopse;
    livro.Class = updatedbook.Class;
    livro.NumCap = updatedbook.NumCap;
    livro.NumPag = updatedbook.NumPag;
    livro.Autor = updatedbook.Autor;
    livro.Favorito = updatedbook.Favorito;
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("/books/{id}", async (LivroDb db, int id) =>
{
    var livro = await db.Livros.FindAsync(id);
    if (livro is null)
    {
        return Results.NotFound();
    }
    db.Livros.Remove(livro);
    await db.SaveChangesAsync();
    return Results.Ok();
});

app.Run();

/*
// GET(s)
app.MapGet("/books", async (LivroDb db) =>
{
    var livros = await db.Livros.ToListAsync();
    return Results.Ok(livros);
});

app.MapGet("/books/{id}", async (int id, LivroDb db) =>
{
    var livro = await db.Livros.FindAsync(id);

    if (livro != null)
    {
        return Results.Ok(livro);
    }
    else
    {
        return Results.NotFound();
    }
});

app.MapGet("/books/by-name/{nome}", async (string nome, LivroDb db) =>
{
    var livros = await db.Livros
        .Where(l => l.Nome == nome)
        .ToListAsync();

    if (livros.Count > 0)
    {
        return Results.Ok(livros);
    }
    else
    {
        return Results.NotFound();
    }
});

// DELETE(s)
app.MapDelete("/books/{id}", async (int id, LivroDb db) =>
{
    if (await db.Livros.FindAsync(id) is Livro livro)
    {
        db.Livros.Remove(livro);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }

    return Results.NotFound();
});

// POST(s)
app.MapPost("/books", async (Livro livro, LivroDb db) =>
{
    db.Livros.Add(livro);
    await db.SaveChangesAsync();

    return Results.Created($"/books/{livro.Id}", livro);
});

// PUT(s)
app.MapPut("/books/{id}", async (int id, Livro inputLivro, LivroDb db) =>
{
    var livro = await db.Livros.FindAsync(id);

    if (livro is null) return Results.NotFound();

    livro.Nome = inputLivro.Nome;
    livro.Autor = inputLivro.Autor;
    livro.Class = inputLivro.Class;
    livro.Sinopse = inputLivro.Sinopse;
    livro.NumCap = inputLivro.NumCap;
    livro.NumPag = inputLivro.NumPag;

    await db.SaveChangesAsync();

    return Results.NoContent();
});
*/