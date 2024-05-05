namespace SistemaDeEstoque.Domain.Repositorios.Loja;

    public interface ILojaUpdateOnlyRepositorio
    {
        void Atualizar(Entidades.Loja loja);

        Task<Entidades.Loja> RecuperarPorId(long lojaId);        
    }