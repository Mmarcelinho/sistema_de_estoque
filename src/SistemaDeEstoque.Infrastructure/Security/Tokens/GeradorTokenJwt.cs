namespace SistemaDeEstoque.Infrastructure.Security.Tokens;

internal class GeradorTokenJwt : IGeradorTokenAcesso
{
    private readonly uint _tempoVidaTokenMinutos;

    private readonly string _chaveDeSeguranca;

    public GeradorTokenJwt(uint tempoDeVidaDoTokenEmMinutos, string chaveDeSeguranca)
    {
        _tempoVidaTokenMinutos = tempoDeVidaDoTokenEmMinutos;
        _chaveDeSeguranca = chaveDeSeguranca;
    }

    public string Gerar(Usuario usuario)
    {
        var claims = new List<Claim>()
        {
            new(ClaimTypes.Name, usuario.Nome),
            new(ClaimTypes.Sid, usuario.IdentificadorUsuario.ToString()),
            new(ClaimTypes.Role, usuario.Role)
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Expires = DateTime.UtcNow.AddMinutes(_tempoVidaTokenMinutos),
            SigningCredentials = new SigningCredentials(SecurityKey(), SecurityAlgorithms.HmacSha256Signature),
            Subject = new ClaimsIdentity(claims)
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var securityToken = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(securityToken);
    }

    private SymmetricSecurityKey SecurityKey()
    {
        var key = Encoding.UTF8.GetBytes(_chaveDeSeguranca);

        return new SymmetricSecurityKey(key);
    }
}
