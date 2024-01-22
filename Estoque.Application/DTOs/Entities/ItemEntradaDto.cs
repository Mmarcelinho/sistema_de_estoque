using System.ComponentModel.DataAnnotations;

namespace Estoque.Application.DTOs.Entities;

    public record InsercaoItemEntradaRequest
    (
        int Id,
        [Required]
        string Lote,
        [Required]
        int Quantidade,
        [Required]
        decimal Valor,
        [Required]
        int IdEntrada,
        [Required]
        int IdProduto
    );

     public record AtualizacaoItemEntradaRequest
    (
        int Id,
        [Required]
        string Lote,
        [Required]
        int Quantidade,
        [Required]
        decimal Valor,
        [Required]
        int IdEntrada,
        [Required]
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
