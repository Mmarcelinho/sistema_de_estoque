using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces.Repositories;
using Estoque.Data.Context;
using Estoque.Data.Repositories.Shared;
using Microsoft.EntityFrameworkCore;

namespace Estoque.Data.Repositories;

public class ItemEntradaRepository(DataContext dataContext) : RepositoryBase<ItemEntrada>(dataContext), IItemEntradaRepository
{

    public override async Task<IEnumerable<ItemEntrada>> ObterTodosAsync() =>

    await Context.ItemEntradas
    .Include(i => i.Entrada)
    .Include(i => i.Produto)
    .ToListAsync();

    public override async Task<ItemEntrada?> ObterPorIdAsync(int id) =>
    
    await Context.ItemEntradas
    .Include(i => i.Entrada)
    .Include(i => i.Produto)
    .FirstOrDefaultAsync(e => e.Id.Equals(id));

    public async Task<IEnumerable<ItemEntrada?>> ObterPorNfItemEntradasDeEntradaAsync(int NumeroNotaFiscal)
    {
        return await Context.ItemEntradas
        .Include(i => i.Entrada)
        .Include(i => i.Produto)
        .Where(t => t.Entrada.NumeroNotaFiscal == NumeroNotaFiscal)
        .ToListAsync();
    }

    public async Task<IEnumerable<ItemEntrada?>> ObterPorIdItemEntradasDeEntradaAsync(int id)
    {
        return await Context.ItemEntradas
        .Include(i => i.Entrada)
        .Include(i => i.Produto)
        .Where(t => t.IdEntrada == id)
        .ToListAsync();
    }

    public async Task<IEnumerable<ItemEntrada?>> ObterPorIdItemEntradasDeProdutoAsync(int id)
    {
        return await Context.ItemEntradas
        .Include(i => i.Entrada)
        .Include(i => i.Produto)
        .Where(t => t.IdProduto == id)
        .ToListAsync();
    }
}  
