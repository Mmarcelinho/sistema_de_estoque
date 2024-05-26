namespace SistemaDeEstoque.Application.UseCases.Admin.AlterarSenha;

public record AlterarSenhaAdminCommand(RequisicaoAlterarSenhaJson alterarSenha) : IRequest;

public class AlterarSenhaAdminCommandHandler : IRequestHandler<AlterarSenhaAdminCommand>
{
    private readonly IAdminLogado _adminLogado;

    private readonly IAdminUpdateOnlyRepositorio _repositorio;

    private readonly EncriptadorDeSenha _encriptadorDeSenha;

    private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;

    public AlterarSenhaAdminCommandHandler(IAdminLogado adminLogado, IAdminUpdateOnlyRepositorio repositorio, EncriptadorDeSenha encriptadorDeSenha, IUnidadeDeTrabalho unidadeDeTrabalho)
    {
        _adminLogado = adminLogado;
        _repositorio = repositorio;
        _encriptadorDeSenha = encriptadorDeSenha;
        _unidadeDeTrabalho = unidadeDeTrabalho;
    }

    public async Task Handle(AlterarSenhaAdminCommand request, CancellationToken cancellationToken)
    {
        var adminLogado = await _adminLogado.RecuperarAdmin();

        var admin = await _repositorio.RecuperarPorId(adminLogado.Id);

        Validar(request, admin);

        admin.Senha = _encriptadorDeSenha.Criptografar(request.alterarSenha.NovaSenha);

        _repositorio.Atualizar(admin);

        await _unidadeDeTrabalho.Commit();
    }

    private void Validar(AlterarSenhaAdminCommand requisicao, Domain.Entidades.Admin admin)
    {
        var validator = new AlterarSenhaValidator();
        var resultado = validator.Validate(requisicao);

        var senhaAtualCriptografada = _encriptadorDeSenha.Criptografar(requisicao.alterarSenha.SenhaAtual);

        if (!admin.Senha.Equals(senhaAtualCriptografada))
            resultado.Errors.Add(new FluentValidation.Results.ValidationFailure("senhaAtual", UsuarioModelMensagensDeErro.SENHA_ATUAL_INVALIDA));

        if (!resultado.IsValid)
        {
            var mensagens = resultado.Errors.Select(x => x.ErrorMessage).ToList();
            throw new ErrosDeValidacaoException(mensagens);
        }
    }
}

