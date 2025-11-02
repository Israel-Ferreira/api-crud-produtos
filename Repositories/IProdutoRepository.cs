using ApiCrudProdutos.Models;

namespace ApiCrudProdutos.Repositories;

public interface IProdutoRepository
{
    IEnumerable<Produto> GetAll();
    Produto? GetById(int id);
    
    Produto? GetBySku(string sku);
    Task Add(Produto produto);
    Task Update(Produto produto);
    
    Task Delete(Produto produto);
}