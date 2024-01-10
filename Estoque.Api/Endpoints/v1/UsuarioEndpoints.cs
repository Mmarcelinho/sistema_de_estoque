using System.Net;
using Carter;
using System.Security.Claims;
using Estoque.Api.Endpoints.shared;
using Estoque.Application.DTOs.Identity.Request;
using Estoque.Application.DTOs.Identity.Response;
using Estoque.Application.Interfaces.Services;


namespace Estoque.Api.Endpoints.v1;

public class UsuarioEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/usuario");
        group.MapPost("cadastro", Cadastrar)
        .Produces<UsuarioCadastroResponse>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status500InternalServerError)
        .WithName(nameof(Cadastrar));

        group.MapPost("login", Login)
        .Produces<UsuarioCadastroResponse>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status400BadRequest)
        .Produces(StatusCodes.Status401Unauthorized)
        .ProducesProblem(StatusCodes.Status500InternalServerError)
        .WithName(nameof(Login));
    }

    public static async Task<IResult> Cadastrar(IIdentityService _identityService, UsuarioCadastroRequest usuarioCadastro, HttpContext context)
    {
        if (usuarioCadastro is null)
            return Results.BadRequest();

        var resultado = await _identityService.CadastrarUsuario(usuarioCadastro);
        if (resultado.Sucesso)
            return Results.Ok(resultado);
        else if (resultado.Erros.Count > 0)
        {
            var problemDetails = new CustomProblemDetails(HttpStatusCode.BadRequest, context.Request, errors: resultado.Erros);
            return Results.BadRequest(problemDetails);
        }

        return Results.StatusCode(StatusCodes.Status500InternalServerError);
    }

    public static async Task<IResult> Login(IIdentityService _identityService, UsuarioLoginRequest usuarioLogin)
    {
        if(usuarioLogin is null)
        return Results.BadRequest();

        var resultado = await _identityService.Login(usuarioLogin);
        if(resultado.Sucesso)
        return Results.Ok(resultado);

        return Results.Unauthorized();
    }

    public static async Task<IResult> RefreshLogin(IIdentityService _identityService, HttpContext context)
    {
        var identity = context.User.Identity as ClaimsIdentity;

        var usuarioId = identity?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if(usuarioId == null)
        Results.BadRequest();

        var resultado = await _identityService.LoginSemSenha(usuarioId);
        if(resultado.Sucesso)
        return Results.Ok(resultado);

        return Results.Unauthorized();
    }
}
