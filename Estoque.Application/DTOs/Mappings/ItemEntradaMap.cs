using Estoque.Application.DTOs.Entities;
using Estoque.Domain.Entities;

namespace Estoque.Application.DTOs.Mappings;

public static class ItemEntradaMap
{
    public static ItemEntrada ConverterParaEntidade(InsercaoItemEntradaRequest insercaoItemEntrada) =>
    new ItemEntrada
    (
      insercaoItemEntrada.Id,
      insercaoItemEntrada.Lote,
      insercaoItemEntrada.Quantidade,
      insercaoItemEntrada.Valor,
      insercaoItemEntrada.IdEntrada,
      insercaoItemEntrada.IdProduto
    );

    public static ItemEntrada ConverterParaEntidade(AtualizacaoItemEntradaRequest atualizacaoItemEntrada) =>
    new ItemEntrada
    (
      atualizacaoItemEntrada.Id,
      atualizacaoItemEntrada.Lote,
      atualizacaoItemEntrada.Quantidade,
      atualizacaoItemEntrada.Valor,
      atualizacaoItemEntrada.IdEntrada,
      atualizacaoItemEntrada.IdProduto
    );

    public static ItemEntradaResponse ConverterParaResponse(this ItemEntrada itemEntrada) =>
    new ItemEntradaResponse
    (
        itemEntrada.Id,
        itemEntrada.Lote,
        itemEntrada.Quantidade,
        itemEntrada.Valor,
        new EntradaResponseItemEntrada
        (
          itemEntrada.Entrada.DataEntrada,
          itemEntrada.Entrada.Total,
          itemEntrada.Entrada.Frete,
          itemEntrada.Entrada.NumeroNotaFiscal
        ),
        new ProdutoResponseItemEntrada
        (
          itemEntrada.Produto.Nome,
          itemEntrada.Produto.Peso,
          itemEntrada.Produto.Controlado
        )
    );
}
