namespace SistemaDeEstoque.Domain.Repositorios.Fornecedor;

    public interface IFornecedorUpdateOnlyRepositorio
    {
        void Atualizar(Entidades.Fornecedor fornecedor);

        Task<Entidades.Fornecedor> RecuperarPorId(long fornecedorId);
    }
