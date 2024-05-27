namespace SistemaDeEstoque.Application.Servicos.UsuarioLogado;

    public interface IAdminLogado
    {
        Task<Admin> RecuperarAdmin();
    }
