namespace SistemaDeEstoque.Infrastructure.AcessoRepositorio;

public sealed class UnidadeDeTrabalho : IUnidadeDeTrabalho
{
    private readonly SistemaDeEstoqueContext _contexto;

    public UnidadeDeTrabalho(SistemaDeEstoqueContext contexto) =>
    _contexto = contexto;

    public async Task Commit() => await _contexto.SaveChangesAsync();
}
