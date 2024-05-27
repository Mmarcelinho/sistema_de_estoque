namespace SistemaDeEstoque.Domain.Repositorios.Fornecedor;

    public interface IFornecedorWriteOnlyRepositorio
    {
        Task Registrar(Entidades.Fornecedor fornecedor);

        Task Deletar(long fornecedorId);
    }
