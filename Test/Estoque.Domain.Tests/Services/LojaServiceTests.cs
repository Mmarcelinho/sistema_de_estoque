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

public class LojaServiceTests
{
    private readonly LojaService _lojaService;

    private readonly ILojaRepository _lojaRepository;

    private readonly Loja _loja;

    public LojaServiceTests()
    {
        _loja = new Loja(1, "Loja1", "Endereço1", 1, "Bairro1", "12345678", "12345", "12345", 1);

        _lojaRepository = Substitute.For<ILojaRepository>();

        _lojaService = new LojaService(_lojaRepository);
    }

    [Fact]
    public async Task ObterTodosAsync_Deve_Retornar_Todos_Os_Registros()
    {
        _lojaRepository.ObterTodosAsync()
        .Returns(new List<Loja> {
            _loja,
            _loja,
            _loja
        });

        var lojas = await _lojaService.ObterTodosAsync();
        lojas.Should().HaveCount(3);
    }

    [Fact]
    public async Task ObterPorIdAsync_Deve_Retornar_Registro_Com_O_Id_Especificado()
    {
        var id = 1;
        _lojaRepository.ObterPorIdAsync(id)
        .Returns(_loja);
        var loja = await _lojaService.ObterPorIdAsync(id);
        loja.Id.Should().Be(_loja.Id);
    }

    [Fact]
    public async Task ObterPorIdAsync_Deve_Retornar_Todas_As_Lojas_De_Cidade_Com_O_Id_Especificado()
    {
        var id = 1;
        _lojaRepository.ObterPorIdLojasDeCidadeAsync(id)
        .Returns(new List<Loja> {
            _loja,
            _loja,
            _loja
        });

        var lojas = await _lojaService.ObterPorIdLojasDeCidadeAsync(id);
        foreach (var loja in lojas)
        {
            loja.IdCidade.Should().Be(id);
        }
    }

    [Fact]
    public async Task AdicionarAsync_Deve_Adicionar_Loja_E_Retornar_Id()
    {
        var id = 1;
        _lojaRepository.AdicionarAsync(_loja)
        .Returns(id);

        var idNovoRegistro = await _lojaService.AdicionarAsync(_loja);
        idNovoRegistro.Should().Be(id);
    }

    [Fact]
    public async Task AtualizarAsync_Deve_Atualizar_Loja()
    {
        _lojaRepository.AtualizarAsync(_loja)
        .Returns(Task.CompletedTask);

        await _lojaService.AtualizarAsync(_loja);
        await _lojaRepository.Received().AtualizarAsync(_loja);
    }

    [Fact]
    public async Task RemoverAsync_Deve_Remover_Loja()
    {
        _lojaRepository.RemoverAsync(_loja)
        .Returns(Task.CompletedTask);

        _lojaService.RemoverAsync(_loja)
       .Returns(Task.CompletedTask);

        await _lojaService.RemoverAsync(_loja);
        await _lojaRepository.Received().RemoverAsync(_loja);
    }

    [Fact]
    public async Task RemoverPorIdAsync_Deve_Remover_Loja()
    {
        var id = 1;
        _lojaRepository.RemoverPorIdAsync(id)
        .Returns(Task.CompletedTask);

        _lojaService.RemoverPorIdAsync(id)
       .Returns(Task.CompletedTask);

        await _lojaService.RemoverPorIdAsync(id);
        await _lojaRepository.Received().RemoverPorIdAsync(id);
    }

}
