using ApiCrudProdutos.Dtos;
using ApiCrudProdutos.Models;
using ApiCrudProdutos.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiCrudProdutos.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController  : ControllerBase
{
    
    private readonly IProdutoService _produtoService;
    private readonly ILogger<ProdutosController> _logger;

    public ProdutosController(IProdutoService produtoService, ILogger<ProdutosController> logger)
    {
        _produtoService = produtoService;
        _logger = logger;
    }

    [HttpGet]
    public Task<IActionResult> Get()
    {
        var produtos = _produtoService.GetAll();
        return Task.FromResult<IActionResult>(Ok(produtos));
    }

    [HttpPost]
    public async Task<IActionResult> Add(ProdutoDTO produto)
    {
        try
        {
            _logger.LogInformation("Adding produto");
            await _produtoService.Add(produto);
            return Created("api/Produtos", produto);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{sku}")]
    public Task<IActionResult> GetBySku(string sku)
    {
        try
        {
            var produto = _produtoService.GetBySku(sku);
            return Task.FromResult<IActionResult>(Ok(produto));
        }
        catch (Exception e)
        {
            return Task.FromResult<IActionResult>(NotFound(e.Message));
        }
        
        
        return Task.FromResult<IActionResult>(Ok());
    }

    [HttpDelete("{sku}")]
    public async Task<IActionResult> Delete(string sku)
    {
        try
        {
            _logger.LogInformation("Deleting produto");
            await _produtoService.Delete(sku);
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        
    }
    
    
}