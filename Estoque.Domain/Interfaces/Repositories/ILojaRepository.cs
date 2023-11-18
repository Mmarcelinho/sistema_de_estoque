using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces.Repositories.Shared;

namespace Estoque.Domain.Interfaces.Repositories;

public interface ILojaRepository : IRepositoryBase<Loja>
{
    Task<Loja?> ObterPorNomeAsync(string nome);

    Task<IEnumerable<Loja?>>ObterPorIdLojasDeCidadeAsync(int id);

    Task<IEnumerable<Loja?>> ObterPorNomeLojasDeCidadeAsync(string nome);
}
