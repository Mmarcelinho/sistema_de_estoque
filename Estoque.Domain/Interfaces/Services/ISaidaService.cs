using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces.Services.Shared;

namespace Estoque.Domain.Interfaces.Service;

public interface ISaidaService : IServiceBase<Saida>
{
    Task<IEnumerable<Saida?>> ObterPorIdSaidasDeLojaAsync(int id);

    Task<IEnumerable<Saida?>> ObterPorNomeSaidasDeLojaAsync(string nome);

    Task<IEnumerable<Saida?>> ObterPorIdSaidasDeTransportadoraAsync(int id);

    Task<IEnumerable<Saida?>> ObterPorNomeSaidasDeTransportadoraAsync(string nome);
}
