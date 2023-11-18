using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces.Repositories.Shared;

namespace Estoque.Domain.Interfaces.Repositories;

public interface IFornecedorRepository : IRepositoryBase<Fornecedor>
{
    Task<IEnumerable<Fornecedor?>> ObterPorIdFornecedoresDeCidadeAsync(int id);

    Task<IEnumerable<Fornecedor?>> ObterPorNomeFornecedoresDeCidadeAsync(string nome);
}
