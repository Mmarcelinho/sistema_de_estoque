namespace SistemaDeEstoque.Application.UseCases.Admin.Registrar;

public record RegistrarAdminCommand(RequisicaoRegistrarAdminJson registrarAdmin) : IRequest<RespostaAdminRegistradoJson>;

public class RegistrarAdminCommandHandler : IRequestHandler<RegistrarAdminCommand, RespostaAdminRegistradoJson>
{
    private readonly IAdminReadOnlyRepositorio _adminReadOnlyRepositorio;
    private readonly IAdminWriteOnlyRepositorio _repositorio;
    private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;
    private readonly EncriptadorDeSenha _encriptadorDeSenha;
    private readonly TokenController _tokenController;

    public RegistrarAdminCommandHandler(
        IAdminWriteOnlyRepositorio repositorio,
        IUnidadeDeTrabalho unidadeDeTrabalho,
        EncriptadorDeSenha encriptadorDeSenha,
        TokenController tokenController,
        IAdminReadOnlyRepositorio adminReadOnlyRepositorio)
    {
        _repositorio = repositorio;
        _unidadeDeTrabalho = unidadeDeTrabalho;
        _encriptadorDeSenha = encriptadorDeSenha;
        _tokenController = tokenController;
        _adminReadOnlyRepositorio = adminReadOnlyRepositorio;
    }

    public async Task<RespostaAdminRegistradoJson> Handle(RegistrarAdminCommand request, CancellationToken cancellationToken)
    {
        await Validar(request);

        var entidade = new Domain.Entidades.Admin
        {
            Nome = request.registrarAdmin.Nome,
            Email = request.registrarAdmin.Email,
            Senha = _encriptadorDeSenha.Criptografar(request.registrarAdmin.Senha),
            Telefone = request.registrarAdmin.Telefone
        };

        await _repositorio.Adicionar(entidade);

        await _unidadeDeTrabalho.Commit();

        var token = _tokenController.GerarToken(entidade.Email);

        return new RespostaAdminRegistradoJson(token);
    }

    private async Task Validar(RegistrarAdminCommand requisicao)
    {
        var validator = new RegistrarAdminValidator();
        var resultado = validator.Validate(requisicao);

        var existeAdminComEmail = await _adminReadOnlyRepositorio.ExisteAdminComEmail(requisicao.registrarAdmin.Email);
        if (existeAdminComEmail)
            resultado.Errors.Add(new FluentValidation.Results.ValidationFailure("email", UsuarioModelMensagensDeErro.EMAIL_JA_REGISTRADO));

        if (!resultado.IsValid)
        {
            var mensagensDeErro = resultado.Errors.Select(error => error.ErrorMessage).ToList();
            throw new ErrosDeValidacaoException(mensagensDeErro);
        }
    }
}

