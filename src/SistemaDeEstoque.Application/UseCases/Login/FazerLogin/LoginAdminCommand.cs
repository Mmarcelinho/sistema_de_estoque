namespace SistemaDeEstoque.Application.UseCases.Login.FazerLogin;

public record LoginAdminCommand(RequisicaoLoginAdminJson loginAdmin) : IRequest<RespostaLoginAdminJson>;

public class LoginAdminHandler : IRequestHandler<LoginAdminCommand, RespostaLoginAdminJson>
{
    private readonly IAdminReadOnlyRepositorio _adminReadOnlyRepositorio;

    private readonly IEncriptadorDeSenha _encriptadorDeSenha;

    private readonly TokenController _tokenController;


    public LoginAdminHandler(IAdminReadOnlyRepositorio adminReadOnlyRepositorio, IEncriptadorDeSenha encriptadorDeSenha, TokenController tokenController)
    {
        _adminReadOnlyRepositorio = adminReadOnlyRepositorio;
        _encriptadorDeSenha = encriptadorDeSenha;
        _tokenController = tokenController;
    }

    public async Task<RespostaLoginAdminJson> Handle(LoginAdminCommand request, CancellationToken cancellationToken)
    {
        var requisicao = request.loginAdmin;

        var senhaCriptografada = _encriptadorDeSenha.Encriptar(requisicao.Senha);

        var admin = await _adminReadOnlyRepositorio.RecuperarPorEmailSenha(requisicao.Email, senhaCriptografada);

        if (admin is null)
            throw new LoginInvalidoException();

        return new RespostaLoginAdminJson(admin.Nome, _tokenController.GerarToken(admin.Email));
    }
}

