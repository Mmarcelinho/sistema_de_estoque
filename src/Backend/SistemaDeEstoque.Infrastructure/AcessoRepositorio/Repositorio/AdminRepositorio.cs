namespace SistemaDeEstoque.Infrastructure.AcessoRepositorio.Repositorio;

public class AdminRepositorio : IAdminWriteRepositorio, IAdminReadOnlyRepositorio, IAdminUpdateOnlyRepositorio
{
    private readonly SistemaDeEstoqueContext _contexto;

    private readonly IDbConnection _connection;
    public AdminRepositorio(SistemaDeEstoqueContext contexto, IDbConnection connection)
    {
        _contexto = contexto;
        _connection = connection;
    }

    public async Task Adicionar(Admin admin) => await _contexto.Admins.AddAsync(admin);
    
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

    public void Atualizar(Admin admin) => _contexto.Admins.Update(admin);
    
}
