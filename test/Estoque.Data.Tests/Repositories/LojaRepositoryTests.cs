using FluentAssertions;
using Estoque.Data.Context;
using Estoque.Data.Repositories;
using Estoque.Data.Tests.Database;
using Estoque.Domain.Entities;
using Xunit;
using Estoque.Domain.Interfaces.Repositories;

namespace Estoque.Data.Tests.Repositories;

public class LojaRepositoryTests
{
    private readonly DataContext _dataContext;
    private readonly DbInMemory _dbInMemory;

    private readonly LojaRepository _lojaRepository;

    public LojaRepositoryTests()
    {
        _dbInMemory = new DbInMemory();
        _dataContext = _dbInMemory.GetContext();

        _lojaRepository = new LojaRepository(_dataContext);
    }

    [Fact]
    public async Task ObterTodosAsync_Deve_Retornar_Todos_Os_Registros()
    {
        var lojas = await _lojaRepository.ObterTodosAsync();
        lojas.Should().HaveCount(4);
    }

    [Fact]
    public async Task ObterPorIdAsync_Deve_Retornar_Registro_Com_O_Id_Especificado()
    {
        var id = 4;
        var loja = await _lojaRepository.ObterPorIdAsync(id);
        loja.Id.Should().Be(id);
    }

    [Fact]
    public async Task ObterPorIdAsync_Deve_Retornar_Todos_As_Lojas_De_Cidade_Por_Id_Especificado()
    {
        var id = 3;
        var lojas = await _lojaRepository.ObterPorIdLojasDeCidadeAsync(id);
        lojas.Should().HaveCount(1);
    }

    [Fact]
    public async Task ObterPorIdAsync_Deve_Retornar_Todos_As_Lojas_De_Cidade_Por_Nome_Especificado()
    {
        var nome = "Cidade3";
        var lojas = await _lojaRepository.ObterPorNomeLojasDeCidadeAsync(nome);
        lojas.Should().HaveCount(1);
    }

    [Fact]
    public async Task AdicionarAsync_Deve_Adicionar_Loja_E_Retornar_Id()
    {
        var loja = new Loja(5, "Loja5", "Endereco5", 5, "Bairro5", "12345678", "12345", "12345", 4);
        var id = await _lojaRepository.AdicionarAsync(loja);
        id.Should().Be(loja.Id);
    }

    [Fact]
    public async Task AtualizarAsync_Deve_Atualizar_Loja()
    {
        var novoNome = "Loja02";
        var loja = await _lojaRepository.ObterPorIdAsync(2);

        loja.AtualizarLoja(
            novoNome,
            loja.Endereco,
            loja.Numero,
            loja.Bairro,
            loja.Telefone,
            loja.Inscricao,
            loja.Cnpj,
            loja.IdCidade);
        await _lojaRepository.AtualizarAsync(loja);

        loja.Nome.Should().Be(novoNome);
    }

    [Fact]
    public async Task RemoverAsync_Deve_Remover_Loja()
    {
        var id = 2;
        var loja = await _lojaRepository.ObterPorIdAsync(id);
        await _lojaRepository.RemoverAsync(loja);

        var lojaExcluida = await _lojaRepository.ObterPorIdAsync(id);
        lojaExcluida.Should().BeNull();
    }

    [Fact]
    public async Task RemoverPorIdAsync_Deve_Remover_Loja()
    {
        var id = 1;
        await _lojaRepository.RemoverPorIdAsync(id);

        var lojaExcluida = await _lojaRepository.ObterPorIdAsync(id);
        lojaExcluida.Should().BeNull();
    }

    [Fact]
    public async Task RemoverPorIdAsync_Deve_Lancar_Excecao_Para_Registro_Inexistente()
    {
        var id = 100;
        await FluentActions.Invoking(async () => await _lojaRepository.RemoverPorIdAsync(id))
            .Should().ThrowAsync<Exception>("O registro não existe na base de dados.");
    }

}
