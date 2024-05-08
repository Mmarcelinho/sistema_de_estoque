namespace SistemaDeEstoque.Application.Servicos.Validation.Exceptions;

    public static class AdminModelMensagensDeErro
    {
        public static string EMAIL_JA_REGISTRADO = "O e-mail informado já esta registrado na base de dados.";
        public static string EMAIL_USUARIO_EMBRANCO = "O e-mail do usuário deve ser informado.";

        public static string EMAIL_USUARIO_INVALIDO = "O e-mail do usuário é inválido.";

        public static string LOGIN_INVALIDO = "O e-mail e/ou senha estão incorretos.";

        public static string NOME_USUARIO_EMBRANCO = "O nome do usuário deve ser informado.";

        public static string SENHA_ATUAL_INVALIDA = "Senha atual é inválida.";

        public static string SENHA_USUARIO_EMBRANCO = "A senha do usuário deve ser informada.";

        public static string SENHA_USUARIO_MINIMO_SEIS_CARACTERES = "A senha deve conter no minimo 6 caracteres.";

        public static string TELEFONE_USUARIO_EMBRANCO = "O telefone do usuário deve ser informado.";

        public static string TELEFONE_USUARIO_INVALIDO = "O telefone do usuário deve estar no formato XX X XXXX-XXXX";

        public static string TOKEN_EXPIRADO = "Faça login novamente no App.";

        public static string ADMINISTRADOR_NAO_ENCONTRADO = "Administrador não encontrado.";
    }
