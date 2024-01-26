using FluentAssertions;
using Estoque.Data.Context;
using Estoque.Data.Repositories;
using Estoque.Data.Tests.Database;
using Estoque.Domain.Entities;
using Xunit;

namespace Estoque.Data.Tests.Repositories;

public class TransportadoraRepositoryTests
{
    private readonly DataContext _dataContext;
    private readonly DbInMemory _dbInMemory;

    private readonly TransportadoraRepository _transportadoraRepository;

    public TransportadoraRepositoryTests()
    {
        _dbInMemory = new DbInMemory();
        _dataContext = _dbInMemory.GetContext();

        _transportadoraRepository = new TransportadoraRepository(_dataContext);
    }

    [Fact]
    public async Task ObterTodosAsync_Deve_Retornar_Todos_Os_Registros()
    {
        var transportadoras = await _transportadoraRepository.ObterTodosAsync();
        transportadoras.Should().HaveCount(4);
    }

    [Fact]
    public async Task ObterPorIdAsync_Deve_Retornar_Registro_Com_O_Id_Especificado()
    {
        var id = 4;
        var transportadora = await _transportadoraRepository.ObterPorIdAsync(id);
        transportadora.Id.Should().Be(id);
    }

    [Fact]
    public async Task ObterPorIdAsync_Deve_Retornar_Todas_As_Transportadoras_De_Cidade_Por_Id_Especificado()
    {
        var id = 3;
        var transportadoras = await _transportadoraRepository.ObterPorIdTransportadorasDeCidadeAsync(id);
        transportadoras.Should().HaveCount(1);
    }

    [Fact]
    public async Task ObterPorIdAsync_Deve_Retornar_Todas_As_Transportadoras_De_Cidade_Por_Nome_Especificado()
    {
        var nome = "Cidade3";
        var transportadoras = await _transportadoraRepository.ObterPorNomeTransportadorasDeCidadeAsync(nome);
        transportadoras.Should().HaveCount(1);
    }

    [Fact]
    public async Task AdicionarAsync_Deve_Adicionar_Transportadora_E_Retornar_Id()
    {
        var transportadora = new Transportadora(5, "Transportadora5", "Endereco5", 5, "Bairro5", "12345", "12345678", "12345", "transportadora5@gmail.com", "12345678", 4);
        var id = await _transportadoraRepository.AdicionarAsync(transportadora);
        id.Should().Be(transportadora.Id);
    }

    [Fact]
    public async Task AtualizarAsync_Deve_Atualizar_Transportadora()
    {
        var novoNome = "Transportadora02";
        var transportadora = await _transportadoraRepository.ObterPorIdAsync(2);

        transportadora.AtualizarTransportadora(
            novoNome,
            transportadora.Endereco,
            transportadora.Numero,
            transportadora.Bairro,
            transportadora.Cep,
            transportadora.Cnpj,
            transportadora.Inscricao,
            transportadora.Contato,
            transportadora.Telefone,
            transportadora.IdCidade);
        await _transportadoraRepository.AtualizarAsync(transportadora);

        transportadora.Nome.Should().Be(novoNome);
    }

    [Fact]
    public async Task RemoverAsync_Deve_Remover_Transportadora()
    {
        var id = 2;
        var transportadora = await _transportadoraRepository.ObterPorIdAsync(id);
        await _transportadoraRepository.RemoverAsync(transportadora);

        var transportadoraExcluida = await _transportadoraRepository.ObterPorIdAsync(id);
        transportadoraExcluida.Should().BeNull();
    }

    [Fact]
    public async Task RemoverPorIdAsync_Deve_Remover_Transportadora()
    {
        var id = 1;
        await _transportadoraRepository.RemoverPorIdAsync(id);

        var transportadoraExcluida = await _transportadoraRepository.ObterPorIdAsync(id);
        transportadoraExcluida.Should().BeNull();
    }

    [Fact]
    public async Task RemoverPorIdAsync_Deve_Lancar_Excecao_Para_Registro_Inexistente()
    {
        var id = 100;
        await FluentActions.Invoking(async () => await _transportadoraRepository.RemoverPorIdAsync(id))
            .Should().ThrowAsync<Exception>("O registro não existe na base de dados.");
    }

}
