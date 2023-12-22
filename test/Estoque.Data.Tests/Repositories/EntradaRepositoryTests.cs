using FluentAssertions;
using Estoque.Data.Context;
using Estoque.Data.Repositories;
using Estoque.Data.Tests.Database;
using Estoque.Domain.Entities;
using Xunit;
using Estoque.Domain.Interfaces.Repositories;

namespace Estoque.Data.Tests.Repositories;

public class EntradaRepositoryTests
{
    private readonly DataContext _dataContext;
    private readonly DbInMemory _dbInMemory;

    private readonly EntradaRepository _entradaRepository;

    public EntradaRepositoryTests()
    {
        _dbInMemory = new DbInMemory();
        _dataContext = _dbInMemory.GetContext();

        _entradaRepository = new EntradaRepository(_dataContext);
    }

    [Fact]
    public async Task ObterTodosAsync_Deve_Retornar_Todos_Os_Registros()
    {
        var entradas = await _entradaRepository.ObterTodosAsync();
        entradas.Should().HaveCount(4);
    }

    [Fact]
    public async Task ObterPorIdAsync_Deve_Retornar_Registro_Com_O_Id_Especificado()
    {
        var id = 4;
        var entrada = await _entradaRepository.ObterPorIdAsync(id);
        entrada.Id.Should().Be(id);
    }

    [Fact]
    public async Task ObterPorIdAsync_Deve_Retornar_Todas_As_Entradas_De_Transportadora_Com_O_Id_Especificado()
    {
        var id = 3;
        var entradas = await _entradaRepository.ObterPorIdEntradasDeTransportadoraAsync(id);
        entradas.Should().HaveCount(1);
    }

    [Fact]
    public async Task ObterPorNomeAsync_Deve_Retornar_Todas_As_Entradas_De_Transportadora_Com_O_Nome_Especificado()
    {
        var nome = "Transportadora3";
        var entradas = await _entradaRepository.ObterPorNomeEntradasDeTransportadoraAsync(nome);
        entradas.Should().HaveCount(1);
    }

    [Fact]
    public async Task AdicionarAsync_Deve_Adicionar_Entrada_E_Retornar_Id()
    {
        var entrada = new Entrada(5, 500, 50, 1234, 10, 4);
        var id = await _entradaRepository.AdicionarAsync(entrada);
        id.Should().Be(entrada.Id);
    }

    [Fact]
    public async Task AtualizarAsync_Deve_Atualizar_Entrada()
    {
        var novaNotaFiscal = 12345;
        var entrada = await _entradaRepository.ObterPorIdAsync(2);

        entrada.AtualizarEntrada(entrada.Total, entrada.Frete, novaNotaFiscal, entrada.Imposto, entrada.IdTransportadora);
        await _entradaRepository.AtualizarAsync(entrada);

        entrada.NumeroNotaFiscal.Should().Be(novaNotaFiscal);
    }

    [Fact]
    public async Task RemoverAsync_Deve_Remover_Entrada()
    {
        var id = 2;
        var entrada = await _entradaRepository.ObterPorIdAsync(id);
        await _entradaRepository.RemoverAsync(entrada);

        var entradaExcluida = await _entradaRepository.ObterPorIdAsync(id);
        entradaExcluida.Should().BeNull();
    }

    [Fact]
    public async Task RemoverPorIdAsync_Deve_Remover_Entrada()
    {
        var id = 1;
        await _entradaRepository.RemoverPorIdAsync(id);

        var entradaExcluida = await _entradaRepository.ObterPorIdAsync(id);
        entradaExcluida.Should().BeNull();
    }

    [Fact]
    public async Task RemoverPorIdAsync_Deve_Lancar_Excecao_Para_Registro_Inexistente()
    {
        var id = 100;
        await FluentActions.Invoking(async () => await _entradaRepository.RemoverPorIdAsync(id))
            .Should().ThrowAsync<Exception>("O registro não existe na base de dados.");
    }

}
