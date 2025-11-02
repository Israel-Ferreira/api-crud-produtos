using Microsoft.AspNetCore.Mvc;

namespace ApiCrudProdutos.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController  : ControllerBase
{
    
    [HttpGet]
    public Task<IActionResult> Get()
    {
        return Task.FromResult<IActionResult>(Ok());
    }

    [HttpGet("{sku}")]
    public Task<IActionResult> GetBySku(string sku)
    {
        return Task.FromResult<IActionResult>(Ok());
    }

    [HttpDelete("{sku}")]
    public Task<IActionResult> Delete(string sku)
    {
        return Task.FromResult<IActionResult>(NoContent());
    }
    
    
}