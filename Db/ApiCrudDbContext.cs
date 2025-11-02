using ApiCrudProdutos.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCrudProdutos.Db;

public class ApiCrudDbContext(DbContextOptions<ApiCrudDbContext> options) : DbContext(options)
{
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Produto> Produtos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Produto>()
            .HasIndex(p => p.Sku)
            .IsUnique();
    }
}