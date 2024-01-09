using Carter;
using Estoque.Domain.Interfaces.Service;
using Estoque.Application.DTOs.Entities;
using Estoque.Application.DTOs.Mappings;

namespace Estoque.Api.Endpoints.v1;

public class SaidaEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/saidas");

        group.MapGet("", ObterSaidas)
        .Produces<SaidaResponse>(StatusCodes.Status200OK)
        .Produces<SaidaResponse>(StatusCodes.Status404NotFound)
        .WithName(nameof(ObterSaidas));

        group.MapGet("{id:int}", ObterSaidaPorId)
        .Produces<SaidaResponse>(StatusCodes.Status200OK)
        .Produces<SaidaResponse>(StatusCodes.Status404NotFound)
        .WithName(nameof(ObterSaidaPorId));

        group.MapGet("/transportadora/saidas/{id:int}", ObterPorIdSaidasDeTransportadora)
        .Produces<SaidaResponse>(StatusCodes.Status200OK)
        .Produces<SaidaResponse>(StatusCodes.Status404NotFound)
        .WithName(nameof(ObterPorIdSaidasDeTransportadora));

        group.MapGet("/transportadora/saidas/{nome:alpha}", ObterPorNomeSaidasDeTransportadora)
        .Produces<SaidaResponse>(StatusCodes.Status200OK)
        .Produces<SaidaResponse>(StatusCodes.Status404NotFound)
        .WithName(nameof(ObterPorNomeSaidasDeTransportadora));

        group.MapGet("/loja/saidas/{id:int}", ObterPorIdSaidasDeLoja)
        .Produces<SaidaResponse>(StatusCodes.Status200OK)
        .Produces<SaidaResponse>(StatusCodes.Status404NotFound)
        .WithName(nameof(ObterPorIdSaidasDeLoja));

        group.MapGet("/loja/saidas/{nome:alpha}", ObterPorNomeSaidasDeLoja)
        .Produces<SaidaResponse>(StatusCodes.Status200OK)
        .Produces<SaidaResponse>(StatusCodes.Status404NotFound)
        .WithName(nameof(ObterPorNomeSaidasDeLoja));

        group.MapPost("", InserirSaida)
        .Produces<SaidaResponse>(StatusCodes.Status201Created)
        .Produces<SaidaResponse>(StatusCodes.Status400BadRequest)
        .WithName(nameof(InserirSaida));

        group.MapPut("", AtualizarSaida)
        .Produces<SaidaResponse>(StatusCodes.Status204NoContent)
        .Produces<SaidaResponse>(StatusCodes.Status400BadRequest)
        .WithName(nameof(AtualizarSaida));

        group.MapDelete("{id:int}", RemoverSaida)
        .Produces<SaidaResponse>(StatusCodes.Status204NoContent)
        .Produces<SaidaResponse>(StatusCodes.Status400BadRequest)
        .WithName(nameof(RemoverSaida));
    }

    public static async Task<IResult> ObterSaidas(ISaidaService _saidaService)
    {
        var saidas = await _saidaService.ObterTodosAsync();

        var saidasResponse = saidas.Select(saida =>
        saida.ConverterParaResponse());

        return Results.Ok(saidasResponse);
    }

    public static async Task<IResult> ObterSaidaPorId(
    int id,
    ISaidaService _saidaService)
    {
        var saida = await _saidaService.ObterPorIdAsync(id);

        if (saida is null)
            return Results.NotFound();

        var saidaResponse = SaidaMap.ConverterParaResponse(saida);
        return Results.Ok(saidaResponse);
    }

    public static async Task<IResult> ObterPorIdSaidasDeTransportadora(
    int id,
    ISaidaService _saidaService)
    {
        var saidas = await _saidaService.ObterPorIdSaidasDeTransportadoraAsync(id);

        var saidasResponse = saidas.Select(saida =>
       saida.ConverterParaResponse());

        return Results.Ok(saidasResponse);
    }

    public static async Task<IResult> ObterPorNomeSaidasDeTransportadora(
    string nome,
    ISaidaService _saidaService)
    {
        var saidas = await _saidaService.ObterPorNomeSaidasDeTransportadoraAsync(nome);

        var saidasResponse = saidas.Select(saida =>
       saida.ConverterParaResponse());

        return Results.Ok(saidasResponse);
    }

    public static async Task<IResult> ObterPorIdSaidasDeLoja(
   int id,
   ISaidaService _saidaService)
    {
        var saidas = await _saidaService.ObterPorIdSaidasDeLojaAsync(id);

        var saidasResponse = saidas.Select(saida =>
       saida.ConverterParaResponse());

        return Results.Ok(saidasResponse);
    }

    public static async Task<IResult> ObterPorNomeSaidasDeLoja(
    string nome,
    ISaidaService _saidaService)
    {
        var saidas = await _saidaService.ObterPorNomeSaidasDeLojaAsync(nome);

        var saidasResponse = saidas.Select(saida =>
       saida.ConverterParaResponse());

        return Results.Ok(saidasResponse);
    }

    public static async Task<IResult> InserirSaida(
    InsercaoSaidaRequest insercaoSaida,
    ISaidaService _saidaService)
    {
        var saida = SaidaMap.ConverterParaEntidade(insercaoSaida);

        var id = (int)await _saidaService.AdicionarAsync(saida);

        return Results.CreatedAtRoute(nameof(ObterSaidaPorId), new { id = id }, id);
    }


    public static async Task<IResult> AtualizarSaida(
    AtualizacaoSaidaRequest atualizacaoSaida,
    ISaidaService _saidaService)
    {
        var saida = SaidaMap.ConverterParaEntidade(atualizacaoSaida);

        await _saidaService.AtualizarAsync(saida);

        return Results.NoContent();
    }

    public static async Task<IResult> RemoverSaida(
    int id,
    ISaidaService _saidaService)
    {
        await _saidaService.RemoverPorIdAsync(id);

        return Results.NoContent();
    }
}
