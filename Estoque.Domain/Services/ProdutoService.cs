using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces.Repositories;
using Estoque.Domain.Interfaces.Service;
using Estoque.Domain.Services.Shared;

namespace Estoque.Domain.Services;

    public class ProdutoService : ServiceBase<Produto>, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoService(IProdutoRepository produtoRepository) : base(produtoRepository) =>
        
        _produtoRepository = produtoRepository;

        public async Task<Produto?> ObterPorNomeAsync(string nome) =>
        await _produtoRepository.ObterPorNomeAsync(nome);
    }
