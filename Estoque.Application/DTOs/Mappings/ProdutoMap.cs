using Estoque.Application.DTOs.Entities;
using Estoque.Domain.Entities;

namespace Estoque.Application.DTOs.Mappings;

    public static class ProdutoMap
    {
        public static Produto ConverterParaEntidade(InsercaoProdutoRequest insercaoProduto) =>
        new
        (
            insercaoProduto.Id,
            insercaoProduto.Nome,
            insercaoProduto.Descricao,
            insercaoProduto.Peso,
            insercaoProduto.Controlado,
            insercaoProduto.QuantMinima
        );

        public static Produto ConverterParaEntidade(AtualizacaoProdutoRequest atualizacaoProduto) =>
        new
        (
            atualizacaoProduto.Id,
            atualizacaoProduto.Nome,
            atualizacaoProduto.Descricao,
            atualizacaoProduto.Peso,
            atualizacaoProduto.Controlado,
            atualizacaoProduto.QuantMinima
        );

        public static ProdutoResponse ConverterParaResponse(this Produto produto) =>
        new 
        (
            produto.Id,
            produto.Nome,
            produto.Descricao,
            produto.Peso,
            produto.Controlado,
            produto.QuantMinima
        );
    }
