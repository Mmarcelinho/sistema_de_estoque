using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces.Services.Shared;

namespace Estoque.Domain.Interfaces.Service;

public interface IItemSaidaService : IServiceBase<ItemSaida>
{
    Task<IEnumerable<ItemSaida?>> ObterPorIdItemSaidasDeSaidaAsync(int id);

    Task<IEnumerable<ItemSaida?>> ObterPorIdItemSaidasDeProdutoAsync(int id);
}
