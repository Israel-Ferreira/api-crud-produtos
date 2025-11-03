using System.Text.Json.Serialization;
using ApiCrudProdutos.Db;
using ApiCrudProdutos.Repositories;
using ApiCrudProdutos.Repositories.Impl;
using ApiCrudProdutos.Services;
using ApiCrudProdutos.Services.Impl;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHealthChecks();


builder.Services.AddDbContext<ApiCrudDbContext>(options => 
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("Database"),
        b => b.MigrationsAssembly("ApiCrudProdutos")));


builder.Services.AddScoped<ICategoriaRepository, CategoriaRepositoryImpl>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepositoryImpl>();
builder.Services.AddScoped<IEstoqueRepository, EstoqueRepositoryImpl>();





builder.Services.AddScoped<ICategoriaService, CategoriaServiceImpl>();
builder.Services.AddScoped<IProdutoService, ProdutoServiceImpl>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

using (var scope = app.Services.CreateScope())
{
    try
    {
        var db = scope.ServiceProvider.GetRequiredService<ApiCrudDbContext>();
        db.Database.Migrate();
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
        Console.WriteLine($"Logando o erro da migração: {e.Message}");
    }
}

app.MapControllers();
app.UseHealthChecks("/health");
app.Run();

