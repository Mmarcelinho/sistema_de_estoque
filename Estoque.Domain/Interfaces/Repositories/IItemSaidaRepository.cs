using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces.Repositories.Shared;

namespace Estoque.Domain.Interfaces.Repositories;

public interface IItemSaidaRepository : IRepositoryBase<ItemSaida>
{
    Task<IEnumerable<ItemSaida?>> ObterPorIdItemSaidasDeSaidaAsync(int id);

    Task<IEnumerable<ItemSaida?>> ObterPorIdItemSaidasDeProdutoAsync(int id);
}
