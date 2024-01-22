using System.ComponentModel.DataAnnotations;

namespace Estoque.Application.DTOs.Entities;

    public record InsercaoLojaRequest
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
        string Telefone,
        [Required]
        string Inscricao,
        [Required]
        string Cnpj,
        [Required]
        int IdCidade
    );

    public record AtualizacaoLojaRequest
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
        string Telefone,
        [Required]
        string Inscricao,
        [Required]
        string Cnpj,
        [Required]
        int IdCidade
    );

    public record LojaResponse
    (
        int Id,
        string Nome,
        string Endereco,
        int Numero,
        string Bairro,
        string Telefone,
        string Inscricao,
        string Cnpj,
        CidadeResponse Cidade
    );

      public record LojaResponseSaida
    (
        string Nome,
        string Endereco,
        string Telefone,
        string Cnpj
    );
