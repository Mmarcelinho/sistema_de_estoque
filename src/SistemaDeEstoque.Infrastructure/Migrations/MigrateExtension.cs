namespace SistemaDeEstoque.Infrastructure.Migrations;

    public static class MigrateExtension
    {
        public static void MigrateBancoDeDados(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();

            var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
            runner.ListMigrations();

            runner.MigrateUp();
        }
    }
