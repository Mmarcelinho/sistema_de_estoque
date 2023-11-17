namespace ApiEstoque.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    { }

    public DbSet<Categoria> Categoria { get; set; }
    public DbSet<Cidade> Cidade { get; set; }
    public DbSet<Entrada> Entrada { get; set; }
    public DbSet<Fornecedor> Fornecedor { get; set; }
    public DbSet<ItemEntrada> ItemEntrada { get; set; }
    public DbSet<ItemSaida> ItemSaida { get; set; }
    public DbSet<Loja> Loja { get; set; }
    public DbSet<Produto> Produto { get; set; }
    public DbSet<Saida> Saida { get; set; }
    public DbSet<Transportadora> Transportadora { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);

    }

}
