namespace SistemaDeEstoque.Domain.Repositorios.Saida;

public interface ISaidaUpdateOnlyRepositorio
{
    void Atualizar(Entidades.Saida saida);

    Task<Entidades.Saida> RecuperarPorId(long saidaId);
}
