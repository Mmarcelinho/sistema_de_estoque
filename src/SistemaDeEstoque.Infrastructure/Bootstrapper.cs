namespace SistemaDeEstoque.Infrastructure;

public static class Bootstrapper
{
    public static void AdicionarInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AdicionarFluentMigrator(services, configuration);
        AdicionarContexto(services, configuration);
        AdicionarDbConnection(services, configuration);
        AdicionarUnidadeDeTrabalho(services);
        AdicionarRepositorios(services);

        services.AddScoped<IEncriptadorDeSenha, EncriptadorDeSenha>();
        AdicionarToken(services, configuration);
        services.AddScoped<IAdminLogado, AdminLogado>();
    }

    private static void AdicionarToken(IServiceCollection services, IConfiguration configuration)
    {
        var tempoVidaTokenMinutos = configuration.GetValue<uint>("Configuracoes:Jwt:TempoVidaTokenMinutos");
        var chaveToken = configuration.GetValue<string>("Configuracoes:Jwt:ChaveToken");

        services.AddScoped<IGeradorTokenAcesso>(config => new GeradorTokenJwt(tempoVidaTokenMinutos, chaveToken!));
    }

    private static void AdicionarFluentMigrator(IServiceCollection services, IConfiguration configuration)
    {
        services.AddFluentMigratorCore()
        .ConfigureRunner(c => c.AddMySql8()
        .WithGlobalConnectionString(configuration.GetConexaoCompleta())
        .ScanIn(Assembly.Load("SistemaDeEstoque.Infrastructure")).For.All());
    }

    private static void AdicionarContexto(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConexaoCompleta();
        var versaoServidor = ServerVersion.AutoDetect(connectionString);

        services.AddDbContext<SistemaDeEstoqueContext>(opcoes =>
        {
            opcoes.UseMySql(connectionString, versaoServidor);
        });
    }

    private static void AdicionarDbConnection(IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IDbConnection>
        (provider =>
        {
            var connection = new MySqlConnection(configuration.GetConexaoCompleta());
            connection.Open();
            return connection;
        });
    }

    private static void AdicionarUnidadeDeTrabalho(IServiceCollection services)
    => services.AddScoped<IUnidadeDeTrabalho, UnidadeDeTrabalho>();

    private static void AdicionarRepositorios(IServiceCollection services)
    {
        services.AddScoped<IAdminReadOnlyRepositorio, AdminRepositorio>();
        services.AddScoped<IAdminWriteOnlyRepositorio, AdminRepositorio>();
        services.AddScoped<IAdminUpdateOnlyRepositorio, AdminRepositorio>();

    }
}
