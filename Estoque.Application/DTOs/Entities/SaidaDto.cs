using Estoque.Domain.Entities;

namespace Estoque.Application.DTOs.Entities;

    public record InsercaoSaidaRequest
    (
        int Id,
        double Total,
        double Frete,
        double Imposto,
        int IdLoja,
        int IdTransportadora
    );

    public record AtualizacaoSaidaRequest
    (
        int Id,
        double Total,
        double Frete,
        double Imposto,
        int IdLoja,
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
