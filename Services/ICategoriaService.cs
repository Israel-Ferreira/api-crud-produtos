using ApiCrudProdutos.Dtos;
using ApiCrudProdutos.Models;

namespace ApiCrudProdutos.Services;

public interface ICategoriaService
{
    IEnumerable<Categoria> GetAll();
    Categoria? GetById(int id);
    Task<bool> Delete(int id);
    Task Add(CategoriaDTO categoria);
    Task Update(int id, CategoriaDTO categoria);
}