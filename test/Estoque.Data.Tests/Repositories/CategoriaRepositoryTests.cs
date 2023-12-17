using FluentAssertions;
using Estoque.Data.Context;
using Estoque.Data.Repositories;
using Estoque.Data.Tests.Database;
using Estoque.Domain.Entities;
using Xunit;

namespace Estoque.Data.Tests.Repositories;

public class CategoriaRepositoryTests
{
    private readonly DataContext _dataContext;
    private readonly DbInMemory _dbInMemory;

    private readonly CategoriaRepository _categoriaRepository;

    public CategoriaRepositoryTests()
    {
        _dbInMemory = new DbInMemory();
        _dataContext = _dbInMemory.GetContext();

        _categoriaRepository = new CategoriaRepository(_dataContext);
    }

    [Fact]
    public async Task ObterTodosAsync_Deve_Retornar_Todos_Os_Registros()
    {
        var categorias = await _categoriaRepository.ObterTodosAsync();
        categorias.Should().HaveCount(4);
    }

    [Fact]
    public async Task ObterPorIdAsync_Deve_Retornar_Registro_Com_O_Id_Especificado()
    {
        var id = 4;
        var categoria = await _categoriaRepository.ObterPorIdAsync(id);
        categoria.Id.Should().Be(id);
    }

    [Fact]
    public async Task ObterPorTituloAsync_Deve_Retornar_Registro_Com_O_Titulo_Especificado()
    {
        var titulo = "Categoria3";
        var categoria = await _categoriaRepository.ObterPorTituloAsync(titulo);
        categoria.Titulo.Should().Be(titulo);
    }

}
