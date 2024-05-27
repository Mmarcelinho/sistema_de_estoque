namespace SistemaDeEstoque.Domain.Repositorios.ItemSaida;

    public interface IItemSaidaWriteOnlyRepositorio
    {
        Task Registrar(Entidades.ItemSaida itemSaida);
    }
