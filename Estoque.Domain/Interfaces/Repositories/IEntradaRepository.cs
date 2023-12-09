using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces.Repositories.Shared;

namespace Estoque.Domain.Interfaces.Repositories;

    public interface IEntradaRepository : IRepositoryBase<Entrada>
    {
        Task<IEnumerable<Entrada?>> ObterPorIdEntradasDeTransportadoraAsync(int id);

        Task<IEnumerable<Entrada?>> ObterPorNomeEntradasDeTransportadoraAsync(string nome);
    }
