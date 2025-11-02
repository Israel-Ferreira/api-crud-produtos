using ApiCrudProdutos.Db;
using ApiCrudProdutos.Models;

namespace ApiCrudProdutos.Repositories.Impl;

public class ProdutoRepositoryImpl : IProdutoRepository
{
    
    private readonly ApiCrudDbContext  _context;


    public ProdutoRepositoryImpl(ApiCrudDbContext context)
    {
        _context = context;
    }
    
    
    public IEnumerable<Produto> GetAll()
    {
        return _context.Produtos.OrderBy(p => p.DataCadastro);
    }

    public Produto? GetById(int id)
    {
        return _context.Produtos.FirstOrDefault(p => p.Id == id);
    }

    public Produto? GetBySku(string sku)
    {
        return _context.Produtos.FirstOrDefault(p => p.Sku == sku);
    }

    public async Task Add(Produto produto)
    {
        _context.Produtos.Add(produto);
        await _context.SaveChangesAsync();
    }

    public Task Update(Produto produto)
    {
        _context.Produtos.Update(produto);
        return _context.SaveChangesAsync();
    }

    public async Task Delete(Produto produto)
    {
        _context.Produtos.Remove(produto);
        await _context.SaveChangesAsync();
    }
}