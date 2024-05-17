namespace SistemaDeEstoque.Exceptions.ExceptionsBase;

    public class LoginInvalidoException : SistemaDeEstoqueException
    {
        public LoginInvalidoException() : base(UsuarioModelMensagensDeErro.LOGIN_INVALIDO) { }
    }
