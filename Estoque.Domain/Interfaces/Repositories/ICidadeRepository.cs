using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces.Repositories.Shared;

namespace Estoque.Domain.Interfaces.Repositories;

public interface ICidadeRepository : IRepositoryBase<Cidade>
{
    Task<Cidade?> ObterPorNomeAsync(string nome);
}
