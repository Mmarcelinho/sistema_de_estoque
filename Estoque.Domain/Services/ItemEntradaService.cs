using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces.Repositories;
using Estoque.Domain.Interfaces.Service;
using Estoque.Domain.Services.Shared;

namespace Estoque.Domain.Services;

public class ItemEntradaService : ServiceBase<ItemEntrada>, IItemEntradaService
{
    private readonly IItemEntradaRepository _itemEntradaRepository;
    public ItemEntradaService(IItemEntradaRepository itemEntradaRepository) : base(itemEntradaRepository)
    {
        _itemEntradaRepository = itemEntradaRepository;
    }

    public async Task<IEnumerable<ItemEntrada?>> ObterPorNfItemEntradasDeEntradaAsync(int NumeroNotaFiscal) =>
    await _itemEntradaRepository.ObterPorNfItemEntradasDeEntradaAsync(NumeroNotaFiscal);

    public async Task<IEnumerable<ItemEntrada?>> ObterPorIdItemEntradasDeEntradaAsync(int id) =>
    await _itemEntradaRepository.ObterPorIdItemEntradasDeEntradaAsync(id);

    public async Task<IEnumerable<ItemEntrada?>> ObterPorIdItemEntradasDeProdutoAsync(int id) =>
    await _itemEntradaRepository.ObterPorIdItemEntradasDeProdutoAsync(id);
}
