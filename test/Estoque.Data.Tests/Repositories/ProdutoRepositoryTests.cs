using FluentAssertions;
using Estoque.Data.Context;
using Estoque.Data.Repositories;
using Estoque.Data.Tests.Database;
using Estoque.Domain.Entities;
using Xunit;
using Estoque.Domain.Interfaces.Repositories;

namespace Estoque.Data.Tests.Repositories;

public class ProdutoRepositoryTests
{
    private readonly DataContext _dataContext;
    private readonly DbInMemory _dbInMemory;

    private readonly ProdutoRepository _produtoRepository;

    public ProdutoRepositoryTests()
    {
        _dbInMemory = new DbInMemory();
        _dataContext = _dbInMemory.GetContext();

        _produtoRepository = new ProdutoRepository(_dataContext);
    }

    [Fact]
    public async Task ObterTodosAsync_Deve_Retornar_Todos_Os_Registros()
    {
        var produtos = await _produtoRepository.ObterTodosAsync();
        produtos.Should().HaveCount(4);
    }

    [Fact]
    public async Task ObterPorIdAsync_Deve_Retornar_Registro_Com_O_Id_Especificado()
    {
        var id = 4;
        var produto = await _produtoRepository.ObterPorIdAsync(id);
        produto.Id.Should().Be(id);
    }

    [Fact]
    public async Task ObterPorNomeAsync_Deve_Retornar_Registro_Com_O_Nome_Especificado()
    {
        var nome = "Produto3";
        var produto = await _produtoRepository.ObterPorNomeAsync(nome);
        produto.Nome.Should().Be(nome);
    }

    [Fact]
    public async Task AdicionarAsync_Deve_Adicionar_Produto_E_Retornar_Id()
    {
        var produto = new Produto(5, "Produto5","Produto",10.0,true,5);
        var id = await _produtoRepository.AdicionarAsync(produto);
        id.Should().Be(produto.Id);
    }

    [Fact]
    public async Task AtualizarAsync_Deve_Atualizar_Produto()
    {
        var novoNome = "Produto02";
        var produto = await _produtoRepository.ObterPorIdAsync(2);

        produto.AtualizarProduto(novoNome,produto.Descricao,produto.Peso,produto.Controlado,produto.QuantMinima);
        await _produtoRepository.AtualizarAsync(produto);

        produto.Nome.Should().Be(novoNome);
    }

    [Fact]
    public async Task RemoverAsync_Deve_Remover_Produto()
    {
        var id = 2;
        var produto = await _produtoRepository.ObterPorIdAsync(id);
        await _produtoRepository.RemoverAsync(produto);

        var produtoExcluido = await _produtoRepository.ObterPorIdAsync(id);
        produtoExcluido.Should().BeNull();
    }

    [Fact]
    public async Task RemoverPorIdAsync_Deve_Remover_Produto()
    {
        var id = 1;
        await _produtoRepository.RemoverPorIdAsync(id);

        var produtoExcluido = await _produtoRepository.ObterPorIdAsync(id);
        produtoExcluido.Should().BeNull();
    }

    [Fact]
    public async Task RemoverPorIdAsync_Deve_Lancar_Excecao_Para_Registro_Inexistente()
    {
        var id = 100;
        await FluentActions.Invoking(async () => await _produtoRepository.RemoverPorIdAsync(id))
            .Should().ThrowAsync<Exception>("O registro n�o existe na base de dados.");
    }

}
