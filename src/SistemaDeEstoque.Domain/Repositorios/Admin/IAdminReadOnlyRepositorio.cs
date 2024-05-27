namespace SistemaDeEstoque.Domain.Repositorios.Admin;

public interface IAdminReadOnlyRepositorio
{
    Task<bool> ExisteAdminComEmail(string email);

    Task<Entidades.Admin> RecuperarPorId(long id);

    Task<Entidades.Admin> RecuperarPorEmailSenha(string email, string senha);

    Task<Entidades.Admin> RecuperarPorEmail(string email);
}
