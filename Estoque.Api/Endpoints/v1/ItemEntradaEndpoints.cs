using Carter;
using Estoque.Domain.Interfaces.Service;
using Estoque.Application.DTOs.Entities;
using Estoque.Application.DTOs.Mappings;
using MiniValidation;

namespace Estoque.Api.Endpoints.v1;

public class ItemEntradaEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/itemEntradas");

        group.MapGet("", ObterItemEntradas)
        .Produces<ItemEntradaResponse>(StatusCodes.Status200OK)
        .Produces<ItemEntradaResponse>(StatusCodes.Status404NotFound)
        .WithName(nameof(ObterItemEntradas));

        group.MapGet("{id:int}", ObterItemEntradaPorId)
        .Produces<ItemEntradaResponse>(StatusCodes.Status200OK)
        .Produces<ItemEntradaResponse>(StatusCodes.Status404NotFound)
        .WithName(nameof(ObterItemEntradaPorId));

        group.MapGet("Nf/{NumeroNotaFiscal:int}", ObterItemEntradaPorNf)
        .Produces<ItemEntradaResponse>(StatusCodes.Status200OK)
        .Produces<ItemEntradaResponse>(StatusCodes.Status404NotFound)
        .WithName(nameof(ObterItemEntradaPorNf));


         group.MapGet("entrada/itemEntradas/{id:int}", ObterPorIdItemEntradasDeEntrada)
        .Produces<ItemEntradaResponse>(StatusCodes.Status200OK)
        .Produces<ItemEntradaResponse>(StatusCodes.Status404NotFound)
        .WithName(nameof(ObterPorIdItemEntradasDeEntrada));

        group.MapGet("produto/itemEntradas/{id:int}", ObterPorIdItemEntradasDeProduto)
        .Produces<ItemEntradaResponse>(StatusCodes.Status200OK)
        .Produces<ItemEntradaResponse>(StatusCodes.Status404NotFound)
        .WithName(nameof(ObterPorIdItemEntradasDeProduto));

        group.MapPost("", InserirItemEntrada)
        .Produces<ItemEntradaResponse>(StatusCodes.Status201Created)
        .Produces<ItemEntradaResponse>(StatusCodes.Status400BadRequest)
        .WithName(nameof(InserirItemEntrada));

        group.MapPut("", AtualizarItemEntrada)
        .Produces<ItemEntradaResponse>(StatusCodes.Status204NoContent)
        .Produces<ItemEntradaResponse>(StatusCodes.Status400BadRequest)
        .WithName(nameof(AtualizarItemEntrada));

        group.MapDelete("{id:int}", RemoverItemEntrada)
        .Produces<ItemEntradaResponse>(StatusCodes.Status204NoContent)
        .Produces<ItemEntradaResponse>(StatusCodes.Status400BadRequest)
        .WithName(nameof(RemoverItemEntrada));
    }

    public static async Task<IResult> ObterItemEntradas(
    IItemEntradaService _itemEntradaService)
    {
        var itemEntradas = await _itemEntradaService.ObterTodosAsync();

        var itemEntradasResponse = itemEntradas.Select(itemEntrada => 
        itemEntrada.ConverterParaResponse());

        return Results.Ok(itemEntradasResponse);
    }

    public static async Task<IResult> ObterItemEntradaPorId(
    int id,
    IItemEntradaService _itemEntradaService)
    {
        var itemEntrada = await _itemEntradaService.ObterPorIdAsync(id);

        if (itemEntrada is null)
            return Results.NotFound();

        var itemEntradaResponse = ItemEntradaMap.ConverterParaResponse(itemEntrada);

        return Results.Ok(itemEntradaResponse);
    }

    public static async Task<IResult> ObterItemEntradaPorNf(
    int NumeroNotaFiscal,
    IItemEntradaService _itemEntradaService)
    {
        var itemEntrada = await _itemEntradaService.ObterPorIdAsync(NumeroNotaFiscal);

        if (itemEntrada is null)
            return Results.NotFound();

        var itemEntradaResponse = ItemEntradaMap.ConverterParaResponse(itemEntrada);

        return Results.Ok(itemEntradaResponse);
    }

    public static async Task<IResult> ObterPorIdItemEntradasDeEntrada(
    int id,
    IItemEntradaService _itemEntradaService)
    {
        var itemEntradas = await _itemEntradaService.ObterPorIdItemEntradasDeEntradaAsync(id);

         var itemEntradasResponse = itemEntradas.Select(itemEntrada => 
         itemEntrada.ConverterParaResponse());

        return Results.Ok(itemEntradasResponse);
    }

    public static async Task<IResult> ObterPorIdItemEntradasDeProduto(
    int id,
    IItemEntradaService _itemEntradaService)
    {
        var itemEntradas = await _itemEntradaService.ObterPorIdItemEntradasDeProdutoAsync(id);

         var itemEntradasResponse = itemEntradas.Select(itemEntrada => 
         itemEntrada.ConverterParaResponse());

        return Results.Ok(itemEntradasResponse);
    }

    public static async Task<IResult> InserirItemEntrada(
    InsercaoItemEntradaRequest insercaoItemEntrada,
    IItemEntradaService _itemEntradaService)
    {
        if (!MiniValidator.TryValidate(insercaoItemEntrada, out var errors))
            return Results.ValidationProblem(errors);

        var itemEntrada = ItemEntradaMap.ConverterParaEntidade(insercaoItemEntrada);

        var id = (int)await _itemEntradaService.AdicionarAsync(itemEntrada);

        return Results.CreatedAtRoute(nameof(ObterItemEntradaPorId), new { id = id }, id);
    }


    public static async Task<IResult> AtualizarItemEntrada(
    AtualizacaoItemEntradaRequest atualizacaoItemEntrada,
    IItemEntradaService _itemEntradaService)
    {
        if (!MiniValidator.TryValidate(atualizacaoItemEntrada, out var errors))
            return Results.ValidationProblem(errors);

        var itemEntrada = ItemEntradaMap.ConverterParaEntidade(atualizacaoItemEntrada);

        await _itemEntradaService.AtualizarAsync(itemEntrada);

        return Results.NoContent();
    }

    public static async Task<IResult> RemoverItemEntrada(
    int id,
    IItemEntradaService _itemEntradaService)
    {
        await _itemEntradaService.RemoverPorIdAsync(id);

        return Results.NoContent();
    }
}
