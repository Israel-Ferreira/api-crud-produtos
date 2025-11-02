using ApiCrudProdutos.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ApiCrudProdutos.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriasController : ControllerBase
{
    
    [HttpGet]
    public IActionResult Get()
    {
        return Ok();
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        return Ok();
    }
    
    
    [HttpPost]
    public Task<IActionResult> Add([FromBody] CategoriaDTO categoria)
    {
        return Task.FromResult<IActionResult>(Created());
    }


    [HttpPut("{id}")]
    public Task<IActionResult> Update(int id)
    {
        return Task.FromResult<IActionResult>(Accepted());
    }


    [HttpDelete("{id}")]
    public Task<IActionResult> Delete(int id)
    {
        return Task.FromResult<IActionResult>(NoContent());
    }
}