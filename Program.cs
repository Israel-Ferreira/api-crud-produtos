using ApiCrudProdutos.Db;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHealthChecks();


builder.Services.AddDbContext<ApiCrudDbContext>(options => 
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("Database"),
        b => b.MigrationsAssembly("ApiCrudProdutos")));

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

