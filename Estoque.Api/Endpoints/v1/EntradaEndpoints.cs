using Carter;
using Estoque.Domain.Interfaces.Service;
using Estoque.Application.DTOs.Entities;
using Estoque.Application.DTOs.Mappings;

namespace Estoque.Api.Endpoints.v1;

public class EntradaEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/entradas");

        group.MapGet("", ObterEntradas)
        .Produces<EntradaResponse>(StatusCodes.Status200OK)
        .Produces<EntradaResponse>(StatusCodes.Status404NotFound)
        .WithName(nameof(ObterEntradas));

        group.MapGet("{id:int}", ObterEntradaPorId)
         .Produces<EntradaResponse>(StatusCodes.Status200OK)
        .Produces<EntradaResponse>(StatusCodes.Status404NotFound)
        .WithName(nameof(ObterEntradaPorId));

        group.MapGet("/transportadora/entradas/{id:int}", ObterPorIdEntradasDeTransportadora)
         .Produces<EntradaResponse>(StatusCodes.Status200OK)
        .Produces<EntradaResponse>(StatusCodes.Status404NotFound)
        .WithName(nameof(ObterPorIdEntradasDeTransportadora));

        group.MapPost("", InserirEntrada)
        .Produces<EntradaResponse>(StatusCodes.Status201Created)
        .Produces<EntradaResponse>(StatusCodes.Status400BadRequest)
        .WithName(nameof(InserirEntrada));

        group.MapPut("", AtualizarEntrada)
        .Produces<EntradaResponse>(StatusCodes.Status204NoContent)
        .Produces<EntradaResponse>(StatusCodes.Status400BadRequest)
        .WithName(nameof(AtualizarEntrada));

        group.MapDelete("{id:int}", RemoverEntrada)
        .Produces<EntradaResponse>(StatusCodes.Status204NoContent)
        .Produces<EntradaResponse>(StatusCodes.Status400BadRequest)
        .WithName(nameof(RemoverEntrada));
    }

    public static async Task<IResult> ObterEntradas(IEntradaService _entradaService)
    {
        var entradas = await _entradaService.ObterTodosAsync();

        var entradasResponse = entradas.Select(entrada => 
        entrada.ConverterParaResponse());

        return Results.Ok(entradasResponse);
    }

    public static async Task<IResult> ObterEntradaPorId(
    int id,
    IEntradaService _entradaService)
    {
        var entrada = await _entradaService.ObterPorIdAsync(id);

        if (entrada is null)
            return Results.NotFound();

        var entradaResponse = EntradaMap.ConverterParaResponse(entrada);
        return Results.Ok(entradaResponse);
    }

    public static async Task<IResult> ObterPorIdEntradasDeTransportadora(
    int id,
    IEntradaService _entradaService)
    {
        var entradas = await _entradaService.ObterPorIdEntradasDeTransportadoraAsync(id);

         var entradasResponse = entradas.Select(entrada =>
        entrada.ConverterParaResponse());

        return Results.Ok(entradasResponse);
    }

    public static async Task<IResult> InserirEntrada(
    InsercaoEntradaRequest insercaoEntrada,
    IEntradaService _entradaService)
    {
        var entrada = EntradaMap.ConverterParaEntidade(insercaoEntrada);

        var id = (int)await _entradaService.AdicionarAsync(entrada);

        return Results.CreatedAtRoute(nameof(ObterEntradaPorId), new { id = id }, id);
    }


    public static async Task<IResult> AtualizarEntrada(
    AtualizacaoEntradaRequest atualizacaoEntrada,
    IEntradaService _entradaService)
    {
        var entrada = EntradaMap.ConverterParaEntidade(atualizacaoEntrada);

        await _entradaService.AtualizarAsync(entrada);

        return Results.NoContent();
    }

    public static async Task<IResult> RemoverEntrada(
    int id,
    IEntradaService _entradaService)
    {
        await _entradaService.RemoverPorIdAsync(id);

        return Results.NoContent();
    }
}
