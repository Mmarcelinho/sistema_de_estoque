using Estoque.Data.Context;
using Estoque.Domain.Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Estoque.Data.Tests.Database;

public class DbInMemory
{
    private readonly DataContext _dataContext;
    private readonly SqliteConnection _connection;

    public DbInMemory()
    {
        _connection = new SqliteConnection("DataSource=:memory:");
        _connection.Open();

        var options = new DbContextOptionsBuilder<DataContext>()
        .UseSqlite(_connection)
        .EnableSensitiveDataLogging()
        .Options;

        _dataContext = new DataContext(options);

        InsertFakeData();
    }

    public DataContext GetContext() => _dataContext;

    public void Cleanup() => _connection.Close();

    private void InsertFakeData()
    {
        if (_dataContext.Database.EnsureCreated())
        {
            var ids = new[] { 1, 2, 3, 4 };

            ids.ToList().ForEach(id =>
            {
                CategoriaFakeData(id);
                CidadeFakeData(id);
                EntradaFakeData(id);
                FornecedorFakeData(id);
                ItemEntradaFakeData(id);
                ItemSaidaFakeData(id);
                LojaFakeData(id);
                ProdutoFakeData(id);
                SaidaFakeData(id);
                TransportadoraFakeData(id);
            });
            _dataContext.SaveChanges();
        }

    }

    private void CategoriaFakeData(int id)
    {
        _dataContext.Categorias.Add(new Categoria(id, $"Categoria{id}"));
    }

    private void CidadeFakeData(int id)
    {
        var cidade = new Cidade(id, $"Cidade{id}", "BA");
        _dataContext.Cidades.Add(cidade);
        Console.WriteLine($"Added Cidade: {cidade.Id}");
    }

    private void ProdutoFakeData(int id)
    {
        _dataContext.Produtos.Add(new Produto(id, $"Produto{id}", "Produto", 2 * id, true, id));
    }

    private void EntradaFakeData(int id)
    {
        _dataContext.Entradas.Add(new Entrada(id, 100 * id, 10 * id, 1234, 2 * id, id));
    }

    private void FornecedorFakeData(int id)
    {
        _dataContext.Fornecedores.Add(
         new Fornecedor(
         id, $"Fornecedor{id}", $"Endereco{id}", id, $"Bairro{id}", "12345", $"Fornecedor{id}@gmail.com", "12345", "12345", id)
         );
    }

    private void ItemEntradaFakeData(int id)
    {
        _dataContext.ItemEntradas.Add(new ItemEntrada(id, $"ItemEntrada{id}", 5 * id, 100 * id, id, id));
    }

    private void ItemSaidaFakeData(int id)
    {
        _dataContext.ItemSaidas.Add(new ItemSaida(id, $"ItemSaida{id}", 5 * id, 100 * id, id, id));
    }

    private void LojaFakeData(int id)
    {
        _dataContext.Lojas.Add(new Loja(id, $"Loja{id}", $"Endereco{id}", id, $"Bairro{id}", "12345678", "12345", "12345", id));
    }

    private void SaidaFakeData(int id)
    {
        _dataContext.Saidas.Add(new Saida(id, 100 * id, 10 * id, 2 * id, id, id));
    }

    private void TransportadoraFakeData(int id)
    {
        _dataContext.Transportadoras.Add(new Transportadora(id, $"Transportadora{id}", $"Endereco{id}", id, $"Bairro{id}", "12345", "12345678", "12345", "Transportadora{id}@gmail.com", "12345678", id));
    }
}
