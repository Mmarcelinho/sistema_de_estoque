namespace SistemaDeEstoque.Infrastructure;

public static class Bootstrapper
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AdicionarFluentMigrator(services, configuration);
    }

    private static void AdicionarFluentMigrator(IServiceCollection services, IConfiguration configuration)
    {
        services.AddFluentMigratorCore().ConfigureRunner(c => c.AddMySql8().WithGlobalConnectionString(configuration.GetConexaoCompleta()).ScanIn(Assembly.Load("SistemaDeEstoque.Infrastructure")).For.All());
    }
}
