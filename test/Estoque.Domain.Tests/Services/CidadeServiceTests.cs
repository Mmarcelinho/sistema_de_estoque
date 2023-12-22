using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces.Repositories;
using Estoque.Domain.Services;
using Xunit;

namespace Estoque.Domain.Tests.Services;

public class CidadeServiceTests
{
    private readonly CidadeService _cidadeService;

    private readonly ICidadeRepository _cidadeRepository;

    private readonly Cidade _cidade;

    public CidadeServiceTests()
    {
        _cidade = new Cidade(1, "Cidade1","BA");

        _cidadeRepository = Substitute.For<ICidadeRepository>();

        _cidadeService = new CidadeService(_cidadeRepository);
    }

    [Fact]
    public async Task ObterTodosAsync_Deve_Retornar_Todos_Os_Registros()
    {
        _cidadeRepository.ObterTodosAsync()
        .Returns(new List<Cidade> {
            _cidade,
            _cidade,
            _cidade
        });

        var cidades = await _cidadeService.ObterTodosAsync();
        cidades.Should().HaveCount(3);
    }

    [Fact]
    public async Task ObterPorIdAsync_Deve_Retornar_Registro_Com_O_Id_Especificado()
    {
        var id = 1;
        _cidadeRepository.ObterPorIdAsync(id)
        .Returns(_cidade);
        var cidade = await _cidadeService.ObterPorIdAsync(id);
        cidade.Id.Should().Be(_cidade.Id);
    }

    [Fact]
    public async Task ObterPorNomeAsync_Deve_Retornar_Registro_Com_O_Nome_Especificado()
    {
        var titulo = "Cidade1";
        _cidadeRepository.ObterPorNomeAsync(titulo)
        .Returns(_cidade);
        var cidade = await _cidadeService.ObterPorNomeAsync(titulo);
        cidade.Nome.Should().Be(_cidade.Nome);
    }

    [Fact]
    public async Task AdicionarAsync_Deve_Adicionar_Cidade_E_Retornar_Id()
    {
        var id = 1;
        _cidadeRepository.AdicionarAsync(_cidade)
        .Returns(id);

        var idNovoRegistro = await _cidadeService.AdicionarAsync(_cidade);
        idNovoRegistro.Should().Be(id);
    }

    [Fact]
    public async Task AtualizarAsync_Deve_Atualizar_Cidade()
    {
        _cidadeRepository.AtualizarAsync(_cidade)
        .Returns(Task.CompletedTask);

        await _cidadeService.AtualizarAsync(_cidade);
        await _cidadeRepository.Received().AtualizarAsync(_cidade);
    }

    [Fact]
    public async Task RemoverAsync_Deve_Remover_Cidade()
    {
        _cidadeRepository.RemoverAsync(_cidade)
        .Returns(Task.CompletedTask);

        _cidadeService.RemoverAsync(_cidade)
       .Returns(Task.CompletedTask);

        await _cidadeService.RemoverAsync(_cidade);
        await _cidadeRepository.Received().RemoverAsync(_cidade);
    }

    [Fact]
    public async Task RemoverPorIdAsync_Deve_Remover_Cidade()
    {
        var id = 1;
        _cidadeRepository.RemoverPorIdAsync(id)
        .Returns(Task.CompletedTask);

        _cidadeService.RemoverPorIdAsync(id)
       .Returns(Task.CompletedTask);

        await _cidadeService.RemoverPorIdAsync(id);
        await _cidadeRepository.Received().RemoverPorIdAsync(id);
    }

}
