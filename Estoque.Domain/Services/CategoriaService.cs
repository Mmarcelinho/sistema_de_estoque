using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces.Repositories;
using Estoque.Domain.Interfaces.Service;
using Estoque.Domain.Services.Shared;

namespace Estoque.Domain.Services;

    public class CategoriaService : ServiceBase<Categoria>, ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        public CategoriaService(ICategoriaRepository categoriaRepository) : base(categoriaRepository) =>
        
            _categoriaRepository = categoriaRepository;
        

        public async Task<Categoria?> ObterPorTituloAsync(string titulo) => 
        await _categoriaRepository.ObterPorTituloAsync(titulo);
    }   
