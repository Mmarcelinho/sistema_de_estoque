using FluentAssertions;
using Estoque.Data.Context;
using Estoque.Data.Repositories;
using Estoque.Data.Tests.Database;
using Estoque.Domain.Entities;
using Xunit;
using Estoque.Domain.Interfaces.Repositories;

namespace Estoque.Data.Tests.Repositories;

public class FornecedorRepositoryTests
{
    private readonly DataContext _dataContext;
    private readonly DbInMemory _dbInMemory;

    private readonly FornecedorRepository _fornecedorRepository;

    public FornecedorRepositoryTests()
    {
        _dbInMemory = new DbInMemory();
        _dataContext = _dbInMemory.GetContext();

        _fornecedorRepository = new FornecedorRepository(_dataContext);
    }

    [Fact]
    public async Task ObterTodosAsync_Deve_Retornar_Todos_Os_Registros()
    {
        var fornecedors = await _fornecedorRepository.ObterTodosAsync();
        fornecedors.Should().HaveCount(4);
    }

    [Fact]
    public async Task ObterPorIdAsync_Deve_Retornar_Registro_Com_O_Id_Especificado()
    {
        var id = 4;
        var fornecedor = await _fornecedorRepository.ObterPorIdAsync(id);
        fornecedor.Id.Should().Be(id);
    }

    [Fact]
    public async Task ObterPorIdAsync_Deve_Retornar_Todos_Os_Registros_Com_O_IdEstrangeiro_Especificado()
    {
        var id = 3;
        var fornecedores = await _fornecedorRepository.ObterPorIdFornecedoresDeCidadeAsync(id);
        fornecedores.Should().HaveCount(1);
    }


    [Fact]
    public async Task AdicionarAsync_Deve_Adicionar_Produto_E_Retornar_Id()
    {
        var fornecedor = new Fornecedor(5, "Fornecedor5", "Endereco5", 5, "Bairro5", "12345", "12345678", "12345", "12345", 4);
        var id = await _fornecedorRepository.AdicionarAsync(fornecedor);
        id.Should().Be(fornecedor.Id);
    }

    [Fact]
    public async Task AtualizarAsync_Deve_Atualizar_Fornecedor()
    {
        var novoNome = "Fornecedor02";
        var fornecedor = await _fornecedorRepository.ObterPorIdAsync(2);

        fornecedor.AtualizarFornecedor(
            novoNome, 
            fornecedor.Endereco, 
            fornecedor.Numero, 
            fornecedor.Bairro, 
            fornecedor.Cep, 
            fornecedor.Contato, 
            fornecedor.Cnpj, 
            fornecedor.Inscricao, 
            fornecedor.IdCidade);
        await _fornecedorRepository.AtualizarAsync(fornecedor);

        fornecedor.Nome.Should().Be(novoNome);
    }

    [Fact]
    public async Task RemoverAsync_Deve_Remover_Fornecedor()
    {
        var id = 2;
        var fornecedor = await _fornecedorRepository.ObterPorIdAsync(id);
        await _fornecedorRepository.RemoverAsync(fornecedor);

        var fornecedorExcluida = await _fornecedorRepository.ObterPorIdAsync(id);
        fornecedorExcluida.Should().BeNull();
    }

    [Fact]
    public async Task RemoverPorIdAsync_Deve_Remover_Fornecedor()
    {
        var id = 1;
        await _fornecedorRepository.RemoverPorIdAsync(id);

        var fornecedorExcluida = await _fornecedorRepository.ObterPorIdAsync(id);
        fornecedorExcluida.Should().BeNull();
    }

    [Fact]
    public async Task RemoverPorIdAsync_Deve_Lancar_Excecao_Para_Registro_Inexistente()
    {
        var id = 100;
        await FluentActions.Invoking(async () => await _fornecedorRepository.RemoverPorIdAsync(id))
            .Should().ThrowAsync<Exception>("O registro não existe na base de dados.");
    }

}
