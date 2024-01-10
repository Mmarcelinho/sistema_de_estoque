using Carter;
using Estoque.Domain.Interfaces.Service;
using Estoque.Application.DTOs.Entities;
using Estoque.Application.DTOs.Mappings;

namespace Estoque.Api.Endpoints.v1;

public class FornecedorEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/fornecedores");

        group.MapGet("", ObterFornecedores)
        .Produces<FornecedorResponse>(StatusCodes.Status200OK)
        .Produces<FornecedorResponse>(StatusCodes.Status404NotFound)
        .WithName(nameof(ObterFornecedores));

        group.MapGet("{id:int}", ObterFornecedorPorId)
        .Produces<FornecedorResponse>(StatusCodes.Status200OK)
        .Produces<FornecedorResponse>(StatusCodes.Status404NotFound)
        .WithName(nameof(ObterFornecedorPorId));

        group.MapGet("cidade/fornecedores/{id:int}", ObterPorIdFornecedoresDeCidade)
        .Produces<FornecedorResponse>(StatusCodes.Status200OK)
        .Produces<FornecedorResponse>(StatusCodes.Status404NotFound)
        .WithName(nameof(ObterPorIdFornecedoresDeCidade));

        group.MapPost("", InserirFornecedor)
        .Produces<FornecedorResponse>(StatusCodes.Status201Created)
        .Produces<FornecedorResponse>(StatusCodes.Status400BadRequest)
        .WithName(nameof(InserirFornecedor));

        group.MapPut("", AtualizarFornecedor)
        .Produces<FornecedorResponse>(StatusCodes.Status204NoContent)
        .Produces<FornecedorResponse>(StatusCodes.Status400BadRequest)
        .WithName(nameof(AtualizarFornecedor));

        group.MapDelete("{id:int}", RemoverFornecedor)
        .Produces<FornecedorResponse>(StatusCodes.Status204NoContent)
        .Produces<FornecedorResponse>(StatusCodes.Status400BadRequest)
        .WithName(nameof(RemoverFornecedor));
    }

    public static async Task<IResult> ObterFornecedores(
    IFornecedorService _fornecedorService)
    {
        var fornecedores = await _fornecedorService.ObterTodosAsync();

        var fornecedoresResponse = fornecedores.Select(fornecedor => 
        fornecedor.ConverterParaResponse());

        return Results.Ok(fornecedoresResponse);
    }

    public static async Task<IResult> ObterFornecedorPorId(
    int id,
    IFornecedorService _fornecedorService)
    {
        var fornecedor = await _fornecedorService.ObterPorIdAsync(id);

        if (fornecedor is null)
            return Results.NotFound();

        var fornecedorResponse = FornecedorMap.ConverterParaResponse(fornecedor);

        return Results.Ok(fornecedorResponse);
    }

    public static async Task<IResult> ObterPorIdFornecedoresDeCidade(
    int id,
    IFornecedorService _fornecedorService)
    {
        var fornecedores = await _fornecedorService.ObterPorIdFornecedoresDeCidadeAsync(id);

#pragma warning disable CS8604 // Possível argumento de referência nula.
         var fornecedoresResponse = fornecedores.Select(fornecedor => 
         fornecedor.ConverterParaResponse());
#pragma warning restore CS8604 // Possível argumento de referência nula.

        return Results.Ok(fornecedoresResponse);
    }

    public static async Task<IResult> InserirFornecedor(
    InsercaoFornecedorRequest insercaoFornecedor,
    IFornecedorService _fornecedorService)
    {
        var fornecedor = FornecedorMap.ConverterParaEntidade(insercaoFornecedor);

        var id = (int)await _fornecedorService.AdicionarAsync(fornecedor);

        return Results.CreatedAtRoute(nameof(ObterFornecedorPorId), new { id = id }, id);
    }


    public static async Task<IResult> AtualizarFornecedor(
    AtualizacaoFornecedorRequest atualizacaoFornecedor,
    IFornecedorService _fornecedorService)
    {
        var fornecedor = FornecedorMap.ConverterParaEntidade(atualizacaoFornecedor);

        await _fornecedorService.AtualizarAsync(fornecedor);

        return Results.NoContent();
    }

    public static async Task<IResult> RemoverFornecedor(
    int id,
    IFornecedorService _fornecedorService)
    {
        await _fornecedorService.RemoverPorIdAsync(id);

        return Results.NoContent();
    }
}
