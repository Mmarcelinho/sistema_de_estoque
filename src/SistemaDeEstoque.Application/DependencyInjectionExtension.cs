namespace SistemaDeEstoque.Application;

public static class DependencyInjectionExtension
{
    public static void AdicionarApplication(this IServiceCollection services)
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
