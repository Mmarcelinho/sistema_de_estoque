using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces.Services.Shared;

namespace Estoque.Domain.Interfaces.Service;

    public interface ICategoriaService : IServiceBase<Categoria> 
    {
        Task<Categoria?> ObterPorTituloAsync(string titulo);
    }
