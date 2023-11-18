using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces.Repositories;
using Estoque.Data.Context;
using Estoque.Data.Repositories.Shared;
using Microsoft.EntityFrameworkCore;

namespace Estoque.Data.Repositories;

public class FornecedorRepository(DataContext dataContext) : RepositoryBase<Fornecedor>(dataContext), IFornecedorRepository
{

    public override async Task<IEnumerable<Fornecedor>> ObterTodosAsync() =>

    await Context.Fornecedores
    .Include(f => f.Cidade)
    .ToListAsync();

    public override async Task<Fornecedor?> ObterPorIdAsync(int id) =>

    await Context.Fornecedores
    .Include(f => f.Cidade)
    .FirstOrDefaultAsync(f => f.Id.Equals(id));

    public async Task<IEnumerable<Fornecedor?>> ObterPorIdFornecedoresDeCidadeAsync(int id)
    {
        return await Context.Fornecedores
        .Include(f => f.Cidade)
        .Where(f => f.IdCidade == id)
        .ToListAsync();
    }

     public async Task<IEnumerable<Fornecedor?>> ObterPorNomeFornecedoresDeCidadeAsync(string nome)
    {
        return await Context.Fornecedores
        .Include(f => f.Cidade)
        .Where(f => f.Cidade.Nome.Contains(nome))
        .ToListAsync();
    }
}
