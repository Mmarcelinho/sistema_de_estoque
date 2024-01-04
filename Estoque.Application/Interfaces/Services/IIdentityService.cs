using Estoque.Application.DTOs.Identity.Request;
using Estoque.Application.DTOs.Identity.Response;

namespace Estoque.Application.Interfaces.Services;

    public interface IIdentityService
    {
        Task<UsuarioCadastroResponse> CadastrarUsuario(UsuarioCadastroRequest usuarioCadastro);

        Task<UsuarioLoginResponse> Login(UsuarioLoginRequest usuarioLogin);

        Task<UsuarioLoginResponse> LoginSemSenha(string usuarioId);
    }
