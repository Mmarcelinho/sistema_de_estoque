namespace SistemaDeEstoque.Application.UseCases.Admin.Registrar;

public record RegistrarAdminCommand(RequisicaoRegistrarAdminJson registrarAdmin) : IRequest<RespostaAdminRegistradoJson>;

public class RegistrarAdminCommandHandler : IRequestHandler<RegistrarAdminCommand, RespostaAdminRegistradoJson>
{
    private readonly IAdminReadOnlyRepositorio _adminReadOnlyRepositorio;
    private readonly IAdminWriteOnlyRepositorio _repositorio;
    private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;
    private readonly IEncriptadorDeSenha _encriptadorDeSenha;
    private readonly IGeradorTokenAcesso _geradorTokenAcesso;

    public RegistrarAdminCommandHandler(
        IAdminWriteOnlyRepositorio repositorio,
        IUnidadeDeTrabalho unidadeDeTrabalho,
        IEncriptadorDeSenha encriptadorDeSenha,
        IGeradorTokenAcesso geradorTokenAcesso,
        IAdminReadOnlyRepositorio adminReadOnlyRepositorio)
    {
        _repositorio = repositorio;
        _unidadeDeTrabalho = unidadeDeTrabalho;
        _encriptadorDeSenha = encriptadorDeSenha;
        _geradorTokenAcesso = geradorTokenAcesso;
        _adminReadOnlyRepositorio = adminReadOnlyRepositorio;
    }

    public async Task<RespostaAdminRegistradoJson> Handle(RegistrarAdminCommand request, CancellationToken cancellationToken)
    {
        await Validar(request);

        var admin = new Domain.Entidades.Admin
        {
            Nome = request.registrarAdmin.Nome,
            Email = request.registrarAdmin.Email,
            Senha = _encriptadorDeSenha.Encriptar(request.registrarAdmin.Senha),
            Telefone = request.registrarAdmin.Telefone,
            IdentificadorUsuario = Guid.NewGuid(),
            Role = Roles.ADMIN
        };

        await _repositorio.Adicionar(admin);

        await _unidadeDeTrabalho.Commit();

        return new RespostaAdminRegistradoJson
        (
            admin.Nome,
            _geradorTokenAcesso.Gerar(admin)
        );
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

