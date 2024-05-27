namespace SistemaDeEstoque.Domain.Repositorios.Transportadora;

    public interface ITransportadoraWriteOnlyRepositorio
    {
        Task Registrar(Entidades.Transportadora transportadora);

        Task Deletar(long transportadoraId);
    }
