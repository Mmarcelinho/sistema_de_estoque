namespace SistemaDeEstoque.Domain.Security.Tokens;

    public interface IGeradorTokenAcesso
    {
        string Gerar(Usuario usuario);
    }
