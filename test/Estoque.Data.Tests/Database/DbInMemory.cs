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
            });
            _dataContext.SaveChanges();
        }

    }

    private void CategoriaFakeData(int id)
    {
        _dataContext.Categorias.Add(new Categoria(id, $"Categoria{id}"));
    }
}
