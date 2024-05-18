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
        var requisicao = request.registrarAdmin;
        await Validar(requisicao);

        var entidade = new Domain.Entidades.Admin
        {
            Nome = requisicao.Nome,
            Email = requisicao.Email,
            Senha = _encriptadorDeSenha.Criptografar(requisicao.Senha),
            Telefone = requisicao.Telefone
        };

        await _repositorio.Adicionar(entidade);

        await _unidadeDeTrabalho.Commit();

        var token = _tokenController.GerarToken(entidade.Email);

        return new RespostaAdminRegistradoJson(token);
    }

    private async Task Validar(RequisicaoRegistrarAdminJson requisicao)
    {
        var validator = new RegistrarAdminValidator();
        var resultado = validator.Validate(requisicao);

        var existeAdminComEmail = await _adminReadOnlyRepositorio.ExisteAdminComEmail(requisicao.Email);
        if (existeAdminComEmail)
            resultado.Errors.Add(new FluentValidation.Results.ValidationFailure("email", UsuarioModelMensagensDeErro.EMAIL_JA_REGISTRADO));

        if (!resultado.IsValid)
        {
            var mensagensDeErro = resultado.Errors.Select(error => error.ErrorMessage).ToList();
            throw new ErrosDeValidacaoException(mensagensDeErro);
        }
    }
}

