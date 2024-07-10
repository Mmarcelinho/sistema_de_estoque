namespace SistemaDeEstoque.Application.UseCases.Login.Commands.FazerLogin;

public record LoginAdminCommand(RequisicaoLoginAdminJson loginAdmin) : IRequest<RespostaLoginAdminJson>;

public class LoginAdminHandler : IRequestHandler<LoginAdminCommand, RespostaLoginAdminJson>
{
    private readonly IAdminReadOnlyRepositorio _adminReadOnlyRepositorio;

    private readonly IEncriptadorDeSenha _encriptadorDeSenha;

    private readonly IGeradorTokenAcesso _geradorTokenAcesso;


    public LoginAdminHandler(IAdminReadOnlyRepositorio adminReadOnlyRepositorio, IEncriptadorDeSenha encriptadorDeSenha, IGeradorTokenAcesso geradorTokenAcesso)
    {
        _adminReadOnlyRepositorio = adminReadOnlyRepositorio;
        _encriptadorDeSenha = encriptadorDeSenha;
        _geradorTokenAcesso = geradorTokenAcesso;
    }

    public async Task<RespostaLoginAdminJson> Handle(LoginAdminCommand request, CancellationToken cancellationToken)
    {
        var admin = await _adminReadOnlyRepositorio.RecuperarPorEmail(request.loginAdmin.Email);

        if (admin is null)
            throw new LoginInvalidoException();

        var senhaCorreta = _encriptadorDeSenha.Verificar(request.loginAdmin.Senha, admin.Senha);

        if (senhaCorreta == false)
            throw new LoginInvalidoException();

        return new RespostaLoginAdminJson
        (
            admin.Nome,
            _geradorTokenAcesso.Gerar(admin)
        );
    }
}

