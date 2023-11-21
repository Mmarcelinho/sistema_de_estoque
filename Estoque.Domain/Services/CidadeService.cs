using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces.Repositories;
using Estoque.Domain.Interfaces.Service;
using Estoque.Domain.Services.Shared;

namespace Estoque.Domain.Services;

    public class CidadeService : ServiceBase<Cidade>, ICidadeService
    {
          private readonly ICidadeRepository _cidadeRepository;
        public CidadeService(ICidadeRepository cidadeRepository) : base(cidadeRepository) =>
        
            _cidadeRepository = cidadeRepository;
        
        public async Task<Cidade?> ObterPorNomeAsync(string nome) =>
        await _cidadeRepository.ObterPorNomeAsync(nome);
    }
