namespace SistemaDeEstoque.Application.Servicos.UsuarioLogado;

public class AdminLogado : IAdminLogado
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    private readonly TokenController _tokenController;

    private IAdminReadOnlyRepositorio _repositorio;

    public AdminLogado(IHttpContextAccessor httpContextAccessor, TokenController tokenController, IAdminReadOnlyRepositorio repositorio)
    {
        _httpContextAccessor = httpContextAccessor;
        _tokenController = tokenController;
        _repositorio = repositorio;
    }
    public async Task<Admin> RecuperarAdmin()
    {
        var authorizationHeader = "Authorization";
        var authorization = _httpContextAccessor.HttpContext.Request.Headers[$"{authorizationHeader}"].ToString();

        var token = authorization["Bearer".Length..].Trim();

        var emailAdmin = _tokenController.RecuperarEmail(token);

        var admin = await _repositorio.RecuperarPorEmail(emailAdmin);

        return admin;
    }
}
