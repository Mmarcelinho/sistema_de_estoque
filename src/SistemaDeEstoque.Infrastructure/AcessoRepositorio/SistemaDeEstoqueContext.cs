namespace SistemaDeEstoque.Infrastructure.AcessoRepositorio;

public class SistemaDeEstoqueContext : DbContext
{
    public SistemaDeEstoqueContext(DbContextOptions<SistemaDeEstoqueContext> options) : base(options) { }

    public DbSet<Admin> Admins { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SistemaDeEstoqueContext).Assembly);
    }
}
