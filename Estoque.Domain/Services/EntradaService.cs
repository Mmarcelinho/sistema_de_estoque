using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces.Repositories;
using Estoque.Domain.Interfaces.Service;
using Estoque.Domain.Services.Shared;

namespace Estoque.Domain.Services;

    public class EntradaService : ServiceBase<Entrada>, IEntradaService
    {
        public EntradaService(IEntradaRepository entradaRepository) : base(entradaRepository) { }
    }
