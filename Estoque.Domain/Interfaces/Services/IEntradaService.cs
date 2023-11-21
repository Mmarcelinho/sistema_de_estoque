using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces.Services.Shared;

namespace Estoque.Domain.Interfaces.Service;

    public interface IEntradaService : IServiceBase<Entrada> 
    { 
        Task<IEnumerable<Entrada?>> ObterPorIdEntradasDeTransportadoraAsync(int id);
    }
