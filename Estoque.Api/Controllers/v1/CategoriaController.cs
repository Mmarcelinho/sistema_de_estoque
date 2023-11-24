using Microsoft.AspNetCore.Mvc;
using Estoque.Domain.Interfaces.Service;
using Estoque.Application.DTOs.Entities;
using Estoque.Application.DTOs.Mappings;

namespace Estoque.Api.Controllers.v1;

[ApiController]
[Route("api/v1/[controller]")]
public class CategoriaController : ControllerBase
{
    private readonly ICategoriaService _categoriaService;
    public CategoriaController(ICategoriaService categoriaService) =>
    _categoriaService = categoriaService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoriaResponse>>> ObterTodos()
    {
        var categorias = await _categoriaService.ObterTodosAsync();
        var categoriasResponse = categorias.Select(categoria => categoria.ConverterParaResponse());
        return Ok(categoriasResponse);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CategoriaResponse>> ObterPorId(int id)
    {
        var categoria = await _categoriaService.ObterPorIdAsync(id);
        if (categoria is null)
            return NotFound();

        var categoriaResponse = CategoriaMap.ConverterParaResponse(categoria);
        return Ok(categoriaResponse);
    }

    [HttpGet("{titulo:alpha}")]
    public async Task<ActionResult<CategoriaResponse>> ObterPorTitulo(string titulo)
    {
        var categoria = await _categoriaService.ObterPorTituloAsync(titulo);
        if (categoria is null)
            return NotFound();

        var categoriaResponse = CategoriaMap.ConverterParaResponse(categoria);
        return Ok(categoriaResponse);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Inserir(InsercaoCategoriaRequest insercaoCategoria)
    {
        var categoria = CategoriaMap.ConverterParaEntidade(insercaoCategoria);
        var id = (int)await _categoriaService.AdicionarAsync(categoria);
        return CreatedAtAction(nameof(ObterPorId), new { id = id }, id);
    }

    [HttpPut]
    public async Task<ActionResult> Atualizar(AtualizacaoCategoriaRequest atualizacaoCategoria)
    {
        var categoria = CategoriaMap.ConverterParaEntidade(atualizacaoCategoria);
        await _categoriaService.AtualizarAsync(categoria);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Remover(int id)
    {  
        await _categoriaService.RemoverPorIdAsync(id);
        return NoContent();
    }

}
