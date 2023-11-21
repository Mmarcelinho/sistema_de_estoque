namespace Estoque.Application.DTOs.Entities;

    public record InsercaoItemEntradaRequest
    (
        int Id,
        string Lote,
        int Quantidade,
        decimal Valor,
        int IdEntrada,
        int IdProduto
    );

     public record AtualizacaoItemEntradaRequest
    (
        int Id,
        string Lote,
        int Quantidade,
        decimal Valor,
        int IdEntrada,
        int IdProduto
    );

     public record ItemEntradaResponse
    (
        int Id,
        string Lote,
        int Quantidade,
        decimal Valor,
        EntradaResponseItemEntrada Entrada,
        ProdutoResponseItemEntrada Produto
    );
