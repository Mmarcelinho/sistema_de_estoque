using System.Net;
using SistemaDeEstoque.Exceptions.ErrorMessages;

namespace SistemaDeEstoque.Exceptions.ExceptionsBase;

public class LoginInvalidoException : SistemaDeEstoqueException
{
    public LoginInvalidoException() : base(UsuarioModelMensagensDeErro.LOGIN_INVALIDO) { }

    public override int StatusCode => (int)HttpStatusCode.Unauthorized;

    public override List<string> RecuperarErros()
    {
        return [Message];
    }
}
