namespace SistemaDeEstoque.Domain.Repositorios.Entrada;

    public interface IEntradaUpdateOnlyRepositorio
    {
        void Atualizar(Entidades.Entrada entrada);

        Task<Entidades.Entrada> RecuperarPorId(long entradaId);
    }
