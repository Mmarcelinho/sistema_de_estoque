using Carter;
using Estoque.Domain.Interfaces.Service;
using Estoque.Application.DTOs.Entities;
using Estoque.Application.DTOs.Mappings;

namespace Estoque.Api.Endpoints.v1;

public class LojaEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/Lojas");

        group.MapGet("", ObterLojas)
        .Produces<LojaResponse>(StatusCodes.Status200OK)
        .Produces<LojaResponse>(StatusCodes.Status404NotFound)
        .WithName(nameof(ObterLojas));

        group.MapGet("{id:int}", ObterLojaPorId)
        .Produces<LojaResponse>(StatusCodes.Status200OK)
        .Produces<LojaResponse>(StatusCodes.Status404NotFound)
        .WithName(nameof(ObterLojaPorId));

        group.MapGet("{nome:alpha}", ObterLojaPorNome)
        .Produces<LojaResponse>(StatusCodes.Status200OK)
        .Produces<LojaResponse>(StatusCodes.Status404NotFound)
        .WithName(nameof(ObterLojaPorNome));

        group.MapGet("cidade/lojas/{id:int}", ObterPorIdLojasDeCidade)
        .Produces<LojaResponse>(StatusCodes.Status200OK)
        .Produces<LojaResponse>(StatusCodes.Status404NotFound)
        .WithName(nameof(ObterPorIdLojasDeCidade));

        group.MapPost("", InserirLoja)
        .Produces<LojaResponse>(StatusCodes.Status201Created)
        .Produces<LojaResponse>(StatusCodes.Status400BadRequest)
        .WithName(nameof(InserirLoja));

        group.MapPut("", AtualizarLoja)
        .Produces<LojaResponse>(StatusCodes.Status204NoContent)
        .Produces<LojaResponse>(StatusCodes.Status400BadRequest)
        .WithName(nameof(AtualizarLoja));

        group.MapDelete("{id:int}", RemoverLoja)
        .Produces<LojaResponse>(StatusCodes.Status204NoContent)
        .Produces<LojaResponse>(StatusCodes.Status400BadRequest)
        .WithName(nameof(RemoverLoja));
    }

    public static async Task<IResult> ObterLojas(
    ILojaService _lojaService)
    {
        var lojas = await _lojaService.ObterTodosAsync();

        var lojasResponse = lojas.Select(loja => 
        loja.ConverterParaResponse());

        return Results.Ok(lojasResponse);
    }

    public static async Task<IResult> ObterLojaPorId(
    int id,
    ILojaService _lojaService)
    {
        var loja = await _lojaService.ObterPorIdAsync(id);

        if (loja is null)
            return Results.NotFound();

        var lojaResponse = LojaMap.ConverterParaResponse(loja);

        return Results.Ok(lojaResponse);
    }

    public static async Task<IResult> ObterLojaPorNome(
    string nome,
    ILojaService _lojaService)
    {
        var loja = await _lojaService.ObterPorNomeAsync(nome);

        if (loja is null)
            return Results.NotFound();

        var lojaResponse = LojaMap.ConverterParaResponse(loja);

        return Results.Ok(lojaResponse);
    }

    public static async Task<IResult> ObterPorIdLojasDeCidade(
    int id,
    ILojaService _LojaService)
    {
        var lojas = await _LojaService.ObterPorIdLojasDeCidadeAsync(id);

#pragma warning disable CS8604 // Possível argumento de referência nula.
         var lojasResponse = lojas.Select(loja => 
         loja.ConverterParaResponse());
#pragma warning restore CS8604 // Possível argumento de referência nula.

        return Results.Ok(lojasResponse);
    }

    public static async Task<IResult> InserirLoja(
    InsercaoLojaRequest insercaoLoja,
    ILojaService _lojaService)
    {
        var loja = LojaMap.ConverterParaEntidade(insercaoLoja);

        var id = (int)await _lojaService.AdicionarAsync(loja);

        return Results.CreatedAtRoute(nameof(ObterLojaPorId), new { id = id }, id);
    }


    public static async Task<IResult> AtualizarLoja(
    AtualizacaoLojaRequest atualizacaoLoja,
    ILojaService _lojaService)
    {
        var loja = LojaMap.ConverterParaEntidade(atualizacaoLoja);

        await _lojaService.AtualizarAsync(loja);

        return Results.NoContent();
    }

    public static async Task<IResult> RemoverLoja(
    int id,
    ILojaService _lojaService)
    {
        await _lojaService.RemoverPorIdAsync(id);

        return Results.NoContent();
    }
}
