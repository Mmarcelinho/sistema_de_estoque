using FluentAssertions;
using NSubstitute;
using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces.Repositories;
using Estoque.Domain.Services;
using Xunit;

namespace Estoque.Domain.Tests.Services;

public class ProdutoServiceTests
{
    private readonly ProdutoService _produtoService;

    private readonly IProdutoRepository _produtoRepository;

    private readonly Produto _produto;

    public ProdutoServiceTests()
    {
        _produto = new Produto(1, "Produto1", "Produto", 50, true, 10);

        _produtoRepository = Substitute.For<IProdutoRepository>();

        _produtoService = new ProdutoService(_produtoRepository);
    }

    [Fact]
    public async Task ObterTodosAsync_Deve_Retornar_Todos_Os_Registros()
    {
        _produtoRepository.ObterTodosAsync()
        .Returns(new List<Produto> {
            _produto,
            _produto,
            _produto
        });

        var produtos = await _produtoService.ObterTodosAsync();
        produtos.Should().HaveCount(3);
    }

    [Fact]
    public async Task ObterPorIdAsync_Deve_Retornar_Registro_Com_O_Id_Especificado()
    {
        var id = 1;
        _produtoRepository.ObterPorIdAsync(id)
        .Returns(_produto);
        var produto = await _produtoService.ObterPorIdAsync(id);
        produto.Id.Should().Be(_produto.Id);
    }

    [Fact]
    public async Task ObterPorNomeAsync_Deve_Retornar_Registro_Com_O_Nome_Especificado()
    {
        var titulo = "Produto1";
        _produtoRepository.ObterPorNomeAsync(titulo)
        .Returns(_produto);
        var produto = await _produtoService.ObterPorNomeAsync(titulo);
        produto.Nome.Should().Be(_produto.Nome);
    }

    [Fact]
    public async Task AdicionarAsync_Deve_Adicionar_Produto_E_Retornar_Id()
    {
        var id = 1;
        _produtoRepository.AdicionarAsync(_produto)
        .Returns(id);

        var idNovoRegistro = await _produtoService.AdicionarAsync(_produto);
        idNovoRegistro.Should().Be(id);
    }

    [Fact]
    public async Task AtualizarAsync_Deve_Atualizar_Produto()
    {
        _produtoRepository.AtualizarAsync(_produto)
        .Returns(Task.CompletedTask);

        await _produtoService.AtualizarAsync(_produto);
        await _produtoRepository.Received().AtualizarAsync(_produto);
    }

    [Fact]
    public async Task RemoverAsync_Deve_Remover_Produto()
    {
        _produtoRepository.RemoverAsync(_produto)
        .Returns(Task.CompletedTask);

        _produtoService.RemoverAsync(_produto)
       .Returns(Task.CompletedTask);

        await _produtoService.RemoverAsync(_produto);
        await _produtoRepository.Received().RemoverAsync(_produto);
    }

    [Fact]
    public async Task RemoverPorIdAsync_Deve_Remover_Produto()
    {
        var id = 1;
        _produtoRepository.RemoverPorIdAsync(id)
        .Returns(Task.CompletedTask);

        _produtoService.RemoverPorIdAsync(id)
       .Returns(Task.CompletedTask);

        await _produtoService.RemoverPorIdAsync(id);
        await _produtoRepository.Received().RemoverPorIdAsync(id);
    }

}
