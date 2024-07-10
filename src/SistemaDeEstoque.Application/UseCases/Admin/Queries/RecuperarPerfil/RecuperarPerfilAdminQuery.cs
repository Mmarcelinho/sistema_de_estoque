namespace SistemaDeEstoque.Application.UseCases.Admin.Queries.RecuperarPerfil;

public record RecuperarPerfilAdminQuery() : IRequest<RespostaPerfilAdminJson>;

public class RecuperarPerfilAdminQueryHandler : IRequestHandler<RecuperarPerfilAdminQuery, RespostaPerfilAdminJson>
{
    private readonly IAdminLogado _adminLogado;

    public RecuperarPerfilAdminQueryHandler(IAdminLogado adminLogado) => _adminLogado = adminLogado;


    public async Task<RespostaPerfilAdminJson> Handle(RecuperarPerfilAdminQuery request, CancellationToken cancellationToken)
    {
        var admin = await _adminLogado.Recuperar();

        return new RespostaPerfilAdminJson
        (
            admin.Nome,
            admin.Email,
            admin.Telefone
        );
    }
}

