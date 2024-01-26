using FluentAssertions;
using NSubstitute;
using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces.Repositories;
using Estoque.Domain.Services;
using Xunit;

namespace Estoque.Domain.Tests.Services;

public class ItemSaidaServiceTests
{
    private readonly ItemSaidaService _itemSaidaService;

    private readonly IItemSaidaRepository _itemSaidaRepository;

    private readonly ItemSaida _itemSaida;

    public ItemSaidaServiceTests()
    {
        _itemSaida = new ItemSaida(1, "1234", 10, 100, 1, 1);

        _itemSaidaRepository = Substitute.For<IItemSaidaRepository>();

        _itemSaidaService = new ItemSaidaService(_itemSaidaRepository);
    }

    [Fact]
    public async Task ObterTodosAsync_Deve_Retornar_Todos_Os_Registros()
    {
        _itemSaidaRepository.ObterTodosAsync()
        .Returns(new List<ItemSaida> {
            _itemSaida,
            _itemSaida,
            _itemSaida
        });

        var itemSaidas = await _itemSaidaService.ObterTodosAsync();
        itemSaidas.Should().HaveCount(3);
    }

    [Fact]
    public async Task ObterPorIdAsync_Deve_Retornar_Registro_Com_O_Id_Especificado()
    {
        var id = 1;
        _itemSaidaRepository.ObterPorIdAsync(id)
        .Returns(_itemSaida);
        var itemSaida = await _itemSaidaService.ObterPorIdAsync(id);
        itemSaida.Id.Should().Be(_itemSaida.Id);
    }


    [Fact]
    public async Task ObterPorIdAsync_Deve_Retornar_Todos_Os_ItemSaidas_De_Saida_Com_O_Id_Especificado()
    {
        var id = 1;
        _itemSaidaRepository.ObterPorIdItemSaidasDeSaidaAsync(id)
        .Returns(new List<ItemSaida> {
            _itemSaida,
            _itemSaida,
            _itemSaida
        });

        var itemSaidas = await _itemSaidaService.ObterPorIdItemSaidasDeSaidaAsync(id);
        foreach (var itemSaida in itemSaidas)
        {
            itemSaida.IdSaida.Should().Be(id);
        }
    }

    [Fact]
    public async Task ObterPorIdAsync_Deve_Retornar_Todos_Os_ItemSaidas_De_Produto_Com_O_Id_Especificado()
    {
        var id = 1;
        _itemSaidaRepository.ObterPorIdItemSaidasDeProdutoAsync(id)
        .Returns(new List<ItemSaida> {
            _itemSaida,
            _itemSaida,
            _itemSaida
        });

        var itemSaidas = await _itemSaidaService.ObterPorIdItemSaidasDeProdutoAsync(id);
        foreach (var itemSaida in itemSaidas)
        {
            itemSaida.IdProduto.Should().Be(id);
        }
    }

    [Fact]
    public async Task AdicionarAsync_Deve_Adicionar_ItemSaida_E_Retornar_Id()
    {
        var id = 1;
        _itemSaidaRepository.AdicionarAsync(_itemSaida)
        .Returns(id);

        var idNovoRegistro = await _itemSaidaService.AdicionarAsync(_itemSaida);
        idNovoRegistro.Should().Be(id);
    }

    [Fact]
    public async Task AtualizarAsync_Deve_Atualizar_ItemSaida()
    {
        _itemSaidaRepository.AtualizarAsync(_itemSaida)
        .Returns(Task.CompletedTask);

        await _itemSaidaService.AtualizarAsync(_itemSaida);
        await _itemSaidaRepository.Received().AtualizarAsync(_itemSaida);
    }

    [Fact]
    public async Task RemoverAsync_Deve_Remover_ItemSaida()
    {
        _itemSaidaRepository.RemoverAsync(_itemSaida)
        .Returns(Task.CompletedTask);

        _itemSaidaService.RemoverAsync(_itemSaida)
       .Returns(Task.CompletedTask);

        await _itemSaidaService.RemoverAsync(_itemSaida);
        await _itemSaidaRepository.Received().RemoverAsync(_itemSaida);
    }

    [Fact]
    public async Task RemoverPorIdAsync_Deve_Remover_ItemSaida()
    {
        var id = 1;
        _itemSaidaRepository.RemoverPorIdAsync(id)
        .Returns(Task.CompletedTask);

        _itemSaidaService.RemoverPorIdAsync(id)
       .Returns(Task.CompletedTask);

        await _itemSaidaService.RemoverPorIdAsync(id);
        await _itemSaidaRepository.Received().RemoverPorIdAsync(id);
    }

}
