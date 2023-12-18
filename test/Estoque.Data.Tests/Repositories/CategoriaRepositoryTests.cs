using FluentAssertions;
using Estoque.Data.Context;
using Estoque.Data.Repositories;
using Estoque.Data.Tests.Database;
using Estoque.Domain.Entities;
using Estoque.Application.DTOs.Entities;
using Estoque.Application.DTOs.Mappings;
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

    [Fact]
    public async Task AdicionarAsync_Deve_Adicionar_Categoria_E_Retornar_Id()
    {
        var categoria = new Categoria(5, "Categoria5");
        var id = await _categoriaRepository.AdicionarAsync(categoria);
        id.Should().Be(categoria.Id);
    }

    [Fact]
    public async Task AtualizarAsync_Deve_Atualizar_Categoria()
    {
        var novoTitulo = "Categoria02";
        var categoria = await _categoriaRepository.ObterPorIdAsync(2);

        categoria.AtualizarCategoria(novoTitulo);
        await _categoriaRepository.AtualizarAsync(categoria);
       
        categoria.Titulo.Should().Be(novoTitulo);
    }

        [Fact]
        public async Task RemoverAsync_Deve_Remover_Categoria()
        {
            var id = 2;
            var categoria = await _categoriaRepository.ObterPorIdAsync(id);
            await _categoriaRepository.RemoverAsync(categoria);

            var categoriaExcluido = await _categoriaRepository.ObterPorIdAsync(id);
            categoriaExcluido.Should().BeNull();
        }

        [Fact]
        public async Task RemoverPorIdAsync_Deve_Remover_Categoria()
        {
            var id = 1;
            await _categoriaRepository.RemoverPorIdAsync(id);

            var categoriaExcluido = await _categoriaRepository.ObterPorIdAsync(id);
            categoriaExcluido.Should().BeNull();
        }

        [Fact]
        public async Task RemoverPorIdAsync_Deve_Lancar_Excecao_Para_Registro_Inexistente()
        {
            var id = 100;
            await FluentActions.Invoking(async () => await _categoriaRepository.RemoverPorIdAsync(id))
                .Should().ThrowAsync<Exception>("O registro não existe na base de dados.");
        }
    }


