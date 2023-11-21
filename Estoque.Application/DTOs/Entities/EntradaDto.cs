namespace Estoque.Application.DTOs.Entities;

public record InsercaoEntradaRequest
(
int Id,
decimal Total,
decimal Frete,
int NumeroNotaFiscal,
decimal Imposto,
int IdTransportadora
);

public record AtualizacaoEntradaRequest
(
int Id,
decimal Total,
decimal Frete,
int NumeroNotaFiscal,
decimal Imposto,
int IdTransportadora
);

public record EntradaResponse
(
int Id,
DateTime DataPedido,
DateTime DataEntrada,
decimal Total,
decimal Frete,
int NumeroNotaFiscal,
decimal Imposto,
TransportadoraResponseEntrada Transportadora
);

public record EntradaResponseItemEntrada
(
DateTime DataEntrada,
decimal Total,
decimal Frete,
int NumeroNotaFiscal
);
