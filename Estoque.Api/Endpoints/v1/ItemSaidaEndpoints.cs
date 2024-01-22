using Carter;
using Estoque.Domain.Interfaces.Service;
using Estoque.Application.DTOs.Entities;
using Estoque.Application.DTOs.Mappings;
using MiniValidation;

namespace Estoque.Api.Endpoints.v1;

public class ItemSaidaEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/itemSaidas");

        group.MapGet("", ObterItemSaidas)
        .Produces<ItemSaidaResponse>(StatusCodes.Status200OK)
        .Produces<ItemSaidaResponse>(StatusCodes.Status404NotFound)
        .WithName(nameof(ObterItemSaidas));

        group.MapGet("{id:int}", ObterItemSaidaPorId)
        .Produces<ItemSaidaResponse>(StatusCodes.Status200OK)
        .Produces<ItemSaidaResponse>(StatusCodes.Status404NotFound)
        .WithName(nameof(ObterItemSaidaPorId));

        group.MapGet("saida/itemSaidas/{id:int}", ObterPorIdItemSaidasDeSaida)
        .Produces<ItemSaidaResponse>(StatusCodes.Status200OK)
        .Produces<ItemSaidaResponse>(StatusCodes.Status404NotFound)
        .WithName(nameof(ObterPorIdItemSaidasDeSaida));

        group.MapGet("produto/itemSaidas/{id:int}", ObterPorIdItemSaidasDeProduto)
        .Produces<ItemSaidaResponse>(StatusCodes.Status200OK)
        .Produces<ItemSaidaResponse>(StatusCodes.Status404NotFound)
        .WithName(nameof(ObterPorIdItemSaidasDeProduto));

        group.MapPost("", InserirItemSaida)
        .Produces<ItemSaidaResponse>(StatusCodes.Status201Created)
        .Produces<ItemSaidaResponse>(StatusCodes.Status400BadRequest)
        .WithName(nameof(InserirItemSaida));

        group.MapPut("", AtualizarItemSaida)
        .Produces<ItemSaidaResponse>(StatusCodes.Status204NoContent)
        .Produces<ItemSaidaResponse>(StatusCodes.Status400BadRequest)
        .WithName(nameof(AtualizarItemSaida));

        group.MapDelete("{id:int}", RemoverItemSaida)
        .Produces<ItemSaidaResponse>(StatusCodes.Status204NoContent)
        .Produces<ItemSaidaResponse>(StatusCodes.Status400BadRequest)
        .WithName(nameof(RemoverItemSaida));
    }

    public static async Task<IResult> ObterItemSaidas(
    IItemSaidaService _itemSaidaService)
    {
        var itemSaidas = await _itemSaidaService.ObterTodosAsync();

        var itemSaidasResponse = itemSaidas.Select(itemSaida => 
        itemSaida.ConverterParaResponse());

        return Results.Ok(itemSaidasResponse);
    }

    public static async Task<IResult> ObterItemSaidaPorId(
    int id,
    IItemSaidaService _itemSaidaService)
    {
        var itemSaida = await _itemSaidaService.ObterPorIdAsync(id);

        if (itemSaida is null)
            return Results.NotFound();

        var itemSaidaResponse = ItemSaidaMap.ConverterParaResponse(itemSaida);

        return Results.Ok(itemSaidaResponse);
    }

    public static async Task<IResult> ObterPorIdItemSaidasDeSaida(
    int id,
    IItemSaidaService _itemSaidaService)
    {
        var itemSaidas = await _itemSaidaService.ObterPorIdItemSaidasDeSaidaAsync(id);

         var itemSaidasResponse = itemSaidas.Select(itemSaida => 
         itemSaida.ConverterParaResponse());

        return Results.Ok(itemSaidasResponse);
    }

    public static async Task<IResult> ObterPorIdItemSaidasDeProduto(
    int id,
    IItemSaidaService _itemSaidaService)
    {
        var itemSaidas = await _itemSaidaService.ObterPorIdItemSaidasDeProdutoAsync(id);

         var itemSaidasResponse = itemSaidas.Select(itemSaida => 
         itemSaida.ConverterParaResponse());

        return Results.Ok(itemSaidasResponse);
    }

    public static async Task<IResult> InserirItemSaida(
    InsercaoItemSaidaRequest insercaoItemSaida,
    IItemSaidaService _itemSaidaService)
    {
        if (!MiniValidator.TryValidate(insercaoItemSaida, out var errors))
            return Results.ValidationProblem(errors);

        var itemSaida = ItemSaidaMap.ConverterParaEntidade(insercaoItemSaida);

        var id = (int)await _itemSaidaService.AdicionarAsync(itemSaida);

        return Results.CreatedAtRoute(nameof(ObterItemSaidaPorId), new { id = id }, id);
    }


    public static async Task<IResult> AtualizarItemSaida(
    AtualizacaoItemSaidaRequest atualizacaoItemSaida,
    IItemSaidaService _itemSaidaService)
    {
        if (!MiniValidator.TryValidate(atualizacaoItemSaida, out var errors))
            return Results.ValidationProblem(errors);

        var itemSaida = ItemSaidaMap.ConverterParaEntidade(atualizacaoItemSaida);

        await _itemSaidaService.AtualizarAsync(itemSaida);

        return Results.NoContent();
    }

    public static async Task<IResult> RemoverItemSaida(
    int id,
    IItemSaidaService _itemSaidaService)
    {
        await _itemSaidaService.RemoverPorIdAsync(id);

        return Results.NoContent();
    }
}
