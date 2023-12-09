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
    .Include(s => s.Loja)
    .Include(s => s.Transportadora)
    .ToListAsync();

    public override async Task<Saida?> ObterPorIdAsync(int id) =>

    await Context.Saidas
    .Include(s => s.Loja)
    .Include(s => s.Transportadora)
    .FirstOrDefaultAsync(s => s.Id.Equals(id));

    public async Task<IEnumerable<Saida?>> ObterPorIdSaidasDeLojaAsync(int id)
    {
        return await Context.Saidas
        .Include(s => s.Loja)
        .Include(s => s.Transportadora)
        .Where(s => s.IdLoja == id)
        .ToListAsync();
    }

    public async Task<IEnumerable<Saida?>> ObterPorNomeSaidasDeLojaAsync(string nome)
    {
        return await Context.Saidas
        .Include(s => s.Loja)
        .Include(s => s.Transportadora)
        .Where(s => s.Loja.Nome == nome)
        .ToListAsync();
    }

    public async Task<IEnumerable<Saida?>> ObterPorIdSaidasDeTransportadoraAsync(int id)
    {
        return await Context.Saidas
        .Include(s => s.Loja)
        .Include(s => s.Transportadora)
        .Where(s => s.IdTransportadora == id)
        .ToListAsync();
    }

    public async Task<IEnumerable<Saida?>> ObterPorNomeSaidasDeTransportadoraAsync(string nome)
    {
        return await Context.Saidas
        .Include(s => s.Loja)
        .Include(s => s.Transportadora)
        .Where(s => s.Transportadora.Nome == nome)
        .ToListAsync();
    }
}
