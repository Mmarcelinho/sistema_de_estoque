using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces.Repositories;
using Estoque.Domain.Interfaces.Service;
using Estoque.Domain.Services.Shared;

namespace Estoque.Domain.Services;

    public class CategoriaService : ServiceBase<Categoria>, ICategoriaService
    {
        public CategoriaService(ICategoriaRepository categoriaRepository) : base(categoriaRepository) { }
    }
