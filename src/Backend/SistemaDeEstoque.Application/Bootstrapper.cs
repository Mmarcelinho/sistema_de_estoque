namespace SistemaDeEstoque.Application;

public static class Bootstrapper
{
    public static void AdicionarApplication(this IServiceCollection services, IConfiguration configuration)
    {
        AdicionarMediatR(services, configuration);
    }

    private static void AdicionarMediatR(IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(config =>
        {
            config.AddOpenBehavior(typeof(ValidationsBehavior<,>));
        });

        services.AddValidatorsFromAssembly(Assembly.Load("SistemaDeEstoque.Application"));
    }
}
