namespace SistemaDeEstoque.Domain.Repositorios.Fornecedor;

    public interface IFornecedorReadOnlyRepositorio
    {
        Task<IList<Entidades.Fornecedor>> RecuperarTodos();

        Task<Entidades.Fornecedor> RecuperarPorId(long fornecedorId);
    }
