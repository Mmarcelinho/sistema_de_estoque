using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces.Repositories;
using Estoque.Data.Context;
using Estoque.Data.Repositories.Shared;
using Microsoft.EntityFrameworkCore;

namespace Estoque.Data.Repositories;

public class LojaRepository(DataContext dataContext) : RepositoryBase<Loja>(dataContext), ILojaRepository
{

    public override async Task<IEnumerable<Loja>> ObterTodosAsync() =>

    await Context.Lojas
    .Include(l => l.Cidade)
    .ToListAsync();

    public override async Task<Loja?> ObterPorIdAsync(int id) =>

    await Context.Lojas
    .Include(l => l.Cidade)
    .FirstOrDefaultAsync(l => l.Id.Equals(id));

    public async Task<Loja?> ObterPorNomeAsync(string nome) =>

    await Context.Lojas
    .Include(l => l.Cidade)
    .FirstOrDefaultAsync(l => l.Nome.Contains(nome));

    public async Task<IEnumerable<Loja?>> ObterPorIdLojasDeCidadeAsync(int id)
    {
        return await Context.Lojas
        .Include(l => l.Cidade)
        .Where(t => t.IdCidade == id)
        .ToListAsync();
    }

    public async Task<IEnumerable<Loja?>> ObterPorNomeLojasDeCidadeAsync(string nome)
    {
        return await Context.Lojas
        .Include(l => l.Cidade)
        .Where(l => l.Cidade.Nome == nome)
        .ToListAsync();
    }
}
