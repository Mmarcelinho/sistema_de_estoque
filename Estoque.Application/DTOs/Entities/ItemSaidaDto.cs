using System.ComponentModel.DataAnnotations;

namespace Estoque.Application.DTOs.Entities;

public record InsercaoItemSaidaRequest
(
  int Id,
  [Required]
  string Lote,
  [Required]
  int Quantidade,
  [Required]
  decimal Valor,
  [Required]
  int IdSaida,
  [Required]
  int IdProduto
);

public record AtualizacaoItemSaidaRequest
(
  int Id,
  [Required]
  string Lote,
  [Required]
  int Quantidade,
  [Required]
  decimal Valor,
  [Required]
  int IdSaida,
  [Required]
  int IdProduto
);

public record ItemSaidaResponse
(
  int Id,
  string Lote,
  int Quantidade,
  decimal Valor,
  SaidaResponseItemSaida Saida
);



