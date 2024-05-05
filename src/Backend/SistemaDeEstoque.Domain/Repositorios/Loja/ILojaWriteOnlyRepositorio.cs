namespace SistemaDeEstoque.Domain.Repositorios.Loja;

    public interface ILojaWriteOnlyRepositorio
    {
        Task Registrar(Entidades.Loja loja);

        Task Deletar(long lojaId);
    }
