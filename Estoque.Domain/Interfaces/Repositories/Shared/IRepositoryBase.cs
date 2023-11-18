using Estoque.Domain.Entities.Shared;
namespace Estoque.Domain.Interfaces.Repositories.Shared;

public interface IRepositoryBase<TEntity> : IDisposable where TEntity : Entity
{
    Task<IEnumerable<TEntity>> ObterTodosAsync();
    Task<TEntity?> ObterPorIdAsync(int id);
    Task<object> AdicionarAsync(TEntity objeto);
    Task AtualizarAsync(TEntity objeto);
    Task RemoverAsync(TEntity objeto);
    Task RemoverPorIdAsync(int id);
}
