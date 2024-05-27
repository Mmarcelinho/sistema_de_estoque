namespace SistemaDeEstoque.Domain.Repositorios.ItemEntrada;

    public interface IItemEntradaWriteOnlyRepositorio
    {
        Task Registrar(Entidades.ItemEntrada itemEntrada);
    }
