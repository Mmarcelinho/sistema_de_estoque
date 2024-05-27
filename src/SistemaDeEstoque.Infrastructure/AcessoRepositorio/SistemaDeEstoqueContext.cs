namespace SistemaDeEstoque.Infrastructure.AcessoRepositorio;

public class SistemaDeEstoqueContext : DbContext
{
    public SistemaDeEstoqueContext(DbContextOptions<SistemaDeEstoqueContext> options) : base(options) { }

    public DbSet<Admin> Admins { get; set; }

    public DbSet<Endereco> Enderecos { get; set; }

    public DbSet<Entrada> Entradas { get; set; }

    public DbSet<Fornecedor> Fornecedores { get; set; }

    public DbSet<HistoricoEstoque> HistoricosEstoque { get; set; }

    public DbSet<ItemEntrada> ItemEntradas { get; set; }

    public DbSet<ItemSaida> ItemSaida { get; set; }

    public DbSet<Loja> Loja { get; set; }

    public DbSet<Produto> IProduto { get; set; }

    public DbSet<Saida> Saida { get; set; }

    public DbSet<Transportadora> Transportadora { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SistemaDeEstoqueContext).Assembly);
    }
}
