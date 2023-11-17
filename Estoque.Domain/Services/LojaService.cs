using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces.Repositories;
using Estoque.Domain.Interfaces.Service;
using Estoque.Domain.Services.Shared;

namespace Estoque.Domain.Services;

    public class LojaService : ServiceBase<Loja>, ILojaService
    {
        public LojaService(ILojaRepository lojaRepository) : base(lojaRepository) { }
    }
