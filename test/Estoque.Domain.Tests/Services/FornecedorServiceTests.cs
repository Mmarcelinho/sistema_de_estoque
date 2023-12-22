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

public class FornecedorServiceTests
{
    private readonly FornecedorService _fornecedorService;

    private readonly IFornecedorRepository _fornecedorRepository;

    private readonly Fornecedor _fornecedor;

    public FornecedorServiceTests()
    {
        _fornecedor = new Fornecedor(1, "Fornecedor1", "Endereço1", 1, "Bairro1", "12345", "Fornecedor1@gmail.com", "12345", "12345", 1);

        _fornecedorRepository = Substitute.For<IFornecedorRepository>();

        _fornecedorService = new FornecedorService(_fornecedorRepository);
    }

    [Fact]
    public async Task ObterTodosAsync_Deve_Retornar_Todos_Os_Registros()
    {
        _fornecedorRepository.ObterTodosAsync()
        .Returns(new List<Fornecedor> {
            _fornecedor,
            _fornecedor,
            _fornecedor
        });

        var fornecedores = await _fornecedorService.ObterTodosAsync();
        fornecedores.Should().HaveCount(3);
    }

    [Fact]
    public async Task ObterPorIdAsync_Deve_Retornar_Registro_Com_O_Id_Especificado()
    {
        var id = 1;
        _fornecedorRepository.ObterPorIdAsync(id)
        .Returns(_fornecedor);
        var fornecedor = await _fornecedorService.ObterPorIdAsync(id);
        fornecedor.Id.Should().Be(_fornecedor.Id);
    }

    [Fact]
    public async Task ObterPorIdAsync_Deve_Retornar_Todos_As_Fornecedores_De_Cidade_Com_O_Id_Especificado()
    {
        var id = 1;
        _fornecedorRepository.ObterPorIdFornecedoresDeCidadeAsync(id)
        .Returns(new List<Fornecedor> {
            _fornecedor,
            _fornecedor,
            _fornecedor
        });

        var fornecedores = await _fornecedorService.ObterPorIdFornecedoresDeCidadeAsync(id);
        foreach (var fornecedor in fornecedores)
        {
            fornecedor.IdCidade.Should().Be(id);
        }
    }

    [Fact]
    public async Task AdicionarAsync_Deve_Adicionar_Fornecedor_E_Retornar_Id()
    {
        var id = 1;
        _fornecedorRepository.AdicionarAsync(_fornecedor)
        .Returns(id);

        var idNovoRegistro = await _fornecedorService.AdicionarAsync(_fornecedor);
        idNovoRegistro.Should().Be(id);
    }

    [Fact]
    public async Task AtualizarAsync_Deve_Atualizar_Fornecedor()
    {
        _fornecedorRepository.AtualizarAsync(_fornecedor)
        .Returns(Task.CompletedTask);

        await _fornecedorService.AtualizarAsync(_fornecedor);
        await _fornecedorRepository.Received().AtualizarAsync(_fornecedor);
    }

    [Fact]
    public async Task RemoverAsync_Deve_Remover_Fornecedor()
    {
        _fornecedorRepository.RemoverAsync(_fornecedor)
        .Returns(Task.CompletedTask);

        _fornecedorService.RemoverAsync(_fornecedor)
       .Returns(Task.CompletedTask);

        await _fornecedorService.RemoverAsync(_fornecedor);
        await _fornecedorRepository.Received().RemoverAsync(_fornecedor);
    }

    [Fact]
    public async Task RemoverPorIdAsync_Deve_Remover_Fornecedor()
    {
        var id = 1;
        _fornecedorRepository.RemoverPorIdAsync(id)
        .Returns(Task.CompletedTask);

        _fornecedorService.RemoverPorIdAsync(id)
       .Returns(Task.CompletedTask);

        await _fornecedorService.RemoverPorIdAsync(id);
        await _fornecedorRepository.Received().RemoverPorIdAsync(id);
    }

}
