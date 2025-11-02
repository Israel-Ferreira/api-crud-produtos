using ApiCrudProdutos.Dtos;
using ApiCrudProdutos.Models;
using ApiCrudProdutos.Repositories;

namespace ApiCrudProdutos.Services;

public class CategoriaServiceImpl : ICategoriaService
{
    
    private readonly ICategoriaRepository _categoriaRepository;
    private readonly ILogger<CategoriaServiceImpl> _logger;


    public CategoriaServiceImpl(ICategoriaRepository categoriaRepository, ILogger<CategoriaServiceImpl> logger)
    {
        _categoriaRepository = categoriaRepository;
        _logger = logger;
    }
    
    
    public IEnumerable<Categoria> GetAll()
    {
        var categorias = _categoriaRepository.GetAll();
        return categorias;
    }

    public Categoria? GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task Add(CategoriaDTO categoria)
    {
        throw new NotImplementedException();
    }

    public Task Update(int id, CategoriaDTO categoria)
    {
        throw new NotImplementedException();
    }
}