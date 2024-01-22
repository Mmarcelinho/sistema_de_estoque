using System.ComponentModel.DataAnnotations;

namespace Estoque.Application.DTOs.Entities;

    public record InsercaoCategoriaRequest
    (
        int Id,
        [Required]
        string Titulo
    );

    public record AtualizacaoCategoriaRequest
    (
        int Id,
        [Required]
        string Titulo
    );

    public record CategoriaResponse
    (
        int Id,
        string Titulo
    );
