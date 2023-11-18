using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Estoque.Domain.Entities;

namespace Estoque.Data.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);

    }

    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Cidade> Cidades { get; set; }
    public DbSet<Entrada> Entradas { get; set; }
    public DbSet<Fornecedor> Fornecedores { get; set; }
    public DbSet<ItemEntrada> ItemEntradas { get; set; }
    public DbSet<ItemSaida> ItemSaidas { get; set; }
    public DbSet<Loja> Lojas { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Saida> Saidas { get; set; }
    public DbSet<Transportadora> Transportadoras { get; set; }

}
