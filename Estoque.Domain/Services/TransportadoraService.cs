using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces.Repositories;
using Estoque.Domain.Interfaces.Service;
using Estoque.Domain.Services.Shared;

namespace Estoque.Domain.Services;

public class TransportadoraService : ServiceBase<Transportadora>, ITransportadoraService
{
    private readonly ITransportadoraRepository _transportadoraRepository;
    public TransportadoraService(ITransportadoraRepository transportadoraRepository) : base(transportadoraRepository) =>

    _transportadoraRepository = transportadoraRepository;

    public async Task<IEnumerable<Transportadora>> ObterPorIdTransportadorasDeCidadeAsync(int id) =>
    await _transportadoraRepository.ObterPorIdTransportadorasDeCidadeAsync(id);

    public async Task<IEnumerable<Transportadora>> ObterPorNomeTransportadorasDeCidadeAsync(string nome) =>
    await _transportadoraRepository.ObterPorNomeTransportadorasDeCidadeAsync(nome);
}
