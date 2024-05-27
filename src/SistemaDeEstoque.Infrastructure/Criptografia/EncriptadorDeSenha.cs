namespace SistemaDeEstoque.Infrastructure.Criptografia;

internal class EncriptadorDeSenha : IEncriptadorDeSenha
{
    public string Encriptar(string senha)
    {
        string senhaEncriptografada = BC.HashPassword(senha);

        return senhaEncriptografada;
    }

    public bool Verificar(string senha, string senhaEncriptografada) => BC.Verify(senha, senhaEncriptografada);
}
