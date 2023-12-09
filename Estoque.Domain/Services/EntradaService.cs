using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces.Repositories;
using Estoque.Domain.Interfaces.Service;
using Estoque.Domain.Services.Shared;

namespace Estoque.Domain.Services;

    public class EntradaService : ServiceBase<Entrada>, IEntradaService
    {
        private readonly IEntradaRepository _entradaRepository;
        public EntradaService(IEntradaRepository entradaRepository) : base(entradaRepository) => _entradaRepository = entradaRepository;
        
        public async Task<IEnumerable<Entrada?>> ObterPorIdEntradasDeTransportadoraAsync(int id) =>
        await _entradaRepository.ObterPorIdEntradasDeTransportadoraAsync(id);

        public async Task<IEnumerable<Entrada?>> ObterPorNomeEntradasDeTransportadoraAsync(string nome) =>
        await _entradaRepository.ObterPorNomeEntradasDeTransportadoraAsync(nome);
    }
