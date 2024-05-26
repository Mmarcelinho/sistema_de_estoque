namespace SistemaDeEstoque.Domain.Entidades.Base;

public abstract class Usuario : EntidadeBase
{
    public string Nome { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Senha { get; set; } = string.Empty;

    public string Telefone { get; set; } = string.Empty;

    public Guid IdentificadorUsuario { get; set; }

    public string Role { get; set; } = string.Empty;

}
