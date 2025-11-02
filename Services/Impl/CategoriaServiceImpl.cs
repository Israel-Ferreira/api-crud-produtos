using ApiCrudProdutos.Dtos;
using ApiCrudProdutos.Exceptions;
using ApiCrudProdutos.Models;
using ApiCrudProdutos.Repositories;

namespace ApiCrudProdutos.Services.Impl;

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
        var  categoria = _categoriaRepository.GetById(id);

        if (categoria == null)
        {
            string msg = $"Categoria com id {id} não encontrada";
            throw new NotFoundException(msg);
        }
        
        
        return categoria;
    }

    public async Task<bool> Delete(int id)
    {
        var categoria = _categoriaRepository.GetById(id);

        if (categoria == null)
        {
            string msg = $"Categoria com id {id} não encontrada";
            throw new NotFoundException(msg);
        }
        
        await _categoriaRepository.Delete(categoria);
        return true;
    }

    public async Task Add(CategoriaDTO categoria)
    {
        if (categoria.Nome == "")
        {
            throw new BadRequestException();
        }
        
        Categoria categoriaEntity = new Categoria(categoria.Nome);
        await _categoriaRepository.Add(categoriaEntity);
    }

    public async Task Update(int id, CategoriaDTO categoria)
    {
        var categoriaEntity = _categoriaRepository.GetById(id);

        if (categoriaEntity == null)
        {
            string msg = $"Categoria com id {id} não encontrada";
            throw new NotFoundException(msg);
        }
        
        categoriaEntity.Nome = categoria.Nome;
        await _categoriaRepository.Update(categoriaEntity);
    }
}