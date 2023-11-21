using Estoque.Application.DTOs.Entities;
using Estoque.Domain.Entities;

namespace Estoque.Application.DTOs.Mappings;

public static class ItemSaidaMap
{
    public static ItemSaida ConverterParaEntidade(InsercaoItemSaidaRequest insercaoItemSaida) =>
    new ItemSaida
    (
        insercaoItemSaida.Id,
        insercaoItemSaida.Lote,
        insercaoItemSaida.Quantidade,
        insercaoItemSaida.Valor,
        insercaoItemSaida.IdSaida,
        insercaoItemSaida.IdProduto
    );

    public static ItemSaida ConverterParaEntidade(AtualizacaoItemSaidaRequest atualizacaoItemSaida) =>
    new ItemSaida
    (
        atualizacaoItemSaida.Id,
        atualizacaoItemSaida.Lote,
        atualizacaoItemSaida.Quantidade,
        atualizacaoItemSaida.Valor,
        atualizacaoItemSaida.IdSaida,
        atualizacaoItemSaida.IdProduto
    );

    public static ItemSaidaResponse ConverterParaResponse(this ItemSaida itemSaida
    ) =>
    new ItemSaidaResponse
    (
        itemSaida.Id,
        itemSaida.Lote,
        itemSaida.Quantidade,
        itemSaida.Valor,
        new SaidaResponseItemSaida
        (
          itemSaida.Saida.Total,
          itemSaida.Saida.Frete,
          itemSaida.Saida.Imposto
        )
    );
}