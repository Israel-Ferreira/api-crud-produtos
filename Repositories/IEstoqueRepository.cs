using ApiCrudProdutos.Models;

namespace ApiCrudProdutos.Repositories;

public interface IEstoqueRepository
{
    Estoque? GetByProductSku(string sku);
    Estoque? GetById(int id);
    
    Task Add(Estoque estoque);
    Task Update(Estoque estoque);
    
}