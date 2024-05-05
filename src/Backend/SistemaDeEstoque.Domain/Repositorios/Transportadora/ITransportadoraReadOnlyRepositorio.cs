namespace SistemaDeEstoque.Domain.Repositorios.Transportadora;

public interface ITransportadoraReadOnlyRepositorio
{
    Task<IList<Entidades.Transportadora>> RecuperarTodos();

    Task<Entidades.Transportadora> RecuperarPorId(long transportadoraId);
}
