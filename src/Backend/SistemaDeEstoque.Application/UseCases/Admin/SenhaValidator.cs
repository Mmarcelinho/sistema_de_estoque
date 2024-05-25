namespace SistemaDeEstoque.Application.UseCases.Admin;

    public class SenhaValidator : AbstractValidator<string>
    {
        public SenhaValidator()
        {
            RuleFor(senha => senha).NotEmpty().WithMessage(UsuarioModelMensagensDeErro.SENHA_USUARIO_EMBRANCO);
            When(senha => !string.IsNullOrWhiteSpace(senha), () => 
            {
                RuleFor(senha => senha.Length)
                .GreaterThanOrEqualTo(6)
                .WithMessage(UsuarioModelMensagensDeErro.SENHA_USUARIO_MINIMO_SEIS_CARACTERES);
            });
        }
    }
