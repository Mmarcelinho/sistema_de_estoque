using FluentAssertions;
using Estoque.Data.Context;
using Estoque.Data.Repositories;
using Estoque.Data.Tests.Database;
using Estoque.Domain.Entities;
using Xunit;
using Estoque.Domain.Interfaces.Repositories;

namespace Estoque.Data.Tests.Repositories;

public class CidadeRepositoryTests
{
    private readonly DataContext _dataContext;
    private readonly DbInMemory _dbInMemory;

    private readonly CidadeRepository _cidadeRepository;

    public CidadeRepositoryTests()
    {
        _dbInMemory = new DbInMemory();
        _dataContext = _dbInMemory.GetContext();

        _cidadeRepository = new CidadeRepository(_dataContext);
    }

    [Fact]
    public async Task ObterTodosAsync_Deve_Retornar_Todos_Os_Registros()
    {
        var cidades = await _cidadeRepository.ObterTodosAsync();
        cidades.Should().HaveCount(4);
    }

    [Fact]
    public async Task ObterPorIdAsync_Deve_Retornar_Registro_Com_O_Id_Especificado()
    {
        var id = 4;
        var cidade = await _cidadeRepository.ObterPorIdAsync(id);
        cidade.Id.Should().Be(id);
    }

    [Fact]
    public async Task ObterPorTituloAsync_Deve_Retornar_Registro_Com_O_Nome_Especificado()
    {
        var nome = "Cidade3";
        var cidade = await _cidadeRepository.ObterPorNomeAsync(nome);
        cidade.Nome.Should().Be(nome);
    }

    [Fact]
    public async Task AdicionarAsync_Deve_Adicionar_Produto_E_Retornar_Id()
    {
        var cidade = new Cidade(5, "Cidade5","RJ");
        var id = await _cidadeRepository.AdicionarAsync(cidade);
        id.Should().Be(cidade.Id);
    }

    [Fact]
    public async Task AtualizarAsync_Deve_Atualizar_Cidade()
    {
        var novoNome = "Cidade02";
        var cidade = await _cidadeRepository.ObterPorIdAsync(2);

        cidade.AtualizarCidade(novoNome,cidade.Uf);
        await _cidadeRepository.AtualizarAsync(cidade);

        cidade.Nome.Should().Be(novoNome);
    }

    [Fact]
    public async Task RemoverAsync_Deve_Remover_Cidade()
    {
        var id = 2;
        var cidade = await _cidadeRepository.ObterPorIdAsync(id);
        await _cidadeRepository.RemoverAsync(cidade);

        var cidadeExcluida = await _cidadeRepository.ObterPorIdAsync(id);
        cidadeExcluida.Should().BeNull();
    }

    [Fact]
    public async Task RemoverPorIdAsync_Deve_Remover_Cidade()
    {
        var id = 1;
        await _cidadeRepository.RemoverPorIdAsync(id);

        var cidadeExcluida = await _cidadeRepository.ObterPorIdAsync(id);
        cidadeExcluida.Should().BeNull();
    }

    [Fact]
    public async Task RemoverPorIdAsync_Deve_Lancar_Excecao_Para_Registro_Inexistente()
    {
        var id = 100;
        await FluentActions.Invoking(async () => await _cidadeRepository.RemoverPorIdAsync(id))
            .Should().ThrowAsync<Exception>("O registro não existe na base de dados.");
    }

}
