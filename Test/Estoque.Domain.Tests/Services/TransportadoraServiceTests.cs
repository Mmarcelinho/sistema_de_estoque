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

public class TransportadoraServiceTests
{
    private readonly TransportadoraService _transportadoraService;

    private readonly ITransportadoraRepository _transportadoraRepository;

    private readonly Transportadora _transportadora;

    public TransportadoraServiceTests()
    {
        _transportadora = new Transportadora(1, "Transportadora1", "Endereço1", 1, "Bairro1", "12345678", "12345", "12345", "Transportadora1@gmail.com", "12345678", 1);

        _transportadoraRepository = Substitute.For<ITransportadoraRepository>();

        _transportadoraService = new TransportadoraService(_transportadoraRepository);
    }

    [Fact]
    public async Task ObterTodosAsync_Deve_Retornar_Todos_Os_Registros()
    {
        _transportadoraRepository.ObterTodosAsync()
        .Returns(new List<Transportadora> {
            _transportadora,
            _transportadora,
            _transportadora
        });

        var transportadoras = await _transportadoraService.ObterTodosAsync();
        transportadoras.Should().HaveCount(3);
    }

    [Fact]
    public async Task ObterPorIdAsync_Deve_Retornar_Registro_Com_O_Id_Especificado()
    {
        var id = 1;
        _transportadoraRepository.ObterPorIdAsync(id)
        .Returns(_transportadora);
        var transportadora = await _transportadoraService.ObterPorIdAsync(id);
        transportadora.Id.Should().Be(_transportadora.Id);
    }

    [Fact]
    public async Task ObterPorIdAsync_Deve_Retornar_Todas_As_Transportadoras_De_Cidade_Com_O_Id_Especificado()
    {
        var id = 1;
        _transportadoraRepository.ObterPorIdTransportadorasDeCidadeAsync(id)
        .Returns(new List<Transportadora> {
            _transportadora,
            _transportadora,
            _transportadora
        });

        var transportadoras = await _transportadoraService.ObterPorIdTransportadorasDeCidadeAsync(id);
        foreach (var transportadora in transportadoras)
        {
            transportadora.IdCidade.Should().Be(id);
        }
    }

    [Fact]
    public async Task AdicionarAsync_Deve_Adicionar_Transportadora_E_Retornar_Id()
    {
        var id = 1;
        _transportadoraRepository.AdicionarAsync(_transportadora)
        .Returns(id);

        var idNovoRegistro = await _transportadoraService.AdicionarAsync(_transportadora);
        idNovoRegistro.Should().Be(id);
    }

    [Fact]
    public async Task AtualizarAsync_Deve_Atualizar_Transportadora()
    {
        _transportadoraRepository.AtualizarAsync(_transportadora)
        .Returns(Task.CompletedTask);

        await _transportadoraService.AtualizarAsync(_transportadora);
        await _transportadoraRepository.Received().AtualizarAsync(_transportadora);
    }

    [Fact]
    public async Task RemoverAsync_Deve_Remover_Transportadora()
    {
        _transportadoraRepository.RemoverAsync(_transportadora)
        .Returns(Task.CompletedTask);

        _transportadoraService.RemoverAsync(_transportadora)
       .Returns(Task.CompletedTask);

        await _transportadoraService.RemoverAsync(_transportadora);
        await _transportadoraRepository.Received().RemoverAsync(_transportadora);
    }

    [Fact]
    public async Task RemoverPorIdAsync_Deve_Remover_Transportadora()
    {
        var id = 1;
        _transportadoraRepository.RemoverPorIdAsync(id)
        .Returns(Task.CompletedTask);

        _transportadoraService.RemoverPorIdAsync(id)
       .Returns(Task.CompletedTask);

        await _transportadoraService.RemoverPorIdAsync(id);
        await _transportadoraRepository.Received().RemoverPorIdAsync(id);
    }

}
