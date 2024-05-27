namespace SistemaDeEstoque.Application.Servicos.Criptografia;

    public class EncriptadorDeSenha
    {
        private readonly string _chaveAdicional;

        public EncriptadorDeSenha(string chaveAdicional) => _chaveAdicional = chaveAdicional;

        public string Criptografar(string senha)
        {
            var senhaComChaveAdicional = $"{senha}{_chaveAdicional}";

            var bytes = Encoding.UTF8.GetBytes(senhaComChaveAdicional);
            byte[] hashBytes = SHA512.HashData(bytes);
            return StringBytes(hashBytes);
        }

        private static string StringBytes(byte[] bytes)
        {
            var sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                var hex = b.ToString("x2");
                sb.Append(hex);
            }
            return sb.ToString();
        }
    }
