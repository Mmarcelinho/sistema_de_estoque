using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces.Repositories.Shared;

namespace Estoque.Domain.Interfaces.Repositories;

public interface ITransportadoraRepository : IRepositoryBase<Transportadora>
{
    Task<IEnumerable<Transportadora>> ObterPorIdTransportadorasDeCidadeAsync(int id);

    Task<IEnumerable<Transportadora>> ObterPorNomeTransportadorasDeCidadeAsync(string nome);
}
