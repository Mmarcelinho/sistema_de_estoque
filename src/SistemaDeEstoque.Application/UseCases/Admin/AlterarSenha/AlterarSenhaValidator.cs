namespace SistemaDeEstoque.Application.UseCases.Admin.AlterarSenha;

public class AlterarSenhaValidator : AbstractValidator<AlterarSenhaAdminCommand>
{
    public AlterarSenhaValidator()
    {
        RuleFor(c => c.alterarSenha.NovaSenha).SetValidator(new SenhaValidator());
    }
}
