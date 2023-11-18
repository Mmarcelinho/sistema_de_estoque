using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces.Repositories.Shared;

namespace Estoque.Domain.Interfaces.Repositories;

public interface IItemEntradaRepository : IRepositoryBase<ItemEntrada>
{
    Task<IEnumerable<ItemEntrada?>> ObterPorIdItemEntradasDeEntradaAsync(int id);
    Task<IEnumerable<ItemEntrada?>> ObterPorNfItemEntradasDeEntradaAsync(int NumeroNotaFiscal);

      Task<IEnumerable<ItemEntrada?>> ObterPorIdItemEntradasDeProdutoAsync(int id);
}
