using Carter;
using Estoque.Domain.Interfaces.Service;
using Estoque.Domain.Entities;
using Estoque.Application.DTOs.Entities;
using Estoque.Application.DTOs.Mappings;

namespace Estoque.Api.Endpoints.v1;

public class CidadeEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/cidades");

        group.MapGet("", ObterCidades)
        .Produces<CidadeResponse>(StatusCodes.Status200OK)
        .Produces<CidadeResponse>(StatusCodes.Status404NotFound)
        .WithName(nameof(ObterCidades));

        group.MapGet("{id:int}", ObterCidadePorId)
       .Produces<CidadeResponse>(StatusCodes.Status200OK)
       .Produces<CidadeResponse>(StatusCodes.Status404NotFound)
       .WithName(nameof(ObterCidadePorId));

        group.MapGet("{nome:alpha}", ObterCidadePorNome)
        .Produces<CidadeResponse>(StatusCodes.Status200OK)
        .Produces<CidadeResponse>(StatusCodes.Status404NotFound)
        .WithName(nameof(ObterCidadePorNome));

        group.MapPost("", InserirCidade)
        .Produces<CidadeResponse>(StatusCodes.Status201Created)
        .Produces<CidadeResponse>(StatusCodes.Status400BadRequest)
        .WithName(nameof(InserirCidade));

        group.MapPut("", AtualizarCidade)
        .Produces<CidadeResponse>(StatusCodes.Status204NoContent)
        .Produces<CidadeResponse>(StatusCodes.Status400BadRequest)
        .WithName(nameof(AtualizarCidade));

        group.MapDelete("{id:int}", RemoverCidade)
        .Produces<CidadeResponse>(StatusCodes.Status204NoContent)
        .Produces<CidadeResponse>(StatusCodes.Status400BadRequest)
        .WithName(nameof(RemoverCidade));
    }

    public static async Task<IResult> ObterCidades(
    ICidadeService _cidadeService)
    {
        var cidades = await _cidadeService.ObterTodosAsync();

        var cidadesResponse = cidades.Select(cidades =>
        cidades.ConverterParaResponse());

        return Results.Ok(cidadesResponse);
    }

    public static async Task<IResult> ObterCidadePorId(
    int id,
    ICidadeService _cidadeService)
    {
        var cidade = await _cidadeService.ObterPorIdAsync(id);

        if (cidade is null)
            return Results.NotFound();

        var cidadeResponse = CidadeMap.ConverterParaResponse(cidade);

        return Results.Ok(cidadeResponse);
    }

    public static async Task<IResult> ObterCidadePorNome(
    string nome,
    ICidadeService _cidadeService)
    {
        var cidade = await _cidadeService.ObterPorNomeAsync(nome);

        if (cidade is null)
            return Results.NotFound();

        var cidadeResponse = CidadeMap.ConverterParaResponse(cidade);

        return Results.Ok(cidadeResponse);
    }

    public static async Task<IResult> InserirCidade(
    InsercaoCidadeRequest insercaoCidade,
    ICidadeService _cidadeService)
    {
        var cidade = CidadeMap.ConverterParaEntidade(insercaoCidade);

        var id = (int)await _cidadeService.AdicionarAsync(cidade);

        return Results.CreatedAtRoute(nameof(ObterCidadePorId), new { id = id }, id);
    }

    public static async Task<IResult> AtualizarCidade(
    AtualizacaoCidadeRequest atualizacaoCidade,
    ICidadeService _cidadeService)
    {
        var cidade = CidadeMap.ConverterParaEntidade(atualizacaoCidade);

        await _cidadeService.AtualizarAsync(cidade);

        return Results.NoContent();
    }

    public static async Task<IResult> RemoverCidade(
    int id,
    ICidadeService _cidadeService)
    {
        await _cidadeService.RemoverPorIdAsync(id);

        return Results.NoContent();
    }

}
