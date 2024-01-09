using Microsoft.EntityFrameworkCore;
using Estoque.Data.Context;
using Estoque.Data.Repositories;
using Estoque.Domain.Interfaces.Repositories;
using Estoque.Domain.Interfaces.Service;
using Estoque.Domain.Services;
using Microsoft.AspNetCore.Identity;
using Estoque.Identity.Data;
using Estoque.Identity.Services;
using Estoque.Application.Interfaces.Services;

namespace Estoque.Api.IoC;

public static class NativeInjectorConfig
{
    public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DataContext>(options => options.UseSqlServer(configuration.GetConnectionString("ApiEstoque")));

        services.AddDbContext<IdentityDataContext>(options => options.UseSqlServer(configuration.GetConnectionString("ApiEstoque")));

        services.AddDefaultIdentity<IdentityUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<IdentityDataContext>()
            .AddDefaultTokenProviders();

        services.AddScoped<IIdentityService, IdentityService>();

        services.AddScoped<ICategoriaRepository, CategoriaRepository>();
        services.AddScoped<ICategoriaService, CategoriaService>();

        services.AddScoped<ICidadeRepository, CidadeRepository>();
        services.AddScoped<ICidadeService, CidadeService>();

        services.AddScoped<IEntradaRepository, EntradaRepository>();
        services.AddScoped<IEntradaService, EntradaService>();

        services.AddScoped<IFornecedorRepository, FornecedorRepository>();
        services.AddScoped<IFornecedorService, FornecedorService>();

        services.AddScoped<IItemEntradaRepository, ItemEntradaRepository>();
        services.AddScoped<IItemEntradaService, ItemEntradaService>();

        services.AddScoped<IItemSaidaRepository, ItemSaidaRepository>();
        services.AddScoped<IItemSaidaService, ItemSaidaService>();

        services.AddScoped<ILojaRepository, LojaRepository>();
        services.AddScoped<ILojaService, LojaService>();

        services.AddScoped<IProdutoRepository, ProdutoRepository>();
        services.AddScoped<IProdutoService, ProdutoService>();

        services.AddScoped<ISaidaRepository, SaidaRepository>();
        services.AddScoped<ISaidaService, SaidaService>();

        services.AddScoped<ITransportadoraRepository, TransportadoraRepository>();
        services.AddScoped<ITransportadoraService, TransportadoraService>();
    }
}