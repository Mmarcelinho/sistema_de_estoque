using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces.Repositories;
using Estoque.Data.Context;
using Estoque.Data.Repositories.Shared;
using Microsoft.EntityFrameworkCore;

namespace Estoque.Data.Repositories;

public class EntradaRepository(DataContext dataContext) : RepositoryBase<Entrada>(dataContext), IEntradaRepository
{

    public override async Task<IEnumerable<Entrada>> ObterTodosAsync() =>

    await Context.Entradas
    .Include(e => e.Transportadora)
    .ToListAsync();

    public override async Task<Entrada?> ObterPorIdAsync(int id) =>

    await Context.Entradas
    .Include(e => e.Transportadora)
    .FirstOrDefaultAsync(e => e.Id.Equals(id));

    public async Task<IEnumerable<Entrada?>> ObterPorIdEntradasDeTransportadoraAsync(int id)
    {
        return await Context.Entradas
        .Include(e => e.Transportadora)
        .Where(e => e.IdTransportadora == id)
        .ToListAsync();
    }
}
