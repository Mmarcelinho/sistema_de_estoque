using System.ComponentModel.DataAnnotations;

namespace Estoque.Application.DTOs.Entities;

    public record InsercaoCidadeRequest
    (
        int Id,
        [Required]
        string Nome,
        [Required]
        string Uf
    );

    public record AtualizacaoCidadeRequest
    (
        int Id,
        [Required]
        string Nome,
        [Required]
        string Uf
    );

     public record CidadeResponse
    (
        int Id,
        string Nome,
        string Uf
    );


