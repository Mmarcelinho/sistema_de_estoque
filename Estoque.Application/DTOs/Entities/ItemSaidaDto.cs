namespace Estoque.Application.DTOs.Entities;

public record InsercaoItemSaidaRequest
(
  int Id,
  string Lote,
  int Quantidade,
  decimal Valor,
  int IdSaida,
  int IdProduto
);

public record AtualizacaoItemSaidaRequest
(
  int Id,
  string Lote,
  int Quantidade,
  decimal Valor,
  int IdSaida,
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



