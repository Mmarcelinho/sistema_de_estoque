using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces.Repositories.Shared;

namespace Estoque.Domain.Interfaces.Repositories;

public interface ISaidaRepository : IRepositoryBase<Saida>
{
    Task<IEnumerable<Saida?>>ObterPorIdSaidasDeLojaAsync(int id);

    Task<IEnumerable<Saida?>>ObterPorNomeSaidasDeLojaAsync(string nome);

    Task<IEnumerable<Saida?>>ObterPorIdSaidasDeTransportadoraAsync(int id);

    Task<IEnumerable<Saida?>>ObterPorNomeSaidasDeTransportadoraAsync(string nome);
}
