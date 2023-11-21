namespace Estoque.Application.DTOs.Entities;

    public record InsercaoLojaRequest
    (
        int Id,
        string Nome,
        string Endereco,
        int Numero,
        string Bairro,
        string Telefone,
        string Inscricao,
        string Cnpj,
        int IdCidade
    );

    public record AtualizacaoLojaRequest
    (
        int Id,
        string Nome,
        string Endereco,
        int Numero,
        string Bairro,
        string Telefone,
        string Inscricao,
        string Cnpj,
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
