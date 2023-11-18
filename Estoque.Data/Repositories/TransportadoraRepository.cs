using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces.Repositories;
using Estoque.Data.Context;
using Estoque.Data.Repositories.Shared;
using Microsoft.EntityFrameworkCore;

namespace Estoque.Data.Repositories;

public class TransportadoraRepository(DataContext dataContext) : RepositoryBase<Transportadora>(dataContext), ITransportadoraRepository
{

    public override async Task<IEnumerable<Transportadora>> ObterTodosAsync() =>

    await Context.Transportadoras
    .Include(t => t.Cidade)
    .ToListAsync();

    public override async Task<Transportadora?> ObterPorIdAsync(int id) =>

    await Context.Transportadoras
    .Include(t => t.Cidade)
    .FirstOrDefaultAsync(t => t.Id.Equals(id));

    public async Task<IEnumerable<Transportadora>> ObterPorIdTransportadorasDeCidadeAsync(int id)
    {
        return await Context.Transportadoras
        .Include(t => t.Cidade)
        .Where(t => t.IdCidade == id)
        .ToListAsync();
    }

    public async Task<IEnumerable<Transportadora>> ObterPorNomeTransportadorasDeCidadeAsync(string nome)
    {
        return await Context.Transportadoras
        .Include(t => t.Cidade)
        .Where(t => t.Cidade.Nome.Contains(nome))
        .ToListAsync();
    }
}
