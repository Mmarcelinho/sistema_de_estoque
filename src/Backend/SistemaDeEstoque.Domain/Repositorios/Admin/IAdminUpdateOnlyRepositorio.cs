namespace SistemaDeEstoque.Domain.Repositorios.Admin;

public interface IAdminUpdateOnlyRepositorio
{
    void Atualizar(Entidades.Admin admin);

    Task<Entidades.Admin> RecuperarPorId(long id);
}
