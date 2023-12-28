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

public class SaidaServiceTests
{
    private readonly SaidaService _saidaService;

    private readonly ISaidaRepository _saidaRepository;

    private readonly Saida _saida;

    public SaidaServiceTests()
    {
        _saida = new Saida(1, 100, 10, 2, 1, 1);

        _saidaRepository = Substitute.For<ISaidaRepository>();

        _saidaService = new SaidaService(_saidaRepository);
    }

    [Fact]
    public async Task ObterTodosAsync_Deve_Retornar_Todos_Os_Registros()
    {
        _saidaRepository.ObterTodosAsync()
        .Returns(new List<Saida> {
            _saida,
            _saida,
            _saida
        });

        var saidas = await _saidaService.ObterTodosAsync();
        saidas.Should().HaveCount(3);
    }

    [Fact]
    public async Task ObterPorIdAsync_Deve_Retornar_Registro_Com_O_Id_Especificado()
    {
        var id = 1;
        _saidaRepository.ObterPorIdAsync(id)
        .Returns(_saida);
        var saida = await _saidaService.ObterPorIdAsync(id);
        saida.Id.Should().Be(_saida.Id);
    }

    [Fact]
    public async Task ObterPorIdAsync_Deve_Retornar_Todas_As_Saidas_De_Loja_Com_O_Id_Especificado()
    {
        var id = 1;
        _saidaRepository.ObterPorIdSaidasDeLojaAsync(id)
        .Returns(new List<Saida> {
            _saida,
            _saida,
            _saida
        });

        var saidas = await _saidaService.ObterPorIdSaidasDeLojaAsync(id);
        foreach (var saida in saidas)
        {
            saida.IdTransportadora.Should().Be(id);
        }
    }

    [Fact]
    public async Task ObterPorIdAsync_Deve_Retornar_Todas_As_Saidas_De_Transportadora_Com_O_Id_Especificado()
    {
        var id = 1;
        _saidaRepository.ObterPorIdSaidasDeTransportadoraAsync(id)
        .Returns(new List<Saida> {
            _saida,
            _saida,
            _saida
        });

        var saidas = await _saidaService.ObterPorIdSaidasDeTransportadoraAsync(id);
        foreach (var saida in saidas)
        {
            saida.IdTransportadora.Should().Be(id);
        }
    }

    [Fact]
    public async Task AdicionarAsync_Deve_Adicionar_Saida_E_Retornar_Id()
    {
        var id = 1;
        _saidaRepository.AdicionarAsync(_saida)
        .Returns(id);

        var idNovoRegistro = await _saidaService.AdicionarAsync(_saida);
        idNovoRegistro.Should().Be(id);
    }

    [Fact]
    public async Task AtualizarAsync_Deve_Atualizar_Saida()
    {
        _saidaRepository.AtualizarAsync(_saida)
        .Returns(Task.CompletedTask);

        await _saidaService.AtualizarAsync(_saida);
        await _saidaRepository.Received().AtualizarAsync(_saida);
    }

    [Fact]
    public async Task RemoverAsync_Deve_Remover_Saida()
    {
        _saidaRepository.RemoverAsync(_saida)
        .Returns(Task.CompletedTask);

        _saidaService.RemoverAsync(_saida)
       .Returns(Task.CompletedTask);

        await _saidaService.RemoverAsync(_saida);
        await _saidaRepository.Received().RemoverAsync(_saida);
    }

    [Fact]
    public async Task RemoverPorIdAsync_Deve_Remover_Saida()
    {
        var id = 1;
        _saidaRepository.RemoverPorIdAsync(id)
        .Returns(Task.CompletedTask);

        _saidaService.RemoverPorIdAsync(id)
       .Returns(Task.CompletedTask);

        await _saidaService.RemoverPorIdAsync(id);
        await _saidaRepository.Received().RemoverPorIdAsync(id);
    }

}
