using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces.Services.Shared;

namespace Estoque.Domain.Interfaces.Service;

public interface ILojaService : IServiceBase<Loja>
{
    Task<Loja?> ObterPorNomeAsync(string nome);

    Task<IEnumerable<Loja?>> ObterPorIdLojasDeCidadeAsync(int id);

    Task<IEnumerable<Loja?>> ObterPorNomeLojasDeCidadeAsync(string nome);
}
