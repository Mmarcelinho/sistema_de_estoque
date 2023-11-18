using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces.Repositories;
using Estoque.Data.Context;
using Estoque.Data.Repositories.Shared;
using Microsoft.EntityFrameworkCore;

namespace Estoque.Data.Repositories;

    public class ProdutoRepository(DataContext dataContext) : RepositoryBase<Produto>(dataContext),IProdutoRepository
    {
    public async Task<Produto?> ObterPorNomeAsync(string nome) => 

    await Context.Produtos.FirstOrDefaultAsync(p => p.Nome.Contains(nome));
}
