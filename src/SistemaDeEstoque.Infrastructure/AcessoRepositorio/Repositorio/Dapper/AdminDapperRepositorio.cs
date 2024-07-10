namespace SistemaDeEstoque.Infrastructure.AcessoRepositorio.Repositorio.Dapper;

    public class AdminDapperRepositorio: IAdminReadOnlyRepositorio
{
    private readonly IDbConnection _connection;
    public AdminDapperRepositorio(SistemaDeEstoqueContext contexto, SqlFactory sqlFactory) => _connection = sqlFactory.CriarSqlConnection();
    
    public async Task<bool> ExisteAdminComEmail(string email)
    {
        var query = AdminQueries.RecuperarAdminExistentePorEmailQuery(email);
        var count = await _connection.ExecuteScalarAsync<int>(query.Query, query.Parameters);
        return count > 0;
    }

    public async Task<Admin> RecuperarPorEmail(string email)
    {
        var query = AdminQueries.RecuperarAdminPorEmailQuery(email);
        var admin = await _connection.QueryFirstOrDefaultAsync<Admin>(query.Query, query.Parameters);
        return admin;
    }

    public async Task<Admin> RecuperarPorEmailSenha(string email, string senha)
    {
        var query = AdminQueries.RecuperarAdminPorEmailSenhaQuery(email, senha);
        var admin = await _connection.QueryFirstOrDefaultAsync<Admin>(query.Query, query.Parameters);
        return admin;
    }

    public async Task<Admin> RecuperarPorId(long id)
    {
        var query = AdminQueries.RecuperarAdminPorIdQuery(id);
        var admin = await _connection.QueryFirstOrDefaultAsync<Admin>(query.Query, query.Parameters);
        return admin;
    }
}
