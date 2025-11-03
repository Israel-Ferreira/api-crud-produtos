using ApiCrudProdutos.Db;
using ApiCrudProdutos.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCrudProdutos.Repositories.Impl;

public class EstoqueRepositoryImpl : IEstoqueRepository
{
    
    private readonly ApiCrudDbContext _apiCrudDbContext;

    public EstoqueRepositoryImpl(ApiCrudDbContext apiCrudDbContext)
    {
        _apiCrudDbContext = apiCrudDbContext;
    }


    public Estoque? GetByProductSku(string sku)
    {
        return _apiCrudDbContext.Estoques
            .Include(estoque => estoque.Produto)
            .FirstOrDefault(estoque => estoque.Produto.Sku == sku);
    }

    public Estoque? GetById(int id)
    {
        throw new NotImplementedException();
    }
    

    Task IEstoqueRepository.Update(Estoque estoque)
    {
        throw new NotImplementedException();
    }

    public async Task Add(Estoque estoque)
    {
        _apiCrudDbContext.Estoques.Add(estoque);
        await _apiCrudDbContext.SaveChangesAsync();
    }

    public void Update(Estoque estoque)
    {
        throw new NotImplementedException();
    }
}