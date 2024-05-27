namespace SistemaDeEstoque.Domain.Repositorios.Entrada;

    public interface IEntradaWriteOnlyRepositorio
    {
        Task Registrar(Entidades.Entrada entrada);

        Task Deletar(long entradaId);
    }
