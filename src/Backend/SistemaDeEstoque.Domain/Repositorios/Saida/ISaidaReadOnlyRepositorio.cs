namespace SistemaDeEstoque.Domain.Repositorios.Saida;

public interface ISaidaReadOnlyRepositorio
{
    Task<IList<Entidades.Saida>> RecuperarTodos();

    Task<Entidades.Saida> RecuperarPorId(long saidaId);
}
