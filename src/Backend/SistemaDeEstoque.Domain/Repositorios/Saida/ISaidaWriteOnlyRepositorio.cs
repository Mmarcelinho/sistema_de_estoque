namespace SistemaDeEstoque.Domain.Repositorios.Saida;

    public interface ISaidaWriteOnlyRepositorio
    {
        Task Registrar(Entidades.Saida saida);

        Task Deletar(long saidaId);
    }
