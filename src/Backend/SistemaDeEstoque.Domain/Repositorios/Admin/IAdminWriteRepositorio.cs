namespace SistemaDeEstoque.Domain.Repositorios.Admin;

public interface IAdminWriteRepositorio
{
    Task Adicionar(Entidades.Admin admin);
}
