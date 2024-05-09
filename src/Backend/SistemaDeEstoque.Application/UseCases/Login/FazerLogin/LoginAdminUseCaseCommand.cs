namespace SistemaDeEstoque.Application.UseCases.Login.FazerLogin;

public record LoginAdminUseCaseCommand(RequisicaoLoginAdminJson loginAdmin) : IRequest<RespostaLoginAdminJson>;

public class LoginAdminUseCaseHandler : IRequestHandler<LoginAdminUseCaseCommand, RespostaLoginAdminJson>
{
    private readonly IAdminReadOnlyRepositorio _adminReadOnlyRepositorio;

    private readonly EncriptadorDeSenha _encriptadorDeSenha;

    private readonly TokenController _tokenController;


    public LoginAdminUseCaseHandler(IAdminReadOnlyRepositorio adminReadOnlyRepositorio, EncriptadorDeSenha encriptadorDeSenha, TokenController tokenController)
    {
        _adminReadOnlyRepositorio = adminReadOnlyRepositorio;
        _encriptadorDeSenha = encriptadorDeSenha;
        _tokenController = tokenController;
    }

    public async Task<RespostaLoginAdminJson> Handle(LoginAdminUseCaseCommand request, CancellationToken cancellationToken)
    {
        var requisicao = request.loginAdmin;

        var senhaCriptografada = _encriptadorDeSenha.Criptografar(requisicao.Senha);

        var admin = await _adminReadOnlyRepositorio.RecuperarPorEmailSenha(requisicao.Email, senhaCriptografada);

        if (admin is null)
            throw new Exception(AdminModelMensagensDeErro.ADMINISTRADOR_NAO_ENCONTRADO);

        return new RespostaLoginAdminJson(admin.Nome, _tokenController.GerarToken(admin.Email));
    }
}

