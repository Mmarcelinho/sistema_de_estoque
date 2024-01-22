using System.ComponentModel.DataAnnotations;

namespace Estoque.Application.DTOs.Entities;

    public record InsercaoTransportadoraRequest
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
        string Cnpj,
        [Required]
        string Inscricao,
        [Required]
        string Contato,
        [Required]
        string Telefone,
        [Required]
        int IdCidade
    );

    public record AtualizacaoTransportadoraRequest
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
        string Cnpj,
        [Required]
        string Inscricao,
        [Required]
        string Contato,
        [Required]
        string Telefone,
        [Required]
        int IdCidade
    );

    public record TransportadoraResponse
    (
        int Id,
        string Nome,
        string Endereco,
        int Numero,
        string Bairro,
        string Cep,
        string Cnpj,
        string Inscricao,
        string Contato,
        string Telefone,
        CidadeResponse Cidade
    );

     public record TransportadoraResponseEntrada
    (
        string Nome,
        string Cep,
        string Cnpj,
        string Telefone
    );

    public record TransportadoraResponseSaida
    (
        string Nome,
        string Cep,
        string Cnpj,
        string Telefone
    );
