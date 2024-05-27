namespace SistemaDeEstoque.Domain.Repositorios.Transportadora;

    public interface ITransportadoraUpdateOnlyRepositorio
    {
        void Atualizar(Entidades.Transportadora transportadora);

        Task<Entidades.Transportadora> RecuperarPorId(long transportadoraId);
    }
