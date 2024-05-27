namespace SistemaDeEstoque.Infrastructure.AcessoRepositorio.Queries;

public static class AdminQueries
{
    public static QueryModel RecuperarAdminExistentePorEmailQuery(string email)
    {
        string tabela = Map.ContextMapping.RecuperarTabelaAdmin();

        string query = @$"SELECT COUNT(*) FROM {tabela} WHERE Email = @Email";

        var parameters = new
        {
            Email = email
        };

        return new QueryModel(query, parameters);
    }
    public static QueryModel RecuperarAdminPorEmailQuery(string email)
    {
        string tabela = Map.ContextMapping.RecuperarTabelaAdmin();

        string query = @$"SELECT * FROM {tabela} WHERE Email = @Email";

        var parameters = new
        {
            Email = email
        };

        return new QueryModel(query, parameters);
    }
    public static QueryModel RecuperarAdminPorEmailSenhaQuery(string email, string senha)
    {
        string tabela = Map.ContextMapping.RecuperarTabelaAdmin();

        string query = @$"SELECT * FROM {tabela} WHERE Email = @Email AND Senha = @Senha";

        var parameters = new
        {
            Email = email,
            Senha = senha
        };

        return new QueryModel(query, parameters);
    }
    public static QueryModel RecuperarAdminPorIdQuery(long id)
    {
        string tabela = Map.ContextMapping.RecuperarTabelaAdmin();

        string query = @$"SELECT * FROM {tabela} WHERE Id = @Id";

        var parameters = new
        {
            Id = id
        };

        return new QueryModel(query, parameters);
    }
}
