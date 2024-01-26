using FluentAssertions;
using Estoque.Data.Context;
using Estoque.Data.Repositories;
using Estoque.Data.Tests.Database;
using Estoque.Domain.Entities;
using Xunit;

namespace Estoque.Data.Tests.Repositories;

public class SaidaRepositoryTests
{
    private readonly DataContext _dataContext;
    private readonly DbInMemory _dbInMemory;

    private readonly SaidaRepository _saidaRepository;

    public SaidaRepositoryTests()
    {
        _dbInMemory = new DbInMemory();
        _dataContext = _dbInMemory.GetContext();

        _saidaRepository = new SaidaRepository(_dataContext);
    }

    [Fact]
    public async Task ObterTodosAsync_Deve_Retornar_Todos_Os_Registros()
    {
        var saidas = await _saidaRepository.ObterTodosAsync();
        saidas.Should().HaveCount(4);
    }

    [Fact]
    public async Task ObterPorIdAsync_Deve_Retornar_Registro_Com_O_Id_Especificado()
    {
        var id = 4;
        var saida = await _saidaRepository.ObterPorIdAsync(id);
        saida.Id.Should().Be(id);
    }

    [Fact]
    public async Task ObterPorIdAsync_Deve_Retornar_Todas_As_Saidas_De_Loja_Com_O_Id_Especificado()
    {
        var id = 3;
        var saidas = await _saidaRepository.ObterPorIdSaidasDeLojaAsync(id);
        saidas.Should().HaveCount(1);
    }

    [Fact]
    public async Task ObterPorNomeAsync_Deve_Retornar_Todas_As_Saidas_De_Loja_Com_O_Nome_Especificado()
    {
        var nome = "Loja3";
        var saidas = await _saidaRepository.ObterPorNomeSaidasDeLojaAsync(nome);
        saidas.Should().HaveCount(1);
    }

    [Fact]
    public async Task ObterPorIdAsync_Deve_Retornar_Todas_As_Saidas_De_Transportadora_Com_O_Id_Especificado()
    {
        var id = 3;
        var saidas = await _saidaRepository.ObterPorIdSaidasDeTransportadoraAsync(id);
        saidas.Should().HaveCount(1);
    }

    [Fact]
    public async Task ObterPorNomeAsync_Deve_Retornar_Todas_As_Saidas_De_Transportadora_Com_O_Nome_Especificado()
    {
        var nome = "Transportadora3";
        var saidas = await _saidaRepository.ObterPorNomeSaidasDeTransportadoraAsync(nome);
        saidas.Should().HaveCount(1);
    }

    [Fact]
    public async Task AdicionarAsync_Deve_Adicionar_Saida_E_Retornar_Id()
    {
        var saida = new Saida(5, 500, 50, 5, 4, 4);
        var id = await _saidaRepository.AdicionarAsync(saida);
        id.Should().Be(saida.Id);
    }

    [Fact]
    public async Task AtualizarAsync_Deve_Atualizar_Saida()
    {
        var novoTotal = 250;
        var saida = await _saidaRepository.ObterPorIdAsync(2);

        saida.AtualizarSaida(novoTotal, saida.Frete, saida.Imposto, saida.IdLoja, saida.IdTransportadora);
        await _saidaRepository.AtualizarAsync(saida);

        saida.Total.Should().Be(novoTotal);
    }

    [Fact]
    public async Task RemoverAsync_Deve_Remover_Saida()
    {
        var id = 2;
        var saida = await _saidaRepository.ObterPorIdAsync(id);
        await _saidaRepository.RemoverAsync(saida);

        var saidaExcluida = await _saidaRepository.ObterPorIdAsync(id);
        saidaExcluida.Should().BeNull();
    }

    [Fact]
    public async Task RemoverPorIdAsync_Deve_Remover_Saida()
    {
        var id = 1;
        await _saidaRepository.RemoverPorIdAsync(id);

        var saidaExcluida = await _saidaRepository.ObterPorIdAsync(id);
        saidaExcluida.Should().BeNull();
    }

    [Fact]
    public async Task RemoverPorIdAsync_Deve_Lancar_Excecao_Para_Registro_Inexistente()
    {
        var id = 100;
        await FluentActions.Invoking(async () => await _saidaRepository.RemoverPorIdAsync(id))
            .Should().ThrowAsync<Exception>("O registro não existe na base de dados.");
    }

}
