namespace SistemaDeEstoque.Domain.Repositorios.Loja;

    public interface ILojaReadOnlyRepositorio
    {
        Task<IList<Entidades.Loja>> RecuperarTodos();

        Task<Entidades.Loja> RecuperarPorId(long lojaId);
    }
