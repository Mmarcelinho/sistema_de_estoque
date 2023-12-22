using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces.Repositories;
using Estoque.Domain.Services;
using Xunit;

namespace Estoque.Domain.Tests.Services;

public class CategoriaServiceTests
{
    private readonly CategoriaService _categoriaService;

    private readonly ICategoriaRepository _categoriaRepository;

    private readonly Categoria _categoria;

    public CategoriaServiceTests()
    {
        _categoria = new Categoria(1, "Categoria1");

        _categoriaRepository = Substitute.For<ICategoriaRepository>();

        _categoriaService = new CategoriaService(_categoriaRepository);
    }

    [Fact]
    public async Task ObterTodosAsync_Deve_Retornar_Todos_Os_Registros()
    {
        _categoriaRepository.ObterTodosAsync()
        .Returns(new List<Categoria> {
            _categoria,
            _categoria,
            _categoria
        });

        var categorias = await _categoriaService.ObterTodosAsync();
        categorias.Should().HaveCount(3);
    }

    [Fact]
    public async Task ObterPorIdAsync_Deve_Retornar_Registro_Com_O_Id_Especificado()
    {
        var id = 1;
        _categoriaRepository.ObterPorIdAsync(id)
        .Returns(_categoria);
        var categoria = await _categoriaService.ObterPorIdAsync(id);
        categoria.Id.Should().Be(_categoria.Id);
    }

    [Fact]
    public async Task ObterPorTituloAsync_Deve_Retornar_Registro_Com_O_Titulo_Especificado()
    {
        var titulo = "Categoria1";
        _categoriaRepository.ObterPorTituloAsync(titulo)
        .Returns(_categoria);
        var categoria = await _categoriaService.ObterPorTituloAsync(titulo);
        categoria.Titulo.Should().Be(_categoria.Titulo);
    }

    [Fact]
    public async Task AdicionarAsync_Deve_Adicionar_Categoria_E_Retornar_Id()
    {
        var id = 1;
        _categoriaRepository.AdicionarAsync(_categoria)
        .Returns(id);

        var idNovoRegistro = await _categoriaService.AdicionarAsync(_categoria);
        idNovoRegistro.Should().Be(id);
    }

    [Fact]
    public async Task AtualizarAsync_Deve_Atualizar_Categoria()
    {
        _categoriaRepository.AtualizarAsync(_categoria)
        .Returns(Task.CompletedTask);

        await _categoriaService.AtualizarAsync(_categoria);
        await _categoriaRepository.Received().AtualizarAsync(_categoria);
    }

    [Fact]
    public async Task RemoverAsync_Deve_Remover_Categoria()
    {
        _categoriaRepository.RemoverAsync(_categoria)
        .Returns(Task.CompletedTask);

        _categoriaService.RemoverAsync(_categoria)
       .Returns(Task.CompletedTask);

        await _categoriaService.RemoverAsync(_categoria);
        await _categoriaRepository.Received().RemoverAsync(_categoria);
    }

    [Fact]
    public async Task RemoverPorIdAsync_Deve_Remover_Categoria()
    {
        var id = 1;
        _categoriaRepository.RemoverPorIdAsync(id)
        .Returns(Task.CompletedTask);

        _categoriaService.RemoverPorIdAsync(id)
       .Returns(Task.CompletedTask);

        await _categoriaService.RemoverPorIdAsync(id);
        await _categoriaRepository.Received().RemoverPorIdAsync(id);
    }

}
