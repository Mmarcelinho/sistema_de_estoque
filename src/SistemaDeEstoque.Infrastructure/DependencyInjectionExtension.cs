namespace SistemaDeEstoque.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AdicionarInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AdicionarFluentMigrator(services, configuration);
        AdicionarContexto(services, configuration);
        AdicionarSqlFactory(services);
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

    private static void AdicionarSqlFactory(IServiceCollection services)
    => services.AddScoped<SqlFactory>();
    
    private static void AdicionarRepositorios(IServiceCollection services)
    {
        services.AddScoped<IAdminReadOnlyRepositorio, AdminDapperRepositorio>();
        services.AddScoped<IAdminWriteOnlyRepositorio, AdminEfRepositorio>();
        services.AddScoped<IAdminUpdateOnlyRepositorio, AdminEfRepositorio>();

        services.AddScoped<IUnidadeDeTrabalho, UnidadeDeTrabalho>();
    }
}
