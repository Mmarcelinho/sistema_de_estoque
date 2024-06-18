using SistemaDeEstoque.Domain.Entidades;

namespace SistemaDeEstoque.Domain.Servicos.AdminLogado;

    public interface IAdminLogado
    {
        Task<Admin> Recuperar();
    }
