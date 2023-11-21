using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces.Services.Shared;

namespace Estoque.Domain.Interfaces.Service;

public interface ITransportadoraService : IServiceBase<Transportadora>
{
    Task<IEnumerable<Transportadora>> ObterPorIdTransportadorasDeCidadeAsync(int id);

    Task<IEnumerable<Transportadora>> ObterPorNomeTransportadorasDeCidadeAsync(string nome);
}
