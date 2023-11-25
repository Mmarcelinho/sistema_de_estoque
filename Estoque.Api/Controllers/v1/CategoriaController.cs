using Carter;
using Estoque.Domain.Interfaces.Service;
using Estoque.Application.DTOs.Entities;
using Estoque.Application.DTOs.Mappings;

namespace Estoque.Api.Controllers.v1;

public class CategoriaEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/categorias");
        group.MapGet("", ObterTodos).WithName(nameof(ObterTodos));
        group.MapGet("{id:int}", ObterPorId).WithName(nameof(ObterPorId));
        group.MapGet("{titulo:alpha}", ObterPorTitulo).WithName(nameof(ObterPorTitulo));
        group.MapPost("", Inserir).WithName(nameof(Inserir));
        group.MapPut("", Atualizar).WithName(nameof(Atualizar));
        group.MapDelete("{id:int}", Remover).WithName(nameof(Remover));
    }

    public static async Task<IResult> ObterTodos(ICategoriaService _categoriaService)
    {
        var categorias = await _categoriaService.ObterTodosAsync();
        var categoriasResponse = categorias.Select(categoria => categoria.ConverterParaResponse());
        return Results.Ok(categoriasResponse);
    }

    public static async Task<IResult> ObterPorId(
    int id,
    ICategoriaService _categoriaService)
    {
        var categoria = await _categoriaService.ObterPorIdAsync(id);
        if (categoria is null)
            return Results.NotFound();

        var categoriaResponse = CategoriaMap.ConverterParaResponse(categoria);
        return Results.Ok(categoriaResponse);
    }

    public static async Task<IResult> ObterPorTitulo(
    string titulo,
    ICategoriaService _categoriaService)
    {
        var categoria = await _categoriaService.ObterPorTituloAsync(titulo);
        if (categoria is null)
            return Results.NotFound();

        var categoriaResponse = CategoriaMap.ConverterParaResponse(categoria);
        return Results.Ok(categoriaResponse);
    }

    public static async Task<IResult> Inserir(InsercaoCategoriaRequest insercaoCategoria,
    ICategoriaService _categoriaService)
    {
        var categoria = CategoriaMap.ConverterParaEntidade(insercaoCategoria);
        var id = (int)await _categoriaService.AdicionarAsync(categoria);
        return Results.CreatedAtRoute(nameof(ObterPorId), new { id = id }, id);
    }


    public static async Task<IResult> Atualizar(AtualizacaoCategoriaRequest atualizacaoCategoria,
    ICategoriaService _categoriaService)
    {
        var categoria = CategoriaMap.ConverterParaEntidade(atualizacaoCategoria);
        await _categoriaService.AtualizarAsync(categoria);
        return Results.NoContent();
    }

    public static async Task<IResult> Remover(
    int id,
    ICategoriaService _categoriaService)
    {
        await _categoriaService.RemoverPorIdAsync(id);
        return Results.NoContent();
    }
}
