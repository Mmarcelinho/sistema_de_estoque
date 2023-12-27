using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces.Repositories;
using Estoque.Domain.Services;
using Xunit;
using FluentAssertions.Equivalency;

namespace Estoque.Domain.Tests.Services;

public class ItemEntradaServiceTests
{
    private readonly ItemEntradaService _itemEntradaService;

    private readonly IItemEntradaRepository _itemEntradaRepository;

    private readonly ItemEntrada _itemEntrada;

    public ItemEntradaServiceTests()
    {
        _itemEntrada = new ItemEntrada(1, "1234", 10, 100, 1, 1);

        _itemEntradaRepository = Substitute.For<IItemEntradaRepository>();

        _itemEntradaService = new ItemEntradaService(_itemEntradaRepository);
    }

    [Fact]
    public async Task ObterTodosAsync_Deve_Retornar_Todos_Os_Registros()
    {
        _itemEntradaRepository.ObterTodosAsync()
        .Returns(new List<ItemEntrada> {
            _itemEntrada,
            _itemEntrada,
            _itemEntrada
        });

        var itemEntradas = await _itemEntradaService.ObterTodosAsync();
        itemEntradas.Should().HaveCount(3);
    }

    [Fact]
    public async Task ObterPorIdAsync_Deve_Retornar_Registro_Com_O_Id_Especificado()
    {
        var id = 1;
        _itemEntradaRepository.ObterPorIdAsync(id)
        .Returns(_itemEntrada);
        var itemEntrada = await _itemEntradaService.ObterPorIdAsync(id);
        itemEntrada.Id.Should().Be(_itemEntrada.Id);
    }


    [Fact]
    public async Task ObterPorIdAsync_Deve_Retornar_Todas_Os_ItemEntradas_De_Entrada_Com_O_Id_Especificado()
    {
        var id = 1;
        _itemEntradaRepository.ObterPorIdItemEntradasDeEntradaAsync(id)
        .Returns(new List<ItemEntrada> {
            _itemEntrada,
            _itemEntrada,
            _itemEntrada
        });

        var itemEntradas = await _itemEntradaService.ObterPorIdItemEntradasDeEntradaAsync(id);
        foreach (var itemEntrada in itemEntradas)
        {
            itemEntrada.IdEntrada.Should().Be(id);
        }
    }

    [Fact]
    public async Task ObterPorIdAsync_Deve_Retornar_Todas_Os_ItemEntradas_De_Produto_Com_O_Id_Especificado()
    {
        var id = 1;
        _itemEntradaRepository.ObterPorIdItemEntradasDeProdutoAsync(id)
        .Returns(new List<ItemEntrada> {
            _itemEntrada,
            _itemEntrada,
            _itemEntrada
        });

        var itemEntradas = await _itemEntradaService.ObterPorIdItemEntradasDeProdutoAsync(id);
        foreach (var itemEntrada in itemEntradas)
        {
            itemEntrada.IdProduto.Should().Be(id);
        }
    }

    [Fact]
    public async Task AdicionarAsync_Deve_Adicionar_ItemEntrada_E_Retornar_Id()
    {
        var id = 1;
        _itemEntradaRepository.AdicionarAsync(_itemEntrada)
        .Returns(id);

        var idNovoRegistro = await _itemEntradaService.AdicionarAsync(_itemEntrada);
        idNovoRegistro.Should().Be(id);
    }

    [Fact]
    public async Task AtualizarAsync_Deve_Atualizar_ItemEntrada()
    {
        _itemEntradaRepository.AtualizarAsync(_itemEntrada)
        .Returns(Task.CompletedTask);

        await _itemEntradaService.AtualizarAsync(_itemEntrada);
        await _itemEntradaRepository.Received().AtualizarAsync(_itemEntrada);
    }

    [Fact]
    public async Task RemoverAsync_Deve_Remover_ItemEntrada()
    {
        _itemEntradaRepository.RemoverAsync(_itemEntrada)
        .Returns(Task.CompletedTask);

        _itemEntradaService.RemoverAsync(_itemEntrada)
       .Returns(Task.CompletedTask);

        await _itemEntradaService.RemoverAsync(_itemEntrada);
        await _itemEntradaRepository.Received().RemoverAsync(_itemEntrada);
    }

    [Fact]
    public async Task RemoverPorIdAsync_Deve_Remover_ItemEntrada()
    {
        var id = 1;
        _itemEntradaRepository.RemoverPorIdAsync(id)
        .Returns(Task.CompletedTask);

        _itemEntradaService.RemoverPorIdAsync(id)
       .Returns(Task.CompletedTask);

        await _itemEntradaService.RemoverPorIdAsync(id);
        await _itemEntradaRepository.Received().RemoverPorIdAsync(id);
    }

}
