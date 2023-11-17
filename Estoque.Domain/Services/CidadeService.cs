using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces.Repositories;
using Estoque.Domain.Interfaces.Service;
using Estoque.Domain.Services.Shared;

namespace Estoque.Domain.Services;

    public class CidadeService : ServiceBase<Cidade>, ICidadeService
    {
        public CidadeService(ICidadeRepository cidadeRepository) : base(cidadeRepository) { }
    }
