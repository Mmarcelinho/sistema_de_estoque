namespace Estoque.Application.DTOs.Entities;

    public record InsercaoProdutoRequest
    (
        int Id,
        string Nome,
        string Descricao,
        double Peso,
        bool Controlado,
        int QuantMinima
    );

    public record AtualizacaoProdutoRequest
    (
        int Id,
        string Nome,
        string Descricao,
        double Peso,
        bool Controlado,
        int QuantMinima
    );

    public record ProdutoResponse
    (
        int Id,
        string Nome,
        string Descricao,
        double Peso,
        bool Controlado,
        int QuantMinima
    );

    public record ProdutoResponseItemEntrada
    (
        string Nome,
        double Peso,
        bool Controlado
    );
