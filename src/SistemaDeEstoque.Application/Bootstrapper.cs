namespace SistemaDeEstoque.Application;

public static class Bootstrapper
{
    public static void AdicionarApplication(this IServiceCollection services, IConfiguration configuration)
    {
        AdicionarMediatR(services);
    }

    private static void AdicionarMediatR(IServiceCollection services)
    {
        var myHandlers = AppDomain.CurrentDomain.Load("SistemaDeEstoque.Application");

        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblies(myHandlers);
            config.AddOpenBehavior(typeof(ValidationsBehavior<,>));
        });

        services.AddValidatorsFromAssembly(Assembly.Load("SistemaDeEstoque.Application"));
    }
}
