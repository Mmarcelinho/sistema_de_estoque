using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces.Services.Shared;

namespace Estoque.Domain.Interfaces.Service;

public interface IProdutoService : IServiceBase<Produto>
{
    Task<Produto?> ObterPorNomeAsync(string nome);
}
