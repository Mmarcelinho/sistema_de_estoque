using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces.Repositories;
using Estoque.Data.Context;
using Estoque.Data.Repositories.Shared;
using Microsoft.EntityFrameworkCore;

namespace Estoque.Data.Repositories;

    public class CidadeRepository : RepositoryBase<Cidade>,ICidadeRepository
    {
        public CidadeRepository(DataContext dataContext) : base(dataContext) { }

    public async Task<Cidade?> ObterPorNomeAsync(string nome) => 

    await Context.Cidades.FirstOrDefaultAsync(c => c.Nome.Contains(nome));
}
