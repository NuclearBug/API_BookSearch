using BookAPI;
using Microsoft.EntityFrameworkCore;

/*
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<LivroDb>(opt => opt.UseInMemoryDatabase("BookList"));
*/
/*
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<LivroDb>(opt =>
    opt.UseSqlServer("Server=tcp:booksearcgserver.database.windows.net,1433;Initial Catalog=dbbooksearch;" +
    "Persist Security Info=False;User ID=0ed6dc86-1f2a-452c-9841-e352e6774c9c;Password=12345678;" +
    "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Authentication='Active Directory Password';"));
*/
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<LivroDb>(opt => opt.UseInMemoryDatabase("BookList"));

// builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();


// GETs
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

app.Run();

/*
app.MapPost("/books", async (Livro livro, LivroDb db) =>
{
    db.Livros.Add(livro);
    await db.SaveChangesAsync();

    return Results.Created($"/books/{todo.Id}", todo);
});

app.MapPut("/books/{id}", async (int id, Livro inputTodo, LivroDb db) =>
{
    var todo = await db.Livros.FindAsync(id);

    if (todo is null) return Results.NotFound();

    todo.Nome = inputTodo.Nome;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/books/{id}", async (int id, LivroDb db) =>
{
    if (await db.Livros.FindAsync(id) is Livro todo)
    {
        db.Livros.Remove(todo);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }

    return Results.NotFound();
});
*/