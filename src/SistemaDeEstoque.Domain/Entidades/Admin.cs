namespace SistemaDeEstoque.Domain.Entidades;

    public class Admin : Usuario
    {
        public new string Role { get; set; } = Roles.ADMIN;
    }
