using Carter;
using Estoque.Domain.Interfaces.Service;
using Estoque.Application.DTOs.Entities;
using Estoque.Application.DTOs.Mappings;

namespace Estoque.Api.Endpoints.v1;

public class TransportadoraEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/transportadoras");

        group.MapGet("", ObterTransportadoras)
        .Produces<TransportadoraResponse>(StatusCodes.Status200OK)
        .Produces<TransportadoraResponse>(StatusCodes.Status404NotFound)
        .WithName(nameof(ObterTransportadoras));

        group.MapGet("{id:int}", ObterTransportadoraPorId)
        .Produces<TransportadoraResponse>(StatusCodes.Status200OK)
        .Produces<TransportadoraResponse>(StatusCodes.Status404NotFound)
        .WithName(nameof(ObterTransportadoraPorId));

        group.MapGet("cidade/transportadoras/{id:int}", ObterPorIdTransportadorasDeCidade)
        .Produces<TransportadoraResponse>(StatusCodes.Status200OK)
        .Produces<TransportadoraResponse>(StatusCodes.Status404NotFound)
        .WithName(nameof(ObterPorIdTransportadorasDeCidade));

        group.MapPost("", InserirTransportadora)
        .Produces<TransportadoraResponse>(StatusCodes.Status201Created)
        .Produces<TransportadoraResponse>(StatusCodes.Status400BadRequest)
        .WithName(nameof(InserirTransportadora));

        group.MapPut("", AtualizarTransportadora)
        .Produces<TransportadoraResponse>(StatusCodes.Status204NoContent)
        .Produces<TransportadoraResponse>(StatusCodes.Status400BadRequest)
        .WithName(nameof(AtualizarTransportadora));

        group.MapDelete("{id:int}", RemoverTransportadora)
        .Produces<TransportadoraResponse>(StatusCodes.Status204NoContent)
        .Produces<TransportadoraResponse>(StatusCodes.Status400BadRequest)
        .WithName(nameof(RemoverTransportadora));
    }

    public static async Task<IResult> ObterTransportadoras(
    ITransportadoraService _transportadoraService)
    {
        var transportadoras = await _transportadoraService.ObterTodosAsync();

        var transportadorasResponse = transportadoras.Select(transportadora => 
        transportadora.ConverterParaResponse());

        return Results.Ok(transportadorasResponse);
    }

    public static async Task<IResult> ObterTransportadoraPorId(
    int id,
    ITransportadoraService _transportadoraService)
    {
        var transportadora = await _transportadoraService.ObterPorIdAsync(id);

        if (transportadora is null)
            return Results.NotFound();

        var transportadoraResponse = TransportadoraMap.ConverterParaResponse(transportadora);

        return Results.Ok(transportadoraResponse);
    }

    public static async Task<IResult> ObterPorIdTransportadorasDeCidade(
    int id,
    ITransportadoraService _transportadoraService)
    {
        var transportadoras = await _transportadoraService.ObterPorIdTransportadorasDeCidadeAsync(id);

         var transportadorasResponse = transportadoras.Select(transportadora => 
         transportadora.ConverterParaResponse());

        return Results.Ok(transportadorasResponse);
    }

    public static async Task<IResult> InserirTransportadora(
    InsercaoTransportadoraRequest insercaoTransportadora,
    ITransportadoraService _transportadoraService)
    {
        var transportadora = TransportadoraMap.ConverterParaEntidade(insercaoTransportadora);

        var id = (int)await _transportadoraService.AdicionarAsync(transportadora);

        return Results.CreatedAtRoute(nameof(ObterTransportadoraPorId), new { id = id }, id);
    }


    public static async Task<IResult> AtualizarTransportadora(
    AtualizacaoTransportadoraRequest atualizacaoTransportadora,
    ITransportadoraService _transportadoraService)
    {
        var transportadora = TransportadoraMap.ConverterParaEntidade(atualizacaoTransportadora);

        await _transportadoraService.AtualizarAsync(transportadora);

        return Results.NoContent();
    }

    public static async Task<IResult> RemoverTransportadora(
    int id,
    ITransportadoraService _transportadoraService)
    {
        await _transportadoraService.RemoverPorIdAsync(id);

        return Results.NoContent();
    }
}
