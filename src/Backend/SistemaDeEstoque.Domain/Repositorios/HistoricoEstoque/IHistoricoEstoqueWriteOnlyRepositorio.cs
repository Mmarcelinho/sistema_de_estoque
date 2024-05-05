namespace SistemaDeEstoque.Domain.Repositorios.HistoricoEstoque;

    public interface IHistoricoEstoqueWriteOnlyRepositorio
    {
        Task Registrar(Entidades.HistoricoEstoque historico);
    }
