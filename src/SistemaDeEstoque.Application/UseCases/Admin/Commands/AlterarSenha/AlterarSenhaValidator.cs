namespace SistemaDeEstoque.Application.UseCases.Admin.Commands.AlterarSenha;

public class AlterarSenhaValidator : AbstractValidator<AlterarSenhaAdminCommand>
{
    public AlterarSenhaValidator()
    {
        RuleFor(c => c.alterarSenha.NovaSenha).SetValidator(new SenhaValidator());
    }
}
