namespace Estoque.Application.DTOs.Entities;

    public record InsercaoCidadeRequest
    (
        int Id,
        string Nome,
        string Uf
    );

    public record AtualizacaoCidadeRequest
    (
        int Id,
        string Nome,
        string Uf
    );

     public record CidadeResponse
    (
        int Id,
        string Nome,
        string Uf
    );


