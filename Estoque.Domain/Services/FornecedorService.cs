using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces.Repositories;
using Estoque.Domain.Interfaces.Service;
using Estoque.Domain.Services.Shared;

namespace Estoque.Domain.Services;

    public class FornecedorService : ServiceBase<Fornecedor>, IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        public FornecedorService(IFornecedorRepository fornecedorRepository) : base(fornecedorRepository) => _fornecedorRepository = fornecedorRepository;

    public async Task<IEnumerable<Fornecedor?>> ObterPorIdFornecedoresDeCidadeAsync(int id) =>
    await _fornecedorRepository.ObterPorIdFornecedoresDeCidadeAsync(id);

    public async Task<IEnumerable<Fornecedor?>> ObterPorNomeFornecedoresDeCidadeAsync(string nome) =>
    await _fornecedorRepository.ObterPorNomeFornecedoresDeCidadeAsync(nome);
    }
