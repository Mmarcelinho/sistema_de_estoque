using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces.Services.Shared;

namespace Estoque.Domain.Interfaces.Service;

public interface IFornecedorService : IServiceBase<Fornecedor>
{
    Task<IEnumerable<Fornecedor?>> ObterPorIdFornecedoresDeCidadeAsync(int id);

    Task<IEnumerable<Fornecedor?>> ObterPorNomeFornecedoresDeCidadeAsync(string nome);
}
