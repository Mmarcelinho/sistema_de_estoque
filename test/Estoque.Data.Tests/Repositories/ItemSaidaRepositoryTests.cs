using FluentAssertions;
using Estoque.Data.Context;
using Estoque.Data.Repositories;
using Estoque.Data.Tests.Database;
using Estoque.Domain.Entities;
using Xunit;

namespace Estoque.Data.Tests.Repositories;

public class ItemSaidaRepositoryTests
{
    private readonly DataContext _dataContext;
    private readonly DbInMemory _dbInMemory;

    private readonly ItemSaidaRepository _itemSaidaRepository;

    public ItemSaidaRepositoryTests()
    {
        _dbInMemory = new DbInMemory();
        _dataContext = _dbInMemory.GetContext();

        _itemSaidaRepository = new ItemSaidaRepository(_dataContext);
    }

    [Fact]
    public async Task ObterTodosAsync_Deve_Retornar_Todos_Os_Registros()
    {
        var itemSaidas = await _itemSaidaRepository.ObterTodosAsync();
        itemSaidas.Should().HaveCount(4);
    }

    [Fact]
    public async Task ObterPorIdAsync_Deve_Retornar_Registro_Com_O_Id_Especificado()
    {
        var id = 4;
        var itemSaida = await _itemSaidaRepository.ObterPorIdAsync(id);
        itemSaida.Id.Should().Be(id);
    }

    [Fact]
    public async Task ObterPorIdAsync_Deve_Retornar_Todos_Os_ItemSaidas_De_Saida_Com_O_Id_Especificado()
    {
        var id = 3;
        var itemSaidas = await _itemSaidaRepository.ObterPorIdItemSaidasDeSaidaAsync(id);
        itemSaidas.Should().HaveCount(1);
    }

    [Fact]
    public async Task ObterPorIdAsync_Deve_Retornar_Todos_Os_ItemSaidas_De_Produto_Com_O_Id_Especificado()
    {
        var id = 3;
        var itemSaidas = await _itemSaidaRepository.ObterPorIdItemSaidasDeProdutoAsync(id);
        itemSaidas.Should().HaveCount(1);
    }

    [Fact]
    public async Task AdicionarAsync_Deve_Adicionar_ItemSaida_E_Retornar_Id()
    {
        var itemSaida = new ItemSaida(5, "ItemSaida5", 50, 500, 4, 4);
        var id = await _itemSaidaRepository.AdicionarAsync(itemSaida);
        id.Should().Be(itemSaida.Id);
    }

    [Fact]
    public async Task AtualizarAsync_Deve_Atualizar_ItemSaida()
    {
        var novoLote = "ItemSaida02";
        var itemSaida = await _itemSaidaRepository.ObterPorIdAsync(2);

        itemSaida.AtualizarItemSaida(novoLote, itemSaida.Quantidade, itemSaida.Valor, itemSaida.IdSaida, itemSaida.IdProduto);
        await _itemSaidaRepository.AtualizarAsync(itemSaida);

        itemSaida.Lote.Should().Be(novoLote);
    }

    [Fact]
    public async Task RemoverAsync_Deve_Remover_ItemSaida()
    {
        var id = 2;
        var itemSaida = await _itemSaidaRepository.ObterPorIdAsync(id);
        await _itemSaidaRepository.RemoverAsync(itemSaida);

        var itemSaidaExcluido = await _itemSaidaRepository.ObterPorIdAsync(id);
        itemSaidaExcluido.Should().BeNull();
    }

    [Fact]
    public async Task RemoverPorIdAsync_Deve_Remover_ItemSaida()
    {
        var id = 1;
        await _itemSaidaRepository.RemoverPorIdAsync(id);

        var itemSaidaExcluido = await _itemSaidaRepository.ObterPorIdAsync(id);
        itemSaidaExcluido.Should().BeNull();
    }

    [Fact]
    public async Task RemoverPorIdAsync_Deve_Lancar_Excecao_Para_Registro_Inexistente()
    {
        var id = 100;
        await FluentActions.Invoking(async () => await _itemSaidaRepository.RemoverPorIdAsync(id))
            .Should().ThrowAsync<Exception>("O registro n�o existe na base de dados.");
    }

}
