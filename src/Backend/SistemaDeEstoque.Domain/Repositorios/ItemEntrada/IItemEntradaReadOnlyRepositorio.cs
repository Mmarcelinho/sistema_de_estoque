namespace SistemaDeEstoque.Domain.Repositorios.ItemEntrada;

    public interface IItemEntradaReadOnlyRepositorio
    {
        Task<IList<Entidades.ItemEntrada>> RecuperarTodos();

        Task<Entidades.ItemEntrada> RecuperarPorId(long itemEntradaId);
    }
