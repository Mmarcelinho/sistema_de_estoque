namespace SistemaDeEstoque.Domain.Repositorios.HistoricoEstoque;

    public interface IHistoricoEstoqueReadOnlyRepositorio
    {
        Task<IList<Entidades.HistoricoEstoque>> RecuperarTodos();

        Task<Entidades.HistoricoEstoque> RecuperarPorId(long historicoId);
    }
