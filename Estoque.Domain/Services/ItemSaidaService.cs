using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces.Repositories;
using Estoque.Domain.Interfaces.Service;
using Estoque.Domain.Services.Shared;

namespace Estoque.Domain.Services;

public class ItemSaidaService : ServiceBase<ItemSaida>, IItemSaidaService
{
    private readonly IItemSaidaRepository _itemSaidaRepository;
    public ItemSaidaService(IItemSaidaRepository itemSaidaRepository) : base(itemSaidaRepository) =>

        _itemSaidaRepository = itemSaidaRepository;


    public async Task<IEnumerable<ItemSaida?>> ObterPorIdItemSaidasDeSaidaAsync(int id) =>
        await _itemSaidaRepository.ObterPorIdItemSaidasDeSaidaAsync(id);

    public async Task<IEnumerable<ItemSaida?>> ObterPorIdItemSaidasDeProdutoAsync(int id) =>
        await _itemSaidaRepository.ObterPorIdItemSaidasDeProdutoAsync(id);
}
