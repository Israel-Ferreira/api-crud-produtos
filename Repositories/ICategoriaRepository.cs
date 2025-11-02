using ApiCrudProdutos.Models;

namespace ApiCrudProdutos.Repositories;

public interface ICategoriaRepository
{
    IEnumerable<Categoria> GetAll();
    Categoria? GetById(int id);
    Task Add(Categoria item);
    Task Delete(Categoria item);
    
    Task Update(Categoria item);
    
}