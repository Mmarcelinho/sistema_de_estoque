using System.ComponentModel.DataAnnotations;

namespace Estoque.Application.DTOs.Entities;

public record InsercaoEntradaRequest
(
int Id,
[Required]
decimal Total,
[Required]
decimal Frete,
[Required]
int NumeroNotaFiscal,
[Required]
decimal Imposto,
[Required]
int IdTransportadora
);

public record AtualizacaoEntradaRequest
(
int Id,
[Required]
decimal Total,
[Required]
decimal Frete,
[Required]
int NumeroNotaFiscal,
[Required]
decimal Imposto,
[Required]
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
