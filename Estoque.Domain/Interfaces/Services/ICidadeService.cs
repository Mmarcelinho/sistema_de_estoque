using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces.Services.Shared;

namespace Estoque.Domain.Interfaces.Service;

    public interface ICidadeService : IServiceBase<Cidade>
    {
        Task<Cidade?> ObterPorNomeAsync(string nome);
    }
