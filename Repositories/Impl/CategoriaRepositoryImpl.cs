using ApiCrudProdutos.Db;
using ApiCrudProdutos.Models;

namespace ApiCrudProdutos.Repositories.Impl;

public class CategoriaRepositoryImpl : ICategoriaRepository
{
    
    private readonly ApiCrudDbContext _dbContext;


    public CategoriaRepositoryImpl(ApiCrudDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    
    public IEnumerable<Categoria> GetAll()
    {
        return _dbContext.Categorias;
    }

    public Categoria? GetById(int id)
    {
        return _dbContext.Categorias.Find(id);
    }

    public async Task Add(Categoria item)
    {
        _dbContext.Categorias.Add(item);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(Categoria item)
    {
        _dbContext.Categorias.Remove(item);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Update(Categoria item)
    {
        _dbContext.Categorias.Update(item);
        await _dbContext.SaveChangesAsync();
        
    }
}