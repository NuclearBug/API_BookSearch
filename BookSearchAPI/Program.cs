using BookSearchAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Livros") ?? "Data Source=Livros.db";
builder.Services.AddSqlite<LivroDb>(connectionString);

// builder.Services.AddDbContext<LivroDb>(opt => opt.UseInMemoryDatabase("BookList"));
builder.Services.AddEndpointsApiExplorer();

// Conexão com o Banco da FreeDb.Tech:
Env.Load();

string connectDb(){
    var connectionString = Environment.GetEnvironmentVariable("DATABASE");

    if (connectionString != null){
        Console.WriteLine("Success");
        return connectionString;
    }
    return builder.Configuration.GetConnectionString("credentials") ?? throw new InvalidOperationException("Connect string not found");
}

var takeString = connectDb();

builder.Services.AddDbContext<LivroDb>(options => 
    options.UseMySql(takeString, ServerVersion.AutoDetect(takeString))
);
// --

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

// Endpoints - Books;

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

// Endpoints - Favoritos:
app.MapPost("/favoritos", async (LivroDb db, Favorito favorito) =>
{
    await db.Favoritos.AddAsync(favorito);
    await db.SaveChangesAsync();
    return Results.Created($"/favorito/{favorito.Email + ", " + favorito.Id_livro}", favorito);
});

app.MapGet("/favoritos/{email}", async (LivroDb db, string email) =>
{
    var favorito = await db.Favoritos.FirstOrDefaultAsync(f => f.Email == email);

    if (favorito != null)
    {
        return Results.Ok(favorito); // Retorna o objeto "favorito" encontrado como uma resposta HTTP Ok (200)
    }
    else
    {
        return Results.NotFound("Nenhum registro corresponde ao e-mail fornecido."); // Retorna uma resposta HTTP Not Found (404)
    }
});

app.MapDelete("/favoritos/{id_favorito}", async (LivroDb db, int id) =>
{
    var favorito = await db.Favoritos.FindAsync(id);
    if (favorito is null)
    {
        return Results.NotFound();
    }
    db.Favoritos.Remove(favorito);
    await db.SaveChangesAsync();
    return Results.Ok();
});

// Endpoints - Usuario:

app.MapGet("/users", async (LivroDb db) => await db.Usuarios.ToListAsync());

app.MapGet("/users/{email}", async (LivroDb db, string email) => await db.Usuarios.FindAsync(email));

app.MapPost("/users", async (LivroDb db, Usuario usuarios) =>
{
    await db.Usuarios.AddAsync(usuarios);
    await db.SaveChangesAsync();
    return Results.Created($"/usuario/{usuarios.Email}", usuarios);
});

app.MapPut("/users/{email}", async (LivroDb db, Usuario updateduser, string email) =>
{
    var usuario = await db.Usuarios.FindAsync(email);
    if (usuario is null) return Results.NotFound();
    usuario.Nome = updateduser.Nome;
    usuario.Email = updateduser.Email;
    usuario.Senha = updateduser.Senha;
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("/users/{email}", async (LivroDb db, string email) =>
{
    var usuario = await db.Usuarios.FindAsync(email);
    if (usuario is null)
    {
        return Results.NotFound();
    }
    db.Usuarios.Remove(usuario);
    await db.SaveChangesAsync();
    return Results.Ok();
});

app.Run();
