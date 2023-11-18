using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces.Repositories;
using Estoque.Data.Context;
using Estoque.Data.Repositories.Shared;
using Microsoft.EntityFrameworkCore;

namespace Estoque.Data.Repositories;

public class SaidaRepository(DataContext dataContext) : RepositoryBase<Saida>(dataContext), ISaidaRepository
{

    public override async Task<IEnumerable<Saida>> ObterTodosAsync() =>

    await Context.Saidas
    .Include(e => e.Loja)
    .Include(e => e.Transportadora)
    .ToListAsync();

    public override async Task<Saida?> ObterPorIdAsync(int id) =>

    await Context.Saidas
    .Include(e => e.Loja)
    .Include(e => e.Transportadora)
    .FirstOrDefaultAsync(e => e.Id.Equals(id));

    public async Task<IEnumerable<Saida?>> ObterPorIdSaidasDeLojaAsync(int id)
    {
        return await Context.Saidas
        .Include(e => e.Loja)
        .Include(e => e.Transportadora)
        .Where(e => e.IdLoja == id)
        .ToListAsync();
    }

    public async Task<IEnumerable<Saida?>> ObterPorNomeSaidasDeLojaAsync(string nome)
    {
        return await Context.Saidas
        .Include(t => t.Loja)
        .Include(t => t.Transportadora)
        .Where(t => t.Loja.Nome == nome)
        .ToListAsync();
    }

    public async Task<IEnumerable<Saida?>> ObterPorIdSaidasDeTransportadoraAsync(int id)
    {
        return await Context.Saidas
        .Include(t => t.Loja)
        .Include(t => t.Transportadora)
        .Where(t => t.IdTransportadora == id)
        .ToListAsync();
    }

    public async Task<IEnumerable<Saida?>> ObterPorNomeSaidasDeTransportadoraAsync(string nome)
    {
        return await Context.Saidas
        .Include(t => t.Loja)
        .Include(t => t.Transportadora)
        .Where(t => t.Transportadora.Nome == nome)
        .ToListAsync();
    }
}
