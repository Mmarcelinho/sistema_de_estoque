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

public class EntradaServiceTests
{
    private readonly EntradaService _entradaService;

    private readonly IEntradaRepository _entradaRepository;

    private readonly Entrada _entrada;

    public EntradaServiceTests()
    {
        _entrada = new Entrada(1, 100, 10, 12345, 5, 1);

        _entradaRepository = Substitute.For<IEntradaRepository>();

        _entradaService = new EntradaService(_entradaRepository);
    }

    [Fact]
    public async Task ObterTodosAsync_Deve_Retornar_Todos_Os_Registros()
    {
        _entradaRepository.ObterTodosAsync()
        .Returns(new List<Entrada> {
            _entrada,
            _entrada,
            _entrada
        });

        var entradas = await _entradaService.ObterTodosAsync();
        entradas.Should().HaveCount(3);
    }

    [Fact]
    public async Task ObterPorIdAsync_Deve_Retornar_Registro_Com_O_Id_Especificado()
    {
        var id = 1;
        _entradaRepository.ObterPorIdAsync(id)
        .Returns(_entrada);
        var entrada = await _entradaService.ObterPorIdAsync(id);
        entrada.Id.Should().Be(_entrada.Id);
    }

    [Fact]
    public async Task ObterPorIdAsync_Deve_Retornar_Todas_As_Entradas_De_Transportadora_Com_O_Id_Especificado()
    {
        var id = 1;
        _entradaRepository.ObterPorIdEntradasDeTransportadoraAsync(id)
        .Returns(new List<Entrada> {
            _entrada,
            _entrada,
            _entrada
        });

        var entradas = await _entradaService.ObterPorIdEntradasDeTransportadoraAsync(id);
        foreach (var entrada in entradas)
        {
            entrada.IdTransportadora.Should().Be(id);
        }
    }

    [Fact]
    public async Task AdicionarAsync_Deve_Adicionar_Entrada_E_Retornar_Id()
    {
        var id = 1;
        _entradaRepository.AdicionarAsync(_entrada)
        .Returns(id);

        var idNovoRegistro = await _entradaService.AdicionarAsync(_entrada);
        idNovoRegistro.Should().Be(id);
    }

    [Fact]
    public async Task AtualizarAsync_Deve_Atualizar_Entrada()
    {
        _entradaRepository.AtualizarAsync(_entrada)
        .Returns(Task.CompletedTask);

        await _entradaService.AtualizarAsync(_entrada);
        await _entradaRepository.Received().AtualizarAsync(_entrada);
    }

    [Fact]
    public async Task RemoverAsync_Deve_Remover_Entrada()
    {
        _entradaRepository.RemoverAsync(_entrada)
        .Returns(Task.CompletedTask);

        _entradaService.RemoverAsync(_entrada)
       .Returns(Task.CompletedTask);

        await _entradaService.RemoverAsync(_entrada);
        await _entradaRepository.Received().RemoverAsync(_entrada);
    }

    [Fact]
    public async Task RemoverPorIdAsync_Deve_Remover_Entrada()
    {
        var id = 1;
        _entradaRepository.RemoverPorIdAsync(id)
        .Returns(Task.CompletedTask);

        _entradaService.RemoverPorIdAsync(id)
       .Returns(Task.CompletedTask);

        await _entradaService.RemoverPorIdAsync(id);
        await _entradaRepository.Received().RemoverPorIdAsync(id);
    }

}
