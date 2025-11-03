using ApiCrudProdutos.Dtos;
using ApiCrudProdutos.Exceptions;
using ApiCrudProdutos.Models;
using ApiCrudProdutos.Repositories;
using Microsoft.IdentityModel.Tokens;

namespace ApiCrudProdutos.Services.Impl;

public class ProdutoServiceImpl : IProdutoService
{
    private readonly IProdutoRepository _produtoRepository;
    private readonly IEstoqueRepository _estoqueRepository;
    private readonly ICategoriaRepository _categoriaRepository;
    
    private readonly ILogger<ProdutoServiceImpl> _logger;
    

    public ProdutoServiceImpl(IProdutoRepository produtoRepository, IEstoqueRepository estoqueRepository, ICategoriaRepository categoriaRepository,  ILogger<ProdutoServiceImpl> logger)
    {
        _produtoRepository = produtoRepository;
        _estoqueRepository = estoqueRepository;
        _categoriaRepository = categoriaRepository;
        _logger = logger;
    }


    public IEnumerable<Produto> GetAll()
    {
        return _produtoRepository.GetAll();
    }

    public Produto? GetById(int id)
    {
        return _produtoRepository.GetById(id);
    }

    public Produto? GetBySku(string sku)
    {
        Produto? produto = _produtoRepository.GetBySku(sku);

        if (produto == null)
        {
            _logger.LogError($"Produto {sku} was not found");
            throw new NotFoundException("Produto Not Found");
        }
        
        return produto;
    }

    public async Task Add(ProdutoDTO produto)
    {
        if (produto.Nome.IsNullOrEmpty())
        {
            throw new BadRequestException();
        }

        if (produto.CategoriaId == 0)
        {
            throw new BadRequestException();
        }
        
        var categoria = _categoriaRepository.GetById(produto.CategoriaId);

        if (categoria == null)
        {
            throw new NotFoundException("Categoria não encontrada");
        }
        
        
        string sku = Guid.NewGuid().ToString("N");

        Produto produtoEntity = new(produto.Nome, produto.Descricao, sku);
        produtoEntity.Categoria = categoria;
        
        
        await _produtoRepository.Add(produtoEntity);

        Estoque estoqueEntity = new();
        estoqueEntity.Produto = produtoEntity;
        estoqueEntity.Quantidade = 1;
        
        await _estoqueRepository.Add(estoqueEntity);
    }
    

    public Task Update(int id, ProdutoDTO produto)
    {
        throw new NotImplementedException();
    }

    public async Task Delete(string sku)
    {
        Produto? produto = _produtoRepository.GetBySku(sku);

        if (produto == null)
        {
            _logger.LogError($"Produto {sku} was not found");
            throw new NotFoundException("Produto Not Found");
        }
        
        await _produtoRepository.Delete(produto);
    }
}