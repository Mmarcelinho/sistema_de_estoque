using Carter;
using Estoque.Domain.Interfaces.Service;
using Estoque.Domain.Entities;
using Estoque.Application.DTOs.Entities;
using Estoque.Application.DTOs.Mappings;

namespace Estoque.Api.Endpoints.v1;

public class ProdutoEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/produtos");

        group.MapGet("", ObterProdutos)
        .Produces<ProdutoResponse>(StatusCodes.Status200OK)
        .Produces<ProdutoResponse>(StatusCodes.Status404NotFound)
        .WithName(nameof(ObterProdutos));

        group.MapGet("{id:int}", ObterProdutoPorId)
       .Produces<ProdutoResponse>(StatusCodes.Status200OK)
       .Produces<ProdutoResponse>(StatusCodes.Status404NotFound)
       .WithName(nameof(ObterProdutoPorId));

        group.MapGet("{nome:alpha}", ObterProdutoPorNome)
        .Produces<ProdutoResponse>(StatusCodes.Status200OK)
        .Produces<ProdutoResponse>(StatusCodes.Status404NotFound)
        .WithName(nameof(ObterProdutoPorNome));

        group.MapPost("", InserirProduto)
        .Produces<ProdutoResponse>(StatusCodes.Status201Created)
        .Produces<ProdutoResponse>(StatusCodes.Status400BadRequest)
        .WithName(nameof(InserirProduto));

        group.MapPut("", AtualizarProduto)
        .Produces<ProdutoResponse>(StatusCodes.Status204NoContent)
        .Produces<ProdutoResponse>(StatusCodes.Status400BadRequest)
        .WithName(nameof(AtualizarProduto));

        group.MapDelete("{id:int}", RemoverProduto)
        .Produces<ProdutoResponse>(StatusCodes.Status204NoContent)
        .Produces<ProdutoResponse>(StatusCodes.Status400BadRequest)
        .WithName(nameof(RemoverProduto));
    }

    public static async Task<IResult> ObterProdutos(
    IProdutoService _produtoService)
    {
        var produtos = await _produtoService.ObterTodosAsync();

        var produtosResponse = produtos.Select(produtos =>
        produtos.ConverterParaResponse());

        return Results.Ok(produtosResponse);
    }

    public static async Task<IResult> ObterProdutoPorId(
    int id,
    IProdutoService _produtoService)
    {
        var produto = await _produtoService.ObterPorIdAsync(id);

        if (produto is null)
            return Results.NotFound();

        var produtoResponse = ProdutoMap.ConverterParaResponse(produto);

        return Results.Ok(produtoResponse);
    }

    public static async Task<IResult> ObterProdutoPorNome(
    string nome,
    IProdutoService _produtoService)
    {
        var produto = await _produtoService.ObterPorNomeAsync(nome);

        if (produto is null)
            return Results.NotFound();

        var produtoResponse = ProdutoMap.ConverterParaResponse(produto);

        return Results.Ok(produtoResponse);
    }

    public static async Task<IResult> InserirProduto(
    InsercaoProdutoRequest insercaoProduto,
    IProdutoService _produtoService)
    {
        var produto = ProdutoMap.ConverterParaEntidade(insercaoProduto);

        var id = (int)await _produtoService.AdicionarAsync(produto);

        return Results.CreatedAtRoute(nameof(ObterProdutoPorId), new { id = id }, id);
    }

    public static async Task<IResult> AtualizarProduto(
    AtualizacaoProdutoRequest atualizacaoProduto,
    IProdutoService _produtoService)
    {
        var produto = ProdutoMap.ConverterParaEntidade(atualizacaoProduto);

        await _produtoService.AtualizarAsync(produto);

        return Results.NoContent();
    }

    public static async Task<IResult> RemoverProduto(
    int id,
    IProdutoService _produtoService)
    {
        await _produtoService.RemoverPorIdAsync(id);

        return Results.NoContent();
    }

}
