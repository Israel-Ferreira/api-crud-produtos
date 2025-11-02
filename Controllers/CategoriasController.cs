using ApiCrudProdutos.Dtos;
using ApiCrudProdutos.Exceptions;
using ApiCrudProdutos.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiCrudProdutos.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriasController : ControllerBase
{
    
    private readonly ICategoriaService _categoriaService;
    private readonly ILogger<CategoriasController> _logger;

    public CategoriasController(ICategoriaService categoriaService, ILogger<CategoriasController> logger)
    {
        _categoriaService = categoriaService;
        _logger = logger;
    }
    
    [HttpGet]
    public IActionResult Get()
    {
        var categorias = _categoriaService.GetAll();
        return Ok(categorias);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        try
        {
            var categoria = _categoriaService.GetById(id);
            return Ok(categoria);
        }
        catch (NotFoundException nfe)
        {
            _logger.LogError(nfe.Message);
            return NotFound();
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return StatusCode(500);
        }
    }
    
    
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CategoriaDTO categoria)
    {
        try
        {
            await _categoriaService.Add(categoria);
            return Created();
        }
        catch (BadRequestException brex)
        {
            _logger.LogError(brex.Message);
            return BadRequest();
        }
        
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id,  [FromBody] CategoriaDTO categoria)
    {
        try
        {
            await _categoriaService.Update(id, categoria);
            return NoContent();
        }
        catch (NotFoundException ex)
        {
            _logger.LogError(ex.Message);
            return NotFound();
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return StatusCode(500);
        }
        
        
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _categoriaService.Delete(id);
            return NoContent();
        }
        catch (NotFoundException e)
        {
            _logger.LogError(e.Message);
            return NotFound();
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return StatusCode(500);
        }
        
    }
}