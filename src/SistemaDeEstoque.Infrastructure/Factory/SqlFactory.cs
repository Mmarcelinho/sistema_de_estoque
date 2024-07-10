namespace SistemaDeEstoque.Infrastructure.Factory;

    public class SqlFactory
    {
        private readonly IConfiguration _configuration;

        public SqlFactory(IConfiguration configuration) => _configuration = configuration;

        public IDbConnection CriarSqlConnection()
        {
            var connectionString = _configuration.GetConnectionString("Conexao");
            return new MySqlConnection(connectionString);
        }
    }
