using Carter;
using Estoque.Domain.Interfaces.Service;
using Estoque.Application.DTOs.Entities;
using Estoque.Application.DTOs.Mappings;

namespace Estoque.Api.Endpoints.v1;

public class CategoriaEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/categorias");

        group.MapGet("", ObterCategorias)
        .Produces<CategoriaResponse>(StatusCodes.Status200OK)
        .Produces<CategoriaResponse>(StatusCodes.Status404NotFound)
        .WithName(nameof(ObterCategorias));

        group.MapGet("{id:int}", ObterCategoriaPorId)
         .Produces<CategoriaResponse>(StatusCodes.Status200OK)
        .Produces<CategoriaResponse>(StatusCodes.Status404NotFound)
        .WithName(nameof(ObterCategoriaPorId));

        group.MapGet("{titulo:alpha}", ObterCategoriaPorTitulo)
        .Produces<CategoriaResponse>(StatusCodes.Status200OK)
        .Produces<CategoriaResponse>(StatusCodes.Status404NotFound)
        .WithName(nameof(ObterCategoriaPorTitulo));

        group.MapPost("", InserirCategoria)
        .Produces<CategoriaResponse>(StatusCodes.Status201Created)
        .Produces<CategoriaResponse>(StatusCodes.Status400BadRequest)
        .WithName(nameof(InserirCategoria));

        group.MapPut("", AtualizarCategoria)
        .Produces<CategoriaResponse>(StatusCodes.Status204NoContent)
        .Produces<CategoriaResponse>(StatusCodes.Status400BadRequest)
        .WithName(nameof(AtualizarCategoria));

        group.MapDelete("{id:int}", RemoverCategoria)
        .Produces<CategoriaResponse>(StatusCodes.Status204NoContent)
        .Produces<CategoriaResponse>(StatusCodes.Status400BadRequest)
        .WithName(nameof(RemoverCategoria));
    }

    public static async Task<IResult> ObterCategorias(
    ICategoriaService _categoriaService)
    {
        var categorias = await _categoriaService.ObterTodosAsync();

        var categoriasResponse = categorias.Select(categoria => 
        categoria.ConverterParaResponse());

        return Results.Ok(categoriasResponse);
    }

    public static async Task<IResult> ObterCategoriaPorId(
    int id,
    ICategoriaService _categoriaService)
    {
        var categoria = await _categoriaService.ObterPorIdAsync(id);

        if (categoria is null)
            return Results.NotFound();

        var categoriaResponse = CategoriaMap.ConverterParaResponse(categoria);

        return Results.Ok(categoriaResponse);
    }

    public static async Task<IResult> ObterCategoriaPorTitulo(
    string titulo,
    ICategoriaService _categoriaService)
    {
        var categoria = await _categoriaService.ObterPorTituloAsync(titulo);

        if (categoria is null)
            return Results.NotFound();

        var categoriaResponse = CategoriaMap.ConverterParaResponse(categoria);

        return Results.Ok(categoriaResponse);
    }

    public static async Task<IResult> InserirCategoria(
    InsercaoCategoriaRequest insercaoCategoria,
    ICategoriaService _categoriaService)
    {
        var categoria = CategoriaMap.ConverterParaEntidade(insercaoCategoria);

        var id = (int)await _categoriaService.AdicionarAsync(categoria);

        return Results.CreatedAtRoute(nameof(ObterCategoriaPorId), new { id = id }, id);
    }


    public static async Task<IResult> AtualizarCategoria(
    AtualizacaoCategoriaRequest atualizacaoCategoria,
    ICategoriaService _categoriaService)
    {
        var categoria = CategoriaMap.ConverterParaEntidade(atualizacaoCategoria);

        await _categoriaService.AtualizarAsync(categoria);

        return Results.NoContent();
    }

    public static async Task<IResult> RemoverCategoria(
    int id,
    ICategoriaService _categoriaService)
    {
        await _categoriaService.RemoverPorIdAsync(id);
        
        return Results.NoContent();
    }
}
