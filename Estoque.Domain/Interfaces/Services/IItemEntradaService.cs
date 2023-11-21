using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces.Services.Shared;

namespace Estoque.Domain.Interfaces.Service;

public interface IItemEntradaService : IServiceBase<ItemEntrada>
{
    Task<IEnumerable<ItemEntrada?>> ObterPorIdItemEntradasDeEntradaAsync(int id);

    Task<IEnumerable<ItemEntrada?>> ObterPorNfItemEntradasDeEntradaAsync(int NumeroNotaFiscal);

    Task<IEnumerable<ItemEntrada?>> ObterPorIdItemEntradasDeProdutoAsync(int id);
}
