using ApiCrudProdutos.Dtos;
using ApiCrudProdutos.Models;

namespace ApiCrudProdutos.Services;

public interface IProdutoService
{
    IEnumerable<Produto> GetAll();
    Produto? GetById(int id);
    
    Produto? GetBySku(string sku);
    
    Task Add(ProdutoDTO produto);
    Task Update(int id, ProdutoDTO produto);
    Task Delete(string sku);
}