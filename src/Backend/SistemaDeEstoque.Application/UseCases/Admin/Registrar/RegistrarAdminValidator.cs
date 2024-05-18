using System.Text.RegularExpressions;

namespace SistemaDeEstoque.Application.UseCases.Admin.Registrar;

public class RegistrarAdminValidator : AbstractValidator<RequisicaoRegistrarAdminJson>
{
    public RegistrarAdminValidator()
    {
        RuleFor(c => c.Nome).NotEmpty().WithMessage(UsuarioModelMensagensDeErro.NOME_USUARIO_EMBRANCO);
        RuleFor(c => c.Email).NotEmpty().WithMessage(UsuarioModelMensagensDeErro.EMAIL_USUARIO_EMBRANCO);
        RuleFor(c => c.Telefone).NotEmpty().WithMessage(UsuarioModelMensagensDeErro.TELEFONE_USUARIO_EMBRANCO);
        RuleFor(c => c.Senha).SetValidator(new SenhaValidator());
        When(c => !string.IsNullOrWhiteSpace(c.Email), () =>
        {
            RuleFor(c => c.Email).EmailAddress().WithMessage(UsuarioModelMensagensDeErro.EMAIL_USUARIO_INVALIDO);
        });
        When(c => !string.IsNullOrWhiteSpace(c.Telefone), () =>
        {
            RuleFor(c => c.Telefone).Custom((telefone, contexto) =>
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
