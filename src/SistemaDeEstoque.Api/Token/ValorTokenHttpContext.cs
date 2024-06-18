using SistemaDeEstoque.Domain.Security.Tokens;

namespace SistemaDeEstoque.Api.Token;

    public class ValorTokenHttpContext : IProvedorDeToken
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public ValorTokenHttpContext(IHttpContextAccessor httpContextAccessor)
        {
            _contextAccessor = httpContextAccessor;
        }

        public string ObterTokenDaRequisicao()
        {
            var autorizacao = _contextAccessor.HttpContext!.Request.Headers.Authorization.ToString();

            return autorizacao["Bearer ".Length..].Trim();
        }
    }
