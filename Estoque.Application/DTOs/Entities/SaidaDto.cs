using Estoque.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Estoque.Application.DTOs.Entities;

    public record InsercaoSaidaRequest
    (
        int Id,
        [Required]
        double Total,
        [Required]
        double Frete,
        [Required]
        double Imposto,
        [Required]
        int IdLoja,
        [Required]
        int IdTransportadora
    );

    public record AtualizacaoSaidaRequest
    (
        int Id,
        [Required]
        double Total,
        [Required]
        double Frete,
        [Required]
        double Imposto,
        [Required]
        int IdLoja,
        [Required]
        int IdTransportadora
    );

    public record SaidaResponse
    (
        int Id,
        double Total,
        double Frete,
        double Imposto,
        LojaResponseSaida Loja,
        TransportadoraResponseSaida Transportadora
    );

     public record SaidaResponseItemSaida
    (
        double Total,
        double Frete,
        double Imposto
    );
