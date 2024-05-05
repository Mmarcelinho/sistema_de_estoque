namespace SistemaDeEstoque.Domain.Repositorios.ItemSaida;

    public interface IItemSaidaReadOnlyRepositorio
    {
        Task<IList<Entidades.ItemSaida>> RecuperarTodos();

        Task<Entidades.ItemSaida> RecuperarPorId(long itemSaidaId);
    }
