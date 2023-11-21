using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces.Repositories;
using Estoque.Domain.Interfaces.Service;
using Estoque.Domain.Services.Shared;

namespace Estoque.Domain.Services;

public class LojaService : ServiceBase<Loja>, ILojaService
{
    private readonly ILojaRepository _lojaRepository;
    public LojaService(ILojaRepository lojaRepository) : base(lojaRepository) =>

        _lojaRepository = lojaRepository;

    public async Task<Loja?> ObterPorNomeAsync(string nome) =>
    await _lojaRepository.ObterPorNomeAsync(nome);
    public async Task<IEnumerable<Loja?>> ObterPorIdLojasDeCidadeAsync(int id) =>
    await _lojaRepository.ObterPorIdLojasDeCidadeAsync(id);

    public async Task<IEnumerable<Loja?>> ObterPorNomeLojasDeCidadeAsync(string nome) =>
    await _lojaRepository.ObterPorNomeLojasDeCidadeAsync(nome);
}
