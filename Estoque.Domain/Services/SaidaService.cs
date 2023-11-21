using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces.Repositories;
using Estoque.Domain.Interfaces.Service;
using Estoque.Domain.Services.Shared;

namespace Estoque.Domain.Services;

public class SaidaService : ServiceBase<Saida>, ISaidaService
{
    private readonly ISaidaRepository _saidaRepository;
    public SaidaService(ISaidaRepository saidaRepository) : base(saidaRepository) =>

    _saidaRepository = saidaRepository;

    public async Task<IEnumerable<Saida?>> ObterPorIdSaidasDeLojaAsync(int id) =>
    await _saidaRepository.ObterPorIdSaidasDeLojaAsync(id);

    public async Task<IEnumerable<Saida?>> ObterPorNomeSaidasDeLojaAsync(string nome) =>
    await _saidaRepository.ObterPorNomeSaidasDeLojaAsync(nome);
    public async Task<IEnumerable<Saida?>> ObterPorIdSaidasDeTransportadoraAsync(int id) =>
    await _saidaRepository.ObterPorIdSaidasDeTransportadoraAsync(id);

    public async Task<IEnumerable<Saida?>> ObterPorNomeSaidasDeTransportadoraAsync(string nome) =>
    await _saidaRepository.ObterPorNomeSaidasDeTransportadoraAsync(nome);
}
