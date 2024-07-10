namespace SistemaDeEstoque.Application.UseCases.Admin.Commands.AlterarSenha;

public record AlterarSenhaAdminCommand(RequisicaoAlterarSenhaJson alterarSenha) : IRequest;

public class AlterarSenhaAdminCommandHandler : IRequestHandler<AlterarSenhaAdminCommand>
{
    private readonly IAdminLogado _adminLogado;

    private readonly IAdminUpdateOnlyRepositorio _repositorio;

    private readonly IEncriptadorDeSenha _encriptadorDeSenha;

    private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;

    public AlterarSenhaAdminCommandHandler(IAdminLogado adminLogado, IAdminUpdateOnlyRepositorio repositorio, IEncriptadorDeSenha encriptadorDeSenha, IUnidadeDeTrabalho unidadeDeTrabalho)
    {
        _adminLogado = adminLogado;
        _repositorio = repositorio;
        _encriptadorDeSenha = encriptadorDeSenha;
        _unidadeDeTrabalho = unidadeDeTrabalho;
    }

    public async Task Handle(AlterarSenhaAdminCommand request, CancellationToken cancellationToken)
    {
        var adminLogado = await _adminLogado.Recuperar();

        var admin = await _repositorio.RecuperarPorId(adminLogado.Id);

        Validar(request, admin);

        admin.Senha = _encriptadorDeSenha.Encriptar(request.alterarSenha.NovaSenha);

        _repositorio.Atualizar(admin);

        await _unidadeDeTrabalho.Commit();
    }

    private void Validar(AlterarSenhaAdminCommand requisicao, Domain.Entidades.Admin admin)
    {
        if (!_encriptadorDeSenha.Verificar(requisicao.alterarSenha.SenhaAtual, admin.Senha))
            throw new Exception(UsuarioModelMensagensDeErro.SENHA_ATUAL_INVALIDA);
    }
}

