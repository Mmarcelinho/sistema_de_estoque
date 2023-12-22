using FluentAssertions;
using Estoque.Data.Context;
using Estoque.Data.Repositories;
using Estoque.Data.Tests.Database;
using Estoque.Domain.Entities;
using Xunit;
using Estoque.Domain.Interfaces.Repositories;

namespace Estoque.Data.Tests.Repositories;

public class ItemEntradaRepositoryTests
{
    private readonly DataContext _dataContext;
    private readonly DbInMemory _dbInMemory;

    private readonly ItemEntradaRepository _itemEntradaRepository;

    public ItemEntradaRepositoryTests()
    {
        _dbInMemory = new DbInMemory();
        _dataContext = _dbInMemory.GetContext();

        _itemEntradaRepository = new ItemEntradaRepository(_dataContext);
    }

    [Fact]
    public async Task ObterTodosAsync_Deve_Retornar_Todos_Os_Registros()
    {
        var itemEntradas = await _itemEntradaRepository.ObterTodosAsync();
        itemEntradas.Should().HaveCount(4);
    }

    [Fact]
    public async Task ObterPorIdAsync_Deve_Retornar_Registro_Com_O_Id_Especificado()
    {
        var id = 4;
        var itemEntrada = await _itemEntradaRepository.ObterPorIdAsync(id);
        itemEntrada.Id.Should().Be(id);
    }

    [Fact]
    public async Task ObterPorIdAsync_Deve_Retornar_Todos_Os_ItemEntradas_De_Entrada_Com_O_Id_Especificado()
    {
        var id = 3;
        var itemEntradas = await _itemEntradaRepository.ObterPorIdItemEntradasDeEntradaAsync(id);
        itemEntradas.Should().HaveCount(1);
    }

    [Fact]
    public async Task ObterPorIdAsync_Deve_Retornar_Todos_Os_ItemEntradas_De_Entrada_Com_A_Nf_Especificado()
    {
        var nf = 1233;
        var itemEntradas = await _itemEntradaRepository.ObterPorNfItemEntradasDeEntradaAsync(nf);
        itemEntradas.Should().HaveCount(1);
    }

    [Fact]
    public async Task ObterPorIdAsync_Deve_Retornar_Todos_Os_ItemEntradas_De_Produto_Com_O_Id_Especificado()
    {
        var id = 3;
        var itemEntradas = await _itemEntradaRepository.ObterPorIdItemEntradasDeProdutoAsync(id);
        itemEntradas.Should().HaveCount(1);
    }

    [Fact]
    public async Task AdicionarAsync_Deve_Adicionar_ItemEntrada_E_Retornar_Id()
    {
        var itemEntrada = new ItemEntrada(5, "ItemEntrada5", 50, 500, 4, 4);
        var id = await _itemEntradaRepository.AdicionarAsync(itemEntrada);
        id.Should().Be(itemEntrada.Id);
    }

    [Fact]
    public async Task AtualizarAsync_Deve_Atualizar_ItemEntrada()
    {
        var novoLote = "ItemEntrada02";
        var itemEntrada = await _itemEntradaRepository.ObterPorIdAsync(2);

        itemEntrada.AtualizarItemEntrada(novoLote, itemEntrada.Quantidade, itemEntrada.Valor, itemEntrada.IdEntrada, itemEntrada.IdProduto);
        await _itemEntradaRepository.AtualizarAsync(itemEntrada);

        itemEntrada.Lote.Should().Be(novoLote);
    }

    [Fact]
    public async Task RemoverAsync_Deve_Remover_ItemEntrada()
    {
        var id = 2;
        var itemEntrada = await _itemEntradaRepository.ObterPorIdAsync(id);
        await _itemEntradaRepository.RemoverAsync(itemEntrada);

        var itemEntradaExcluido = await _itemEntradaRepository.ObterPorIdAsync(id);
        itemEntradaExcluido.Should().BeNull();
    }

    [Fact]
    public async Task RemoverPorIdAsync_Deve_Remover_ItemEntrada()
    {
        var id = 1;
        await _itemEntradaRepository.RemoverPorIdAsync(id);

        var itemEntradaExcluido = await _itemEntradaRepository.ObterPorIdAsync(id);
        itemEntradaExcluido.Should().BeNull();
    }

    [Fact]
    public async Task RemoverPorIdAsync_Deve_Lancar_Excecao_Para_Registro_Inexistente()
    {
        var id = 100;
        await FluentActions.Invoking(async () => await _itemEntradaRepository.RemoverPorIdAsync(id))
            .Should().ThrowAsync<Exception>("O registro n�o existe na base de dados.");
    }

}
