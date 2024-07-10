namespace SistemaDeEstoque.Application.UseCases.Admin.Commands.Registrar;

public class RegistrarAdminValidator : AbstractValidator<RegistrarAdminCommand>
{
    public RegistrarAdminValidator()
    {
        RuleFor(c => c.registrarAdmin.Nome).NotEmpty().WithMessage(UsuarioModelMensagensDeErro.NOME_USUARIO_EMBRANCO);
        RuleFor(c => c.registrarAdmin.Email).NotEmpty().WithMessage(UsuarioModelMensagensDeErro.EMAIL_USUARIO_EMBRANCO);
        RuleFor(c => c.registrarAdmin.Telefone).NotEmpty().WithMessage(UsuarioModelMensagensDeErro.TELEFONE_USUARIO_EMBRANCO);
        RuleFor(c => c.registrarAdmin.Senha).SetValidator(new SenhaValidator());
        When(c => !string.IsNullOrWhiteSpace(c.registrarAdmin.Email), () =>
        {
            RuleFor(c => c.registrarAdmin.Email).EmailAddress().WithMessage(UsuarioModelMensagensDeErro.EMAIL_USUARIO_INVALIDO);
        });
        When(c => !string.IsNullOrWhiteSpace(c.registrarAdmin.Telefone), () =>
        {
            RuleFor(c => c.registrarAdmin.Telefone).Custom((telefone, contexto) =>
            {
                string padraoTelefone = "[0-9]{2} [1-9]{1} [0-9]{4}-[0-9]{4}";
                var isMatch = Regex.IsMatch(telefone, padraoTelefone, RegexOptions.None, TimeSpan.FromMilliseconds(100));
                if (!isMatch)
                {
                    contexto.AddFailure(new FluentValidation.Results.ValidationFailure(nameof(telefone), UsuarioModelMensagensDeErro.TELEFONE_USUARIO_INVALIDO));
                }
            });

        });
    }
}
