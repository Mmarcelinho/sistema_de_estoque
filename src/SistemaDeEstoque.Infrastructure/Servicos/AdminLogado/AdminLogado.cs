namespace SistemaDeEstoque.Infrastructure.Servicos.AdminLogado;

public class AdminLogado : IAdminLogado
{
    private readonly SistemaDeEstoqueContext _contexto;

    private readonly IProvedorDeToken _provedorToken;

    public AdminLogado(SistemaDeEstoqueContext contexto, IProvedorDeToken provedorToken)
    {
        _contexto = contexto;
        _provedorToken = provedorToken;
    }

    public async Task<Admin> Recuperar()
    {
        const string CLAIM_TYPE_ROLE = "role";

        string token = _provedorToken.ObterTokenDaRequisicao();

        var tokenHandler = new JwtSecurityTokenHandler();

        var JwtSecurityToken = tokenHandler.ReadJwtToken(token);        

        var identificador = JwtSecurityToken.Claims.First(claim => claim.Type == ClaimTypes.Sid).Value;

        var role = JwtSecurityToken.Claims.First(claim => claim.Type == CLAIM_TYPE_ROLE).Value;

        return await _contexto.Admins.AsNoTracking().FirstAsync(admin => admin.IdentificadorUsuario == Guid.Parse(identificador));
    }
}
