using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces.Repositories;
using Estoque.Data.Context;
using Estoque.Data.Repositories.Shared;
using Microsoft.EntityFrameworkCore;

namespace Estoque.Data.Repositories;

public class ItemSaidaRepository(DataContext dataContext) : RepositoryBase<ItemSaida>(dataContext), IItemSaidaRepository
{

    public override async Task<IEnumerable<ItemSaida>> ObterTodosAsync() =>

    await Context.ItemSaidas
    .Include(i => i.Saida)
    .Include(i => i.Produto)
    .ToListAsync();

    public override async Task<ItemSaida?> ObterPorIdAsync(int id) =>
    
    await Context.ItemSaidas
    .Include(i => i.Saida)
    .Include(i => i.Produto)
    .FirstOrDefaultAsync(e => e.Id.Equals(id));

    public async Task<IEnumerable<ItemSaida?>> ObterPorIdItemSaidasDeSaidaAsync(int id)
    {
        return await Context.ItemSaidas
        .Include(i => i.Saida)
        .Include(i => i.Produto)
        .Where(i => i.IdSaida == id)
        .ToListAsync();
    }

    public async Task<IEnumerable<ItemSaida?>> ObterPorIdItemSaidasDeProdutoAsync(int id)
    {
        return await Context.ItemSaidas
        .Include(i => i.Saida)
        .Include(i => i.Produto)
        .Where(i => i.IdProduto == id)
        .ToListAsync();
    }
}  
