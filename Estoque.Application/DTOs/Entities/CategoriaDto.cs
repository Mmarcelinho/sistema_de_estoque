namespace Estoque.Application.DTOs.Entities;

    public record InsercaoCategoriaRequest
    (
        int Id,
        string Titulo
    );

    public record AtualizacaoCategoriaRequest
    (
        int Id,
        string Titulo
    );

    public record CategoriaResponse
    (
        int Id,
        string Titulo
    );
