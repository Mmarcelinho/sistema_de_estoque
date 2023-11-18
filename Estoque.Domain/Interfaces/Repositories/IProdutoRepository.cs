using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces.Repositories.Shared;

namespace Estoque.Domain.Interfaces.Repositories;

public interface IProdutoRepository : IRepositoryBase<Produto>
{
    Task<Produto?> ObterPorNomeAsync(string nome);
}
