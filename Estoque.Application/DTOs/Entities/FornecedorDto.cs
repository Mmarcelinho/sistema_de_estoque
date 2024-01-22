using System.ComponentModel.DataAnnotations;

namespace Estoque.Application.DTOs.Entities;

public record InsercaoFornecedorRequest
(
     int Id,
     [Required]
     string Nome,
     [Required]
     string Endereco,
     [Required]
     int Numero,
     [Required]
     string Bairro,
     [Required]
     string Cep,
     [Required]
     string Contato,
     [Required]
     string Cnpj,
     [Required]
     string Inscricao,
     [Required]
     int IdCidade
);
   
public record AtualizacaoFornecedorRequest
(
     int Id,
     [Required]
     string Nome,
     [Required]
     string Endereco,
     [Required]
     int Numero,
     [Required]
     string Bairro,
     [Required]
     string Cep,
     [Required]
     string Contato,
     [Required]
     string Cnpj,
     [Required]
     string Inscricao,
     [Required]
     int IdCidade
);

public record FornecedorResponse
(
     int Id,
     string Nome,
     string Endereco,
     int Numero,
     string Bairro,
     string Cep,
     string Contato,
     string Cnpj,
     string Inscricao,
     CidadeResponse Cidade
);