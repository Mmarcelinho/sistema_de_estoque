using Estoque.Domain.Entities.Shared;

namespace Estoque.Domain.Interfaces.Services.Shared;

public interface IServiceBase<TEntity> : IDisposable where TEntity : Entity
{
    Task<IEnumerable<TEntity>> ObterTodosAsync();
    Task<TEntity?> ObterPorIdAsync(int id);

    Task<TEntity?> ObterPorNomeAsync(string nome);

    Task<TEntity?> ObterPorIdUmParaMuitosAsync(int id);

    Task<TEntity?> ObterPorNomeUmParaMuitosAsync(string nome);
    Task<object> AdicionarAsync(TEntity objeto);
    Task AtualizarAsync(TEntity objeto);
    Task RemoverAsync(TEntity objeto);
    Task RemoverPorIdAsync(int id);
}
