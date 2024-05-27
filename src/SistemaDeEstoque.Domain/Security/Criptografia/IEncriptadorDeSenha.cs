namespace SistemaDeEstoque.Domain.Security.Criptografia;

    public interface IEncriptadorDeSenha
    {
        string Encriptar(string senha);

        bool Verificar(string senha, string senhaEncriptografada);
    }
