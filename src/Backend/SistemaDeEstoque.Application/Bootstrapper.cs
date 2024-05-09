namespace SistemaDeEstoque.Application;

public static class Bootstrapper
{
    public static void AdicionarApplication(this IServiceCollection services, IConfiguration configuration)
    {

        AdicionarChaveAdicionalSenha(services, configuration);
        AdicionarTokenJWT(services, configuration);
        AdicionarMediatR(services);
        AdicionarUsuarioLogado(services);
    }

    private static void AdicionarChaveAdicionalSenha(IServiceCollection services, IConfiguration configuration)
    {
        var section = configuration.GetRequiredSection("Configuracoes:Senha:ChaveAdicionalSenha");

        services.AddScoped(option => new EncriptadorDeSenha(section.Value));
    }

    private static void AdicionarTokenJWT(IServiceCollection services, IConfiguration configuration)
    {
        var sectionTempoDeVida = configuration.GetRequiredSection("Configuracoes:Jwt:TempoVidaTokenMinutos");
        var sectionKey = configuration.GetRequiredSection("Configuracoes:Jwt:ChaveToken");

        services.AddScoped(option => new TokenController(int.Parse(sectionTempoDeVida.Value), sectionKey.Value));
    }

    private static void AdicionarMediatR(IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.AddOpenBehavior(typeof(ValidationsBehavior<,>));
        });

        services.AddValidatorsFromAssembly(Assembly.Load("SistemaDeEstoque.Application"));
    }

    private static void AdicionarUsuarioLogado(IServiceCollection services)
    => services.AddScoped<IAdminLogado, AdminLogado>();
}
