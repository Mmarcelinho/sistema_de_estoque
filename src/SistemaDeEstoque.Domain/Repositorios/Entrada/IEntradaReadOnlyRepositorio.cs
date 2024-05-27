namespace SistemaDeEstoque.Domain.Repositorios.Entrada;

    public interface IEntradaReadOnlyRepositorio
    {
        Task<IList<Entidades.Entrada>> RecuperarTodos();

        Task<Entidades.Entrada> RecuperarPorId(long entradaId);
    }
